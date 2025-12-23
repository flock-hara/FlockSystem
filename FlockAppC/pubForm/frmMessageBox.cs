using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlockAppC.pubForm
{
    public partial class frmMessageBox : Form
    {
        private const int f_width = 550;
        private const int f_height = 160;
        private const int f_x = 0;
        private const int f_y = 0;
        private const int f_case = 0;
        private const int l_width = 487;
        private const int l_height = 62;
        private const int l_x = 26;
        private const int l_y = 9;
        private const int l_f_size = 10;
        private const bool l_f_bold = false;
        private const bool l_f_italic = false;
        private readonly System.Drawing.Color l_f_color = System.Drawing.Color.Black;

        // ================================================
        // フォーム属性
        // ================================================
        public int F_size_width { get; set; }
        public int F_size_height {  get; set; }
        public int F_location_x {  get; set; }
        public int F_location_y { get; set; }
        // ボタン表示 0:ボタン表示なし 1:閉じるのみ 2:OK/Cancel
        public int F_button_case {  get; set; }
        // ボタンクリック結果 0:Cancel,閉じる 1:OK
        public int F_result {  get; set; }
        public int F_position {  get; set; }
        // ================================================
        // ラベル属性
        // ================================================
        public int L_size_width { get; set; }
        public int L_size_height { get; set; }
        public int L_location_x { get; set; }
        public int L_location_y { get; set; }
        public int L_font_size { get; set; }
        public bool L_font_bold { get; set; }
        public bool L_font_italic { get; set; }
        public Color L_fore_color { get; set; }
        public string L_alignment {  get; set; }
        public string L_value {  get; set; }

        public frmMessageBox()
        {
            InitializeComponent();

            F_size_width = f_width;
            F_size_height = f_height;
            F_location_x = f_x;
            F_location_y = f_y;
            F_button_case = f_case;
            F_result = 0;
            F_position = 1;                 // WindowsDefaultLocation

            L_value = "";
            L_size_width = l_width;
            L_size_height = l_height;
            L_location_x = l_x;
            L_location_x = l_y;
            L_font_size = l_f_size;
            L_font_bold = l_f_bold;
            L_font_italic = l_f_italic;
            L_fore_color = l_f_color;
            L_alignment = "MiddleCenter";
            // MiddleLeft
            // MiddleRight
            // TopCenter
            // TopLeft
            // TopRight
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            // ===================================================
            // フォーム属性設定
            // ===================================================
            this.Width = F_size_width;
            this.Height = F_size_height;
            if (this.F_button_case == 1)
            {
                this.btnClose.Visible = true;
                this.btnOk.Visible = false;
                this.btnCancel.Visible = false;
            }
            else if (this.F_button_case == 2)
            {
                this.btnClose.Visible = false;
                this.btnOk.Visible = true;
                this.btnCancel.Visible = true;
            }
            else
            {
                this.btnClose.Visible = false;
                this.btnOk.Visible = false;
                this.btnCancel.Visible = false;
            }
            // 表示位置
            switch(F_position)
            {
                case 1:
                    this.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    break;
                case 2:
                    this.StartPosition = FormStartPosition.CenterScreen;
                    break;
                case 3:
                    this.StartPosition = FormStartPosition.CenterParent;
                    break;
                case 4:
                    this.StartPosition = FormStartPosition.WindowsDefaultBounds;
                    break;
                case 5:
                    this.StartPosition = FormStartPosition.Manual;
                    break;
            }

            // ===================================================
            // ラベル、フォント属性設定
            // ===================================================
            this.lblMessage.Text = L_value;
            this.lblMessage.Width = L_size_width;
            this.lblMessage.Height = L_size_height;
            this.lblMessage.Location = new Point(L_location_x, L_location_y);
            this.lblMessage.ForeColor = L_fore_color;
            if (L_font_bold == true) { this.lblMessage.Font = new Font(this.lblMessage.Font.FontFamily, L_font_size, FontStyle.Bold); }
            else { this.lblMessage.Font = new Font(this.lblMessage.Font.FontFamily, L_font_size); }
            
            switch(L_alignment)
            {
                case "MiddleCenter":
                    this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                    break;
                case "MiddleLeft":
                    this.lblMessage.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case "MiddleRight":
                    this.lblMessage.TextAlign = ContentAlignment.MiddleRight;
                    break;
                case "TopCenter":
                    this.lblMessage.TextAlign = ContentAlignment.TopCenter;
                    break;
                case "TopLeft":
                    this.lblMessage.TextAlign = ContentAlignment.TopLeft;
                    break;
                case "TopRight":
                    this.lblMessage.TextAlign = ContentAlignment.TopRight;
                    break;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.F_result = 0;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.F_result = 0;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.F_result = 1;
            this.Close();
        }
    }
}
