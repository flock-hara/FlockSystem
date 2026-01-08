using FlockAppC.pubClass;
using FlockAppC.pubForm;
using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace FlockAppC
{
    public partial class frmLogin : Form
    {
        private readonly StringBuilder sb = new();

        public frmLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // ドロップダウンスタイル
            this.cmbUser.DropDownStyle = ComboBoxStyle.DropDownList;

            // ====================================================================================
            // Rootパス、Applicationパス
            // ====================================================================================
            string xml_file_path_;
            XDocument xml_;
            XElement root_element_;
            xml_file_path_ = @"C:\FLOCK\フロックAPP\FlockSysConf.xml";
            // XMLファイル読み込み
            xml_ = XDocument.Load(xml_file_path_);
            // ルートタグを変数に
            root_element_ = xml_.Element("appSettings");
            //アプリケーションルートパス
            ClsPublic.pubRootPath = root_element_.Element("FlockRootPath").Value;
            ClsPublic.pubAppPath = root_element_.Element("ScheduleEditPath").Value;

            // サーバー名、IPアドレス 2025/08/26 ADD
            ClsPublic.pubServerName = root_element_.Element("ServerName").Value;
            ClsPublic.pubServerIP = root_element_.Element("ServerIP").Value;

            // ====================================================================================
            // デフォルト担当者ID
            // ====================================================================================
            xml_file_path_ = @"C:\FLOCK\フロックAPP\FlockSysID.xml";
            // XMLファイル読み込み
            xml_ = XDocument.Load(xml_file_path_);
            // ルートタグを変数に
            root_element_ = xml_.Element("appSettings");
            // デフォルトID
            int userID = int.Parse(root_element_.Element("TantoID").Value);

            // ====================================================================================
            // DB情報 2025/08/13 UPD
            // ====================================================================================
            ClsDbConfig.LoadDBParam();

            // ====================================================================================
            // 担当者コンボボックス
            // ====================================================================================
            SetUserComboBox(userID);

            // ====================================================================================
            // 前回パスワード表示
            // ====================================================================================
            ClsXml cls = new(@"C:\FLOCK\フロックAPP\EXE\FlockAppLogin.xml");
            XmlNode node;
            // パスワード
            node = cls.GetNode("/appSettings/Pswd");
            if (node != null)
            {
                this.txtPassword.Text = node.InnerText;
            }

            // デフォルトボタン設定
            this.AcceptButton = btnLogin;
        }
        /// <summary>
        /// フォーム表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            // ログインユーザー情報保持
            ClsLoginUser.GetUser(int.Parse(this.cmbUser.SelectedValue.ToString()));

            // 画面表示の際はパスワードにフォーカス
            this.txtPassword.Focus();
        }
        /// <summary>
        /// 担当者コンボボックス設定
        /// </summary>
        /// <param name="p_userID"></param>
        private void SetUserComboBox(int p_userID = 0)
        {
            ClsControll cls = new();

            // ================================================================
            // 担当者コンボボックス設定＆指定担当者選択状態にする
            // ================================================================
            // 条件編集
            sb.Clear();
            sb.AppendLine("office_id IN(" + ClsPublic.OFFICE_HONSHA + "," + ClsPublic.OFFICE_SAITAMA + "," + ClsPublic.OFFICE_YOKOHAMA + ")");
            sb.AppendLine("AND");
            sb.AppendLine("group_id IN(" + ClsPublic.SALES + "," + ClsPublic.AFFAIRS + "," + ClsPublic.PROXY + "," + ClsPublic.OFFICER + "," + ClsPublic.GUEST +")");
            sb.AppendLine("AND");
            // sb.AppendLine("zai_flag = 1");       2026/01/08 UPD
            sb.AppendLine("delete_flag != " + ClsPublic.FLAG_ON);
            // コンボボックス設定
            cls.SetTantoCmb4(this.cmbUser, p_userID, sb.ToString(), "reg_sort");
        }
        /// <summary>
        /// ログインボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            switch(ClsLoginUser.CheckPassword(int.Parse(this.cmbUser.SelectedValue.ToString()), txtPassword.Text))
            {
                case 0:
                    // =====================================================
                    // ログインOK
                    // =====================================================
                    // ログイン画面非表示
                    this.Visible = false;
                    // ログインユーザー情報保持
                    ClsLoginUser.GetUser(int.Parse(this.cmbUser.SelectedValue.ToString()));

                    // ====================================================================================
                    // ユーザーID保存
                    // ====================================================================================
                    ClsXml cls = new(@"C:\FLOCK\フロックAPP\FlockSysID.xml");
                    cls.UpdateNode("/appSettings/TantoID", this.cmbUser.SelectedValue.ToString());
                    cls.Save();

                    // ====================================================================================
                    // パスワード保存
                    // ====================================================================================
                    ClsXml clspwd = new(@"C:\FLOCK\フロックAPP\EXE\FlockAppLogin.xml");
                    clspwd.UpdateNode("/appSettings/Pswd", this.txtPassword.Text);
                    clspwd.Save();

                    // メインメニューへ遷移
                    using (FrmFlockMenu frm = new())
                    {
                        frm.ShowDialog();
                    }
                    this.Close();
                    this.Dispose();
                    break;
                case 1:
                    // =====================================================
                    // パスワード相違
                    // =====================================================
                    MessageBox.Show("パスワードが違います。", "警告", MessageBoxButtons.OK);
                    break;
                case 2:
                    // =====================================================
                    // パスワード未設定
                    // =====================================================
                    MessageBox.Show("パスワードが設定されていません。" + Environment.NewLine + "「パスワード設定」ボタンから、パスワードを設定してください。", "通知", MessageBoxButtons.OK);
                    break;
            }
        }
        /// <summary>
        /// キャンセルボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        /// <summary>
        /// ヘルプボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHelp_Click(object sender, EventArgs e)
        {
            ClsPublic.pubHelpID = 99;
            using (frmHelpView frm = new())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// パスワード設定ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPassword_Click(object sender, EventArgs e)
        {
            using (FrmLoginSetPassword frm = new())
            {
                frm.ShowDialog();
            }
        }
    }
}
