using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    /// <summary>
    /// Formulario del historial.
    /// </summary>
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "../../../Historico.dat";

        /// <summary>
        /// Inicializa los componentes del formulario.
        /// </summary>
        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga la lista del listBox con los datos leidos del archivo.
        /// </summary>
        /// <param name="sender">Objeto que lanzo le evento.</param>
        /// <param name="e">Argumentos pasados por el evento.</param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            List<string> lsString;
            archivos.leer(out lsString);
            for (int i = 0; i < lsString.Count; i++)
            {
                this.lstHistorial.Items.Add( lsString[i] );
            }
        }
    }
}
