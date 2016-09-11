using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_lab_II
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOperacion.Items.Add("+");
            cmbOperacion.Items.Add("-");
            cmbOperacion.Items.Add("*");
            cmbOperacion.Items.Add("/");
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(textBox1.Text);
            Numero num2 = new Numero(textBox2.Text);
            double result = Calculadora.operar(num1, num2, Calculadora.validarOperador(cmbOperacion.Text));
            lblResultado.Text = result.ToString();

        }

        private void btnLimpiar_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            lblResultado.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
