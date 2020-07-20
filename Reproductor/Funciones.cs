using System;
using System.Collections.Generic;
using System.Linq;
using LogP;
using Simulador.Input;

namespace Reproductor
{

    public class Funciones
    {
        #region Parsear Comando Imagenes

        /// <summary>
        /// Busca los Guid id de las imagenes a buscar
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve una Lista de los Guid Id de las imagenes</returns>
        public static List<Guid> ObtenerIdImagenes(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Fuunción ObtenerIdImagenes()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                List<Guid> IdImagenes = new List<Guid>();
                if (accion.Contains("/"))
                {
                    if (accion.Split("/")[0].Contains(","))
                    {
                        foreach (var item in accion.Split("/")[0].Split(","))
                        {
                            IdImagenes.Add(Guid.Parse(item));
                        }
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "Se obtuvieron el/los Id's de Imagen";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return IdImagenes;
                    }
                    else
                    {
                        if (accion.Contains(","))
                        {
                            foreach (var item in accion.Split(","))
                            {
                                IdImagenes.Add(Guid.Parse(item));
                            }
                            using (LogP.LogP l = new LogP.LogP())
                            {
                                l.Fecha = DateTime.Now;
                                l.Mensaje = "Se obtuvieron el/los Id's de Imagen";
                                l.Etiqueta = Etiqueta.Info;
                                l.InfoLog();
                            }
                            return IdImagenes;
                        }
                        else
                        {
                            using (LogP.LogP l = new LogP.LogP())
                            {
                                l.Fecha = DateTime.Now;
                                l.Mensaje = "Se obtuvieron el/los Id's de Imagen";
                                l.Etiqueta = Etiqueta.Info;
                                l.InfoLog();
                            }
                            return new List<Guid>() { Guid.Parse(accion.Split("/")[0]) };
                        }
                    }
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "No se obtuvo ningún Id de Imagen";
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
                    l.Mensaje = "Error al obtener el/los Id's de Imagen";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return null;
            }
        }

        /// <summary>
        /// Devuelve las areas que se epecifican el la accion
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve una lista las areas a aplicar en las imagenes</returns>
        public static List<int> ObtenerAreas(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerAreas()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                List<int> areas = new List<int>();
                if (accion.Contains("/"))
                {
                    if (accion.Split("/")[1].Contains(","))
                    {

                        foreach (var item in accion.Split("/")[1].Split(","))
                        {
                            areas.Add(int.Parse(item));
                        }
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "Se obtuvieron la/las Áreas";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return areas;
                    }
                    else
                    {
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "Se obtuvieron la/las Áreas";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return new List<int>() { int.Parse(accion.Split("/")[1]) };
                    }
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "No se obtuvo ninguna Área";
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
                    l.Mensaje = "Error al obtener las Áreas";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return null;
            }

        }

        /// <summary>
        /// Devuelve el boton que se quiere utilizar para hacer el click
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un Boton con el balor del boton a pulsar</returns>
        public static Boton ObtenerRBotonImagen(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerRBotonImagen()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                if (accion.Split("/").Length > 2)
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Devuelve Botón del Ratón";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }

                    switch (accion.Split("/")[2])
                    {
                        case "I":
                            return Boton.Izquierdo;
                        case "D":
                            return Boton.Derecho;
                        default:
                            return Boton.Izquierdo;
                    }
                }
                return Boton.Izquierdo;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerRBotonImagen()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return Boton.Izquierdo;
            }
        }

        /// <summary>
        /// Devuelve un int con la velocidad de raton entre clicks
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un int con el valor de la velocidad si no devuelve la velocidad por defecto que es 200</returns>
        public static int ObtenerRVelocidadImagen(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerRVelocidadImagen()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                if (accion.Split("/").Length == 5)
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Devuelve velocidad";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    return int.Parse(accion.Split("/")[4]);
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve velocidad por defecto";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return 200;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerRVelocidadImagen()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return 0;
            }
        }

        /// <summary>
        /// Devuelve el numero de veces que se quiere hacer click
        /// </summary>
        /// <param name="accion"></param>
        /// <returns>Devuelve elun int con la veces que se quiere hacer click si no devuelve el valor por defecto que son 2 clicks</returns>
        public static int ObtenerRClickIimagen(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerRClickIimagen()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                if (accion.Split("/").Length == 5 || accion.Split("/").Length == 4)
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Devuelve Clicks de Ratón";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    return int.Parse(accion.Split("/")[3]);
                }
                return 2;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerRClickIimagen()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return 0;
            }
        }
        #endregion

        #region Parsear Comando Raton

        /// <summary>
        /// Obtineel boton que va a hacer la accion de click
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un Boton con el que se hará la accion</returns>
        public static Boton ObtenerBoton(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerBoton()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve Boton";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                switch (accion.Split("/")[0])
                {
                    case "I":
                        return Boton.Izquierdo;
                    case "D":
                        return Boton.Derecho;
                    default:
                        return Boton.Izquierdo;
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerBoton()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return Boton.Nulo;
            }
        }

        /// <summary>
        /// Obtine la velocidad entre clicks de raton
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un int con el valor de la velocidad</returns>
        public static int ObtenerVelocidad(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerVelocidad()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve Velocidad";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return int.Parse(accion.Split("/")[2]);
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerVelocidad()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return 0;
            }
        }

        /// <summary>
        /// Obtiene el numero de clicks de raton para hacer la accion de click
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un int el número de clicks a hacer</returns>
        public static int ObtenerClick(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerClick)";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve Clicks";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return int.Parse(accion.Split("/")[1]);
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerClick()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return 0;
            }
        }

        /// <summary>
        /// Obtine el punto del obejto raton para moverlo hacia alli
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un objeto Point con el valor de las cordenadas del objeto raton</returns>
        public static OpenCvSharp.Point ObtenerCoordenadas(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerCoordenadas()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve las Coordenadas";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return new OpenCvSharp.Point(int.Parse(accion.Split("/")[0].Split(",")[0]), int.Parse(accion.Split("/")[0].Split(",")[1]));
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerCoordenadas()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return new OpenCvSharp.Point(0, 0);
            }
        }

        /// <summary>
        /// Obtien la posicion del raton a partir de la cual va a hacer el movimiento
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve una Posicion para saber cual es el punto 0,0</returns>
        public static Posicion ObtenerPosicion(string accion)
        {
            try
            {
                if (accion.Contains("/"))
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Función ObtenerPosicion()";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Devuelve la Posición";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    switch (accion.Split("/")[1])
                    {
                        case "0":
                            return Posicion.Absoluta;
                        case "1":
                            return Posicion.Relativa;
                        default:
                            return Posicion.Absoluta;
                    }
                }
                return Posicion.Absoluta;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "OK ObtenerPosicion()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return Posicion.Absoluta;
            }
        }
        #endregion

        #region Parsear Comando Hash

        /// <summary>
        /// Obtiene la clave del Hash
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un string con el valos de la clave del Hash</returns>
        public static string ObtenerClaveHash(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerClaveHash()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                if (accion.Contains("/"))
                {
                    using (LogP.LogP l = new LogP.LogP())
                    {
                        l.Fecha = DateTime.Now;
                        l.Mensaje = "Devuelve Clave Hash";
                        l.Etiqueta = Etiqueta.Info;
                        l.InfoLog();
                    }
                    return accion.Split("/")[0];
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve Clave Hash";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return accion;
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerClaveHash";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }

                return null;
            }
        }

        /// <summary>
        /// Obtiene el valos del Hash
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un string con el valos del Hash</returns>
        public static string ObtenerValorHash(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerValorHash()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve Valor Hash";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return accion.Split("/")[1];
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerValorHash()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return null;
            }
        }
        #endregion

        #region Parsear Comando Lista

        /// <summary>
        /// Obtiene todos los valores de la accion separados por comas en una lista
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutars</param>
        /// <return>Devuelve un objeto List con todos sus valores</return>    
        public static List<string> ObtenerLista(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerLista()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve la Lista";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return accion.Split("/")[0].Split(",").ToList();
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerLista()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return null;
            }
        }

        /// <summary>
        /// Ontiene el nombre clave de la lista
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un string con el nombre clave de la lista</returns>
        public static string ObtenerNombreLista(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerNombreLista()()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuele Nombre Lista";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return accion.Split("/")[1];
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerNombreLista()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return "";
            }
        }

        /// <summary>
        /// Obtiene el valor de la lista 
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un string con el valor de la lista</returns>
        public static string ObtenerValorLista(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerValorLista()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve Valor Lista";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return accion.Split("/")[0];
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerValorLista()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return "";
            }
        }

        /// <summary>
        /// Obtiene los valores a añadir en una lista
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Deveulve una List con los valores de la lista</returns>
        public static List<string> ObtenerValoresLista(string accion)
        {
            try
            {
                return accion.Split("/")[0].Split(",").ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        #region Parsear Comando Teclado

        /// <summary>
        /// Oobtiene el listado de teclas a pulsar
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <return>Devuelve un List con las teclas a pulsar</return>
        public static List<string> ObtenerTeclas(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerTeclas()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                if (accion.Contains("/"))
                {
                    if (accion.Split("/")[0].Contains(","))
                    {
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "Devuelve Teclas";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return accion.Split("/")[0].Split(",").ToList();
                    }
                    else
                    {
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "Devuelve Teclas";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return new List<string>() { accion.Split("/")[0] };
                    }
                }
                else
                {
                    if (accion.Contains(","))
                    {
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "Devuelve Teclas";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return accion.Split(",").ToList();
                    }
                    else
                    {
                        using (LogP.LogP l = new LogP.LogP())
                        {
                            l.Fecha = DateTime.Now;
                            l.Mensaje = "Devuelve Teclas";
                            l.Etiqueta = Etiqueta.Info;
                            l.InfoLog();
                        }
                        return new List<string>() { accion };
                    }
                }
            }

            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerTeclas()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return null;
            }
        }

        /// <summary>
        /// Obtiene  velocidad entre pulsado de teclas
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un int con la velocidad</returns>
        public static int ObtenerVelocidadTeclado(string accion)
        {
            try
            {
                return int.Parse(accion.Split("/")[2]);
            }
            catch (Exception)
            {
                return 0;

            }
        }

        /// <summary>
        /// Obtiene el numero de vecesque se van a pulsar las teclas
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns>Devuelve un int con el numero de veces que se van a pulsar las teclas</returns>
        public static int ObtenerRepeticionesTeclas(string accion)
        {
            try
            {
                return int.Parse(accion.Split("/")[1]);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion

        #region Parsear Comando String
        /// <summary>
        /// Obtiene una lista con la palabra que se va a sustir, la palabra por la que se va a sustituir y la frase donde se va a sustituir
        /// </summary>
        /// <param name="accion">Accion del comando reemplazar</param>
        /// <returns>Devuelve un List con todas los valores para sustituir</returns>
        public static List<string> ObtenerValoresReemplazar(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerValeresReemplazar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve los Valores";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return accion.Split(",").ToList();
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerValoresReemplazar()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return null;
            }
        }
        #endregion

        #region Comado Evaluar
        /// <summary>
        /// Saca las cadenas de comparacion separnadolas por los caracteres booleanos
        /// </summary>
        /// <param name="accion">String de toda la cadena de comparación</param>
        /// <param name="cadenas">Lista de todas las cadenas que tiene que comprar</param>
        /// <param name="signos">Signos booleanos que tiene que comparar de cada cadena</param>
        public static void ObtenerCadenasBool(string accion, out List<string> cadenas, out List<string> signos)
        {
            try
            {
                cadenas = new List<string>();
                signos = new List<string>();
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerCadenasBool()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                cadenas = new List<string>();
                signos = new List<string>();
                foreach (var item in accion.Split("&&"))
                {
                    if (item.Contains("||"))
                    {
                        foreach (var item1 in item.Split("||"))
                        {
                            cadenas.Add(item1);
                        }
                    }
                    else
                    {
                        cadenas.Add(item);
                    }
                }

                for (int i = 0; i < accion.Length; i++)
                {
                    if (accion[i].ToString().Equals("|") || accion[i].ToString().Equals("&"))
                    {
                        switch (accion[i].ToString())
                        {
                            case "|":
                                signos.Add("||");
                                i++;
                                break;
                            case "&":
                                signos.Add("&&");
                                i++;
                                break;
                            default:
                                break;
                        }
                    }
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Se obtuvieron las Cadenas";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerCadenasBool()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                cadenas = null;
                signos = null;
            }
        }

        /// <summary>
        /// Separa los datos para comparar las cadenas
        /// </summary>
        /// <param name="accion">Accion que quieres comparar</param>
        /// <param name="tipoA">Tipo de dato del primer comparador que puede ser S: string, H: hash, C: clipboard y N: numero</param>
        /// <param name="valorA">Valor del primer comparador</param>
        /// <param name="tipoB">Tipo de dato del segundo comparador que puede ser S: string, H: hash, C: clipboard y N: numero</param>
        /// <param name="valorB">Valor del segundo comprador</param>
        /// <param name="signo">Signo que se va a utilizar en la compración</param>
        public static void ObtenerEvaluar(string accion, out string tipoA, out string valorA, out string tipoB, out string valorB, out string signo)
        {
            try
            {

                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerEvaluar()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                tipoA = accion.Split("'")[0].Replace(":", "");
                valorA = accion.Split("'")[1];
                if (accion.Split("'")[1].Length > 3)
                {
                    tipoB = accion.Split("'")[2].Substring(2).Replace(":", "");
                    signo = accion.Split("'")[2].Substring(0, 2);
                }
                else
                {
                    tipoB = accion.Split("'")[2].Substring(1).Replace(":", "");
                    signo = accion.Split("'")[2].Substring(0, 1);
                }
                valorB = accion.Split("'")[3];
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Se obtuvieron los Valores";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerEvaluar()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                tipoA = null;
                tipoB = null;
                valorA = null;
                valorB = null;
                signo = null;
            }
        }
        #endregion 

        #region Parsear Comando Ocr
        /// <summary>
        /// Obtiene el id de la imagenpara saber la posicion donde aplicar el OCR
        /// </summary>
        /// <param name="accion">string con la información del comando</param>
        /// <returns>Devuelve un Guid ci el id de la imagen base</returns>
        public static Guid ObtenerIdOcr(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerIdOcr()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve el Id de Imagen";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return Guid.Parse(accion.Split(",")[0]);
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtnerIdOcr";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return new Guid();
            }
        }

        /// <summary>
        /// Obtiene la clave del Hash donde se va a guardar el resultado del OCR
        /// </summary>
        /// <param name="accion">Valor del comando a ejecutar</param>
        /// <returns> Devuelve un strinf con el valor de la clave del hash</returns>
        public static string ObtenerClaveOcr(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerClavedOcr()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve La Clave de Imagen";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return accion.Split(",")[1];
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerClavedOcr()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }

                return null;
            }
        }
        #endregion

        #region Parsear Comando Funcion
        public static string ObtenerNombreFuncion(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerNombreFuncion()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve Nombre Función";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                    return accion.Split("(")[0];
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerNombreFuncion()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return "";
            }
        }

        /// <summary>
        /// Separa la accion en el nombre de la funcion con sus parámetros
        /// </summary>
        /// <param name="accion">String de todo el comado función a ejecutar</param>
        /// <param name="nombre">Nombre de la función a la que debe de llamar</param>
        /// <param name="parametros">Lista de parámetros que se le pasan a la función</param>
        public static List<string> ObtenerParametrosFuncion(string accion)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función ObtenerParametrosFuncion()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelve parámetros de laFunción";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return accion.Split("(")[1].Replace(")", "").Split(",").ToList();
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error ObtenerParametrosFuncion()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return null;
            }
        }
        #endregion

    }
}

