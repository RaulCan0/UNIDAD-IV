//Alumno Raúl Cano Briseño
using System;
using System.Collections.Generic;

namespace GENERADOR
{
    public class Lenguaje : Sintaxis, IDisposable
    {
         public void Dispose()
        {
            cerrar(); 
            Console.WriteLine("Destructor");
        }
       
    }

}