using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstLocationUser : Form
    {
        /// <summary>
        /// プロパティ
        /// </summary>
        public int Location_Id { get; set; } = 0;                   // 専従先ID
        public string Location_Name { get; set; } = string.Empty;   // 専従先名
        public int User_Id { get; set; } = 0;                       // 担当者ID

        private readonly StringBuilder sb = new();

        public frmMstLocationUser()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMstLocationUser_Load(object sender, EventArgs e)
        {
            // 初期表示時は新規モード
            this.lblNew.Visible = true;

            // フォーム初期化
            InitializeForm();

            // 追加/編集モードの判定
            if (this.User_Id > 0)
            {
                // 編集モード
                this.lblNew.Visible = false;
                // 画面表示
                DisplayUser(this.Location_Id,this.User_Id);
            }
        }
        /// <summary>
        /// 画面初期化
        /// </summary>
        public void InitializeForm()
        {
            // 画面の初期化
            this.lblLocationName.Text = this.Location_Name;
            this.txtUserName.Text = string.Empty;
            this.txtGroupName.Text = string.Empty;
            this.txtPost.Text = string.Empty;
            this.txtTelNo.Text = string.Empty;
            this.txtMobileNo.Text = string.Empty;
            this.txtMailAddress.Text = string.Empty;
            this.chkConfirm.Checked = false;
            this.txtLoginId.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtComment.Text = string.Empty;

            // フォーカスを設定
            this.txtUserName.Focus();
        }
        /// <summary>
        /// 専従先担当者情報表示
        /// </summary>
        /// <param name="locationId"></param>
        private void DisplayUser(int locationId,int userId)
        {
            // 専従先担当者情報を取得
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_専従先担当者.id");
                    sb.AppendLine(",Mst_専従先担当者.location_id");
                    sb.AppendLine(",Mst_専従先担当者.user_name");
                    sb.AppendLine(",Mst_専従先担当者.group_name");
                    sb.AppendLine(",Mst_専従先担当者.post");
                    sb.AppendLine(",Mst_専従先担当者.tel_no");
                    sb.AppendLine(",Mst_専従先担当者.mobile_no");
                    sb.AppendLine(",Mst_専従先担当者.mailaddress");
                    sb.AppendLine(",Mst_専従先担当者.confirm_flag");
                    sb.AppendLine(",Mst_専従先担当者.login_id");
                    sb.AppendLine(",Mst_専従先担当者.password");
                    sb.AppendLine(",Mst_専従先担当者.comment");
                    sb.AppendLine(",Mst_専従先.fullname");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先担当者");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先担当者.location_id = Mst_専従先.location_id");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_専従先担当者.location_id = " + locationId);
                    sb.AppendLine("AND");
                    sb.AppendLine("Mst_専従先担当者.id = " + userId);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("Mst_専従先担当者.id");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.txtUserName.Text = dr["user_name"].ToString();
                            this.txtGroupName.Text = dr["group_name"].ToString();
                            this.txtPost.Text = dr["post"].ToString();
                            this.txtTelNo.Text = dr["tel_no"].ToString();
                            this.txtMobileNo.Text = dr["mobile_no"].ToString();
                            this.txtMailAddress.Text = dr["mailaddress"].ToString();
                            if (int.Parse(dr["confirm_flag"].ToString()) == 1) { this.chkConfirm.Checked = true; }
                            else { this.chkConfirm.Checked = false; }
                            this.txtLoginId.Text = dr["login_id"].ToString();
                            this.txtPassword.Text = dr["password"].ToString();
                            this.txtComment.Text = dr["comment"].ToString();
                            this.lblLocationName.Text = dr["fullname"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 保存ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // 未入力判定
            if (this.txtUserName.Text.Length == 0)
            {
                MessageBox.Show("未入力項目がります。", "結果", MessageBoxButtons.OK);
                return;
            }

            ClsMstLocationUser cls = new()
            {
                Location_id = this.Location_Id,
                User_name = this.txtUserName.Text,
                Group_name = this.txtGroupName.Text,
                Post = this.txtPost.Text,
                Tel_no = this.txtTelNo.Text,
                Mobile_no = this.txtMobileNo.Text,
                Mailaddress = this.txtMailAddress.Text
            };

            // 確認フラグ
            if (this.chkConfirm.Checked == true)
            {
                cls.Confirm_flag = 1;
            }
            else
            {
                cls.Confirm_flag = 0;
            }
            cls.Login_id = this.txtLoginId.Text;
            cls.Password = this.txtPassword.Text;
            cls.Comment = this.txtComment.Text;

            if (this.User_Id > 0)
            {
                // 更新
                cls.Id = this.User_Id;
                cls.Update();
            }
            else
            {
                // 新規登録
                this.User_Id = cls.InsertScalar();
            }

            // 転送確認
            if (MessageBox.Show("登録しました。続けてサーバーに転送（同期）しますか？" + Environment.NewLine + "転送先 [" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Instance + "\\" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Database + "]", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                InitializeForm();
                this.Close();
                return;
            }

            try
            {
                // 接続メッセージ
                this.lblConnect.Visible = true;

                // 転送（同期）処理
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // Mst_専従先担当者クラス
                    ClsMstLocationUser clsMstLocationUser = new();
                    // 専従先担当者登録
                    clsMstLocationUser.ExportLocationOneUserData(this.User_Id, clsSqlDb, clsMySqlDb);
                }
                InitializeForm();
                MessageBox.Show("転送しました。", "結果", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
            finally
            {
                // 接続メッセージ
                this.lblConnect.Visible = false;
            }
        }
        /// <summary>
        /// 削除ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClsMstLocationUser cls = new();

            if (this.User_Id > 0)
            {
                // 更新
                cls.Id = this.User_Id;
                cls.Delete();
            }

            MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
            InitializeForm();
            this.Close();
        }
        /// <summary>
        /// 閉じるボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
