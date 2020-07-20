using System;
using System.Collections.Generic;
using System.Text;

namespace Reproductor
{
    public class Comandos
    {
        /// <summary>
        /// Lista de comandos que puede ejecutar el automatismo
        /// </summary>
        public enum Comando
        {
            IMAGEN,
            IMAGENCLICK,
            IMAGENMOVE,
            MOVER,
            CLICK,
            COPIAR,
            PEGAR,
            ESCRIBIR,
            GHASH,
            LHASH,
            LISTA,
            BUSCARLISTA,
            ANADIRLISTA,
            ELIMINARLISTA,
            PULSAR,
            REEMPLAZAR,
            EVALUAR,
            OCR,
            FUNCION,
            PROCESO,
            BUCLE,
            ERROR,          // Este comando lo implenta el Player
            PAUSA
        }
    }
}
