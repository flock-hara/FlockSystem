using FlockAppC.pubClass;
using System;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC
{
    public partial class FrmLoginSetPassword : Form
    {
        private readonly StringBuilder sb = new();

        public FrmLoginSetPassword()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLoginSetPassword_Load(object sender, EventArgs e)
        {
            // パスワード未設定の場合は「新しいパスワード」
            if (ClsLoginUser.ConfirmPass == "") {  this.txtChangePassword.Focus(); }
            else { this.txtPassword.Focus(); }
        }
        /// <summary>
        /// 保存ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReg_Click(object sender, EventArgs e)
        {
            // 入力パスワードチェック
            if (ClsLoginUser.ConfirmPass != this.txtPassword.Text)
            {
                MessageBox.Show("パスワードが違います。", "", MessageBoxButtons.OK);
                return;
            }
            if (this.txtChangePassword.Text.Length < 3)
            {
                MessageBox.Show("パスワードは3文字以上で設定。", "", MessageBoxButtons.OK);
                return;
            }
            if (this.txtChangePassword.Text != this.txtChangePassword2.Text)
            {
                MessageBox.Show("確認入力のパスワードが正しくありません。", "", MessageBoxButtons.OK);
                return;
            }

            // パスワード更新
            try
            {
                // using (clsDb cls = new clsDb(clsPublic.DBNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("SET");
                    sb.AppendLine("confirm_password = '" + this.txtChangePassword.Text + "'");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("staff_id = " + ClsLoginUser.ID);
                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
