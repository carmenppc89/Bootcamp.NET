using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrueba
{
    public partial class PruebaWindForms : Form
    {
        public PruebaWindForms()
        {
            InitializeComponent();
        }

        // txtNombre dentro del txt de btnPulsar
        private void btnPulsar_Click(object sender, EventArgs e)
        {
            btnPulsar.Text = txtNombre.Text;
        }

        private void PruebaWindForms_Load(object sender, EventArgs e)
        {

        }

        private void listDiaSetmana_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPulsar.Text = listDiaSemana.SelectedItem.ToString();
        }

        private void btnFromulario_Click(object sender, EventArgs e)
        {
            FormBootstrap formBootstrap = new FormBootstrap();
            formBootstrap.Show();
        }
    }
}
