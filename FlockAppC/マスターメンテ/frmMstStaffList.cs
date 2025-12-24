using FlockAppC.pubClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstStaffList : Form
    {
        public int Group_Id { get; set; }
        public int Office_Id { get; set; }
        public int Employment_Id { get; set; }
        public bool ProxyFlag { get; set; }

        private readonly StringBuilder sb = new();   

        public frmMstStaffList()
        {
            InitializeComponent();
        }

        private void frmMstStaffList_Load(object sender, EventArgs e)
        {
            SetDgvList();

            Group_Id = 0;
            Office_Id = 0;
            Employment_Id = 0;
            ProxyFlag = false;

            this.lblGroup.Text = "";
            this.lblOffice.Text = "";
            this.lblEmployment.Text = "";
            this.chkProxy.Checked = false;
            // 2025/08/13 ADD あいまい検索キー
            this.txtName.Text = "";

            // 2025/08/13 ADD 並べ替え項目指定コンボボックス
            SetSortCombo();

            // 従業員一覧表示
            DisplayStaff();
            this.dgvList.ClearSelection();

            // フォーム表示位置
            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// 並べ替えコンボボックス設定
        /// </summary>
        private void SetSortCombo()
        {
            DataRow dr;
            DataTable dt = new();

            try
            {
                dt.Columns.Add("Code");
                dt.Columns.Add("Name");

                // SET COMBO
                // 最初の空行
                dr = dt.NewRow();
                dr["Code"] = "0";
                dr["Name"] = "";
                dt.Rows.Add(dr);

                // ｶﾅ
                dr = dt.NewRow();
                dr["Code"] = "1";
                dr["Name"] = "ｶﾅ";
                dt.Rows.Add(dr);

                // ID
                dr = dt.NewRow();
                dr["Code"] = "2";
                dr["Name"] = "ID";
                dt.Rows.Add(dr);

                // コンボボックスにデータテーブルセット
                this.cmbSort.DataSource = dt;
                this.cmbSort.DisplayMember = "Name";
                this.cmbSort.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                // エラー
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// DataGridView設定
        /// </summary>
        private void SetDgvList()
        {
            DataGridViewButtonColumn col00 = new DataGridViewButtonColumn();
            DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col04 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col05 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col06 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col07 = new DataGridViewTextBoxColumn();

            col00.Name = "edit";
            col00.HeaderText = " ";
            col00.Text = "表示・編集";
            col00.UseColumnTextForButtonValue = true;
            col00.Visible = true;

            col01.Name = "id";
            col01.HeaderText = "ID";
            col01.Width = 50;
            col01.Visible = true;

            col02.Name = "name";
            col02.HeaderText = "氏名";
            col02.Width = 150;
            col02.Visible = true;

            col03.Name = "kana";
            col03.HeaderText = "ｶﾅ";
            col03.Width = 50;
            col03.Visible = true;

            col04.Name = "office";
            col04.HeaderText = "所属";
            col04.Width = 150;
            col04.Visible = true;

            col05.Name = "group";
            col05.HeaderText = "部門";
            col05.Width = 90;
            col05.Visible = true;

            col06.Name = "proxy";
            col06.HeaderText = "代務";
            col06.Width = 60;
            col06.Visible = true;

            col07.Name = "kbn";
            col07.HeaderText = "形態";
            col07.Width = 120;
            col07.Visible = true;

            this.dgvList.Columns.Add(col00);
            this.dgvList.Columns.Add(col01);
            this.dgvList.Columns.Add(col02);
            this.dgvList.Columns.Add(col03);
            this.dgvList.Columns.Add(col04);
            this.dgvList.Columns.Add(col05);
            this.dgvList.Columns.Add(col06);
            this.dgvList.Columns.Add(col07);

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
            this.dgvList.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvList.Columns["kana"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvList.Columns["office"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["group"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;        // 列ヘッダ文字位置
            this.dgvList.Columns["proxy"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // 列ヘッダ文字位置
            this.dgvList.Columns["kbn"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;           // 列ヘッダ文字位置

            //奇数行を黄色にする
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvList.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvList.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;          //セルの文字表示位置
            this.dgvList.Columns["kana"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;          //セルの文字表示位置
            this.dgvList.Columns["office"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   //セルの文字表示位置
            this.dgvList.Columns["group"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvList.Columns["proxy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;         //セルの文字表示位置
            this.dgvList.Columns["kbn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           //セルの文字表示位置

            this.dgvList.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);          //フォント設定
            this.dgvList.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定
            this.dgvList.Columns["kana"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定
            this.dgvList.Columns["office"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular); //フォント設定
            this.dgvList.Columns["group"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);      //フォント設定
            this.dgvList.Columns["proxy"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["kbn"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);         //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvList.MultiSelect = false;                                                                         //複数選択
            this.dgvList.ReadOnly = true;                                                                             //読込専用
            this.dgvList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }

        private void DisplayStaff()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    // sb.AppendLine(" Mst_社員.id");          2025/12/24 DEL
                    sb.AppendLine(" Mst_社員.staff_id");
                    sb.AppendLine(",Mst_社員.fullname");
                    sb.AppendLine(",Mst_社員.name1");
                    sb.AppendLine(",Mst_社員.name2");
                    sb.AppendLine(",Mst_社員.kana1");
                    sb.AppendLine(",Mst_社員.kana2");
                    sb.AppendLine(",Mst_社員.fullkana");
                    sb.AppendLine(",Mst_社員.proxy_flag");
                    sb.AppendLine(",Mst_社員.confirm_flag");
                    sb.AppendLine(",Mst_社員.confirm_password");
                    sb.AppendLine(",Mst_社員.tanto_sort");
                    sb.AppendLine(",Mst_社員.reg_sort");
                    sb.AppendLine(",Mst_社員.sort");
                    sb.AppendLine(",Mst_社員.comment");
                    sb.AppendLine(",Mst_社員.group_id");
                    sb.AppendLine(",Mst_部門.name AS group_name");
                    sb.AppendLine(",Mst_社員.office_id");
                    sb.AppendLine(",Mst_所属.name AS office_name");
                    sb.AppendLine(",Mst_社員.kbn");
                    sb.AppendLine(",Mst_区分.strval AS kbn_name");
                    sb.AppendLine(",Mst_社員.zai_flag");
                    sb.AppendLine(",Mst_社員.car_manage_flag");
                    sb.AppendLine(",Mst_社員.attendance_flag");
                    sb.AppendLine(",Mst_社員.master_mente_flag");
                    sb.AppendLine(",Mst_社員.system_control_flag");
                    sb.AppendLine(",Mst_社員.task_flag");
                    sb.AppendLine(",Mst_社員.attsubject_flag");
                    sb.AppendLine(",Mst_社員.car_id");
                    sb.AppendLine(",Mst_社用車.car_no");
                    sb.AppendLine(",Mst_社用車.car_name");
                    sb.AppendLine(",Mst_社用車.reg_no");
                    sb.AppendLine(",Mst_社用車.used_user_id");
                    sb.AppendLine(" FROM Mst_社員");
                    sb.AppendLine(" LEFT JOIN Mst_部門");
                    sb.AppendLine(" ON Mst_社員.group_id = Mst_部門.id");
                    sb.AppendLine(" LEFT JOIN Mst_所属");
                    sb.AppendLine(" ON Mst_社員.office_id  = Mst_所属.id");
                    sb.AppendLine(" LEFT JOIN Mst_社用車");
                    sb.AppendLine(" ON Mst_社員.car_id = Mst_社用車.id");
                    sb.AppendLine(" LEFT JOIN Mst_区分");
                    sb.AppendLine(" ON Mst_社員.kbn  = Mst_区分.value");
                    sb.AppendLine(" AND");
                    sb.AppendLine(" Mst_区分.kbn1 = 101");
                    // 表示条件
                    sb.AppendLine("WHERE");

                    // 2025/08/13 退職者指定
                    // 在席／退職
                    if (this.chkZaiFlag.Checked == false)
                    {
                        sb.AppendLine("zai_flag = " + ClsPublic.FLAG_ON);
                    }
                    else
                    {
                        sb.AppendLine("zai_flag <> " + ClsPublic.FLAG_ON);
                    }

                    // 所属
                    if (Office_Id > 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Mst_社員.office_id = " + Office_Id);
                    }

                    // 部門
                    if (Group_Id > 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Mst_社員.group_id = " + Group_Id);
                    }

                    // 雇用形態
                    if (Employment_Id > 0)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Mst_社員.kbn = " + Employment_Id);
                    }

                    // 代務
                    if (ProxyFlag == true)
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Mst_社員.proxy_flag = " + ClsPublic.FLAG_ON);
                    }

                    // 名前（あいまい）
                    // null・空文字・空白文字（半角スペース・全角スペース・タブなど）をまとめて「空」と判定
                    if (!string.IsNullOrWhiteSpace(this.txtName.Text))
                    {
                        sb.AppendLine("AND");
                        sb.AppendLine("Mst_社員.fullname Like '%" + this.txtName.Text + "'");
                    }
                    // ↑↑↑ null または "" をまとめて判定の場合は
                    // string.IsNullOrEmpty(txtName.Text) を使用

                    sb.AppendLine(" ORDER BY");

                    // 並べ替え
                    switch(this.cmbSort.SelectedIndex)
                    {
                        case 0:
                            sb.AppendLine(" Mst_社員.group_id ASC");
                            break;
                        case 1:
                            sb.AppendLine(" Mst_社員.kana2 ASC");
                            break;
                        case 2:
                            // sb.AppendLine(" Mst_社員.id ASC");         2025/12/24 UPD
                            sb.AppendLine(" Mst_社員.staff_id ASC");
                            break;
                    }

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count == 0)
                        {
                            MessageBox.Show("0件です。", "結果", MessageBoxButtons.OK);
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
                            this.dgvList.Rows[i].Cells["id"].Value = dr["staff_id"].ToString();
                            this.dgvList.Rows[i].Cells["name"].Value = dr["fullname"].ToString();
                            this.dgvList.Rows[i].Cells["kana"].Value = dr["kana1"].ToString();
                            this.dgvList.Rows[i].Cells["office"].Value = dr["office_name"].ToString();
                            this.dgvList.Rows[i].Cells["group"].Value = dr["group_name"].ToString();
                            if (int.Parse(dr["proxy_flag"].ToString()) == 1) { this.dgvList.Rows[i].Cells["proxy"].Value = "〇"; }
                            this.dgvList.Rows[i].Cells["kbn"].Value = dr["kbn_name"].ToString();
                            i++;
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
        /// 所属ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectOffice_Click(object sender, EventArgs e)
        {
            選択画面.frmSelectItem fSelectItem = new()
            {
                Kbn = 2,                  // 
                Value = 0
            };
            fSelectItem.ShowDialog();
            if (fSelectItem.Value == 0) { return; }

            // 所属情報表示
            this.Office_Id = fSelectItem.Value;
            this.lblOffice.Text = fSelectItem.StrVal;
        }
        /// <summary>
        /// 部門ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectGroup_Click(object sender, EventArgs e)
        {
            選択画面.frmSelectItem fSelectItem = new()
            {
                Kbn = 3,                  // 
                Value = 0
            };
            fSelectItem.ShowDialog();
            if (fSelectItem.Value == 0) { return; }

            // 部門情報表示
            this.Group_Id = fSelectItem.Value;
            this.lblGroup.Text = fSelectItem.StrVal;
        }
        /// <summary>
        /// 雇用形態ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectEmployment_Click(object sender, EventArgs e)
        {
            選択画面.frmSelectItem fSelectItem = new()
            {
                Kbn = 1,                  // 雇用形態
                Value = 0
            };
            fSelectItem.ShowDialog();
            if (fSelectItem.Value == 0) { return; }

            // 雇用形態情報表示
            this.Employment_Id = fSelectItem.Value;
            this.lblEmployment.Text = fSelectItem.StrVal;

        }
        /// <summary>
        /// 表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DisplayStaff();
        }
        /// <summary>
        /// 代務チェックボックス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkProxy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkProxy.Checked == true) { ProxyFlag = true; }
            else { ProxyFlag = false; }
        }
        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Group_Id = 0;
            Office_Id = 0;
            Employment_Id = 0;
            ProxyFlag = false;

            this.lblGroup.Text = "";
            this.lblOffice.Text = "";
            this.lblEmployment.Text = "";
            this.chkProxy.Checked = false;

            // 2025/08/13 ADD
            this.txtName.Text = "";
            this.chkZaiFlag.Checked = false;
            this.cmbSort.SelectedIndex = 0;
        }
        /// <summary>
        /// セルクリック（ボタン用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ボタン列がクリックされたかを確認
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // 0 はボタン列のインデックス
            {
                // ID取得
                var id = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString());
                // MessageBox.Show($"{name} のボタンがクリックされました！");

                // 表示
                frmMstStaff fMstStaff = new()
                {
                    List_Staff_Id = id
                };
                fMstStaff.Show();
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
        /// shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMstStaffList_Shown(object sender, EventArgs e)
        {
            this.dgvList.ClearSelection();
        }
    }
}
