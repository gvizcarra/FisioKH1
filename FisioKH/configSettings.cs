using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FisioKH
{
    public static class configSettings
    {

        public static string ObtenConectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        }
        public static string ObtenNombreApp()
        {
            return ConfigurationManager.AppSettings["AppName"];
        }

        public static Array ObtenTabsSeguras()
        {
            string tbs = ConfigurationManager.AppSettings["tabsSeguras"];

            int[] tabsSeguras = tbs
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            return tabsSeguras;
        }


    }
}
