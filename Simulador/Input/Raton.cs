using LogP;
using OpenCvSharp;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using static Simulador.Conf.Estructura;
using static Simulador.Conf.User32;

namespace Simulador.Input
{
    /// <summary>
    /// Listado de botonesde ratón sobre los que se puede actuar
    /// </summary>
    public enum Boton
    {
        Izquierdo = 0,
        Derecho = 1,
        Nulo = 2

    }

    /// <summary>
    /// Listado de posiciones por las que ser rige el movieminto del raton.
    /// Absoluta: El punto inicial es el punto 0,0 de la pantalla, que es la esquina superior izquierda de de esta
    /// Relativa: El punto inicial es el punto donde se encuentre en ese momento el puntero de ratón que lo asiciara como punto 0,0 
    /// </summary>
    public enum Posicion
    {
        Absoluta = 0,
        Relativa = 1
    }

    public class Raton : IDisposable
    {
        /// <summary>
        /// Punto de las coordenadas x,y a donde se quiere desplazar el ratón
        /// </summary>
        public Point Coordenadas { get; set; }
        /// <summary>
        /// Velocidad entre clicks de ratón
        /// </summary>
        public int velocidad { get; set; }
        /// <summary>
        /// Boton del ratón que se quiere pulsar
        /// </summary>
        public Boton boton { get; set; }
        /// <summary>
        /// Numero de clicks que se quiere hacer sobre un boton del raton
        /// </summary>
        public int Click { get; set; }
        /// <summary>
        /// Posición desde donde empieza a contabilizar las coordenadas
        /// </summary>
        public Posicion posicion { get; set; }


        /// <summary>
        /// Simula el movimiento del ratón a un punto específico de la pantalla. Como punto inicial el 0,0, esquina superior izquierda de la pantalla
        /// </summary>
        public void moverRaton()
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función moverRaton()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                if (this.posicion == 0)
                {
                    SetCursorPos(0, 0);
                    Thread.Sleep(200);
                    SetCursorPos(this.Coordenadas.X, this.Coordenadas.Y);
                }
                else
                {
                    INPUT input = new INPUT();
                    input.type = EnviarInputTipoEvento.InputRaton;
                    input.mkhi.mi.dwFlags = EventoRaton.RATON_MOVE;
                    input.mkhi.mi.dx = this.Coordenadas.X;
                    input.mkhi.mi.dy = this.Coordenadas.Y;
                    SendInput(1, ref input, Marshal.SizeOf(new INPUT()));
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Se mueve el ratón hasta (" + this.Coordenadas.X + "," + this.Coordenadas.Y + ")";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }

            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error moverRaton()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
            }
        }

        /// <summary>
        /// Simula un click de ratón con el boton que tenga definada la instancia del objeto
        /// </summary>
        public void clickRaton()
        {
            using (LogP.LogP l = new LogP.LogP())
            {
                l.Fecha = DateTime.Now;
                l.Mensaje = "Función clickRaton()";
                l.Etiqueta = Etiqueta.Info;
                l.InfoLog();
            }
            EventoRaton ev;
            EventoRaton ev1;
            switch (this.boton)
            {
                case Boton.Izquierdo:
                    ev = EventoRaton.RATON_LEFTDOWN;
                    ev1 = EventoRaton.RATON_LEFTUP;
                    break;
                case Boton.Derecho:
                    ev = EventoRaton.RATON_RIGHTDOWN;
                    ev1 = EventoRaton.RATON_RIGHTUP;
                    break;
                default:
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "No se seleccionó ningún Boton";
                        l.Etiqueta = Etiqueta.Error;
                        l.InfoLog();
                    }
                    return;
            }

            try
            {
                for (int i = 0; i <= (this.Click - 1); i++)
                {
                    INPUT input = new INPUT();
                    input.type = EnviarInputTipoEvento.InputRaton;
                    input.mkhi.mi.dwFlags = ev;
                    SendInput(1, ref input, Marshal.SizeOf(new INPUT()));

                    INPUT input1 = new INPUT();
                    input1.type = EnviarInputTipoEvento.InputRaton;
                    input1.mkhi.mi.dwFlags = ev1;
                    SendInput(1, ref input1, Marshal.SizeOf(new INPUT()));
                    Thread.Sleep(this.velocidad);
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Se clickó " + Click + "veces";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error clickRaton()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
            }
        }

        /// <summary>
        /// Selecciona un área con el ratón. El primer es el que tiene definido en ese momento la instancia del objeto. El segundo punto que se pasa por parametro el punto final de la selección
        /// </summary>
        /// <param name="x">Punto final de la selección en el eje x</param>
        /// <param name="y">Punto final de la selección en el eje y</param>
        public void seleccionarRaton(int x, int y)
        {
            try
            {
                this.moverRaton();

                INPUT input = new INPUT();
                input.type = EnviarInputTipoEvento.InputRaton;
                input.mkhi.mi.dwFlags = EventoRaton.RATON_LEFTDOWN;
                SendInput(1, ref input, Marshal.SizeOf(new INPUT()));

                Thread.Sleep(200);
                this.Coordenadas = new Point(x, y);
                this.moverRaton();

                INPUT input1 = new INPUT();
                input1.type = EnviarInputTipoEvento.InputRaton;
                input1.mkhi.mi.dwFlags = EventoRaton.RATON_LEFTUP;
                SendInput(1, ref input1, Marshal.SizeOf(new INPUT()));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Simula el scroll de la rueda del ratón
        /// </summary>
        /// <param name="scroll">las veces que quieres hacer scroll. Si es positivo el scroll sube y vicerversa</param>
        public void scrollRaton(int scroll)
        {
            try
            {
                INPUT input = new INPUT();
                input.type = EnviarInputTipoEvento.InputRaton;
                input.mkhi.mi.dwFlags = EventoRaton.RATON_WHEEL;
                input.mkhi.mi.ratonData = scroll;
                SendInput(1, ref input, Marshal.SizeOf(new INPUT()));
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
