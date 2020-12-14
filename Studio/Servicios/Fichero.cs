using Newtonsoft.Json;
using Studio.Model;
using System;
using System.IO;

namespace Studio.Servicios
{
    public static class Fichero
    {
        public static Automatismo OpenRobot(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    var file = File.ReadAllText(path);
                    var automatismo = JsonConvert.DeserializeObject<Automatismo>(file);
                    return automatismo;
                }
                else return null;

            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public static void SaveRobot(Automatismo automatismo, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(automatismo)); 
        }
    }
}
