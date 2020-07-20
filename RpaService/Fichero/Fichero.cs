using Newtonsoft.Json;
using OzorpaService.Data;
using System;
using System.IO;

namespace OzorpaService.Fichero
{
    public static class Fichero
    {

        public static Automatismo CargarRobot(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    var file = File.ReadAllText(path);
                    var automatismo = JsonConvert.DeserializeObject<Data.Automatismo>(file);
                    return automatismo;
                }
                else return null;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
