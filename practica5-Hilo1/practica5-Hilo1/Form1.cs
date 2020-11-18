using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica5_Hilo1
{
    public partial class Form1 : Form
    {
        //
        private Thread hiloSecundario;

        /** Controladores de eventos de espera para el hilo principal y el hilo secundario */
        private ManualResetEvent controladorPararHiloSecundario;
        private ManualResetEvent controladorHiloSecundarioParado;

        //Delegado para asignarle valor a pbProgreso
        private delegate void SetValueDelegate(int prValue);

        //Objeto para el acceso a los controles desde un hilo secundario
         MethodInvoker delegado;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //tsdtipoletra.DropDownItems.;
            
            tstamañoletra.SelectedIndex = 2;
            ncaracteres.Text = "0";
            nfilas.Text = "0";
            Wide();



            //Crear los contradores para llevar a cabo la detension de manera ordenada
            controladorPararHiloSecundario = new ManualResetEvent(false);
            controladorHiloSecundarioParado = new ManualResetEvent(false);

            //Delegado que hace referencia al método que tiene que ejecutar el hilo
            ThreadStart delegadoPS = new ThreadStart(TareaSecundaria);
            //Creación del hilo
            hiloSecundario = new Thread(delegadoPS);
            //Ejecución del hilo
            hiloSecundario.Start();
        }

        private void wideeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wide();
        }

        private void Wide()
        {
            int tam = int.Parse(tstamañoletra.SelectedItem.ToString());
            if (text.SelectionFont != null)
            {
                System.Drawing.Font currentFont = text.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (text.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                text.SelectionFont = new Font(
                   "wide latin",
                   tam,
                   newFontStyle
                );
                tsdtipoletra.Text = "Wide Lite";
            }
        }

        private void arialToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // text.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            Arial();
        }

        private void Arial()
        {
            int tam = int.Parse(tstamañoletra.SelectedItem.ToString());
            if (text.SelectionFont != null)
            {
                System.Drawing.Font currentFont = text.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (text.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                text.SelectionFont = new Font(
                   "Arial",
                   tam,
                   newFontStyle
                );
                tsdtipoletra.Text = "Arial";
            }
        }

        private void Validaciones_tamaño_de_letra()
        {
            if (tstamañoletra.SelectedIndex == 0 )
            {
                if (tsdtipoletra.Text == "Wide Latin")
                {
                    Wide();
                }
                if ( tsdtipoletra.Text == "Arial")
                {
                    Arial();
                }
            }
            
            if (tstamañoletra.SelectedIndex == 1)
            {

                if (tsdtipoletra.Text == "Wide Latin")
                {
                    Wide();
                }
                if (tsdtipoletra.Text == "Arial")
                {
                    Arial();
                }
            }
            if (tstamañoletra.SelectedIndex == 2)
            {
                if (tsdtipoletra.Text == "Wide Latin")
                {
                    Wide();
                }
                if (tsdtipoletra.Text == "Arial")
                {
                    Arial();
                }
            }
            if (tstamañoletra.SelectedIndex == 3)
            {
                if (tsdtipoletra.Text == "Wide Latin")
                {
                    Wide();
                }
                if (tsdtipoletra.Text == "Arial")
                {
                    Arial();
                }
            }
            if (tstamañoletra.SelectedIndex == 4)
            {
                if (tsdtipoletra.Text == "Wide Latin")
                {
                    Wide();
                }
                if (tsdtipoletra.Text == "Arial")
                {
                    Arial();
                }
            }
            if (tstamañoletra.SelectedIndex == 5)
            {
                if (tsdtipoletra.Text == "Wide Latin")
                {
                    Wide();
                }
                if (tsdtipoletra.Text == "Arial")
                {
                    Arial();
                }
            }
            if (tstamañoletra.SelectedIndex == 6)
            {
                if (tsdtipoletra.Text == "Wide Latin")
                {
                    Wide();
                }
                if (tsdtipoletra.Text == "Arial")
                {
                    Arial();
                }
            }
            if (tstamañoletra.SelectedIndex == 7)
            {
                if (tsdtipoletra.Text == "Wide Latin")
                {
                    Wide();
                }
                if (tsdtipoletra.Text == "Arial")
                {
                    Arial();
                }
            }
            if (tstamañoletra.SelectedIndex == 8)
            {
                if (tsdtipoletra.Text == "Wide Latin")
                {
                Wide();
                 }
                 if (tsdtipoletra.Text == "Arial")
                 {
                      Arial();
                 }
            }
            if (tstamañoletra.SelectedIndex == 9)
            {
                if (tsdtipoletra.Text == "Wide Latin")
                {
                Wide();
                 }
                 if (tsdtipoletra.Text == "Arial")
                 {
                      Arial();
                 }
            }
            if (tstamañoletra.SelectedIndex == 10)
            {
                if (tsdtipoletra.Text == "Wide Latin")
                {
                Wide();
                
                 }
                 if (tsdtipoletra.Text == "Arial")
                 {
                      Arial();
                 }
            }
            if (tstamañoletra.SelectedIndex == 11)
            {
                if (tsdtipoletra.Text == "Wide Latin")
                {
                Wide();
                 }
                 if (tsdtipoletra.Text == "Arial")
                 {
                      Arial();
                 }
            }
        }

        private void tstamañoletra_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validaciones_tamaño_de_letra();
        }

        ///////////////////////////////////////////////
        ///
        private void TareaSecundaria()
        {
            
            int caracteres = 0, filas = 0;
            int hecho = 0, tpHecho = 0;
            while (true)
           {
                //    hecho += 1;
                //    tpHecho = (int)(hecho / numCargaUCP.Value * 100);
                //    if (tpHecho > text.Text.Length)
                //        SetValue_pbProgreso(tpHecho);
                delegado = new MethodInvoker(SetValue_ncaracteres);
                ncaracteres.Invoke(delegado);
                delegado = new MethodInvoker(SetValue_nfilas);
                nfilas.Invoke(delegado);

                Thread.Sleep(100);
            }

            

           
        }

        //Método para asignar valor a pbProgreso desde un delegado
       private void SetValue_pbProgreso(int hecho)
        {
            //Si no estamos en el hilo que creo el objeto pbProgreso necesitamos 
            //llamar a Invoke por lo que InvikeRequired devolverá true
            if (text.InvokeRequired)
           {
                SetValueDelegate delegado = new SetValueDelegate(SetValue_pbProgreso);
                text.Invoke(delegado, new object[] { hecho });
            }
            else
                nfilas.Text = Convert.ToString(hecho);
       }

        //Metodo para acceder a btCalcular desde un MethodInvoker
        private void SetValue_ncaracteres()
        {

            if (text.Text != null)
            {
                
                ncaracteres.Text = Convert.ToString(text.Text.Length);
            }
            
        }

        //Metodo para acceder a numCargaUCP desde un MethodInvoker
        private void SetValue_nfilas()
        {
            if (text.Text != null)
            {
                nfilas.Text = Convert.ToString(text.Lines.Count());
               // nfilas.Text = Convert.ToString(text.Text.Length);
            }
            
        }

        private bool pararHiloSecundario()
        {
            /* si el hilo no ha sifo creado o si este no esta en ejecución, retornamos false */
            if (hiloSecundario == null || !hiloSecundario.IsAlive)
                return false;

            /* Cambiar el estado de espera a señalizado para informar al hilo secundario que debe parar */
            controladorPararHiloSecundario.Set();

            while (hiloSecundario.IsAlive)
            {
                /** Esperamos a que los hilos secundarios informen que han parado. Esta espera se realiza 
                 * durante 100 milisegundos de no ocurrir ningun aviso se continua **/
                if (WaitHandle.WaitAll(new WaitHandle[] { controladorHiloSecundarioParado }, 100, true))
                    break;

                /** Se procesan los eventos que se hayan producido en el tiempo de bloqueo **/
                Application.DoEvents();
            }

            return true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pararHiloSecundario())
                return;
        }




        /// <summary>
        /// evento Text change 
        /// </summary>
        /// 
        private void text_TextChanged(object sender, EventArgs e)
        {
         //   TareaSecundaria();
        }
    }
}
