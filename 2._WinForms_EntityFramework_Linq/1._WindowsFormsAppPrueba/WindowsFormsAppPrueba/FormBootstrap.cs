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
    public partial class FormBootstrap : Form
    {
        public FormBootstrap()
        {
            InitializeComponent();
        }

        private void FormBootstrap_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string message = GetData();
            string caption = "Datos Introducidos:";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(message, caption, buttons);

            //if (result == System.Windows.Forms.DialogResult.OK)
            //{
            //    Application.Exit();
            //}
        }

        private string GetData()
        {
            //string res = "";
            StringBuilder res = new StringBuilder("");

            return ($@"
- Title:        {txtTitle.Text}
- Location:     {cmBoxLocation.Text}
- Type:         {cmbBoxType.Text}
- Criticity:    {cmbBoxCriticity.Text}
- Enviroment:
    - Production:       {chckBoxProd.CheckState.ToString()}
    - Preproduction:    {chckBoxPreprod.CheckState.ToString()}
    - Demo:             {chckBoxDemo.CheckState.ToString()}
- Description:
{txtDesc.Text}
- Start Date:   {dateStart.Value.Date}
- Duration:     {numUDDuration.Text}
- Status:       {cmbBoxStatus.Text}
- Complete:     {cmbBoxPercent.Text}
- Send email:   {chckBoxEmail.CheckState.ToString()}
");
            //return res;
        }
    }
}
