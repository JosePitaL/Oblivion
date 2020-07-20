using OpenCvSharp;
using Simulador.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using LogP;
using Procesator;
using Ocr;

namespace Reproductor
{
    public static class Reproductor
    {

        /// <summary>
        /// Lista de Objetos Hash que se utilizaran en la ejecución del automatismo
        /// </summary>
        private static List<Hash> lHash = new List<Hash>();
        /// <summary>
        /// Dicccionario de listas con su clave para utilizar durante la ejecucín del automatismo
        /// </summary>
        private static Dictionary<string, List<string>> listas = new Dictionary<string, List<string>>();




        /// <summary>
        /// Ejecuta los comandos que se especifican por parámetros, con sus valores
        /// </summary>
        /// <param name="comando">La opción de comando que se quiere que se ejecute del enum</param>
        /// <param name="accion">Es un string con los valores del comando</param>
        public static bool Ejecutor(Comandos.Comando comando, string accion)
        {
            using (LogP.LogP l = new LogP.LogP())
            {
                l.Fecha = DateTime.Now;
                l.Mensaje = "Se va a procesar el comando " + comando.ToString() + ": " + accion;
                l.Etiqueta = Etiqueta.Info;
                l.InfoLog();
            }
            switch (comando)
            {
                case Comandos.Comando.IMAGEN:
                    return ComandoImagen(accion);
                case Comandos.Comando.IMAGENCLICK:
                    return ComandoImagenClick(accion);
                case Comandos.Comando.IMAGENMOVE:
                    return ComandoImagenMove(accion);
                case Comandos.Comando.MOVER:
                    return ComandoMover(accion);
                case Comandos.Comando.CLICK:
                    return ComandoClick(accion);
                case Comandos.Comando.COPIAR:
                    return ComandoCopiar();
                case Comandos.Comando.PEGAR:
                    return ComandoPegar();
                case Comandos.Comando.ESCRIBIR:
                    return ComandoEscribir(accion);
                case Comandos.Comando.GHASH:
                    return ComandoGHash(accion);
                case Comandos.Comando.LHASH:
                    return ComandoLHash(accion);
                case Comandos.Comando.LISTA:
                    return ComandoLista(accion);
                case Comandos.Comando.BUSCARLISTA:
                    return ComandoBuscarLista(accion);
                case Comandos.Comando.ANADIRLISTA:
                    return ComandoAnadirLista(accion);
                case Comandos.Comando.ELIMINARLISTA:
                    return ComandoEliminarLista(accion);
                case Comandos.Comando.PULSAR:
                    return ComandoPulsar(accion);
                case Comandos.Comando.REEMPLAZAR:
                    return ComandoReemplazar(accion);
                case Comandos.Comando.EVALUAR:
                    return ComandoEvaluar(accion);
                case Comandos.Comando.OCR:
                    return ComandoOcr(accion);
                case Comandos.Comando.FUNCION:
                    return ComandoFuncion(accion);
                case Comandos.Comando.PROCESO:
                    return ComandoProceso(accion);
                case Comandos.Comando.BUCLE:
                    return ComandoBucle(accion);
                case Comandos.Comando.PAUSA:
                    return ComandoPausa(accion);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Formato: id,i...dn/area O (a1,a2,a3,a4)
        /// Busca una o varias imagenes en la pantalla si la encuentra devuelve true si no false
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si encuentra alguna de la imagenes si no devuelve false</returns>
        private static bool ComandoImagen(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoImagen()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                List<Guid> IdImagenes = Funciones.ObtenerIdImagenes(accion);
                List<int> areas = Funciones.ObtenerAreas(accion);
                foreach (var id in IdImagenes)
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Inicia comparación id " + id;
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    Imagen template = Imagen.ObtenerTemplate(id);
                    Imagen captura = template.ObtenerCaptura(areas);
                    if (Imagen.Comparar(captura, template) != new Point(0, 0))
                    {
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "OK ComandoImagen()";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return true;
                    }
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "KO ComandoImagen()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return false;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoImagen()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }

        }

        /// <summary>
        /// Formato: id,i...dn/area O (a1,a2,a3,a4)/boton/clicks/velocidad
        /// Busca una imagen y si la encuentra hace un click de raton con el raton especificado
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Deveulve true si encontro la imagen e hizo el click y si no devulve false</returns>
        private static bool ComandoImagenClick(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoImagenClick()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                List<Guid> IdImagenes = Funciones.ObtenerIdImagenes(accion);
                List<int> areas = Funciones.ObtenerAreas(accion);

                foreach (Guid id in IdImagenes)
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Inicia comparación id " + id;
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    Imagen template = Imagen.ObtenerTemplate(id);
                    Imagen captura = template.ObtenerCaptura(areas);

                    Point comparacion = Imagen.Comparar(captura, template);
                    if (comparacion != new Point(0, 0))
                    {
                        using Raton raton = new Raton()
                        {
                            Coordenadas = new Point((template.PtoInicio.X + (comparacion.X / 2)), (template.PtoInicio.Y + (comparacion.Y / 2))),
                            velocidad = Funciones.ObtenerRVelocidadImagen(accion),
                            boton = Funciones.ObtenerRBotonImagen(accion),
                            Click = Funciones.ObtenerRClickIimagen(accion),
                            posicion = Posicion.Absoluta
                        };
                        raton.moverRaton();
                        raton.clickRaton();
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "OK ComandoImagenClick()";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return true;
                    }
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "KO ComandoImagenClick()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return false;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoImagenClick()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Formato: id,i...dn/area O (a1,a2,a3,a4)
        /// busca una imagen y posiciona el puntero del raton donde la encuentra
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si encuentra la imageny posiciona el raton si no devuelve false</returns>
        private static bool ComandoImagenMove(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoImagenMove()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                List<Guid> IdImagenes = Funciones.ObtenerIdImagenes(accion);
                List<int> areas = Funciones.ObtenerAreas(accion);

                foreach (Guid id in IdImagenes)
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Inicia comparación id " + id;
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    Imagen template = Imagen.ObtenerTemplate(id);
                    Imagen captura = template.ObtenerCaptura(areas);
                    Point comparacion = Imagen.Comparar(captura, template);
                    if (comparacion != new Point(0, 0))
                    {
                        using Raton raton = new Raton()
                        {
                            Coordenadas = new Point((template.PtoInicio.X + (comparacion.X / 2)), (template.PtoInicio.Y + (comparacion.Y / 2))),
                            velocidad = 200,
                            boton = Boton.Izquierdo,
                            Click = 0,
                            posicion = Posicion.Absoluta
                        };
                        raton.moverRaton();
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "OK ComandoImagenMove()";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return true;
                    }
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "KO ComandoImagenMove()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return false;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoImagenMove()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Formato; x,y/posicion
        /// Mueve el raton hasta la posicion indicada en accion
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Deveulve true si el movimiento fue correcto y si no devuelve false</returns>
        private static bool ComandoMover(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoMover()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using Raton raton = new Raton()
                {
                    Coordenadas = Funciones.ObtenerCoordenadas(accion),
                    velocidad = 200,
                    boton = Boton.Izquierdo,
                    Click = 0,
                    posicion = Funciones.ObtenerPosicion(accion)
                };
                raton.moverRaton();
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoMover()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoMover()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Formato boton/clicks/velocidad
        /// Hace tantos clicks de raton con el boton especificado  en la instancia del objeto raton
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si hace los clicks y si no devuelve false</returns>
        private static bool ComandoClick(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoClick()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using Raton raton = new Raton()
                {
                    Coordenadas = new Point(0, 0),
                    velocidad = Funciones.ObtenerVelocidad(accion),
                    boton = Funciones.ObtenerBoton(accion),
                    Click = Funciones.ObtenerClick(accion),
                    posicion = Posicion.Relativa
                };
                raton.clickRaton();
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoClick()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "ErroComandoClick()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Copia lo que esta seleccionado y tenga foco en el sistema. Hace un CONTROL+C
        /// </summary>
        /// <returns>Deveuelve true si copio correctamente y false si no lo hhizo</returns>
        private static bool ComandoCopiar()
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoCopiar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Simulador.Input.Cb.Copiar();
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComadoCopiar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComadoCopiar()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Pega lo en el foco lo que tenga almacenado en el clipboard
        /// </summary>
        /// <returns>Deveuelve true si copio correctamente y si no devuelve false</returns>
        private static bool ComandoPegar()
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoPegar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Simulador.Input.Cb.Pegar();
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoPegar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoPegar()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Me te en el cliboard el valor de accion y lo pega en el foco
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si escribió correctamente y si no devuelve false</returns>
        private static bool ComandoEscribir(string accion)
        {
            try
            {
                //SUGERENCIA: mirar como hacer el comando con las pulsaciones de teclas
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoEscribir()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Clipboard.SetText(accion);
                ComandoPegar();
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoEscribir()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoEscribir()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Formato : key/value
        /// Introduce en la lista de Hash el nuevo Hash
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si introdujo correctamente el Hash si no devuelve false</returns>
        private static bool ComandoGHash(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoGHash()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Hash hash = new Hash()
                {

                    hash = new KeyValuePair<string, string>(Funciones.ObtenerClaveHash(accion), Funciones.ObtenerValorHash(accion))

                };
                if (hash.hash.Key != null && hash.hash.Value != null)
                {
                    hash.GuardarHash(lHash);
                }
                else
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "KO ComandoGHash()";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }

                    return false;
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoGHash()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoGHash()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Recupera el valor del Hash por su clave dentro de la lista de hashes y lo escribe en el foco
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Deveuelve true si devolvio bien el hash y si no devuelve false</returns>
        private static bool ComandoLHash(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoLHash()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Hash h = Hash.LeerHash(lHash, Funciones.ObtenerClaveHash(accion));
                ComandoEscribir(h.hash.Value);
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoLHash()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoLHash()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Formato: nombre/valor1,...valorn
        /// Crea una nueva lista y la mete en el diccionario de listas con su clave correspondiente
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si se itrodujo correctamente si no deveulve false</returns>
        private static bool ComandoLista(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoLista()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                listas.Add(Funciones.ObtenerNombreLista(accion), Funciones.ObtenerLista(accion));
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK OK ComadoLista()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoLista()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Obtiene el valor de la lista y lo mete en el clipboard
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si encuentra el valor en la lista y si no devuelve false</returns>
        private static bool ComandoBuscarLista(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoBuscarLista()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Clipboard.SetText(listas.GetValueOrDefault(Funciones.ObtenerNombreLista(accion)).Where(x => x == Funciones.ObtenerValorLista(accion)).FirstOrDefault());
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoBuscarLista()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoBuscarLista()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Formato: nombre/valor1,...valorn
        /// Añade a la lista de clave especificada el nuevo valor o valores
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si se insertaron bien los valores y false en caso contrario</returns>
        private static bool ComandoAnadirLista(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoAnadirLista()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                foreach (var item in Funciones.ObtenerValoresLista(accion))
                {
                    listas.GetValueOrDefault(Funciones.ObtenerNombreLista(accion)).Add(item);
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoAnadirLista()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoAnadirLista()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Elimina el valor la lista especificada por su nombre y pasandole el indice a eliminar
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Deveulve true si elimo el valor y si no devuelve false</returns>
        private static bool ComandoEliminarLista(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoEliminarLista()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                for (int i = 0; i <= Funciones.ObtenerNombreLista(accion).Count(); i++)
                {
                    Funciones.ObtenerNombreLista(accion).Remove(i);
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoEliminarLista()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoEliminarLista()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Formato: tecla,...teclan
        /// Simula el pulsado de las teclas pasadas por parametro
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si presiona correctamente las teclas y false en caso contrario</returns>
        private static bool ComandoPulsar(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoPulsar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                var Lista = Funciones.ObtenerTeclas(accion);
                foreach (var item in Lista)
                {
                    Teclado.mantenerTecla(Teclado.Tecla(item));
                    Thread.Sleep(200);
                }

                Lista.Reverse();
                foreach (var item in Lista)
                {
                    Teclado.soltarTecla(Teclado.Tecla(item));
                    Thread.Sleep(200);
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoPulsar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoPulsar()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Sustituyo una palabra por otra en una frase dada
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si la sustiitucion fue correcta y false en caso contrario</returns>
        private static bool ComandoReemplazar(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoReemplazar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Funciones.ObtenerValoresReemplazar(accion);
                if (Funciones.ObtenerValoresReemplazar(accion)[0].Equals("CB")) Funciones.ObtenerValoresReemplazar(accion)[2].Replace(Funciones.ObtenerValoresReemplazar(accion)[0], Clipboard.GetText());
                else Funciones.ObtenerValoresReemplazar(accion)[2].Replace(Funciones.ObtenerValoresReemplazar(accion)[0], Funciones.ObtenerValoresReemplazar(accion)[1]);
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ComandoReemplazar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComadoReemplazar()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Formato: tipo:'valor' == tipo:'valor' && tipo:'valor' != tipo:'valor'
        /// Tipos: N (Numero), S (string), H (Hash), C (Clipboard) 
        /// Evalua expresiones
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si la evalucion es verdadera y en caso contrario false</returns>
        private static bool ComandoEvaluar(string accion)
        {
            /// Función que evalua la comparación
            static bool Evaluar(string tipoA, string valorA, string tipoB, string valorB, string signo)
            {
                try
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Función Evaluar()";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    decimal valorfA = 0, valorfB = 0;
                    if (tipoA.Equals("H"))
                    {
                        valorA = Hash.LeerHash(lHash, valorA).hash.Value;
                    }
                    else if (tipoA.Equals("C"))
                    {
                        valorA = Clipboard.GetText();
                    }

                    if (tipoB.Equals("H"))
                    {
                        valorB = Hash.LeerHash(lHash, valorB).hash.Value;
                    }
                    else if (tipoB.Equals("C"))
                    {
                        valorB = Clipboard.GetText();
                    }
                    if (tipoA.Equals("N") || tipoB.Equals("N"))
                    {
                        valorfA = decimal.Parse(valorA);
                        valorfB = decimal.Parse(valorB);
                    }

                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Devuelve valor Evaluar()";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    switch (signo)
                    {
                        case "<":
                            if (valorA == null && valorB == null)
                            {
                                if (valorfA < valorfB) return true;
                                else return false;
                            }
                            return false;
                        case ">":
                            if (valorA == null && valorB == null)
                            {
                                if (valorfA > valorfB) return true;
                                else return false;
                            }
                            return false;
                        case "<=":
                            if (valorA == null && valorB == null)
                            {
                                if (valorfA <= valorfB) return true;
                                else return false;
                            }
                            return false;
                        case ">=":
                            if (valorA == null && valorB == null)
                            {
                                if (valorfA >= valorfB) return true;
                                else return false;
                            }
                            return false;
                        case "==":
                            if (valorA == null && valorB == null)
                            {
                                if (valorfA == valorfB) return true;
                                else return false;
                            }
                            else
                            {
                                if (valorA.Equals(valorB)) return true;
                                else return false;
                            }
                        case "!=":
                            if (valorA == null && valorB == null)
                            {
                                if (valorfA == valorfB) return true;
                                else return false;
                            }
                            else
                            {
                                if (!valorA.Equals(valorB)) return true;
                                else return false;
                            }
                        default:
                            break;
                    }
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Devuelve valor Evaluar()";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    return false;
                }
                catch
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Error Evaluar()";
                        l.Etiqueta = Etiqueta.Error;
                        l.InfoLog();
                    }
                    return false;
                }
            }
            using (LogP.LogP l = new LogP.LogP())
            {
                l.Fecha = DateTime.Now;
                l.Mensaje = "Función ComandoEvaluar()";
                l.Etiqueta = Etiqueta.Info;
                l.InfoLog();
            }
            try
            {
                List<bool> resultados = new List<bool>();
                Funciones.ObtenerCadenasBool(accion, out List<string> cadenas, out List<string> signos);
                for (int i = 0; i < cadenas.Count; i++)
                {
                    Funciones.ObtenerEvaluar(cadenas[i], out string tipoA, out string valorA, out string tipoB, out string valorB, out string signo);
                    resultados.Add(Evaluar(tipoA, valorA, tipoB, valorB, signo));
                }

                bool result = resultados[0];
                if (resultados.Count > 1)
                {
                    for (int i = 1; i < resultados.Count; i++)
                    {

                        switch (signos[i])
                        {
                            case "||":
                                result = result || resultados[i];
                                break;
                            case "&&":
                                result = result && resultados[i];
                                break;
                            default:
                                break;
                        }
                    }
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = result + " ComandoEvaluar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return result;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoEvaluar()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Guarda en un Hash con una clave el string obtenido de una imagen
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si el guardado en el hash es correcto y en caso contrario false</returns>
        private static bool ComandoOcr(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoOcr()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Ocr.Ocr ocr = new Ocr.Ocr()
                {
                    Id = Funciones.ObtenerIdOcr(accion),
                    Clave = Funciones.ObtenerClaveOcr(accion)
                };

                Imagen captura = Imagen.ObtenerTemplate(ocr.Id).ObtenerCaptura(new List<int>() { 0 });

                ComandoGHash(ocr.Clave + "," + ocr.SacarTexto());
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Ok ComandoOcr()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoOcr()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        private static bool ComandoFuncion(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoFuncion()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Funciones.ObtenerNombreFuncion(accion);
                Funciones.ObtenerParametrosFuncion(accion);
                if (Funciones.ObtenerParametrosFuncion(accion).Count == 0)
                {
                    //Funcion llamar a la función sin parámetros
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Ok ComadoFuncion()";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    return true;
                }
                else
                {
                    // Función llamar a la función con parámetros
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Ok ComadoFuncion()";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComadoFuncion()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// lanza el proceso de la ruta especificada
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si el proceso se lanzo y false si no</returns>
        private static bool ComandoProceso(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoProceso";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Process.Start(accion);
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Ok ComandoProceso()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoProceso()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Formato: tecla,...teclan/nveces/velocidad
        /// Pulsa un o un grupo de teclas tantas veces como in recibe y a una cierta velocidad
        /// </summary>
        /// <param name="accion"></param>
        /// <returns>Devuelve true si se completa el bucle y false en caso contrario</returns>
        private static bool ComandoBucle(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoBucle()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                for (int i = 0; i < Funciones.ObtenerRepeticionesTeclas(accion); i++)
                {
                    ComandoPulsar(String.Join(",", Funciones.ObtenerTeclas(accion).ToArray()));
                    Thread.Sleep(Funciones.ObtenerVelocidadTeclado(accion));
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Ok ComandoBucle()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ComandoBucle()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return false;
            }
        }

        /// <summary>
        /// Hace ua pausa en la ejecucion
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve true si se completa u false en caso contrario</returns>
        private static bool ComandoPausa(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ComandoPausa()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                Thread.Sleep(int.Parse(accion));
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Ok ComandoPausa()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
