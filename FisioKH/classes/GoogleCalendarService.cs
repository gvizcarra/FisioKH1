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
                // ================= CITA =================
                row["cIdCita"] = GetLong(data, "cIdCita", 0);
                row["cIdPaciente"] = GetLong(data, "cIdPaciente", 0);
                row["cFechaCita"] = GetNullableDateTime(data, "cFechaCita");
                row["cFechaRegistro"] = GetNullableDateTime(data, "cFechaRegistro");
                row["cRealizada"] = GetBool(data, "cRealizada", false);
                row["cIdUsuarioCita"] = GetLong(data, "cIdUsuarioCita", 0);
                row["cIdTipoTratamiento"] = GetLong(data, "cIdTipoTratamiento", 0);
                row["idGoogleCalendar"] = GetString(data, "idGoogleCalendar");
                row["cIdFisioterapeuta"] = GetLong(data, "cIdFisioterapeuta", 0);
                row["cNombreFisioterapeuta"] = GetString(data, "cNombreFisioterapeuta");
                row["cClaveEtiqueta"] = GetString(data, "cClaveEtiqueta");
                row["cNombreCompletoPaciente"] = GetString(data, "cNombreCompletoPaciente");
                row["cNombreTratamiento"] = GetString(data, "cNombreTratamiento");

                // ================= VISITA =================
                row["vIdVisita"] = GetLong(data, "vIdVisita", 0);
                row["vIdPaciente"] = GetLong(data, "vIdPaciente", 0);
                row["vFechaVisita"] = GetNullableDateTime(data, "vFechaVisita");
                row["vIdUsuario"] = GetLong(data, "vIdUsuario", 0);
                row["vIdTipoTratamiento"] = GetLong(data, "vIdTipoTratamiento", 0);
                row["vIdPrecio"] = GetLong(data, "vIdPrecio", 0);
                row["vPagado"] = GetBool(data, "vPagado", false);
                row["vOcupaFactura"] = GetBool(data, "vOcupaFactura", false);
                row["vNotas"] = GetString(data, "vNotas");

                // ================= PAGO =================
                row["vrIdPago"] = GetLong(data, "vrIdPago", 0);
                row["vrIdUsuario"] = GetLong(data, "vrIdUsuario", 0);
                row["vrIdMetodoPago"] = GetLong(data, "vrIdMetodoPago", 0);
                row["vrCantidadPago"] = GetDecimal(data, "vrCantidadPago", 0);
                row["vrReferenciaPago"] = GetString(data, "vrReferenciaPago");
            }

            table.Rows.Add(row);
        }

  

        return table;
    }

    private static DataTable BuildEventsSchema()
    {
        var table = new DataTable();

        // ================= GOOGLE BASE =================
        table.Columns.Add("Id");
        table.Columns.Add("Title");
        table.Columns.Add("Start", typeof(DateTime)).AllowDBNull = true;
        table.Columns.Add("End", typeof(DateTime)).AllowDBNull = true;
        table.Columns.Add("ColorId");

        // ================= FLAGS =================
        table.Columns.Add("HasDbMatch", typeof(bool));
        table.Columns.Add("MatchStatus");

        // ================= CITA =================
        table.Columns.Add("cIdCita", typeof(long));
        table.Columns.Add("cIdPaciente", typeof(long));
        table.Columns.Add("cFechaCita", typeof(DateTime)).AllowDBNull = true; ;
        table.Columns.Add("cFechaRegistro", typeof(DateTime)).AllowDBNull = true; 
        table.Columns.Add("cRealizada", typeof(bool));
        table.Columns.Add("cIdUsuarioCita", typeof(long));
        table.Columns.Add("cIdTipoTratamiento", typeof(long));
        table.Columns.Add("idGoogleCalendar");
        table.Columns.Add("cIdFisioterapeuta", typeof(long));
        table.Columns.Add("cNombreFisioterapeuta");
        table.Columns.Add("cClaveEtiqueta");
        table.Columns.Add("cNombreCompletoPaciente");
        table.Columns.Add("cNombreTratamiento");

        // ================= VISITA =================
        table.Columns.Add("vIdVisita", typeof(long));
        table.Columns.Add("vIdPaciente", typeof(long));
        table.Columns.Add("vFechaVisita", typeof(DateTime)).AllowDBNull = true; 
        table.Columns.Add("vIdUsuario", typeof(long));
        table.Columns.Add("vIdTipoTratamiento", typeof(long));
        table.Columns.Add("vIdPrecio", typeof(long));
        table.Columns.Add("vPagado", typeof(bool));
        table.Columns.Add("vOcupaFactura", typeof(bool));
        table.Columns.Add("vNotas");

        // ================= PAGO =================
        table.Columns.Add("vrIdPago", typeof(long));
        table.Columns.Add("vrIdUsuario", typeof(long));
        table.Columns.Add("vrIdMetodoPago", typeof(long));
        table.Columns.Add("vrCantidadPago", typeof(decimal));
        table.Columns.Add("vrReferenciaPago");


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

    private static decimal GetDecimal(Dictionary<string, object> data, string key, decimal fallback)
    {
        if (data == null) return fallback;
        if (!data.TryGetValue(key, out var v) || v == null || v == DBNull.Value)
            return fallback;

        try { return Convert.ToDecimal(v); }
        catch { return fallback; }
    }


    private static DateTime? GetNullableDateTime(Dictionary<string, object> data, string key)
    {
        if (data == null) return null;
        if (!data.TryGetValue(key, out var v) || v == null || v == DBNull.Value)
            return null;

        try { return Convert.ToDateTime(v); }
        catch { return null; }
    }


    #endregion
}
