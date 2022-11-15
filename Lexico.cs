//Alumno Raúl Cano Briseño
using System.IO;

namespace GENERADOR
{
    public class Lexico : Token
    {
        protected StreamReader archivo;
        protected StreamWriter log;
        protected StreamWriter asm;

        const int F = -1;
        const int E = -2;
        protected int linea, posicion=0;
        int[,] TRAND = new int[,]
        {
           
        };
        public Lexico()
        {
            linea = 1;
            string path = "C:\\Users\\tprog\\OneDrive\\Documentos\\Generador\\c.gram";
            bool existencia = File.Exists(path);
            log = new StreamWriter("C:\\Users\\tprog\\OneDrive\\Documentos\\Generador\\prueba.Log");
            log.AutoFlush = true;
           
            
            //log.WriteLine("Primer constructor");
            log.WriteLine("Archivo: prueba.cpp");
            log.WriteLine(DateTime.Now);

         

            if (existencia == true)
            {
                archivo = new StreamReader(path);
            }
            else
            {
                throw new Error("Error: El archivo c.gram no existe", log);
            }
        }
        public Lexico(string nombre)
        {
            linea = 1;
            //Usar el objeto path

            string pathLog = Path.ChangeExtension(nombre, ".log");
            log = new StreamWriter(pathLog);
            log.AutoFlush = true;
           

            log.WriteLine("Archivo: " + nombre);
            log.WriteLine(DateTime.Now);


            if (File.Exists(nombre))
            {
                archivo = new StreamReader(nombre);
            }
            else
            {
                throw new Error("Error: El archivo " + Path.GetFileName(nombre) + " no existe ", log);
            }
        }
        public void cerrar()
        {
            archivo.Close();
            log.Close();
        }

        private void clasifica(int estado)
        {
            
        }
        private int columna(char c)
        {
            return 0;
        }
      
        public void NextToken()
        {
            string buffer = "";
            char c;
            int estado = 0;

            while (estado >= 0)
            {
                c = (char)archivo.Peek(); //Funcion de transicion
                estado = TRAND[estado, columna(c)];
                clasifica(estado);
                if (estado >= 0)
                {

                    archivo.Read();
                    posicion++;

            
                    if (c == '\n')
                    {
                        linea++;
                    }
                    if (estado > 0)
                    {
                        buffer += c;
                    }
                    else
                    {
                        buffer = "";
                    }
                }
            }
            setContenido(buffer);
            
            if (estado == E)
            {
                throw new Error("Error lexico: No definido en linea: " + linea, log);
                
            }
        }

        public bool FinArchivo()
        {
            return archivo.EndOfStream;
        }
    }
}