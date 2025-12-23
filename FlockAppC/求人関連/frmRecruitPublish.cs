using FlockAppC.pubClass;
using FlockAppC.選択画面;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.求人関連
{
    public partial class frmRecruitPublish : Form
    {
        // 掲載ヘッダーID
        public int Header_id { get; set; }
        // 専従先、本社・営業所ID
        private int Location_id { get; set; }
        private string Location_name { get; set; }

        private readonly StringBuilder sb = new();

        private readonly System.Drawing.Color _placeholderColor = System.Drawing.Color.Gray;

        public frmRecruitPublish()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRecruitPublish_Load(object sender, EventArgs e)
        {
            //// 専従先のカッコ内の補足設定（ヒントを灰色で表示させる）
            //this.txtLocationComment.Text = _placeholderText;
            //this.txtLocationComment.ForeColor = _placeholderColor;
            //this.txtLocationComment.Enter += RemovePlaceholder;         // イベント登録：Enter
            //this.txtLocationComment.Leave += SetPlaceholder;            // イベント登録：Leave

            InitializeForm();
        }

        #region "専従先の補足関連（ヒントのグレー表示）"
        /// <summary>
        /// 専従先補足のEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            //if (this.txtLocationComment.Text == _placeholderText)
            //{
            //    this.txtLocationComment.Text = "";
            //    this.txtLocationComment.ForeColor = System.Drawing.Color.Black;  // 通常の色に戻す
            //}
        }
        /// <summary>
        /// 専従先補足のLeaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetPlaceholder(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(this.txtLocationComment.Text))
            //{
            //    this.txtLocationComment.Text = _placeholderText;
            //    this.txtLocationComment.ForeColor = _placeholderColor;  // 薄い色に戻す
            //}
        }
        // プレースホルダーテキストのプロパティ
        //public string PlaceholderText
        //{
        //    get { return _placeholderText; }
        //    set
        //    {
        //        _placeholderText = value;
        //        if (string.IsNullOrWhiteSpace(this.Text))
        //        {
        //            this.Text = _placeholderText;
        //            this.ForeColor = _placeholderColor;
        //        }
        //    }
        //}
        #endregion

        /// <summary>
        /// フォーム初期化（初期表示）
        /// </summary>
        private void InitializeForm()
        {
            // 新規 or 編集 判定
            if (Header_id == 0)
            {
                // 新規追加
                this.rdo2.Checked = true;
                this.lblNew.Visible = true;
            }
            else
            {
                // 掲載先情報表示
                DisplayPublish();
                this.lblNew.Visible = false;
            }
        }
        /// <summary>
        /// 掲載先表示
        /// </summary>
        private void DisplayPublish()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" location_id");
                    sb.AppendLine(",location_name");
                    sb.AppendLine(",publish");
                    sb.AppendLine(",publish_date");
                    sb.AppendLine(",vacancy");
                    sb.AppendLine(",file_path1");
                    sb.AppendLine(",file_path2");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",publish_flag");
                    sb.AppendLine(",location_comment");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_求人掲載");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + this.Header_id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.Location_id = int.Parse(dr["location_id"].ToString());
                            if (this.Location_id >= 51 && this.Location_id <= 59) { this.rdo1.Checked = true; }
                            else { this.rdo2.Checked = true; }
                            this.txtLocationName.Text = dr["location_name"].ToString();
                            this.txtPublish.Text = dr["publish"].ToString();
                            if (DateTime.Parse(dr["publish_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.mtxtDate.Text = "    /  /"; }
                            else { this.mtxtDate.Text = DateTime.Parse(dr["publish_date"].ToString()).ToString("yyyy/MM/dd"); }
                            this.txtVacancy.Text = dr["vacancy"].ToString();
                            this.txtFilePath1.Text = dr["file_path1"].ToString();
                            this.txtFilePath2.Text = dr["file_path2"].ToString();
                            this.txtComment.Text = dr["comment"].ToString();
                            if (int.Parse(dr["publish_flag"].ToString()) == 0)
                            {
                                this.chkPublishFlag.Checked = false;
                            }
                            else
                            {
                                this.chkPublishFlag.Checked = true;
                            }
                            this.txtLocationComment.Text = dr["location_comment"].ToString();
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
        /// 募集元選択処理
        /// </summary>
        private void InitializeLocation()
        {
            if (this.rdo1.Checked == true)
            {
                // 本社・営業所等
                this.txtLocationName.Text = "";
                this.txtLocationComment.Text = "";
            }
            else
            {
                // 専従先
                this.txtLocationName.Text = "";
                this.txtLocationComment.Text = "";
            }
        }
        /// <summary>
        /// イベント　募集元：本社・営業所
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            InitializeLocation();
        }
        /// <summary>
        /// イベント　募集元：専従先
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdo2_CheckedChanged(object sender, EventArgs e)
        {
            InitializeLocation();
        }
        /// <summary>
        /// 求人元選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation_Click(object sender, EventArgs e)
        {
            this.txtLocationName.Text = "";

            // 求人元判定
            if (this.rdo1.Checked == true)
            {
                // 本社・営業所
                選択画面.frmSelectItem frm = new()
                {
                    Kbn = 2,
                    Value = 0
                };
                frm.ShowDialog();
                if (frm.Value != 0)
                {
                    this.txtLocationName.Text = frm.StrVal;
                    this.Location_name = frm.StrVal;
                    this.Location_id = frm.Value;
                }
            }
            else
            {
                // 専従先
                frmSelectLocation fSelectLocation = new()
                {
                    TargetTable = "Mst_専従先",
                    Select_location_name = "",
                    Select_location_id = 0
                };
                fSelectLocation.ShowDialog();
                if (fSelectLocation.Select_location_id == 0) return;
                this.txtLocationName.Text = fSelectLocation.Select_location_name.ToString();
                this.Location_name = fSelectLocation.Select_location_name.ToString();
                this.Location_id = fSelectLocation.Select_location_id;
            }
        }
        /// <summary>
        /// 求人掲載先選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brnSelectPublish_Click(object sender, EventArgs e)
        {
            // 本社・営業所
            選択画面.frmSelectItem frm = new()
            {
                Kbn = 4,
                Value = 0
            };
            frm.ShowDialog();
            if (frm.Value != 0)
            {
                this.txtPublish.Text = frm.StrVal;
            }

        }
        /// <summary>
        /// 登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu1_Click(object sender, EventArgs e)
        {
            if (CheckInputData() != true)
            {
                MessageBox.Show("入力漏れがあります。", "入力エラー", MessageBoxButtons.OK);
                return;
            }

            using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
            {
                // 新規、更新判定
                if (this.Header_id == 0)
                {
                    // 新規
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Trn_求人掲載");
                    sb.AppendLine("(");
                    sb.AppendLine(" location_id");
                    sb.AppendLine(",location_name");
                    sb.AppendLine(",publish");
                    sb.AppendLine(",publish_date");
                    sb.AppendLine(",vacancy");
                    sb.AppendLine(",file_path1");
                    sb.AppendLine(",file_path2");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",publish_flag");
                    sb.AppendLine(",location_comment");
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(this.Location_id.ToString());
                    sb.AppendLine(",'" + this.txtLocationName.Text + "'");
                    sb.AppendLine(",'" + this.txtPublish.Text + "'");
                    if (this.mtxtDate.Text == "    /  ")
                    {
                        // 空白の場合は初期値
                        sb.AppendLine(",'1900/01/01'");
                    }
                    else
                    {
                        sb.AppendLine(",'" + this.mtxtDate.Text + "'");
                    }
                    sb.AppendLine("," + this.txtVacancy.Text);
                    sb.AppendLine(",'" + this.txtFilePath1.Text + "'");
                    sb.AppendLine(",'" + this.txtFilePath2.Text + "'");
                    sb.AppendLine(",'" + this.txtComment.Text + "'");
                    if (this.chkPublishFlag.Checked == true)
                    {
                        // 掲載終了
                        sb.AppendLine(",1");
                    }
                    else
                    {
                        // 掲載中
                        sb.AppendLine(",0");
                    }
                    sb.AppendLine(",'" + this.txtLocationComment.Text + "'");
                    sb.AppendLine(")");
                }
                else
                {
                    // 更新
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Trn_求人掲載");
                    sb.AppendLine("SET");
                    sb.AppendLine(" location_id = " + this.Location_id);
                    sb.AppendLine(",location_name = '" + this.txtLocationName.Text + "'");
                    sb.AppendLine(",publish = '" + this.txtPublish.Text + "'");
                    if (this.mtxtDate.Text == "    /  /")
                    {
                        // 空白の場合は初期値
                        sb.AppendLine(",publish_date = '1900/01/01'");
                    }
                    else
                    {
                        sb.AppendLine(",publish_date = '" + this.mtxtDate.Text + "'");
                    }
                    sb.AppendLine(",vacancy = " + this.txtVacancy.Text);
                    sb.AppendLine(",file_path1 = '" + this.txtFilePath1.Text + "'");
                    sb.AppendLine(",file_path2 = '" + this.txtFilePath2.Text + "'");
                    sb.AppendLine(",comment = '" + this.txtComment.Text + "'");
                    if (this.chkPublishFlag.Checked == true)
                    {
                        // 掲載終了
                        sb.AppendLine(",publish_flag = 1");
                    }
                    else
                    {
                        // 掲載中
                        sb.AppendLine(",publish_flag = 0");
                    }
                    sb.AppendLine(",location_comment = '" + this.txtLocationComment.Text + "'");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + this.Header_id);
                }
                clsSqlDb.DMLUpdate(sb.ToString());
            }
            MessageBox.Show("登録しました。", "結果", MessageBoxButtons.OK);
            this.Close();
        }
        /// <summary>
        /// 入力内容チェック
        /// </summary>
        /// <returns>True:OK/False:NG</returns>
        private bool CheckInputData()
        {
            bool rtn = false;

            if (this.txtLocationName.Text == "") { return rtn; }
            if (this.txtPublish.Text == "") { return rtn; }
            if (this.txtVacancy.Text == "") { return rtn; }

            return true;
        }
        /// <summary>
        /// フォーム表示イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRecruitPublish_Shown(object sender, EventArgs e)
        {
            // InitializeForm();
            this.btnSelectLocation.Focus();
        }
        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu3_Click(object sender, EventArgs e)
        {
            // StringBuilder st = new StringBuilder();

            if (MessageBox.Show("削除しますか？", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_求人掲載");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + Header_id);
                    
                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 選択ボタン１
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect1_Click(object sender, EventArgs e)
        {
            string path = "";
            string file = "";
            string select;

            if (this.txtFilePath1.Text.Length > 3)
            {
                ClsPublic.SeparateFilePath(this.txtFilePath1.Text, ref path, ref file);
                select = ClsPublic.SelectFileDialog(path);
                if (select.Length != 0) { this.txtFilePath1.Text = select; }
            }
            else
            {
                select = ClsPublic.SelectFileDialog(@"C:\");
                this.txtFilePath1.Text = select;
            }
        }
        /// <summary>
        /// 選択ボタン２
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect2_Click(object sender, EventArgs e)
        {
            string path = "";
            string file = "";
            string select;

            if (this.txtFilePath2.Text.Length > 3)
            {
                ClsPublic.SeparateFilePath(this.txtFilePath2.Text, ref path, ref file);
                select = ClsPublic.SelectFileDialog(path);
                if (select.Length != 0) { this.txtFilePath2.Text = select; }
            }
            else
            {
                select = ClsPublic.SelectFileDialog(@"C:\");
                this.txtFilePath2.Text = select;
            }
        }
        /// <summary>
        /// 表示１
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay1_Click(object sender, EventArgs e)
        {
            using (ClsPreview cls = new())
            {
                cls.File_name = this.txtFilePath1.Text;
                if (cls.CheckFile() != true) return;
                cls.PreviewFile();
            }
        }
        /// <summary>
        /// 表示２
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay2_Click(object sender, EventArgs e)
        {
            using (ClsPreview cls = new())
            {
                cls.File_name = this.txtFilePath2.Text;
                if (cls.CheckFile() != true) return;
                cls.PreviewFile();
            }
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
