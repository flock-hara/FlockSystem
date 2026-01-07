using DocumentFormat.OpenXml.Wordprocessing;
using FlockAppC.pubClass;
using FlockAppC.tblClass;
using FlockAppC.選択画面;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstLocationCar : Form
    {
        public int Id { get; set; }
        public int Location_id { get; set; }

        private readonly StringBuilder sb = new();

        public frmMstLocationCar()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMstLocationCar_Load(object sender, EventArgs e)
        {
            // Initialize DataGridView
            SetDgvList();
            InitializeForm(true);

            // 専従先マスタメンテからの遷移の場合、車両を表示
            if (Location_id != 0)
            {
                SetHeader();
                DisplayList();
            }

            // フォーム表示位置
            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// ヘッダー情報表示
        /// </summary>
        private void SetHeader()
        {
            ClsMstLocation cls = new()
            {
                Location_Id = Location_id
            };
            cls.SelectName();                                               // 専従先名称、締日、基本契約走行距離　取得
            this.lblLocation.Text = cls.Name;                               // 専従先名称
            if (cls.ClosingDate == 31) { this.lblClosingDate.Text = "末"; } // 締日
            else if (cls.ClosingDate != -1) { this.lblClosingDate.Text = cls.ClosingDate.ToString(); }
            else { this.lblClosingDate.Text = "未設定"; }
            if (cls.ConstractFlag == 1) { this.lblContract.Visible = true; } // 基本契約走行距離
            else { this.lblContract.Visible = false; }

            // 基本契約走行距離有無により入力を制御
            if (cls.ConstractFlag == 1)
            {
                // 有り
                this.txtUnitPrice.Enabled = false;
                this.txtFuelCost.Enabled = true;
                this.txtContractKm.Enabled = true;
                this.txtBurdenFee.Enabled = true;
            }
            else
            {
                // 無し
                this.txtUnitPrice.Enabled = true;
                this.txtFuelCost.Enabled = false;
                this.txtContractKm.Enabled = false;
                this.txtBurdenFee.Enabled = false;
            }
        }

        /// <summary>
        /// DataGridView設定
        /// </summary>
        private void SetDgvList()
        {
            DataGridViewTextBoxColumn col01 = new()
            {
                Name = "id",
                HeaderText = "ID",
                Width = 1,
                Visible = false
            };
            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "no",
                HeaderText = "車両番号",
                Width = 80,
                Visible = true
            };
            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "fullname",
                HeaderText = "車両識別",
                Width = 180,
                Visible = true
            };
            DataGridViewTextBoxColumn col04 = new()
            {
                Name = "name",
                HeaderText = "号車",
                Width = 140,
                Visible = true
            };
            DataGridViewTextBoxColumn col05 = new()
            {
                Name = "car_name",
                HeaderText = "車種",
                Width = 200,
                Visible = true
            };
            DataGridViewTextBoxColumn col06 = new()
            {
                Name = "unit_price",
                HeaderText = "㎞単価",
                Width = 90,
                Visible = true
            };
            DataGridViewTextBoxColumn col07 = new()
            {
                Name = "fuel_cost",
                HeaderText = "積載燃料費",
                Width = 105,
                Visible = true
            };
            DataGridViewTextBoxColumn col08 = new()
            {
                Name = "contract_km",
                HeaderText = "契約走行粁",
                Width = 105,
                Visible = true
            };
            DataGridViewTextBoxColumn col09 = new()
            {
                Name = "burden_fee",
                HeaderText = "超過走行請負料",
                Width = 110,
                Visible = true
            };
            DataGridViewTextBoxColumn col10 = new()
            {
                Name = "kbn",
                HeaderText = "ﾌﾛｯｸ車",
                Width = 60,
                Visible = true
            };
            // 2026/1/7 ADD 車両識別
            DataGridViewTextBoxColumn col11 = new()
            {
                Name = "identification",
                HeaderText = "識別",
                Width = 1,
                Visible = false
            };

            //DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col04 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col05 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col06 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col07 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col08 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col09 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col10 = new DataGridViewTextBoxColumn();
            //col01.Name = "id";
            //col01.HeaderText = "ID";
            //col01.Width = 1;
            //col01.Visible = false;
            //col02.Name = "no";
            //col02.HeaderText = "車両番号";
            //col02.Width = 80;
            //col02.Visible = true;
            //col03.Name = "fullname";
            //col03.HeaderText = "車両識別";
            //col03.Width = 180;
            //col03.Visible = true;
            //col04.Name = "name";
            //col04.HeaderText = "号車";
            //col04.Width = 140;
            //col04.Visible = true;
            //col05.Name = "car_name";
            //col05.HeaderText = "車種";
            //col05.Width = 200;
            //col05.Visible = true;
            //col06.Name = "unit_price";
            //col06.HeaderText = "㎞単価";
            //col06.Width = 90;
            //col06.Visible = true;
            //col07.Name = "fuel_cost";
            //col07.HeaderText = "積載燃料費";
            //col07.Width = 105;
            //col07.Visible = true;
            //col08.Name = "contract_km";
            //col08.HeaderText = "契約走行粁";
            //col08.Width = 105;
            //col08.Visible = true;
            //col09.Name = "burden_fee";
            //col09.HeaderText = "超過走行請負料";
            //col09.Width = 110;
            //col09.Visible = true;
            //col10.Name = "kbn";
            //col10.HeaderText = "ﾌﾛｯｸ車";
            //col10.Width = 60;
            //col10.Visible = true;

            this.dgvList.Columns.Add(col01);
            this.dgvList.Columns.Add(col02);
            this.dgvList.Columns.Add(col03);
            this.dgvList.Columns.Add(col04);
            this.dgvList.Columns.Add(col05);
            this.dgvList.Columns.Add(col06);
            this.dgvList.Columns.Add(col07);
            this.dgvList.Columns.Add(col08);
            this.dgvList.Columns.Add(col09);
            this.dgvList.Columns.Add(col10);
            // 2026/1/7 ADD
            this.dgvList.Columns.Add(col11);

            //===========================================================================================
            // 列ヘッダー
            //===========================================================================================
            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvList.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            this.dgvList.RowTemplate.Height = 25;                                                                         //行高さ
            this.dgvList.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvList.AllowUserToResizeRows = false;                                                                   //行高さの変更不可
            this.dgvList.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示
            this.dgvList.Columns["id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;            // 列ヘッダ文字位置
            this.dgvList.Columns["no"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;            // 列ヘッダ文字位置
            this.dgvList.Columns["fullname"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 列ヘッダ文字位置
            this.dgvList.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvList.Columns["car_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 列ヘッダ文字位置
            this.dgvList.Columns["unit_price"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 列ヘッダ文字位置
            this.dgvList.Columns["fuel_cost"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 列ヘッダ文字位置
            this.dgvList.Columns["contract_km"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["burden_fee"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 列ヘッダ文字位置
            this.dgvList.Columns["kbn"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;           // 列ヘッダ文字位置

            //===========================================================================================
            // 列
            //===========================================================================================
            this.dgvList.Columns["no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["fullname"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["unit_price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvList.Columns["fuel_cost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvList.Columns["contract_km"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvList.Columns["burden_fee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvList.Columns["kbn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvList.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);         //フォント設定
            this.dgvList.Columns["no"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);         //フォント設定
            this.dgvList.Columns["fullname"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);   //フォント設定
            this.dgvList.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["car_name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);   //フォント設定
            this.dgvList.Columns["unit_price"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular); //フォント設定
            this.dgvList.Columns["fuel_cost"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);  //フォント設定
            this.dgvList.Columns["contract_km"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);//フォント設定
            this.dgvList.Columns["burden_fee"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular); //フォント設定
            this.dgvList.Columns["kbn"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定

            //===========================================================================================
            // 行
            //===========================================================================================
            //奇数行を黄色にする
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvList.MultiSelect = false;                                                                         //複数選択
            this.dgvList.ReadOnly = true;                                                                             //読込専用
            this.dgvList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// Initialize Form
        /// </summary>
        private void InitializeForm(bool flg)
        {
            Id = 0;

            this.lblLocation.Text = "";
            this.txtNo.Text = "";
            this.txtFullName.Text = "";
            this.txtName.Text = "";
            this.txtCarName.Text = "";
            this.txtUnitPrice.Text = "";
            this.txtFuelCost.Text = "";
            this.txtContractKm.Text = "";
            this.txtBurdenFee.Text = "";
            this.chkKbn.Checked = false;        // 2024/12/17 ADD
            this.lblNew.Visible = flg;
            this.rdoKbn1.Checked = false;       // 2026/1/7 ADD
            this.rdoKbn2.Checked = false;       // 2026/1/7 ADD
        }
        /// <summary>
        /// 専従先選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation_Click(object sender, EventArgs e)
        {
            frmSelectLocation fSelectLocation = new()
            {
                TargetTable = "Mst_専従先",
                Select_location_name = "",
                Select_location_id = 0
            };
            fSelectLocation.ShowDialog();
            InitializeForm(true);
            this.dgvList.Rows.Clear();
            this.Location_id = fSelectLocation.Select_location_id;
            this.lblLocation.Text = fSelectLocation.Select_location_name.ToString();

            SetHeader();
            DisplayList();
        }
        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearLocation_Click(object sender, EventArgs e)
        {
            this.Id = 0;
            this.Location_id = 0;
            this.txtNo.Text = "";
            this.txtFullName.Text = "";
            this.txtName.Text = "";
            this.txtCarName.Text = "";
            this.txtUnitPrice.Text = "";
            this.txtFuelCost.Text = "";
            this.txtContractKm.Text = "";
            this.txtBurdenFee.Text = "";
            this.lblLocation.Text = "";
            this.chkKbn.Checked = false;             // 2024/12/17 ADD
            this.lblNew.Visible = true;
            this.rdoKbn1.Checked = false;           // 2026/1/7 ADD
            this.rdoKbn2.Checked = false;           // 2026/1/7 ADD
            this.dgvList.Rows.Clear();
        }
        /// <summary>
        /// 表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (this.Location_id == 0) return;

            DisplayList();
            this.dgvList.ClearSelection();
        }
        /// <summary>
        /// 専従先車両表示
        /// </summary>
        private void DisplayList()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_専従先車両.id");
                    sb.AppendLine(",Mst_専従先車両.no");
                    sb.AppendLine(",Mst_専従先車両.fullname");
                    sb.AppendLine(",Mst_専従先車両.name");
                    sb.AppendLine(",Mst_専従先車両.car_name");
                    sb.AppendLine(",Mst_専従先車両.location_id");
                    sb.AppendLine(",Mst_専従先車両.kbn");                        // 2024/12/17 ADD   車両区分
                    sb.AppendLine(",Mst_専従先車両.identification");          // 2025/1/7 ADD      車両識別 
                    sb.AppendLine(",Mst_専従先車両走行契約情報.unit_price");
                    sb.AppendLine(",Mst_専従先車両走行契約情報.fuel_cost");
                    sb.AppendLine(",Mst_専従先車両走行契約情報.contract_km");
                    sb.AppendLine(",Mst_専従先車両走行契約情報.burden_fee");
                    sb.AppendLine(" FROM");
                    sb.AppendLine(" Mst_専従先車両");
                    sb.AppendLine(" LEFT JOIN");
                    sb.AppendLine(" Mst_専従先車両走行契約情報");
                    sb.AppendLine(" ON");
                    sb.AppendLine(" Mst_専従先車両.location_id = Mst_専従先車両走行契約情報.location_id");
                    sb.AppendLine(" AND");
                    sb.AppendLine(" Mst_専従先車両.id = Mst_専従先車両走行契約情報.location_car_id");
                    sb.AppendLine(" WHERE");
                    sb.AppendLine(" Mst_専従先車両.location_id = " + this.Location_id);
                    sb.AppendLine(" AND");
                    sb.AppendLine(" Mst_専従先車両.delete_flag = " + ClsPublic.FLAG_OFF);
                    sb.AppendLine(" ORDER BY");
                    sb.AppendLine(" Mst_専従先車両.fullname");
                    sb.AppendLine(",Mst_専従先車両.no");
                    sb.AppendLine(" ASC");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count == 0)
                        {
                            // MessageBox.Show("0件です。", "結果", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            this.dgvList.Rows.Clear();
                        }

                        var i = 0;
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[i].Cells["id"].Value = dr["id"].ToString();
                            this.dgvList.Rows[i].Cells["no"].Value = dr["no"].ToString();
                            this.dgvList.Rows[i].Cells["fullname"].Value = dr["fullname"].ToString();
                            this.dgvList.Rows[i].Cells["name"].Value = dr["name"].ToString();
                            this.dgvList.Rows[i].Cells["car_name"].Value = dr["car_name"].ToString();
                            if (dr["unit_price"].ToString() != "0") { this.dgvList.Rows[i].Cells["unit_price"].Value = dr["unit_price"].ToString(); }
                            else { this.dgvList.Rows[i].Cells["unit_price"].Value = ""; }
                            if (dr["fuel_cost"].ToString() != "0") { this.dgvList.Rows[i].Cells["fuel_cost"].Value = dr["fuel_cost"].ToString(); }
                            else { this.dgvList.Rows[i].Cells["fuel_cost"].Value = ""; }
                            if (dr["contract_km"].ToString() != "0") { this.dgvList.Rows[i].Cells["contract_km"].Value = dr["contract_km"].ToString(); }
                            else { this.dgvList.Rows[i].Cells["contract_km"].Value = ""; }
                            if (dr["burden_fee"].ToString() != "0") { this.dgvList.Rows[i].Cells["burden_fee"].Value = dr["burden_fee"].ToString(); }
                            else { this.dgvList.Rows[i].Cells["burden_fee"].Value = ""; }
                            // 2024/12/17 ADD (S)
                            if (dr["kbn"].ToString() == ClsPublic.FLAG_ON.ToString()) { this.dgvList.Rows[i].Cells["kbn"].Value = "〇"; }
                            else { this.dgvList.Rows[i].Cells["kbn"].Value = ""; }
                            // 2024/12/17 ADD (E)
                            // 2026/1/7 ADD (S)
                            if (dr.IsNull("identification") != true) { this.dgvList.Rows[i].Cells["identification"].Value = dr["identification"].ToString(); }
                            else { this.dgvList.Rows[i].Cells["identification"].Value = ""; }
                            // 2026/1/7 ADD (E)

                            i++;
                        }
                    }
                }
                this.dgvList.ClearSelection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// DataGridView セルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            this.txtNo.Text = "";
            this.txtFullName.Text = "";
            this.txtName.Text = "";
            this.txtCarName.Text = "";
            this.chkKbn.Checked = false;                // 2024/12/17 ADD
            this.lblNew.Visible = false;
            // 新規ラベルを非表示→更新モードに

            //クリックされたセルのClassificationID取得
            Id = int.Parse(this.dgvList.Rows[e.RowIndex].Cells[0].Value.ToString());

            // 画面表示：車両
            this.txtNo.Text = this.dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.txtFullName.Text = this.dgvList.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.txtName.Text = this.dgvList.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.txtCarName.Text = this.dgvList.Rows[e.RowIndex].Cells[4].Value.ToString();
            // 2024/12/17 ADD
            if (this.dgvList.Rows[e.RowIndex].Cells["kbn"].Value != null)
            {
                if (this.dgvList.Rows[e.RowIndex].Cells["kbn"].Value.ToString() == "〇") { this.chkKbn.Checked = true; }
            }
            // 2026/1/7 ADD (S)
            if (this.dgvList.Rows[e.RowIndex].Cells["identification"].Value != null)
            {
                string iden = this.dgvList.Rows[e.RowIndex].Cells["identification"].Value.ToString();
                if (iden == "1") { this.rdoKbn1.Checked = true; }               // 透析
                else if (iden == "2") { this.rdoKbn2.Checked = true; }        // バス・デイ・配送  
            }
            // 2026/1/7 ADD (E)


            // 画面表示：契約
            this.txtUnitPrice.Text = this.dgvList.Rows[e.RowIndex].Cells[5].Value.ToString();
            this.txtFuelCost.Text = this.dgvList.Rows[e.RowIndex].Cells[6].Value.ToString();
            this.txtContractKm.Text = this.dgvList.Rows[e.RowIndex].Cells[7].Value.ToString();
            this.txtBurdenFee.Text = this.dgvList.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        /// <summary>
        /// 新規ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.Id = 0;
            this.txtNo.Text = "";
            this.txtFullName.Text = "";
            this.txtName.Text = "";
            this.txtCarName.Text = "";
            this.txtUnitPrice.Text = "";
            this.txtFuelCost.Text = "";
            this.txtContractKm.Text = "";
            this.txtBurdenFee.Text = "";
            this.chkKbn.Checked = false;         // 2024/12/17 ADD
            this.rdoKbn1.Checked = false;       // 2026/1/7 ADD
            this.rdoKbn2.Checked = false;       // 2026/1/7 ADD
            this.lblNew.Visible = true;
            this.txtNo.Focus();
        }
        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.Id == 0)
            {
                MessageBox.Show("選択してください。", "結果", MessageBoxButtons.OK);
                return;
            }

            ClsMstLocationCar cMstLocationCar = new()
            {
                Id = this.Id
            };
            cMstLocationCar.Delete();

            this.Id = 0;
            this.txtNo.Text = "";
            this.txtFullName.Text = "";
            this.txtName.Text = "";
            this.txtCarName.Text = "";
            this.chkKbn.Checked = false;        // 2024/12/17 ADD
            this.rdoKbn1.Checked = false;       // 2026/1/7 ADD
            this.rdoKbn2.Checked = false;       // 2026/1/7 ADD
            this.lblNew.Visible = true;
            this.txtNo.Focus();
            DisplayList();

            MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);

        }
        /// <summary>
        /// 保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // int new_id = -1;
            // 接続中メッセージ
            this.lblConnect.Visible = false;

            ClsMstLocationCarContract cls2 = new();
            ClsMstLocationCar cls = new()
            {
                No = this.txtNo.Text,
                FullName = this.txtFullName.Text,
                Name = this.txtName.Text,
                CarName = this.txtCarName.Text,
                Location_Id = this.Location_id,
            };

            // 2024/12/17 ADD
            if (this.chkKbn.Checked == false) { cls.Kbn = 0; }
            else { cls.Kbn = 1; }

            // 2026/1/7 ADD (S)
            if (this.rdoKbn1.Checked == true) { cls.Identification = 1; }            // 透析
            else if (this.rdoKbn2.Checked == true) { cls.Identification = 2; }     // バス・デイ・配送
            else { cls.Identification = 0; }
            // 2026/1/7 ADD (E)

            if (this.Id == 0)
            {
                if (this.Location_id == 0 || this.txtNo.Text == "")
                {
                    MessageBox.Show("未入力項目があります。", "結果", MessageBoxButtons.OK);
                    return;
                }
                // 新規 (INSERT)
                // this.Id = cls.Insert();        // INSERT時の新規ID取得
                this.Id = cls.InsertScalar();     // INSERT時の新規ID取得

                // 契約情報登録
                cls2.Location_id = this.Location_id;
                cls2.Car_id = this.Id;
                if (int.TryParse(this.txtUnitPrice.Text,out _) == true) { cls2.Unit_price = int.Parse(this.txtUnitPrice.Text); }
                else { cls2.Unit_price = 0; }
                if (int.TryParse(this.txtFuelCost.Text,out _) == true) { cls2.Fuel_cost = int.Parse(this.txtFuelCost.Text); }
                else { cls2.Fuel_cost = 0; }
                if (int.TryParse(this.txtContractKm.Text, out _) == true) { cls2.Contract_km = int.Parse(this.txtContractKm.Text); }
                else { cls2.Contract_km = 0; }
                if (int.TryParse(this.txtBurdenFee.Text, out _) == true) { cls2.Burden_fee = int.Parse(this.txtBurdenFee.Text); }
                else { cls2.Burden_fee = 0; }
                // cls2.Insert();
                _ = cls2.InsertScalar();    // 戻り値は不要
            }
            else
            {
                // 更新 (UPDATE)
                cls.Id = this.Id;
                cls.Update();

                // 契約情報更新
                cls2.Location_id = this.Location_id;
                cls2.Car_id = this.Id;
                if (int.TryParse(this.txtUnitPrice.Text, out _) == true) { cls2.Unit_price = int.Parse(this.txtUnitPrice.Text); }
                else { cls2.Unit_price = 0; }
                if (int.TryParse(this.txtFuelCost.Text, out _) == true) { cls2.Fuel_cost = int.Parse(this.txtFuelCost.Text); }
                else { cls2.Fuel_cost = 0; }
                if (int.TryParse(this.txtContractKm.Text, out _) == true) { cls2.Contract_km = int.Parse(this.txtContractKm.Text); }
                else { cls2.Contract_km = 0; }
                if (int.TryParse(this.txtBurdenFee.Text, out _) == true) { cls2.Burden_fee = int.Parse(this.txtBurdenFee.Text); }
                else { cls2.Burden_fee = 0; }
                cls2.Update();
            }

            // 転送確認
            if (MessageBox.Show("登録しました。続けてサーバーに転送（同期）しますか？" + Environment.NewLine + "転送先 [" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Instance + "\\" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Database + "]", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                this.Id = 0;
                this.txtNo.Text = "";
                this.txtFullName.Text = "";
                this.txtName.Text = "";
                this.txtCarName.Text = "";
                this.txtUnitPrice.Text = "";
                this.txtFuelCost.Text = "";
                this.txtContractKm.Text = "";
                this.txtBurdenFee.Text = "";
                this.chkKbn.Checked = false;            // 2024/12/17 ADD
                this.rdoKbn1.Checked = false;          // 2026/1/7 ADD
                this.rdoKbn2.Checked = false;          // 2026/1/7 ADD
                this.lblNew.Visible = true;
                this.txtNo.Focus();
                DisplayList();
                return;
            }

            // 転送処理
            try
            {
                // 接続メッセージ
                this.lblConnect.Visible = true;

                // 転送（同期）処理
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // Mst_専従先車両クラス
                    ClsMstLocationCar clsMstLocationCar = new();
                    // 専従先車両登録
                    clsMstLocationCar.ExportLocationOneCarData(Id, clsSqlDb, clsMySqlDb);

                    // 契約情報 (location_id, car_idで特定 -> DELETE,INSERT）
                    ClsMstLocationCarContract clsMstLocationCarContract = new();
                    // 契約情報登録
                    clsMstLocationCarContract.ExportLocationOneCarContractData(this.Location_id, this.Id, clsSqlDb, clsMySqlDb);
                }
                this.Id = 0;
                this.txtNo.Text = "";
                this.txtFullName.Text = "";
                this.txtName.Text = "";
                this.txtCarName.Text = "";
                this.txtUnitPrice.Text = "";
                this.txtFuelCost.Text = "";
                this.txtContractKm.Text = "";
                this.txtBurdenFee.Text = "";
                this.chkKbn.Checked = false;            // 2024/12/17 ADD
                this.rdoKbn1.Checked = false;          // 2026/1/7 ADD
                this.rdoKbn2.Checked = false;          // 2026/1/7 ADD
                this.lblNew.Visible = true;
                this.txtNo.Focus();
                DisplayList();
                MessageBox.Show("転送しました。", "結果", MessageBoxButtons.OK);
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
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 種別のフォーカスが外れた時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFullName_Leave(object sender, EventArgs e)
        {
            if (this.txtFullName.Text == "") return;

            if (this.txtName.Text == "")
            {
                this.txtName.Text = this.txtFullName.Text;
            }

        }
        /// <summary>
        /// フォーム表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMstLocationCar_Shown(object sender, EventArgs e)
        {
            this.dgvList.ClearSelection();
        }
    }
}
