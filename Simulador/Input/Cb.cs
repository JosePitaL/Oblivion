using LogP;
using Simulador.Conf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Simulador.Input
{
    public static class Cb
    {
        /// <summary>
        /// Hacer un CONTROL + C físico para copiar algo seleccionado
        /// </summary>
        public static void Copiar()
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función Copiar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Teclado.mantenerTecla(Estructura.VirtualKey.VK_LCONTROL);
                Thread.Sleep(200);
                Teclado.pulsarTecla(Estructura.VirtualKey.VK_C);
                Thread.Sleep(200);
                Teclado.soltarTecla(Estructura.VirtualKey.VK_LCONTROL);
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Simulación CONTROL+C correcta";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error Copiar()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
            }
        }

        /// <summary>
        /// Hacer un CONTROL + V físico para pegar algo seleccionado
        /// </summary>
        public static void Pegar()
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función Pegar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Teclado.mantenerTecla(Estructura.VirtualKey.VK_LCONTROL);
                Thread.Sleep(200);
                Teclado.pulsarTecla(Estructura.VirtualKey.VK_V);
                Thread.Sleep(200);
                Teclado.soltarTecla(Estructura.VirtualKey.VK_LCONTROL);
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Simulación CONTROL+V correcta";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error Pegar()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
            }
        }
    }
}
