using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlockAppC.pubForm
{
    public partial class frmMessage : Form
    {
        public frmMessage()
        {
            InitializeComponent();
        }

        public void frmMessage_Load(object sender, EventArgs e)
        {
            this.txtMessage.Text = Msg;
            this.txtMessage.SelectionStart = 0;

            this.Location = new Point(0, 0);
        }

        private string _Msg;

        public string Msg
        {
            set { _Msg = value; }
            get { return _Msg; }
        }

    }
}
