using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.社用車関連
{
    public partial class frmCarEdit : Form
    {
        // 走行記録レコードID (セット：編集 / 未セット：新規)
        public int Id {  get; set; }

        private readonly StringBuilder sb = new();

        public frmCarEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCarEdit_Load(object sender, EventArgs e)
        {
            SetUserCmb();
            SetCarCmb();
            SetPointCmb(this.cmbFron_Point);
            SetPointCmb(this.cmbTo_Point);

            if (Id == 0)
            {
                // 新規追加
                InitializeDisp();
            }
            else
            {
                // 編集
                EditCarRunData(Id);
            }

            // 権限判定→権限無しは閲覧のみ可能
            if (ClsLoginUser.CarManageFlag != ClsPublic.FLAG_ON) { this.btnReg.Enabled = false; }

            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// フォームクリア
        /// </summary>
        private void InitializeDisp()
        {
            this.dtpDay.Value = DateTime.Now;
            this.rdoAlcohol_Ok.Checked = false;
            this.rdoAlcohol_Ng.Checked = false;
            this.dtpStart_Time.Text = "";
            this.dtpEnd_Time.Text = "";
            this.txtStart_Odo.Text = "";
            this.txtEnd_Odo.Text = "";
            this.txtDistance.Text = "";
            this.txtNote.Text = "";
            this.txtGas_Stock.Text = "";
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
                    // コンボボックス用
                    DataRow dr;
                    DataTable dt = new();
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");

                    // SQL編集
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" staff_id");
                    sb.AppendLine(",id");
                    sb.AppendLine(",fullname");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Mst_社員");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" zai_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("AND");
                    sb.AppendLine(" proxy_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" sort");

                    // 最初の空行
                    dr = dt.NewRow();
                    dr["Code"] = "0";
                    dr["Name"] = "";
                    dt.Rows.Add(dr);

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 結果を読み込みデータテーブルへセット
                        foreach (DataRow drow in dt_val.Rows)
                        {
                            dr = dt.NewRow();
                            dr["Name"] = drow["fullname"];
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
                    // コンボボックス用
                    DataRow dr;
                    DataTable dt = new();
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");

                    // SQL編集
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",car_no");
                    sb.AppendLine(",car_name");
                    sb.AppendLine("FROM");
                    sb.AppendLine(" Mst_社用車");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" car_no");

                    // cls.Sql = st.ToString();
                    // cls.DMLSelect();

                    // 最初の空行
                    dr = dt.NewRow();
                    dr["Code"] = "0";
                    dr["Name"] = "";
                    dt.Rows.Add(dr);

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
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
        /// 行先コンボボックス
        /// </summary>
        private void SetPointCmb(ComboBox p_cmb)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // コンボボックス用
                    DataRow dr;
                    DataTable dt = new();
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");

                    // SQL編集
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("name");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("location_id");
                    
                    // 最初の空行
                    dr = dt.NewRow();
                    dr["Code"] = "";
                    dr["Name"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["Code"] = "自宅";
                    dr["Name"] = "自宅";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["Code"] = "本社";
                    dr["Name"] = "本社";
                    dt.Rows.Add(dr);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 結果を読み込みデータテーブルへセット
                        foreach (DataRow drow in dt_val.Rows)
                        {
                            dr = dt.NewRow();
                            dr["Code"] = drow["name"];
                            dr["Name"] = drow["name"];
                            dt.Rows.Add(dr);
                        }
                    }

                    // コンボボックスにデータテーブルセット
                    p_cmb.DataSource = dt;
                    p_cmb.DisplayMember = "Name";
                    p_cmb.ValueMember = "Code";
                    p_cmb.SelectedIndex = 0;
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
        /// 編集データを表示
        /// </summary>
        /// <param name="p_id"></param>
        private void EditCarRunData(int p_id)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",car_id");
                    sb.AppendLine(",car_name");
                    sb.AppendLine(",used_user_id");
                    sb.AppendLine(",used_user_name");
                    sb.AppendLine(",day");
                    sb.AppendLine(",start_time");
                    sb.AppendLine(",end_time");
                    sb.AppendLine(",start_odo");
                    sb.AppendLine(",end_odo");
                    sb.AppendLine(",distance");
                    sb.AppendLine(",check_alcohol");
                    sb.AppendLine(",from_point");
                    sb.AppendLine(",to_point");
                    sb.AppendLine(",note");
                    sb.AppendLine(",gas_stock");
                    sb.AppendLine(",delete_flag");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_走行記録");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + p_id);

                    // 処理改善 2025/09/02
                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.cmbCar.SelectedValue = dr["car_id"].ToString();
                            // dr["car_name"].ToString();
                            this.cmbUser.SelectedValue = dr["used_user_id"].ToString();
                            // dr["used_user_name"].ToString();
                            this.dtpDay.Value = DateTime.Parse(dr["day"].ToString());
                            if (dr.IsNull("start_time") != true)
                            {
                                // 初期値（未入力）判定
                                if (dr["start_time"].ToString().Substring(dr["start_time"].ToString().Length - 8) != " 0:00:00")
                                {
                                    // 入力有りの場合は表示
                                    this.dtpStart_Time.Value = DateTime.Parse(dr["start_time"].ToString());
                                }
                                else
                                {
                                    this.dtpStart_Time.Text = "00:00";
                                }
                            }
                            else
                            {
                                this.dtpStart_Time.Text = "00:00";
                            }

                            if (dr.IsNull("end_time") != true)
                            {
                                // 初期値（未入力）判定
                                if (dr["end_time"].ToString().Substring(dr["end_time"].ToString().Length - 8) != " 0:00:00")
                                {
                                    // 入力有りの場合は表示
                                    this.dtpEnd_Time.Value = DateTime.Parse(dr["end_time"].ToString());
                                }
                                else
                                {
                                    this.dtpEnd_Time.Text = "00:00";
                                }
                            }
                            else
                            {
                                this.dtpEnd_Time.Text = "00:00";
                            }

                            // 出発時メーター
                            if (dr.IsNull("start_odo") != true)
                            {
                                this.txtStart_Odo.Text = dr["start_odo"].ToString();
                            }
                            // 到着時メーター
                            if (dr.IsNull("end_odo") != true)
                            {
                                this.txtEnd_Odo.Text = dr["end_odo"].ToString();
                            }
                            // 走行距離
                            if (dr.IsNull("distance") != true)
                            {
                                this.txtDistance.Text = dr["distance"].ToString();
                            }
                            // 給油良
                            if (dr.IsNull("gas_stock") != true)
                            {
                                this.txtGas_Stock.Text = dr["gas_stock"].ToString();
                            }
                            // アルコールチェック
                            if (dr.IsNull("check_alcohol") != true)
                            {
                                if (dr["check_alcohol"].ToString() == "0")
                                {
                                    this.rdoAlcohol_Ok.Checked = true;
                                }
                                else
                                {
                                    this.rdoAlcohol_Ng.Checked = true;
                                }
                            }
                            // 行先(From)
                            this.cmbFron_Point.Text = dr["from_point"].ToString();
                            // 行先(To)
                            this.cmbTo_Point.Text = dr["to_point"].ToString();
                            // 補足
                            this.txtNote.Text = dr["note"].ToString();
                            // 削除
                            if (dr["delete_flag"].ToString() == ClsPublic.FLAG_OFF.ToString())
                            {
                                this.chkDelete_Flag.Checked = false;
                            }
                            else
                            {
                                this.chkDelete_Flag.Checked = true;
                            }
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
        /// 登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            ClsTrnCarRun cls = new();

            // 登録データセット
            cls.Id = Id;
            cls.Car_id = int.Parse(this.cmbCar.SelectedValue.ToString());
            cls.Car_name = this.cmbCar.Text;
            cls.Used_user_id = int.Parse(this.cmbUser.SelectedValue.ToString());
            cls.Used_user_name = this.cmbUser.Text;
            cls.Day = this.dtpDay.Value;

            // 入力チェック
            if (cls.Car_id == 0 || cls.Used_user_id == 0)
            {
                MessageBox.Show("社用車または利用者が選択されていません。", "入力不足", MessageBoxButtons.OK);
                return;
            }

            if (this.dtpStart_Time.Text != "00:00")
            {
                cls.Start_time = this.dtpStart_Time.Value;
            }
            else
            {
                cls.Start_time = DateTime.Parse("1900/01/01");
            }

            if (this.dtpEnd_Time.Text != "00:00")
            {
                cls.End_time = this.dtpEnd_Time.Value;
            }
            else
            {
                cls.End_time = DateTime.Parse("1900/01/01");
            }

            if (this.txtStart_Odo.Text != "")
            {
                cls.Start_odo = int.Parse(this.txtStart_Odo.Text);
            }
            else
            {
                cls.Start_odo = -1;
            }

            if (this.txtEnd_Odo.Text != "")
            {
                cls.End_odo = int.Parse(this.txtEnd_Odo.Text);
            }
            else
            {
                cls.End_odo = -1;
            }

            if (this.txtDistance.Text != "")
            {
                cls.Distance = int.Parse(this.txtDistance.Text);
            }
            else
            {
                cls.Distance = -1;
            }

            cls.Check_alcohol = -1;
            if (this.rdoAlcohol_Ok.Checked == true) { cls.Check_alcohol = 0; }
            else if(this.rdoAlcohol_Ng.Checked == true) { cls.Check_alcohol = 1; }

            if (this.txtGas_Stock.Text != "")
            {
                cls.Gas_stock = decimal.Parse(this.txtGas_Stock.Text);
            }
            else
            {
                cls.Gas_stock = -1;
            }

            cls.From_point = this.cmbFron_Point.Text;
            cls.To_point = this.cmbTo_Point.Text;
            cls.Note = this.txtNote.Text;

            cls.Delete_flag = ClsPublic.FLAG_OFF;
            if (this.chkDelete_Flag.Checked == true) { cls.Delete_flag = ClsPublic.FLAG_ON; }

            // 編集or追加登録
            if (Id > 0) { cls.Update(); }
            else { cls.Insert(); }

            MessageBox.Show("登録しました。", "結果", MessageBoxButtons.OK);
        }
        /// <summary>
        /// ODOメーター値計算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            // テキストボックスから値を取得
            int num1 = 0, num2 = 0;

            // 数値への変換を試行
            bool isValidNum1 = int.TryParse(this.txtStart_Odo.Text, out num1);
            bool isValidNum2 = int.TryParse(this.txtEnd_Odo.Text, out num2);

            if (isValidNum1 && isValidNum2)
            {
                // 合計を計算して表示
                this.txtDistance.Text = (num2 - num1).ToString();
            }
            else
            {
                // 無効な入力がある場合はメッセージを表示
                this.txtDistance.Text = "無効な入力です。";
            }
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
