using System;
using System.Collections;
using System.IO;

namespace Contingencia
{
	/// <summary>
	/// Summary description for Archivo.
	/// </summary>
	public static class ClsFileManager
	{

        public static Boolean ExisteArchivo(string psArchivo)
        {
            if (File.Exists(psArchivo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string FechaArchivo(string psArchivo)
        {
            string fechaArchivo = "";
            if (File.Exists(psArchivo))
            {
                FileInfo FileProps = new FileInfo(psArchivo);
                fechaArchivo = FileProps.LastWriteTime.ToString();
                FileProps = null;
            }
            else
            {
                throw new Exception(Errores.ArchivoNoExiste);
            }
            return fechaArchivo;
        }

        public static void EliminarArchivo(string psArchivo)
        {
            if (File.Exists(psArchivo))
            {
                try
                {
                    File.Delete(psArchivo);
                }
                catch 
                {
                    throw;
                }
            }
        }

        public static void WriteLog(string text)
		{
			string textWrite = text;

            string fileLog = ArchivoBitacora();
			StreamWriter sw = File.AppendText(fileLog);
			//Write a line of text
			sw.WriteLine(textWrite,false);
			sw.Close();
		}

        public static void WriteFile(string text, string Archivo)
        {
            string textWrite = text;

            StreamWriter sw = File.AppendText(Archivo);
            //Write a line of text
            sw.WriteLine(textWrite, false);
            sw.Close();
        }

        private static string ArchivoBitacora()
        {
            string nombreArchivo;
            nombreArchivo = DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".log";
            return nombreArchivo;
        }

        public static ArrayList ReadFile(string file)
		{
			string fileRead = file;
			ArrayList arrayList = new ArrayList();
			// Create an instance of StreamReader to read from a file.
			// The using statement also closes the StreamReader.
            try
            {
                using (StreamReader sr = new StreamReader(fileRead))
                {
                    String line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        arrayList.Add(line);
                    }
                }
                return arrayList;
            }
            catch (Exception)
            {
                throw;
            }

		}

        public static string LeerUltimaLinea(string file)
        {
            string fileRead = file;
            string ultimaLinea = Variables.Nulo;
            int liIntentos = 0;

            while (true)
            {
                try
                {
                    using(StreamReader sr = new StreamReader(fileRead))
                    {
                        String line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            ultimaLinea = line.ToString();
                        }
                    }
                    return ultimaLinea;
                }
                catch (Exception)
                {
                    if (liIntentos < 3)
                    {
                        liIntentos++;
                    }
                    else
                    {
                        throw;
                    }
                }
            }

        }

        public static string LeerPrimeraLinea(string file)
        {
            string fileRead = file;
            string ultimaLinea = Variables.Nulo;
            int liIntentos = 0;

            while (true)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fileRead))
                    {
                        String line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            ultimaLinea = line.ToString();
                            break;
                        }
                    }
                    return ultimaLinea;
                }
                catch (Exception)
                {
                    if (liIntentos < 3)
                    {
                        liIntentos++;
                    }
                    else
                    {
                        throw;
                    }
                }
            }

        }

        public static string NombreMes(int mes)
		{
			string nombreMes = "";
			switch(mes)
			{
				case 1 :
					nombreMes = "JAN";
					break;
				case 2 :
					nombreMes = "FEB";
					break;
				case 3 :
					nombreMes = "MAR";
					break;
				case 4 :
					nombreMes = "APR";
					break;
				case 5 :
					nombreMes = "MAY";
					break;
				case 6 :
					nombreMes = "JUN";
					break;
				case 7 :
					nombreMes = "JUL";
					break;
				case 8 :
					nombreMes = "AUG";
					break;
				case 9 :
					nombreMes = "SEP";
					break;
				case 10 :
					nombreMes = "OCT";
					break;
				case 11 :
					nombreMes = "NOV";
					break;
				case 12 :
					nombreMes = "DEC";
					break;
			}
			return nombreMes;
		}

	}

    public class ErroresArchivo : ApplicationException
    {
        public ErroresArchivo()
        {
        }

        public ErroresArchivo(string message)
            : base(message)
        {
        }
        public ErroresArchivo(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
