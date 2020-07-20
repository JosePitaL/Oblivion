using LogP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulador.Input
{
    public class Hash
    {
        /// <summary>
        /// Propiedad de clave, valor para el almacenamiento de datos
        /// </summary>
        public KeyValuePair<string, string> hash { get; set; }

        /// <summary>
        /// Añade un par clave-valor a la lista que se le pasa por parámetro
        /// </summary>
        /// <param name="listaHash"> Lista donde se va a guardar el Hash</param>
        public void GuardarHash(List<Hash> listaHash)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función GuardarHash()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                if (listaHash.Contains(this))
                {
                    listaHash.Remove(this);
                }
                listaHash.Add(this);
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Se guardó elHash " + this.hash.Key + ":" + this.hash.Value;
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error GuardarHash()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
            }
        }

        /// <summary>
        /// Recupera el valor del hash asociado a la key que se pasa por parametro dentro de la lista de Hash que se pasa por parámetro
        /// </summary>
        /// <param name="listaHash" >Lista donde se quiere buscar el Hash asociado a la Key pasada por parametro</param>
        /// <param name="key">key para buscar su valor asociado en la lista</param>
        /// <returns>Devuelve un Objeto de tipo has con su clave y su valor</returns>
        public static Hash LeerHash(List<Hash> listaHash, string key)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función LeerHash()";
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Devuelveel Hash " + listaHash.Where(x => x.hash.Key == key).FirstOrDefault().hash.Key + ":" + listaHash.Where(x => x.hash.Key == key).FirstOrDefault().hash.Value;
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                return listaHash.Where(x => x.hash.Key == key).FirstOrDefault();
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error LeerHash()";
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
                return null;
            }


        }


    }
}
