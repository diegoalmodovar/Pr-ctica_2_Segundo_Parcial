using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica_2_Segundo_Parcial
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Programa para Calcular Moda, Media y Mediana !!!");

            Console.WriteLine(); /*espacio*/

            Console.Write($"Introduce la cantidad de Personas que quieras: ");
            int num_Seres = Convert.ToInt32(Console.ReadLine());

            List<Persona> personas = new List<Persona>();


            for (int i = 1; i <= num_Seres; i++)

            {

                Console.WriteLine("Ingrese los Datos Necesarios");

                Console.WriteLine(); /*espacio*/

                Console.WriteLine("Nombre: ");
                string nombre = Console.ReadLine();

                Console.WriteLine(); /*espacio*/

                Console.WriteLine("Cedula: ");
                long cedula = Convert.ToInt64(Console.ReadLine());

                Console.WriteLine(); /*espacio*/

                Console.WriteLine("Fecha de Nacimiento (dd-mm-yyyy):  ");
                DateTime fecha_nacimiento = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine(); /*espacio*/
                Console.WriteLine(); /*espacio*/

                personas.Add(new Persona(nombre, cedula, fecha_nacimiento));


                Console.WriteLine("Personas Capturadas");

                Console.WriteLine(); /*espacio*/

                var hoy = DateTime.Today;
                var edad = hoy.Year - fecha_nacimiento.Year;

                foreach (Persona persona in personas)
                {
                    Console.WriteLine($"Nombre: {persona.Nombre}");
                    Console.WriteLine($"Cédula: {persona.Cedula}");
                    Console.WriteLine($"Fecha de Nacimiento: {persona.Fecha_Nacimiento.ToShortDateString()}");
                    Console.WriteLine($"Edad: {edad}");
                }

            }

            Console.ReadKey();

        }
    }
}
