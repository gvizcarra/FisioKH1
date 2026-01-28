using FisioKH;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public class GoogleCalendarService
{
    private static readonly string[] Scopes = { CalendarService.Scope.Calendar };
    private const string AppName = "FisioKH Calendar";

    public CalendarService Service { get; private set; }

    #region Authenticate

    public async Task<bool> AuthenticateAsync()
    {
        try
        {
            UserCredential credential;
            string calendarApiFile = configSettings.ObtenCalendarApiFile;

            using (var stream = new FileStream(calendarApiFile, FileMode.Open, FileAccess.Read))
            {
                var credPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "FisioKH.GoogleCalendar");

                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).ConfigureAwait(false);
            }

            Service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = AppName,
            });

            return true;
        }
        catch (Exception)
        {
            MessageBox.Show("No Existe Archivo de Acceso al Calendario GoogleCalendar");
            return false;
        }
    }

    public bool Authenticate()
    {
        try
        {
            UserCredential credential;
            string calendarApiFile = configSettings.ObtenCalendarApiFile;

            using (var stream = new FileStream(calendarApiFile, FileMode.Open, FileAccess.Read))
            {
                var credPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "FisioKH.GoogleCalendar");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            Service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = AppName,
            });

            return true;
        }
        catch (FileNotFoundException ex)
        {
            MessageBox.Show("Archivo GoogleApi no existe, revisar!\n\n" + ex.FileName);
            return false;
        }
        catch (UnauthorizedAccessException unex)
        {
            MessageBox.Show("Sin Permiso de Archivo GoogleApi, revisar!\n\n" + unex);
            return false;
        }
        catch (System.Net.Http.HttpRequestException httpex)
        {
            MessageBox.Show("Revisar Acceso a Red/Internet!\n\n" + httpex.Message);
            return false;
        }
    }

    #endregion

    #region Connectivity

    public bool IsConnected()
    {
        if (Service == null) return false;

        try
        {
            var request = Service.CalendarList.List();
            request.MaxResults = 1;
            request.Execute();
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion

    #region Read events -> DataTable (Google + DB match)

    public async Task<DataTable> GetEventsTableAsync(DateTime from, DateTime to)
    {
        if (Service == null)
            throw new InvalidOperationException("Google Calendar not authenticated.");

        var table = BuildEventsSchema();

        string KeyOf(Event e) => (e.Id ?? "").Trim();

        // Google events (ASYNC)
        var request = Service.Events.List("primary");
        request.TimeMin = from;
        request.TimeMax = to;
        request.ShowDeleted = false;
        request.SingleEvents = true;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        var list = await request.ExecuteAsync().ConfigureAwait(false);
        var events = list?.Items ?? new List<Event>();

        var eventIds = events.Select(KeyOf)
                             .Where(id => id.Length > 0)
                             .Distinct(StringComparer.OrdinalIgnoreCase)
                             .ToList();

        // DB map: key -> dict (value may be null in your helper design)
        var db = new FisioKH.DBHelperAsync();
        var dbMap = (eventIds.Count == 0)
            ? new Dictionary<string, Dictionary<string, object>>(StringComparer.OrdinalIgnoreCase)
            : await db.GetCitasMapByGoogleEventIdsAsync(eventIds).ConfigureAwait(false);

      

        foreach (var ev in events)
        {
            var row = table.NewRow();

            DateTime start = ev.Start?.DateTime ?? DateTime.Parse(ev.Start?.Date ?? DateTime.MinValue.ToString("yyyy-MM-dd"));
            DateTime end = ev.End?.DateTime ?? DateTime.Parse(ev.End?.Date ?? DateTime.MinValue.ToString("yyyy-MM-dd"));

            string key = KeyOf(ev);

            row["Id"] = ev.Id ?? "";
            row["Title"] = ev.Summary ?? "";
            row["Start"] = start;
            row["End"] = end;
            row["ColorId"] = ev.ColorId ?? "";

           
            bool hasMatch = key.Length > 0 && dbMap.ContainsKey(key);

            row["HasDbMatch"] = hasMatch;
            row["MatchStatus"] = hasMatch ? "OK" : "NO_DB";

            // extras only if dict exists
            if (hasMatch && dbMap.TryGetValue(key, out var data) && data != null)
            {
                row["idCita"] = GetLong(data, "idCita", 0);
                row["codigoCita"] = GetString(data, "codigoCita");
                row["realizada"] = GetBool(data, "realizada", false);
                row["nombreCompletoPaciente"] = GetString(data, "nombreCompletoPaciente");
                row["nombreTratamiento"] = GetString(data, "nombreTratamiento");
                row["nombreFisioterapeuta"] = GetString(data, "nombreFisioterapeuta");
                row["claveEtiqueta"] = GetString(data, "claveEtiqueta");
            }

            table.Rows.Add(row);
        }

  

        return table;
    }

    private static DataTable BuildEventsSchema()
    {
        var table = new DataTable();

        table.Columns.Add("Id"); // Google EventId
        table.Columns.Add("Title");
        table.Columns.Add("Start", typeof(DateTime));
        table.Columns.Add("End", typeof(DateTime));
        table.Columns.Add("ColorId");

        // Flags
        table.Columns.Add("HasDbMatch", typeof(bool));
        table.Columns.Add("MatchStatus"); // OK / NO_DB

        // DB extras
        table.Columns.Add("idCita", typeof(long));
        table.Columns.Add("codigoCita");
        table.Columns.Add("realizada", typeof(bool));
        table.Columns.Add("nombreCompletoPaciente");
        table.Columns.Add("nombreTratamiento");
        table.Columns.Add("nombreFisioterapeuta");
        table.Columns.Add("claveEtiqueta");

        return table;
    }

    #endregion

    #region Safe getters

    private static string GetString(Dictionary<string, object> data, string key)
    {
        if (data == null) return "";
        if (!data.TryGetValue(key, out var v) || v == null || v == DBNull.Value) return "";
        return Convert.ToString(v) ?? "";
    }

    private static long GetLong(Dictionary<string, object> data, string key, long fallback)
    {
        if (data == null) return fallback;
        if (!data.TryGetValue(key, out var v) || v == null || v == DBNull.Value) return fallback;
        try { return Convert.ToInt64(v); } catch { return fallback; }
    }

    private static bool GetBool(Dictionary<string, object> data, string key, bool fallback)
    {
        if (data == null) return fallback;
        if (!data.TryGetValue(key, out var v) || v == null || v == DBNull.Value) return fallback;
        try { return Convert.ToBoolean(v); } catch { return fallback; }
    }

    #endregion
}
