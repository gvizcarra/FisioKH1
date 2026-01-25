using System;
using System.Configuration;
using System.Linq;

namespace FisioKH
{
    public static class configSettings
    {
        /// <summary>
        /// Always returns the latest connection string from the config file.
        /// </summary>
        public static string ObtenConectionString
        {
            get
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var conn = config.ConnectionStrings.ConnectionStrings["SqlConnectionString"];
                return (conn != null) ? conn.ConnectionString : string.Empty;
            }
        }

        /// <summary>
        /// Always returns the latest AppName from the config file.
        /// </summary>
        public static string ObtenNombreApp
        {
            get
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var setting = config.AppSettings.Settings["AppName"];
                return (setting != null) ? setting.Value : string.Empty;
            }
        }
        public static string ObtenCalendarApiFile
        {
            get
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var setting = config.AppSettings.Settings["calendarApiFile"];
                return (setting != null) ? setting.Value : string.Empty;
            }
        }

        /// <summary>
        /// Always returns the latest tabsSeguras array from the config file.
        /// </summary>
        public static int[] ObtenTabsSeguras
        {
            get
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var setting = config.AppSettings.Settings["tabsSeguras"];

                if (setting == null || string.IsNullOrWhiteSpace(setting.Value))
                    return new int[0];

                return setting.Value
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s =>
                    {
                        int n;
                        return int.TryParse(s.Trim(), out n) ? n : 0;
                    })
                    .ToArray();
            }
        }

        /// <summary>
        /// Get or set AppName
        /// </summary>
        public static string AppName
        {
            get
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var setting = config.AppSettings.Settings["AppName"];
                return (setting != null) ? setting.Value : string.Empty;
            }
            set
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var setting = config.AppSettings.Settings["AppName"];
                if (setting != null)
                    setting.Value = value;
                else
                    config.AppSettings.Settings.Add("AppName", value);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        /// <summary>
        /// Get or set SqlConnectionString
        /// </summary>
        public static string SqlConnectionString
        {
            get
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var conn = config.ConnectionStrings.ConnectionStrings["SqlConnectionString"];
                return (conn != null) ? conn.ConnectionString : string.Empty;
            }
            set
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var conn = config.ConnectionStrings.ConnectionStrings["SqlConnectionString"];
                if (conn != null)
                    conn.ConnectionString = value;
                else
                    config.ConnectionStrings.ConnectionStrings.Add(
                        new ConnectionStringSettings("SqlConnectionString", value));

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }

        /// <summary>
        /// Get or set tabsSeguras as an int array (comma-separated in config)
        /// </summary>
        public static int[] TabsSeguras
        {
            get
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var setting = config.AppSettings.Settings["tabsSeguras"];
                if (setting == null || string.IsNullOrWhiteSpace(setting.Value))
                    return new int[0];

                return setting.Value
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => { int n; return int.TryParse(s.Trim(), out n) ? n : 0; })
                    .ToArray();
            }
            set
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string val = string.Join(",", value);

                var setting = config.AppSettings.Settings["tabsSeguras"];
                if (setting != null)
                    setting.Value = val;
                else
                    config.AppSettings.Settings.Add("tabsSeguras", val);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
    }
}
