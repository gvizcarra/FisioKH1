using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisioKH
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pin { get; set; }
        public int Nivel { get; set; }
        public bool Autenticado { get; set; }
        public string ErrorLogin { get; set; } = "";
        public string FechaRegistro { get; set; }
        public bool Activo { get; set; }


    }
}

