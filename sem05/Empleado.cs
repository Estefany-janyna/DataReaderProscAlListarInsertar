using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem05
{
    public class Empleado
    {
        // Propiedades de la clase Empleado
        public int IdEmpleado { get; set; }
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string Tratamiento { get; set; }
        

        // Constructor de la clase Empleado
        public Empleado(int idEmpleado, string apellidos, string nombre, string cargo, string tratamiento)
        {
            IdEmpleado = idEmpleado;
            Apellidos = apellidos;
            Nombre = nombre;
            Cargo = cargo;
            Tratamiento = tratamiento;
           
        }
    }

}
