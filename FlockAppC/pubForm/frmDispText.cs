using System;
using System.Windows.Forms;

namespace FlockAppC.pubForm
{
    public partial class frmDispText : Form
    {
        public string pText;

        public frmDispText()
        {
            InitializeComponent();
        }

        private void FrmDispText_Load(object sender, EventArgs e)
        {
            this.txtText.Text = pText;
            this.txtText.SelectionStart = 0; 
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
