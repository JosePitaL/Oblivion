using Google.Cloud.Vision.V1;
using LogP;
using System;

namespace Ocr
{
    public class Ocr
    {
        public Guid Id { get; set; }
        public string Clave { get; set; }


        public string SacarTexto()
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función SacarTexto()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                var client = ImageAnnotatorClient.Create();
                var image = Image.FromFile(@"D:\captura.jpg");
                var response = client.DetectText(image);
                foreach (var annotation in response)
                {
                    if (annotation.Description != null)
                    {
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "Devuelve Texto" + annotation.Description;
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return annotation.Description;
                    }
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve Vacío";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return "";
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error SacarTexto()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return null;
            }

        }
    }
}
