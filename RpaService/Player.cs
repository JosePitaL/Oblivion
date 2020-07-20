using OzorpaService.Data;
using Reproductor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace OzorpaService
{
    public class Player
    {
        ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        Thread _thread;

        private static bool resultado;
        private static int LoteP = 0;
        private static int MacroP = 0;
        private static List<Accion> Ejecucion;
        private static DateTime InicioMacro;
        private static bool continuidad = true;
        private static int l = 0;
        public static IntPtr ventana;



        public void Start()
        {
            _thread = new Thread(Play);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();

        }

        public void Play()
        {
            try
            {

                var automatismo = Fichero.Fichero.CargarRobot("d:\\robot.json");


                if (automatismo != null)
                {
                    while (continuidad)
                    {
                        _pauseEvent.WaitOne(Timeout.Infinite);
                        ventana = Simulador.Conf.User32.GetForegroundWindow();

                        if (_shutdownEvent.WaitOne(0))
                            break;

                        Ejecucion = automatismo.Lotes[LoteP].Macros[MacroP].Acciones;
                        InicioMacro = DateTime.Now;

                        for (int i = 0; i < Ejecucion.Count; i++)
                        {
                            if (double.Parse(automatismo.Lotes[LoteP].Macros[MacroP].camino.Tiempo) > (DateTime.Now - InicioMacro).TotalSeconds)
                            {
                                if (Ejecucion[i].Comando == Reproductor.Comandos.Comando.ERROR)
                                {
                                    if (!resultado)
                                    {
                                        i = int.Parse(Ejecucion[i].Valor) - 1;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    resultado = Reproductor.Reproductor.Ejecutor(Ejecucion[i].Comando, Ejecucion[i].Valor);
                                    Thread.Sleep(500);
                                }
                            }
                            else
                            {
                                resultado = false;
                                break;
                            }
                        }

                        if (resultado)
                        {
                            l = LoteP;
                            LoteP = int.Parse(automatismo.Lotes[LoteP].Macros[MacroP].camino.Ok.Split("-")[0]);
                            MacroP = int.Parse(automatismo.Lotes[l].Macros[MacroP].camino.Ok.Split("-")[1]);
                        }
                        else
                        {
                            var l = LoteP;
                            LoteP = int.Parse(automatismo.Lotes[LoteP].Macros[MacroP].camino.Ko.Split("-")[0]);
                            MacroP = int.Parse(automatismo.Lotes[l].Macros[MacroP].camino.Ko.Split("-")[1]);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        public void Pause()
        {
            _pauseEvent.Reset();
        }

        public void Continue()
        {
            _pauseEvent.Set();
        }

        public void Stop()
        {
            // Signal the shutdown event
            _shutdownEvent.Set();

            // Make sure to resume any paused threads
            _pauseEvent.Set();

            // Wait for the thread to exit
            _thread.Join();
        }


    }
}

