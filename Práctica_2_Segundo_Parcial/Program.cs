using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            Dictionary<int, int> edades = new Dictionary<int, int>();
            double sumatoria = 0;
            double mediana = 0;
            double promedio = 0;

            try
            {
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
                    var hoy = DateTime.Today;
                    int edad = hoy.Year - fecha_nacimiento.Year;

                    personas.Add(new Persona(nombre, cedula, fecha_nacimiento, edad));

                    Console.WriteLine("Personas Capturadas");

                    Console.WriteLine(); /*espacio*/

                    escribirCSV(nombre, cedula, fecha_nacimiento, edad);

                    foreach (Persona persona in personas)
                    {
                        Console.WriteLine($"Nombre: {persona.Nombre}");
                        Console.WriteLine($"Cédula: {persona.Cedula}");
                        Console.WriteLine($"Fecha de Nacimiento: {persona.Fecha_Nacimiento.ToShortDateString()}");
                        Console.WriteLine($"Edad: {persona.Edad}");
                    }
                }
            } catch(Exception e) {
            Console.WriteLine("Informacion invalida");
            };
            foreach (Persona persona in personas)
            {
                sumatoria = sumatoria + persona.Edad;
                if (edades.ContainsKey(persona.Edad))
                {
                    edades[persona.Edad]++;
                }
                else
                {
                    edades[persona.Edad] = 1;
                }
            }
            Console.WriteLine(sumatoria);
            promedio = sumatoria / personas.Count;
            Console.WriteLine(promedio);
            List<Persona> perssonaOrdn = personas.OrderBy(Persona => Persona.Edad).ToList();

            int x = perssonaOrdn.Count / 2;
            if (perssonaOrdn.Count % 2 == 0)
            {
                mediana = perssonaOrdn[x - 1].Edad + (perssonaOrdn[x].Edad / 2);
            }
            else
            {
                mediana = perssonaOrdn[x].Edad;
            }

            int conteo = edades.Values.Max();
            int moda = edades.FirstOrDefault(y => y.Value == conteo).Key;

            Console.WriteLine("El promedio es " + promedio);
            Console.WriteLine("La mediana es " + mediana);
            Console.WriteLine("La moda es " + moda);
            Console.ReadKey();

        }

        static void escribirCSV(String nombre, long cedula, DateTime fecha_nacimiento, int edad)
        {
            String ruta = @"C:\\Users\\anton\\source\\repos\\Pr-ctica_2_Segundo_Parcial\Practica2.csv";
            String separador = ",";
            StringBuilder salida = new StringBuilder();

            String cadena = nombre + "," + cedula + "," + edad;
            List<String> lista = new List<String>();
            lista.Add(cadena);

            for (int i = 0; i < lista.Count; i++)
            {
                salida.AppendLine(string.Join(separador, lista[i]));

                File.AppendAllText(ruta, salida.ToString());
            }
        }

        static void leerCSV()
        {
            var reader = new StreamReader(File.OpenRead(@"C:\\Users\\anton\\source\\repos\\Pr-ctica_2_Segundo_Parcial\Practica2.csv"));

            while (!reader.EndOfStream)
            {
                var linea = reader.ReadLine();
                var valores = linea.Split(',');

                for (int i = 0; i < valores.Length; i++)
                {
                    if ((i % 3) == 0)
                    {
                        Console.Write(valores[i] + " - " + valores[i + 1] + " - " + valores[i + 2]);
                    }
                    else { Console.WriteLine(); }
                }
            }
        }
    }
}
