using FisioKH;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Calendar.v3.Data;

public class GoogleCalendarService
{
    private static readonly string[] Scopes = { CalendarService.Scope.Calendar };
    private const string AppName = "FisioKH Calendar";

    public CalendarService Service { get; private set; }

    public async Task<List<FisioKHCalendar.CalendarEventKH>> GetCalendarEventsKHAsync(
           DateTime from,
           DateTime to)
    {
        // 1️⃣ Get Google events
        var request = Service.Events.List("primary");
        request.TimeMin = from;
        request.TimeMax = to;
        request.SingleEvents = true;
        request.ShowDeleted = false;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        var googleEvents = request.Execute().Items ?? new List<Event>();

        // 2️⃣ Collect IDs
        var ids = googleEvents
            .Select(e => e.Id)
            .Where(id => !string.IsNullOrWhiteSpace(id))
            .Distinct()
            .ToList();

        // 3️⃣ Get DB matches (async)
        var db = new DBHelperAsync();
        var dbMap = await db.GetCitasMapByGoogleEventIdsAsync(ids);

        // 4️⃣ 🔥 THIS IS WHERE YOUR CODE GOES
        var result = new List<FisioKHCalendar.CalendarEventKH>();

        foreach (var ev in googleEvents)
        {
            dbMap.TryGetValue(ev.Id, out var dbData); // dbData may be null
            result.Add(MapToCalendarEventKH(ev, dbData));
        }

        return result;
    }

    // helper mapper stays in SAME file or partial
    private static FisioKHCalendar.CalendarEventKH MapToCalendarEventKH(
        Event ev,
        Dictionary<string, object> dbData)
    {
        DateTime start = ev.Start.DateTime ?? DateTime.Parse(ev.Start.Date);
        DateTime end = ev.End.DateTime ?? DateTime.Parse(ev.End.Date);

        long citaId = 0;
        if (dbData != null && dbData.TryGetValue("idCita", out var v) && v != null)
            citaId = Convert.ToInt64(v);

        string colorId = ev.ColorId ?? "";

        return new FisioKHCalendar.CalendarEventKH
        {
            Id = ev.Id,
            Title = ev.Summary ?? "",
            Start = start,
            End = end,
            ColorId = colorId,
            Color = FisioKHCalendar.GoogleColorToSystem(colorId),
            CitaID = citaId
        };
    }


    public async Task<bool> AuthenticateAsync()
    {
        try
        {
            UserCredential credential;
            string CalendarApiFile = configSettings.ObtenCalendarApiFile;

         

            using (var stream = new FileStream(CalendarApiFile, FileMode.Open, FileAccess.Read))
            {
                var credPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "FisioKH.GoogleCalendar");

                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));
            }

            Service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = AppName,
            });

            return true;
        }
        catch (Exception ex)
        {
            ex.ToString();
            MessageBox.Show("No Existe Archivo de Acceso al Calendario GoogleCalendar");
            return false;
        }
    }


    public bool Authenticate()
    {
        try
        {
            UserCredential credential;
            String CalendarApiFile = configSettings.ObtenCalendarApiFile;

            using (var stream = new FileStream(CalendarApiFile, FileMode.Open, FileAccess.Read))
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

            return true;   // success
        }
        catch (FileNotFoundException ex)
        {
            MessageBox.Show("Archivo GoogleApi no existe, revisar!\n\n" + ex.FileName.ToString());
            return false;
        } 
        catch (UnauthorizedAccessException unex)
        {
            MessageBox.Show("Sin Permiso de Archivo GoogleApi, revisar!\n\n" + unex.ToString());
            return false;
        } 
        catch (System.Net.Http.HttpRequestException httpex)
        {
            MessageBox.Show("Revisar Acceso a Red/Internet!\n\n" + httpex.Message.ToString());
            return false;
        }
    }

    public async Task<DataTable> GetEventsTableAsync(DateTime from, DateTime to)
    {
        if (Service == null)
            throw new InvalidOperationException("Google Calendar not authenticated.");

        var table = new DataTable();
        table.Columns.Add("Id"); // Google EventId
        table.Columns.Add("Title");
        table.Columns.Add("Start", typeof(DateTime));
        table.Columns.Add("End", typeof(DateTime));
        table.Columns.Add("ColorId");

        // DB extras
        table.Columns.Add("idCita", typeof(long));
        table.Columns.Add("idPaciente", typeof(long));
        table.Columns.Add("fechaRegistro", typeof(DateTime));
        table.Columns.Add("realizada", typeof(bool));
        table.Columns.Add("codigoCita");
        table.Columns.Add("idUsuario", typeof(long));
        table.Columns.Add("idTipoTratamiento", typeof(long));
        table.Columns.Add("idFisioTerapeuta", typeof(long));
        table.Columns.Add("nombreFisioterapeuta");
        table.Columns.Add("claveEtiqueta");
        table.Columns.Add("nombreCompletoPaciente");
        table.Columns.Add("nombreTratamiento");

        // 1️⃣ Google events
        var request = Service.Events.List("primary"); // or calendarId
        request.TimeMin = from;
        request.TimeMax = to;
        request.ShowDeleted = false;
        request.SingleEvents = true;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        var events = request.Execute().Items ?? new List<Google.Apis.Calendar.v3.Data.Event>();

        // 2️⃣ Collect Google EventIds
        var eventIds = events
            .Select(e => e.Id)
            .Where(id => !string.IsNullOrWhiteSpace(id))
            .Distinct()
            .ToList();

        // 3️⃣ DB lookup (ASYNC)
        var dbHelper = new FisioKH.DBHelperAsync();
        var dbRows = await dbHelper.GetCitasByGoogleEventIdsAsync(eventIds)
                                   .ConfigureAwait(false);

        var map = dbRows.AsEnumerable()
            .Where(r => r["idGoogleCalendar"] != DBNull.Value)
            .ToDictionary(r => r["idGoogleCalendar"].ToString(), r => r);

        // 4️⃣ Merge
        foreach (var ev in events)
        {
            DateTime start = ev.Start.DateTime ?? DateTime.Parse(ev.Start.Date);
            DateTime end = ev.End.DateTime ?? DateTime.Parse(ev.End.Date);

            var row = table.NewRow();
            row["Id"] = ev.Id;
            row["Title"] = ev.Summary ?? "";
            row["Start"] = start;
            row["End"] = end;
            row["ColorId"] = ev.ColorId ?? "";

            if (ev.Id != null && map.TryGetValue(ev.Id, out var db))
            {
                Copy(row, "idCita", db, "idCita");
                Copy(row, "idPaciente", db, "idPaciente");
                Copy(row, "fechaRegistro", db, "fechaRegistro");
                Copy(row, "realizada", db, "realizada");
                Copy(row, "codigoCita", db, "codigoCita");
                Copy(row, "idUsuario", db, "idUsuario");
                Copy(row, "idTipoTratamiento", db, "idTipoTratamiento");
                Copy(row, "idFisioTerapeuta", db, "idFisioTerapeuta");
                Copy(row, "nombreFisioterapeuta", db, "nombreFisioterapeuta");
                Copy(row, "claveEtiqueta", db, "claveEtiqueta");
                Copy(row, "nombreCompletoPaciente", db, "nombreCompletoPaciente");
                Copy(row, "nombreTratamiento", db, "nombreTratamiento");
            }

            table.Rows.Add(row);
        }

        return table;
    }

    private static void Copy(DataRow target, string targetCol, DataRow src, string srcCol)
    {
        if (!src.Table.Columns.Contains(srcCol)) return;
        var v = src[srcCol];
        if (v == null || v == DBNull.Value) return;
        target[targetCol] = v;
    }



    public DataTable GetEventsTable(DateTime from, DateTime to)
    {
        var table = new DataTable();
        table.Columns.Add("Id");
        table.Columns.Add("Title");
        table.Columns.Add("Start", typeof(DateTime));
        table.Columns.Add("End", typeof(DateTime));
        table.Columns.Add("ColorId");

        var request = Service.Events.List("primary");

        request.TimeMin = from;
        request.TimeMax = to;
        request.ShowDeleted = false;
        request.SingleEvents = true;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        var events = request.Execute().Items;

        foreach (var ev in events)
        {
            DateTime start = ev.Start.DateTime ?? DateTime.Parse(ev.Start.Date);
            DateTime end = ev.End.DateTime ?? DateTime.Parse(ev.End.Date);

            table.Rows.Add(ev.Id, ev.Summary, start, end, ev.ColorId);
        }

        return table;
    }


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


    public bool AddEvent(string title, DateTime start, DateTime end)
    {
        try
        {
            var ev = new Google.Apis.Calendar.v3.Data.Event()
            {
                Summary = title,
                Start = new Google.Apis.Calendar.v3.Data.EventDateTime { DateTime = start },
                End = new Google.Apis.Calendar.v3.Data.EventDateTime { DateTime = end }
            };

            Service.Events.Insert(ev, "primary").Execute();
            return true;
        }
        catch (Exception ex)
        {
            ex.ToString();
            // MessageBox.Show("Error adding event:\n" + ex.Message);
            return false;
        }
    }






}
