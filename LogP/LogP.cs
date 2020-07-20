using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LogP
{
    public enum Etiqueta
    {
        Info,
        Warning,
        Fatal,
        Error
    }

    public class LogP : IDisposable
    {


        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
        public Etiqueta Etiqueta { get; set; }


        public void InfoLog()
        {
            try
            {
                //List<LogP> lista = new List<LogP>();
                var log = File.ReadAllText(@"D:\OZORPA\log.json");
                if (File.Exists(@"D:\OZORPA\log.json"))
                {
                    var lista = JsonConvert.DeserializeObject<List<LogP>>(log);
                    lista.Add(this);
                    File.WriteAllText(@"D:\OZORPA\log.json", JsonConvert.SerializeObject(lista, Formatting.Indented));
                }
                else
                {
                    File.WriteAllText(@"D:\OZORPA\log.json", JsonConvert.SerializeObject(this, Formatting.Indented));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void BorrarLog()
        {
            try
            {
                if (File.Exists(@"D:\OZORPA\log.json"))
                {
                    File.Delete(@"D:\OZORPA\log.json");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
