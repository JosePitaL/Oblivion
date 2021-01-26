using Newtonsoft.Json;
using Studio.Model;
using Studio.ViewModel;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Studio.Servicios
{
    public class Fichero
    {
        public Fichero(string Path)
        {
            this.Path = Path;
        }

        public Fichero()
        {

        }

        public string Path { get; set; }

        public string OpenFile()
        {
            var open = new OpenFileDialog();
            open.ShowDialog();
            return open.FileName;
            
        }
        public Automatismo OpenRobot()
        {
            try
            {
                if (File.Exists(Path))
                {
                    StreamReader f = new StreamReader(Path, Encoding.UTF8);
                    //var file = File.ReadAllText(Path, Encoding.UTF8);
                    var automatismo = JsonConvert.DeserializeObject<Automatismo>(f.ReadToEnd());
                    return automatismo;
                }
                else return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public void GenerateTree(Automatismo auto, MainWindowViewModel Main)
        {
            foreach (var Lote in auto.Lotes)
            {

                MyTreeViewAutomatismo my1 = new MyTreeViewAutomatismo(auto, new System.Windows.Controls.TextBox());
                my1.textBox.Text = Lote.Nombre;
                Main.Automata.Add(my1);

                foreach (var Macro in Lote.Macros)
                {

                    MyTreeViewAutomatismo my2 = new MyTreeViewAutomatismo(auto, new System.Windows.Controls.TextBox());
                    my2.textBox.Text = Macro.nombre;
                    my1.Items.Add(my2);

                    MyTreeViewAutomatismo Camino = new MyTreeViewAutomatismo(auto, new System.Windows.Controls.TextBox())
                    {
                        Header = "Camino"
                    };
                    MyTreeViewAutomatismo Acciones = new MyTreeViewAutomatismo(auto, new System.Windows.Controls.TextBox())
                    {
                        Header = "Acciones"
                    };
                    MyTreeViewAutomatismo Cok = new MyTreeViewAutomatismo(auto, new System.Windows.Controls.TextBox());
                    Cok.textBox.Text = "OK : " + Macro.camino.Ok;

                    MyTreeViewAutomatismo Cko = new MyTreeViewAutomatismo(auto, new System.Windows.Controls.TextBox());
                    Cko.textBox.Text = "KO : " + Macro.camino.Ko;

                    MyTreeViewAutomatismo Time = new MyTreeViewAutomatismo(auto, new System.Windows.Controls.TextBox());
                    Time.textBox.Text = "Tiempo : " + Macro.camino.Tiempo;
                    
                    Camino.Items.Add(Cok);
                    Camino.Items.Add(Cko);
                    Camino.Items.Add(Time);
                    my2.Items.Add(Camino);
                    my2.Items.Add(Acciones);
                    foreach (var Accion in Macro.Acciones)
                    {
                        MyTreeViewAutomatismo my3 = new MyTreeViewAutomatismo(auto, new System.Windows.Controls.TextBox());
                        my3.textBox.Text = Accion.Comando + " : " + Accion.Valor;
                        Acciones.Items.Add(my3);
                    }
                }
            }
        }

        public void SaveRobot(Automatismo automatismo)
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(automatismo)); 
        }
    }
}
