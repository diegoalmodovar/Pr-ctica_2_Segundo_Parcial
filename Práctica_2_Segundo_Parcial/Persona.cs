using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica_2_Segundo_Parcial
{
    public class Persona
    {
        public string Nombre { get; set; }
        public long Cedula { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }

        public Persona(string nombre, long cedula, DateTime fecha_nacimiento) 
        {

            Nombre = nombre;
            Cedula = cedula;
            Fecha_Nacimiento = fecha_nacimiento;

        }
    }
}
