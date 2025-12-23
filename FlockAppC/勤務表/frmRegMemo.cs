using System;
using System.Windows.Forms;

namespace FlockAppC.勤務表
{
    public partial class frmRegMemo : Form
    {
        public DateTime Day {  get; set; }
        public int Userid { get; set; }


        public frmRegMemo()
        {
            InitializeComponent();
        }

        private void frmRegMemo_Load(object sender, EventArgs e)
        {

        }

        private void btnMenu10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
