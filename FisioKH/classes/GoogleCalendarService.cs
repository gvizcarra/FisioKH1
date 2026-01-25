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



public class GoogleCalendarService
{
    private static readonly string[] Scopes = { CalendarService.Scope.Calendar };
    private const string AppName = "FisioKH Calendar";

    public CalendarService Service { get; private set; }


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
        return await Task.Run(() =>
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
        });
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
