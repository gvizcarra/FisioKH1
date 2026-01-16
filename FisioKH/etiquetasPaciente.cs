using System.Collections.Generic;
using System.Configuration;
using System.Xml;
namespace FisioKH
{

    public class EtiquetaPaciente
    {
        public string Key { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public override string ToString() => Text;
    }

    public static class EtiquetasPacienteHelper
    {
        private const string Prefix = "pac_"; // Only keys starting with this

        public static List<EtiquetaPaciente> GetBindableList()
        {
            var list = new List<EtiquetaPaciente>();

            foreach (string key in ConfigurationManager.AppSettings.AllKeys)
            {
                if (!key.StartsWith(Prefix)) continue;

                var val = ConfigurationManager.AppSettings[key];
                if (string.IsNullOrEmpty(val)) continue;

                var parts = val.Split('|');

                list.Add(new EtiquetaPaciente
                {
                    Key = key.Substring(Prefix.Length), // remove prefix if desired
                    Text = parts[0],
                    Color = parts.Length > 1 ? parts[1] : "Black"
                });
            }

            return list;
        }
    }
}