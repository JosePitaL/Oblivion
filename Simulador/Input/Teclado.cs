using LogP;
using Simulador.Conf;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static Simulador.Conf.Estructura;
using static Simulador.Conf.User32;

namespace Simulador.Input
{
    public static class Teclado
    {
        /// <summary>
        /// Devuelve la virtual key del string asociado
        /// </summary>
        /// <param name="tecla">Texto de la tecla que quieres pulsar</param>
        /// <returns></returns>
        public static VirtualKey Tecla(string tecla)
        {
            switch (tecla)
            {
                case "BACK":
                    return VirtualKey.VK_BACK;
                case "TAB":
                    return VirtualKey.VK_TAB;
                case "CLEAR":
                    return VirtualKey.VK_CLEAR;
                case "RETURN":
                    return VirtualKey.VK_RETURN;
                case "SHIFT":
                    return VirtualKey.VK_SHIFT;
                case "CONTROL":
                    return VirtualKey.VK_CONTROL;
                case "MENU":
                    return VirtualKey.VK_MENU;
                case "PAUSE":
                    return VirtualKey.VK_PAUSE;
                case "CAPITAL":
                    return VirtualKey.VK_CAPITAL;
                case "KANA":
                    return VirtualKey.VK_KANA;
                case "HANGUEL":
                    return VirtualKey.VK_HANGUEL;
                case "HANGUL":
                    return VirtualKey.VK_HANGUL;
                case "IMEON":
                    return VirtualKey.VK_IME_ON;
                case "JUNJA":
                    return VirtualKey.VK_JUNJA;
                case "FINAL":
                    return VirtualKey.VK_FINAL;
                case "HANJA":
                    return VirtualKey.VK_HANJA;
                case "KANJI":
                    return VirtualKey.VK_KANJI;
                case "IMEOFF":
                    return VirtualKey.VK_IME_OFF;
                case "ESCAPE":
                    return VirtualKey.VK_ESCAPE;
                case "CONVERT":
                    return VirtualKey.VK_CONVERT;
                case "NONCONVERT":
                    return VirtualKey.VK_NONCONVERT;
                case "ACCEPT":
                    return VirtualKey.VK_ACCEPT;
                case "MODECHANGE":
                    return VirtualKey.VK_MODECHANGE;
                case "SPACE":
                    return VirtualKey.VK_SPACE;
                case "PAGEUP":
                    return VirtualKey.VK_PRIOR;
                case "PAGEDOWN":
                    return VirtualKey.VK_NEXT;
                case "END":
                    return VirtualKey.VK_END;
                case "HOME":
                    return VirtualKey.VK_HOME;
                case "LEFT":
                    return VirtualKey.VK_LEFT;
                case "UP":
                    return VirtualKey.VK_UP;
                case "RIGHT":
                    return VirtualKey.VK_RIGHT;
                case "DOWN":
                    return VirtualKey.VK_DOWN;
                case "SELECT":
                    return VirtualKey.VK_SELECT;
                case "PRINT":
                    return VirtualKey.VK_PRINT;
                case "EXECUTE":
                    return VirtualKey.VK_EXECUTE;
                case "SNAPSHOT":
                    return VirtualKey.VK_SNAPSHOT;
                case "INSERT":
                    return VirtualKey.VK_INSERT;
                case "DELETE":
                    return VirtualKey.VK_DELETE;
                case "HELP":
                    return VirtualKey.VK_HELP;
                case "0":
                    return VirtualKey.VK_0;
                case "1":
                    return VirtualKey.VK_1;
                case "2":
                    return VirtualKey.VK_2;
                case "3":
                    return VirtualKey.VK_3;
                case "4":
                    return VirtualKey.VK_4;
                case "5":
                    return VirtualKey.VK_5;
                case "6":
                    return VirtualKey.VK_6;
                case "7":
                    return VirtualKey.VK_7;
                case "8":
                    return VirtualKey.VK_8;
                case "9":
                    return VirtualKey.VK_9;
                case "A":
                    return VirtualKey.VK_A;
                case "B":
                    return VirtualKey.VK_B;
                case "C":
                    return VirtualKey.VK_C;
                case "D":
                    return VirtualKey.VK_D;
                case "E":
                    return VirtualKey.VK_E;
                case "F":
                    return VirtualKey.VK_F;
                case "G":
                    return VirtualKey.VK_G;
                case "H":
                    return VirtualKey.VK_H;
                case "I":
                    return VirtualKey.VK_I;
                case "J":
                    return VirtualKey.VK_J;
                case "K":
                    return VirtualKey.VK_K;
                case "L":
                    return VirtualKey.VK_L;
                case "M":
                    return VirtualKey.VK_M;
                case "N":
                    return VirtualKey.VK_N;
                case "O":
                    return VirtualKey.VK_O;
                case "P":
                    return VirtualKey.VK_P;
                case "Q":
                    return VirtualKey.VK_Q;
                case "R":
                    return VirtualKey.VK_R;
                case "S":
                    return VirtualKey.VK_S;
                case "T":
                    return VirtualKey.VK_T;
                case "U":
                    return VirtualKey.VK_U;
                case "V":
                    return VirtualKey.VK_V;
                case "W":
                    return VirtualKey.VK_W;
                case "X":
                    return VirtualKey.VK_X;
                case "Y":
                    return VirtualKey.VK_Y;
                case "Z":
                    return VirtualKey.VK_Z;
                case "LWIN":
                    return VirtualKey.VK_LWIN;
                case "RWIN":
                    return VirtualKey.VK_RWIN;
                case "APPS":
                    return VirtualKey.VK_APPS;
                case "SLEEP":
                    return VirtualKey.VK_DELETE;
                case "NUMPAD0":
                    return VirtualKey.VK_NUMPAD0;
                case "NUMPAD1":
                    return VirtualKey.VK_NUMPAD1;
                case "NUMPAD2":
                    return VirtualKey.VK_NUMPAD2;
                case "NUMPAD3":
                    return VirtualKey.VK_NUMPAD3;
                case "NUMPAD4":
                    return VirtualKey.VK_NUMPAD4;
                case "NUMPAD5":
                    return VirtualKey.VK_NUMPAD5;
                case "NUMPAD6":
                    return VirtualKey.VK_NUMPAD6;
                case "NUMPAD7":
                    return VirtualKey.VK_NUMPAD7;
                case "NUMPAD8":
                    return VirtualKey.VK_NUMPAD8;
                case "NUMPAD9":
                    return VirtualKey.VK_NUMPAD9;
                case "*":
                    return VirtualKey.VK_MULTIPLY;
                case "+":
                    return VirtualKey.VK_ADD;
                case ";":
                case ":":                                   //No es seguro que sean esta teclas
                    return VirtualKey.VK_SEPARATOR;
                case "-":
                    return VirtualKey.VK_SUBTRACT;
                case ".":
                    return VirtualKey.VK_DECIMAL;
                case "/":
                    return VirtualKey.VK_DIVIDE;
                case "F1":
                    return VirtualKey.VK_F1;
                case "F2":
                    return VirtualKey.VK_F2;
                case "F3":
                    return VirtualKey.VK_F3;
                case "F4":
                    return VirtualKey.VK_F4;
                case "F5":
                    return VirtualKey.VK_F5;
                case "F6":
                    return VirtualKey.VK_F6;
                case "F7":
                    return VirtualKey.VK_F7;
                case "F8":
                    return VirtualKey.VK_F8;
                case "F9":
                    return VirtualKey.VK_F9;
                case "F10":
                    return VirtualKey.VK_F10;
                case "F11":
                    return VirtualKey.VK_F11;
                case "F12":
                    return VirtualKey.VK_F12;
                case "F13":
                    return VirtualKey.VK_F13;
                case "F14":
                    return VirtualKey.VK_F14;
                case "F15":
                    return VirtualKey.VK_F15;
                case "F16":
                    return VirtualKey.VK_F16;
                case "F17":
                    return VirtualKey.VK_F17;
                case "F18":
                    return VirtualKey.VK_F18;
                case "F19":
                    return VirtualKey.VK_F19;
                case "F20":
                    return VirtualKey.VK_F20;
                case "F21":
                    return VirtualKey.VK_F21;
                case "F22":
                    return VirtualKey.VK_F22;
                case "F23":
                    return VirtualKey.VK_F23;
                case "F24":
                    return VirtualKey.VK_F24;
                case "NUMLOCK":
                    return VirtualKey.VK_NUMLOCK;
                case "SCROLL":
                    return VirtualKey.VK_SCROLL;
                case "LSHIFT":
                    return VirtualKey.VK_LSHIFT;
                case "RSHIFT":
                    return VirtualKey.VK_RSHIFT;
                case "LCONTROL":
                    return VirtualKey.VK_LCONTROL;
                case "RCONTROL":
                    return VirtualKey.VK_RCONTROL;
                case "LMENU":
                    return VirtualKey.VK_LMENU;
                case "RMENU":
                    return VirtualKey.VK_RMENU;
                case "BBACK":
                    return VirtualKey.VK_BROWSER_BACK;
                case "BFORWARD":
                    return VirtualKey.VK_BROWSER_FORWARD;
                case "BREFRESH":
                    return VirtualKey.VK_BROWSER_REFRESH;
                case "BSTOP":
                    return VirtualKey.VK_BROWSER_STOP;
                case "BSEARCH":
                    return VirtualKey.VK_BROWSER_SEARCH;
                case "BFAVORITES":
                    return VirtualKey.VK_BROWSER_FAVORITES;
                case "BHOME":
                    return VirtualKey.VK_BROWSER_HOME;
                case "VMUTE":
                    return VirtualKey.VK_VOLUME_MUTE;
                case "VDOWN":
                    return VirtualKey.VK_VOLUME_DOWN;
                case "VUP":
                    return VirtualKey.VK_VOLUME_UP;
                case "MNEXTT":
                    return VirtualKey.VK_MEDIA_NEXT_TRACK;
                case "MPREVT":
                    return VirtualKey.VK_MEDIA_PREV_TRACK;
                case "MSTOP":
                    return VirtualKey.VK_MEDIA_STOP;
                case "MPLAY":
                case "MPAUSE":
                    return VirtualKey.VK_MEDIA_PLAY_PAUSE;
                case "LMAIL":
                    return VirtualKey.VK_LAUNCH_MAIL;
                case "LMSELECT":
                    return VirtualKey.VK_LAUNCH_MEDIA_SELECT;
                case "LAPP1":
                    return VirtualKey.VK_LAUNCH_APP1;
                case "LAPP2":
                    return VirtualKey.VK_LAUNCH_APP2;
                case "":
                    return VirtualKey.VK_RCONTROL;
                case "O:":
                case "O;":
                    return VirtualKey.VK_OEM_1;
                case "0+":
                    return VirtualKey.VK_OEM_PLUS;
                case "O,":
                    return VirtualKey.VK_OEM_COMMA;
                case "O-":
                    return VirtualKey.VK_OEM_MINUS;
                case "O.":
                    return VirtualKey.VK_OEM_PERIOD;
                case "O/":
                case "?":
                    return VirtualKey.VK_OEM_2;
                case "`":
                case "~":
                    return VirtualKey.VK_OEM_3;
                case "[":
                case "{":
                    return VirtualKey.VK_OEM_4;
                case @"\":
                case "|":
                    return VirtualKey.VK_OEM_5;
                case "]":
                case "}":
                    return VirtualKey.VK_OEM_6;
                case "O7":
                    return VirtualKey.VK_OEM_7;
                case "O8":
                    return VirtualKey.VK_OEM_8;
                case "O102":
                    return VirtualKey.VK_OEM_102;
                case "PROCESSKEY":
                    return VirtualKey.VK_PROCESSKEY;
                case "PACKET":
                    return VirtualKey.VK_PACKET;
                case "ATTN":
                    return VirtualKey.VK_ATTN;
                case "CRSEL":
                    return VirtualKey.VK_CRSEL;
                case "EXSEL":
                    return VirtualKey.VK_EXSEL;
                case "EREOF":
                    return VirtualKey.VK_EREOF;
                case "PLAY":
                    return VirtualKey.VK_PLAY;
                case "ZOOM":
                    return VirtualKey.VK_ZOOM;
                case "PA1":
                    return VirtualKey.VK_PA1;
                case "OCLEAR":
                    return VirtualKey.VK_OEM_CLEAR;
                default:
                    return VirtualKey.VK_NULL;
            }
        }

        /// <summary>
        /// Hace las acciones de presionar la tecla del parámetro y soltarla. Hace  todas las acciones propias de pulsar una tecla
        /// </summary>
        /// <param name="key">Tecla que se quiere pulsar</param>
        public static void pulsarTecla(VirtualKey key)
        {
            try
            {
                INPUT input1 = new INPUT();
                input1.type = EnviarInputTipoEvento.InputTeclado;
                input1.mkhi.ki.wVk = (UInt16)key;
                input1.mkhi.ki.wScan = (ushort)MapVirtualKey((UInt16)key, 0);
                SendInput(1, ref input1, Marshal.SizeOf(new INPUT()));

                INPUT input2 = new INPUT();
                input2.type = EnviarInputTipoEvento.InputTeclado;
                input2.mkhi.ki.wVk = (UInt16)key;
                input2.mkhi.ki.wScan = (ushort)MapVirtualKey((UInt16)key, 0);
                input2.mkhi.ki.dwFlags = (uint)EventoTeclado.KEYEVENTF_KEYUP;
                SendInput(1, ref input2, Marshal.SizeOf(new INPUT()));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Mantiene la tecla pulsada que recibe por parámetro
        /// </summary>
        /// <param name="key">Tecla que se quiere mantener pulsada</param>
        public static void mantenerTecla(VirtualKey key)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función mantenerTecla()"; ;
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                INPUT input = new INPUT();
                input.type = EnviarInputTipoEvento.InputTeclado;
                input.mkhi.ki.wVk = (UInt16)key;
                input.mkhi.ki.wScan = (ushort)MapVirtualKey((UInt16)key, 0);
                SendInput(1, ref input, Marshal.SizeOf(new INPUT()));
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Se mantine pulsada la tecla" + key.ToString();
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error mantenerTecla()"; ;
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }

            }
        }

        /// <summary>
        /// Suelta la tecla que recibe por parámetro que anteriormente se mantuvo pulsada seguramente
        /// </summary>
        /// <param name="key">Tecla que se quiere soltar</param>
        public static void soltarTecla(VirtualKey key)
        {
            try
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Función soltarTecla()"; ;
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
                INPUT input2 = new INPUT();
                input2.type = EnviarInputTipoEvento.InputTeclado;
                input2.mkhi.ki.wVk = (UInt16)key;
                input2.mkhi.ki.wScan = (ushort)MapVirtualKey((UInt16)key, 0);
                input2.mkhi.ki.dwFlags = (uint)EventoTeclado.KEYEVENTF_KEYUP;
                SendInput(1, ref input2, Marshal.SizeOf(new INPUT()));
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Se suelta la tecla" + key.ToString();
                    l.Etiqueta = Etiqueta.Info;
                    l.InfoLog();
                }
            }
            catch (Exception)
            {
                using (LogP.LogP l = new LogP.LogP())
                {
                    l.Fecha = DateTime.Now;
                    l.Mensaje = "Error soltarTecla()"; ;
                    l.Etiqueta = Etiqueta.Error;
                    l.InfoLog();
                }
            }
        }
    }
}
