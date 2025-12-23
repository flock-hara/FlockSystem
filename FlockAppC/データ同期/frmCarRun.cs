using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.データ同期
{
    public partial class frmCarRun : Form
    {
        private readonly StringBuilder sb = new();

        public frmCarRun()
        {
            InitializeComponent();
        }

        private void FrmCarRun_Load(object sender, EventArgs e)
        {
            this.dtpDate1.Value = DateTime.Now;
            this.dtpDate2.Value = DateTime.Now;

            SetUserCmb();
            SetCarCmb();

            InitializeForm();
        }
        /// <summary>
        /// フォームクリア
        /// </summary>
        private void InitializeForm()
        {
            // XServer接続メッセージ
            this.lblConnect.Visible = false;

            // インポート完了メッセージ
            this.lblMessage.Visible = false;

            // インポート件数クリア
            this.lblCnt.Text = "";

            // プログレスバー非表示、値初期化
            this.pgb.Visible = false;
            this.pgb.Minimum = 0;
            this.pgb.Maximum = 100;
            this.pgb.Value = 0;
            this.Dock = DockStyle.Top;
        }

        /// <summary>
        /// 従業員コンボボックス
        /// </summary>
        private void SetUserCmb()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    DataRow dr;
                    DataTable dt = new();
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");

                    // SQL編集
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" staff_id");
                    sb.AppendLine(",name1");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Mst_社員");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" zai_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("AND");
                    sb.AppendLine(" proxy_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" sort");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 最初の空行
                        dr = dt.NewRow();
                        dr["Code"] = "0";
                        dr["Name"] = "";
                        dt.Rows.Add(dr);

                        // 結果を読み込みデータテーブルへセット
                        foreach (DataRow drow in dt_val.Rows)
                        {
                            dr = dt.NewRow();
                            dr["Name"] = drow["name1"];
                            // dr["Code"] = drow["ID"];
                            dr["Code"] = drow["staff_id"];
                            dt.Rows.Add(dr);
                        }
                    }

                    // コンボボックスにデータテーブルセット
                    this.cmbUser.DataSource = dt;
                    this.cmbUser.DisplayMember = "Name";
                    this.cmbUser.ValueMember = "Code";

                    this.cmbUser.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // エラー
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 社用車コンボボックス
        /// </summary>
        private void SetCarCmb()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    DataRow dr;
                    DataTable dt = new();
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");

                    // SQL編集
                    sb.Length = 0;
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",car_no");
                    sb.AppendLine(",car_name");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Mst_社用車");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" car_no");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 最初の空行
                        dr = dt.NewRow();
                        dr["Code"] = "0";
                        dr["Name"] = "";
                        dt.Rows.Add(dr);

                        // 結果を読み込みデータテーブルへセット
                        foreach (DataRow drow in dt_val.Rows)
                        {
                            dr = dt.NewRow();
                            dr["Name"] = drow["car_no"] + ":" + drow["car_name"];
                            dr["Code"] = drow["id"];
                            dt.Rows.Add(dr);
                        }
                    }

                    // コンボボックスにデータテーブルセット
                    this.cmbCar.DataSource = dt;
                    this.cmbCar.DisplayMember = "Name";
                    this.cmbCar.ValueMember = "Code";

                    this.cmbCar.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // エラー
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
        }

        /// <summary>
        /// インポートボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("走行記録データをインポートしますか？", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            // XServer接続メッセージ表示
            this.lblConnect.Visible = true;
            this.lblConnect.Refresh();

            ClsTrnCarRun cls = new()
            {
                // 抽出条件設定
                Srch_start_date = this.dtpDate1.Value,
                Srch_end_date = this.dtpDate2.Value,
            };

            // 抽出条件設定
            // cls.Srch_start_date = this.dtpDate1.Value;
            // cls.Srch_end_date = this.dtpDate2.Value;
            // 利用者
            if (this.cmbUser.Text != "") { cls.Srch_staff_id = int.Parse(this.cmbUser.SelectedValue.ToString()); }
            else { cls.Srch_staff_id = -1; }
            // 社用車
            if (this.cmbCar.Text != "") { cls.Srch_car_id = int.Parse(this.cmbCar.SelectedValue.ToString()); }
            else { cls.Srch_car_id = -1; }

            // インポート実行
            var cnt = cls.ImportData(ref this.pgb);

            // XServer接続メッセージ
            this.lblConnect.Visible = false;
            this.lblConnect.Refresh();

            // インポート完了メッセージ
            this.lblMessage.Visible = true;
            this.lblMessage.Refresh();
            this.lblCnt.Text = cnt.ToString() + "件";
        }
    }
}
