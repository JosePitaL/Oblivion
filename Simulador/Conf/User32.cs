using System;
using System.Runtime.InteropServices;
using static Simulador.Conf.Estructura;

namespace Simulador.Conf
{
    /// <summary>
    /// Funciones incluidas en la API de windows para interactuar con el sistema Operativo
    /// </summary>
    public static class User32
    {
        [DllImport("user32.dll")]
        public static extern long SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT point);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, ref Estructura.INPUT pInputs, int cbSize);

        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetFocus(IntPtr hWnd);
    }
}
