using System;
using System.Drawing;

namespace FisioKH
{
    public partial class FisioKHCalendar
    {
        public class CalendarEventKH
        {
            // Google base
            public string Id { get; set; } = "";
            public string Title { get; set; } = "";
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string ColorId { get; set; } = "";
            public Color Color { get; set; } = Color.White;

            // Match info
            public bool HasDbMatch { get; set; }
            public string MatchStatus { get; set; } = "";

            public long? cIdCita { get; set; }
            public long? cIdPaciente { get; set; }
            public DateTime? cFechaCita { get; set; }
            public DateTime? cFechaRegistro { get; set; }
            public bool cRealizada { get; set; }
            public long? cIdUsuarioCita { get; set; }
            public long? cIdTipoTratamiento { get; set; }
            public string idGoogleCalendar { get; set; } = "";
            public long? cIdFisioterapeuta { get; set; }
            public string cNombreFisioterapeuta { get; set; } = "";
            public string cClaveEtiqueta { get; set; } = "";
            public string cNombreCompletoPaciente { get; set; } = "";
            public string cNombreTratamiento { get; set; } = "";
            public long? vIdVisita { get; set; }
            public long? vIdPaciente { get; set; }
            public DateTime? vFechaVisita { get; set; }
            public long? vIdUsuario { get; set; }
            public long? vIdTipoTratamiento { get; set; }
            public long? vIdPrecio { get; set; }
            public bool vPagado { get; set; }
            public bool vOcupaFactura { get; set; }
            public string vNotas { get; set; } = "";
            public long? vrIdPago { get; set; }
            public long? vrIdUsuario { get; set; }
            public long? vrIdMetodoPago { get; set; }
            public decimal? vrCantidadPago { get; set; }
            public string vrReferenciaPago { get; set; } = "";
 
        }


        public class EventLayoutInfo
        {
            public CalendarEventKH Event;
            public int SlotIndex;
            public int SlotCount;
        }

        private Color GetSoftColor(Color c)
        {
            int r = (c.R + 255) / 2;
            int g = (c.G + 255) / 2;
            int b = (c.B + 255) / 2;
            return Color.FromArgb(r, g, b);
        }

        public static Color GoogleColorToSystem(string colorId)
        {
            switch (colorId)
            {
                case "1": return Color.FromArgb(121, 134, 203);
                case "2": return Color.FromArgb(51, 182, 121);
                case "3": return Color.FromArgb(142, 36, 170);
                case "4": return Color.FromArgb(230, 124, 115);
                case "5": return Color.FromArgb(246, 191, 38);
                case "6": return Color.FromArgb(244, 81, 30);
                case "7": return Color.FromArgb(3, 155, 229);
                case "8": return Color.FromArgb(97, 97, 97);
                case "9": return Color.FromArgb(63, 81, 181);
                case "10": return Color.FromArgb(11, 128, 67);
                case "11": return Color.FromArgb(213, 0, 0);
                default: return Color.LightGray;
            }
        }
    }
}
