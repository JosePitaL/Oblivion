
using Simulador;
using static Simulador.Conf.Estructura;

namespace Studio.Servicios
{
    public class CapturarPosicion 

    {
        public static POINT GetRatonPosicion()
        {
            POINT point;

            Simulador.Conf.User32.GetCursorPos( out point);

            return point;
        }
       
    }
}

