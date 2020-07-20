using LogP;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


namespace Procesator
{
    public class Imagen
    {
        /// <summary>
        /// Propiedad que enmascara toda la funcionalidad de la libreria OpenCV para el tratado de imagenes
        /// </summary>
        public Mat mascara { get; set; }
        /// <summary>
        /// Punto superior izquierdo desde donde se capturoó la imagen
        /// </summary>
        public OpenCvSharp.Point PtoInicio { get; set; }

        /// <summary>
        /// Busca en el directorio obtenido del archivo de configuracion la imagen que conincida con el id pasado por parametro para usarlo como plantilla o template en el comparado de imagenes
        /// </summary>
        /// <param name="id">Guid de la imagen que se quiere usar como plantilla o template</param>
        /// <returns>devuelve un objeto imagen para usar el en el procesado de imagenes o null si no encuentra imagen que coincida con el id</returns>
        public static Imagen ObtenerTemplate(Guid id)
        {
            try
            {

                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerTemplate()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }

                DirectoryInfo d = new DirectoryInfo(@"D:\OZORPA\Imagenes\repo");

                foreach (var file in d.GetFiles())
                {
                    if (Guid.Parse(file.Name.Split("-")[0]) == id)
                    {

                        Imagen template = new Imagen()
                        {
                            mascara = new Mat(file.FullName, ImreadModes.Grayscale),
                            PtoInicio = new OpenCvSharp.Point(int.Parse(file.Name.Split("-")[1].Replace("(", "").Replace(").jpg", "").Split(",")[0]), int.Parse(file.Name.Split("-")[1].Replace("(", "").Replace(").jpg", "").Split(",")[1]))
                        };
                        file.CopyTo(@"D:\Imagenes\template.jpg", true);
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "Devuelve Imagen del repositorio";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return template;
                    }
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "No se obtuvo ninguna Imagen del repositorio";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return null;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error al obtener Imagen del repositorio";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return null;
            }
        }

        /// <summary>
        /// Obtiene una imagen más grande (defnidas por las areas) a partir del objeto Imagen que llama a la funcion.
        /// </summary>
        /// <param name="areas">Lista de las areas por la cual se genera un objeto Imagen más grande. Si no hay areas captura la pantalla entera</param>
        /// <returns>Devuelve un objeto imagen con las areas aplicadas</returns>
        public Imagen ObtenerCaptura(List<int> areas)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerCaptura()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                if (areas == null)
                {
                    return new Imagen()
                    {
                        mascara = capturarPantalla(),
                        PtoInicio = new OpenCvSharp.Point(0, 0)
                    };
                }
                else
                {
                    if (areas.Count == 1)
                    {
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "Devuelve Captura Imgen en tiempo de ejecución";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return new Imagen()
                        {
                            mascara = capturarImagen(new System.Drawing.Point(this.PtoInicio.X - areas[0], this.PtoInicio.Y - areas[0]), new System.Drawing.Size(2 * areas[0] + this.mascara.Width, 2 * areas[0] + this.mascara.Height)),
                            PtoInicio = new OpenCvSharp.Point(this.PtoInicio.X - areas[0], this.PtoInicio.Y - areas[0])
                        };
                    }
                    else
                    {
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "Devuelve Captura Imgen en tiempo de ejecución";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return new Imagen()
                        {
                            mascara = capturarImagen(new System.Drawing.Point(this.PtoInicio.X - areas[0], this.PtoInicio.Y - areas[2]), new System.Drawing.Size(areas[0] + areas[1] + this.mascara.Width, areas[2] + areas[3] + this.mascara.Height)),
                            PtoInicio = new OpenCvSharp.Point(this.PtoInicio.X - areas[0], this.PtoInicio.Y - areas[2])
                        };

                    }
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error al obtener Captura Imgen en tiempo de ejecución";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return null;
            }
        }

        /// <summary>
        /// Captura toda la pantalla del monitor
        /// </summary>
        /// <returns>Devuel un Objeto Mat de la captura</returns>
        private Mat capturarPantalla()
        {
            try
            {
                Rectangle escritorio = new Rectangle(0, 0, 1920, 1080);
                using (Bitmap bitmap = new Bitmap(escritorio.Width, escritorio.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(System.Drawing.Point.Empty, System.Drawing.Point.Empty, escritorio.Size);
                    }
                    bitmap.Save(@"D:\Imagenes\captura.jpg");
                    return new Mat(@"D:\Imagenes\captura.jpg", ImreadModes.Grayscale);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Catura una imagen de una parte específica de la pantalla
        /// </summary>
        /// <param name="p">Punto desde comienza la captura de la imagen</param>
        /// <param name="s">Tamaño de la imagen que se va a capturar</param>
        /// <returns>Devuelve un Objeto Mat de la captura</returns>
        private Mat capturarImagen(System.Drawing.Point p, System.Drawing.Size s)
        {

            Rectangle imagen = new Rectangle(p, s);
            using (Bitmap bitmap = new Bitmap(imagen.Width, imagen.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(p, System.Drawing.Point.Empty, imagen.Size);
                }
                bitmap.Save(@"D:\Imagenes\captura.jpg");
            }
            return new Mat(@"D:\Imagenes\captura.jpg", ImreadModes.Grayscale);

        }

        /// <summary>
        ///  Encuentra una imagen dentro de otra con un umbral de acierto especificado en el fichero de configuracion
        /// </summary>
        /// <param name="image">Imagen en la que se va a buscar el template</param>
        /// <param name="template">Imagen que se va a buscar en el a image</param>
        /// <returns>Devuelve el punto de inicio donde encontro el template dentro de  image. Si no se cumle el umbral devuelce el punto 0,0</returns>
        public static OpenCvSharp.Point Comparar(Imagen image, Imagen template)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función Comparar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Mat resultado = new Mat();
                var tamano = template.mascara.Size();
                Cv2.MatchTemplate(image.mascara, template.mascara, resultado, TemplateMatchModes.CCoeffNormed);
                Cv2.Normalize(resultado, resultado);
                Cv2.MinMaxLoc(resultado, out double minVal, out double maxVal, out OpenCvSharp.Point minLoc, out OpenCvSharp.Point maxLoc);
                Cv2.ImWrite(@"D:\Imagenes\resultado.jpg", resultado);

                var res = new Mat(image.mascara, new Rect(maxLoc, new OpenCvSharp.Size(tamano.Width, tamano.Height)));

                Mat diff = new Mat();
                Cv2.Subtract(template.mascara, res, diff);
                int diferencia = diff.CountNonZero();
                double umbral = (template.mascara.Height * template.mascara.Width) - (template.mascara.Height * template.mascara.Width * 0.9);
                if (diferencia <= umbral)
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Hay coincidencia de Imagen";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    return maxLoc;
                }
                else
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "No hay coincidencia de Imagen";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    return new OpenCvSharp.Point(0, 0);
                }

            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error en la coparación de Imagenes";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return new OpenCvSharp.Point(0, 0);
            }
        }
    }
}
