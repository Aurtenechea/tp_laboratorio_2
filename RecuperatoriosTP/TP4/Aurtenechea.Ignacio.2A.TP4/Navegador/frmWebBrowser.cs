using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;
using Excepciones;

namespace Navegador
{

    /// <summary>
    /// Formulario del navegador.
    /// </summary>
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivo;


        #region inicializacion
        /// <summary>
        /// Inicializa los componentes del formulario.
        /// </summary>
        public frmWebBrowser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicializa el navegador.
        /// </summary>
        /// <param name="sender">Objeto que lanzo el evento.</param>
        /// <param name="e">Argumentos pasados por el evento.</param>
        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
            archivo = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }
        #endregion

        #region "Escriba aquí..."

        /// <summary>
        /// Hace que no se muestre como ocupado el campo de texto del buscador.
        /// </summary>
        /// <param name="sender">Objeto que lanzo le evento.</param>
        /// <param name="e">Argumentos pasados por el evento.</param>
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        /// <summary>
        /// Asigna el color negro para el buscador del navegador, y quita el texto indicador que aparece por defecto.
        /// </summary>
        /// <param name="sender">Objeto que lanzo le evento.</param>
        /// <param name="e">Argumentos pasados por el evento.</param>
        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Escribe el texto indicador por defecto si por ejemplo se escribio algo y luego se borro.
        /// </summary>
        /// <param name="sender">Objeto que lanzo le evento.</param>
        /// <param name="e">Argumentos pasados por el evento.</param>
        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Selecciona el campo texto cuando se hace click sobre el.
        /// </summary>
        /// <param name="sender">Objeto que lanzo le evento.</param>
        /// <param name="e">Argumentos pasados por el evento.</param>
        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        #region manejadores que no entiendo como funcionan.
        /*
         * No entiendo bien como funcionan ya que cambian de thread todo el tiempo.
         */
        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                // progreso es el parametro que hay que pasarle a la funcion.
                // los parametros que hay que pasarle a las funciones registradas en d, se pasan en un array
                // asi se crea un nuevo array que contiene lo que contiene la variable progreso.
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }
        #endregion

        #region otros manejadores
        /// <summary>
        /// Muestra el historial de paginas web ingresadas en un nuevo form.
        /// </summary>
        /// <param name="sender">Objeto que lanzo el evento.</param>
        /// <param name="e">Argumentos pasados por el evento.</param>
        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial h = new frmHistorial(); 
            h.Show();
        }

        /// <summary>
        /// Descarga como texto la pagina ingresada en el buscador y guarda su direccion (URL) en el archivo
        /// con el cual se inicializo el atributo archivo de la clase.
        /// </summary>
        /// <param name="sender">Objeto que lanzo el evento.</param>
        /// <param name="e">Argumentos pasados por el evento.</param>
        private void btnIr_Click(object sender, EventArgs e)
        {
            try
            {
                Uri direccionWeb;
                Descargador descargador;
                Thread t;

                this.txtUrl.Text = "http://" + this.txtUrl.Text;
                direccionWeb = new Uri(this.txtUrl.Text);
                descargador = new Descargador(direccionWeb);

                // a los eventos del objeto descargador le registro sus respectivos manejadores...
                descargador.CambioPorcentajeDescargaEvento += this.ProgresoDescarga;
                descargador.DescargaFinalizadaEvento += this.FinDescarga;
                descargador.ErrorEvento += this.ErrorDescargaMensaje;

                // archivos es un objeto Texto instanciado con la direccion del archivo "historico.dat"
                // guardar en el archivo la direccion ingresada.
                archivo.guardar(direccionWeb.ToString());

                // asigno al hilo la funcion a ejecutar.
                t = new Thread(new ThreadStart(descargador.IniciarDescarga));
                // comienza ejecucion.
                t.Start();
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR. Algo fallo." + ex.Message);
            }
        }

        /// <summary>
        /// Muestra un mensaje de error si no es posible descargar la pagina de la direccion URL ingresada 
        /// </summary>
        public void ErrorDescargaMensaje()
        {
            MessageBox.Show("ERROR. No se puede acceder a esa pagina.");
        }
        #endregion


    }
}
