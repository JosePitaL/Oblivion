using System;
using System.Collections.Generic;
using System.Text;
using static Reproductor.Comandos;

namespace Studio.Model
{
    public class Accion
    {
        public Comando Comando { get; set; }
        public string Valor { get; set; }
    }
}
