﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OzorpaService.Data
{
    public class Macro
    {
        public string nombre { get; set; }
        public Camino camino { get; set; }
        public List<Accion> Acciones { get; set; }
    }
}