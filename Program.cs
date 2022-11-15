//Alumno Raúl Cano Briseño	
using System;
using System.IO;

namespace GENERADOR
{
    public class Program
    {
        static void Main(string[] args)
        {
            string nombre = "C:\\GENERADOR\\c.gram";
            lenguaje lenguaje = new Lenguaje(nombre);
            lenguaje.Dispose();
        }
    }
}
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using(lenguaje a = new lenguaje())
                {

                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}