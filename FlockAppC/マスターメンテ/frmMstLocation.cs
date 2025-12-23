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
    public partial class frmMstLocation : Form
    {
        public int Id { get; set; }
        public int Instructor_ID { get; set; }

        private readonly StringBuilder sb = new();

        public frmMstLocation()
        {
            InitializeComponent();
        }

        private void frmMstLocation_Load(object sender, EventArgs e)
        {
            // Initialize DataGridView
            SetDgvList();
            InitializeForm(true);
            DisplayLocation();

            // フォーム表示位置
            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// Initialize Form
        /// </summary>
        private void InitializeForm(bool flg)
        {
            Id = 0;

            this.txtName.Text = "";
            this.txtRyakuName.Text = "";
            this.txtKana1.Text = "";
            this.txtStaffName1.Text = "";
            this.txtSort.Text = "";
            this.txtComment.Text = "";
            this.txtTelNo.Text = "";
            this.txtFaxNo.Text = "";
            this.txtMailAddress.Text = "";
            this.txtEmergency_TelNo.Text = "";
            this.txtEmergency_Memo.Text = "";
            this.txtClosingDate.Text = "";
            this.chkContract.Checked = false;
            this.lblNew.Visible = flg;

            // 2025/11/18
            this.Instructor_ID = 0;

            // 並び順表示
            DisplaySortMax();
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
                Width = 50,
                Visible = true
            };
            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "name",
                HeaderText = "名称",
                Width = 300,
                Visible = true
            };
            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "ryaku",
                HeaderText = "略称",
                Width = 180,
                Visible = true
            };
            DataGridViewTextBoxColumn col04 = new()
            {
                Name = "kana",
                HeaderText = "ｶﾅ",
                Width = 50,
                Visible = true
            };
            DataGridViewTextBoxColumn col05 = new()
            {
                Name = "managerid",
                HeaderText = "責任者ID",
                Width = 90,
                Visible = false
            };
            DataGridViewTextBoxColumn col06 = new()
            {
                Name = "manager",
                HeaderText = "責任者名",
                Width = 100,
                Visible = true
            };
            DataGridViewTextBoxColumn col07 = new()
            {
                Name = "sort",
                HeaderText = "並び",
                Width = 50,
                Visible = true
            };
            DataGridViewTextBoxColumn col08 = new()
            {
                Name = "comment",
                HeaderText = "備考",
                Width = 150,
                Visible = true
            };
            DataGridViewTextBoxColumn col09 = new()
            {
                Name = "location_id",
                HeaderText = "専従先ID",
                Width = 50,
                Visible = false
            };
            DataGridViewTextBoxColumn col12 = new()
            {
                Name = "tel_no",
                HeaderText = "",
                Width = 1,
                Visible = false
            };
            DataGridViewTextBoxColumn col13 = new()
            {
                Name = "fax_no",
                HeaderText = "",
                Width = 1,
                Visible = false
            };
            DataGridViewTextBoxColumn col14 = new()
            {
                Name = "mailaddress",
                HeaderText = "",
                Width = 1,
                Visible = false
            };
            DataGridViewTextBoxColumn col15 = new()
            {
                Name = "emergency_tel_no",
                HeaderText = "",
                Width = 1,
                Visible = false
            };
            DataGridViewTextBoxColumn col16 = new()
            {
                Name = "emergency_memo",
                HeaderText = "",
                Width = 1,
                Visible = false,
            };
            DataGridViewTextBoxColumn col17 = new()
            {
                Name = "closing_date",
                HeaderText = "締日",
                Width = 50,
                Visible = true
            };
            DataGridViewTextBoxColumn col18 = new()
            {
                Name = "constract_flag",
                HeaderText = "契走",
                Width = 50,
                Visible = true
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
            //// 2025/06/24 DEL
            //// DataGridViewTextBoxColumn col10 = new DataGridViewTextBoxColumn();
            //// DataGridViewTextBoxColumn col11 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col12 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col13 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col14 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col15 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col16 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col17 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col18 = new DataGridViewTextBoxColumn();
            //col01.Name = "id";
            //col01.HeaderText = "ID";
            //col01.Width = 50;
            //col01.Visible = true;
            //col02.Name = "name";
            //col02.HeaderText = "名称";
            //col02.Width = 300;
            //col02.Visible = true;
            //col03.Name = "ryaku";
            //col03.HeaderText = "略称";
            //col03.Width = 180;
            //col03.Visible = true;
            //col04.Name = "kana";
            //col04.HeaderText = "ｶﾅ";
            //col04.Width = 50;
            //col04.Visible = true;
            //col05.Name = "managerid";
            //col05.HeaderText = "責任者ID";
            //col05.Width = 90;
            //col05.Visible = false;
            //col06.Name = "manager";
            //col06.HeaderText = "責任者名";
            //col06.Width = 100;
            //col06.Visible = true;
            //col07.Name = "sort";
            //col07.HeaderText = "並び";
            //col07.Width = 50;
            //col07.Visible = true;
            //col08.Name = "comment";
            //col08.HeaderText = "備考";
            //col08.Width = 150;
            //col08.Visible = true;
            //col09.Name = "location_id";
            //col09.HeaderText = "専従先ID";
            //col09.Width = 50;
            //col09.Visible = false;
            //// 2025/06/24 DEL
            //// col10.Name = "user_name1";
            //// col10.HeaderText = "";
            //// col10.Width = 1;
            //// col10.Visible = false;
            //// 2025/06/24 DEL
            //// col11.Name = "user_name2";
            //// col11.HeaderText = "";
            //// col11.Width = 1;
            //// col11.Visible = false;
            //col12.Name = "tel_no";
            //col12.HeaderText = "";
            //col12.Width = 1;
            //col12.Visible = false;
            //col13.Name = "fax_no";
            //col13.HeaderText = "";
            //col13.Width = 1;
            //col13.Visible = false;
            //col14.Name = "mailaddress";
            //col14.HeaderText = "";
            //col14.Width = 1;
            //col14.Visible = false;
            //col15.Name = "emergency_tel_no";
            //col15.HeaderText = "";
            //col15.Width = 1;
            //col15.Visible = false;
            //col16.Name = "emergency_memo";
            //col16.HeaderText = "";
            //col16.Width = 1;
            //col16.Visible = false;
            //col17.Name = "closing_date";
            //col17.HeaderText = "締日";
            //col17.Width = 50;
            //col17.Visible = true;
            //col18.Name = "constract_flag";
            //col18.HeaderText = "契走";
            //col18.Width = 50;
            //col18.Visible = true;

            // this.dgvList.Columns.Add(col00);
            this.dgvList.Columns.Add(col01);
            this.dgvList.Columns.Add(col02);
            this.dgvList.Columns.Add(col03);
            this.dgvList.Columns.Add(col04);
            this.dgvList.Columns.Add(col05);
            this.dgvList.Columns.Add(col06);
            this.dgvList.Columns.Add(col17);        // 締日
            this.dgvList.Columns.Add(col18);        // 契約走行有無
            this.dgvList.Columns.Add(col07);
            this.dgvList.Columns.Add(col08);
            this.dgvList.Columns.Add(col09);
            // 2025/06/24 DEL
            // this.dgvList.Columns.Add(col10);
            // this.dgvList.Columns.Add(col11);
            this.dgvList.Columns.Add(col12);
            this.dgvList.Columns.Add(col13);
            this.dgvList.Columns.Add(col14);
            this.dgvList.Columns.Add(col15);
            this.dgvList.Columns.Add(col16);

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
            this.dgvList.Columns["ryaku"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;         // 列ヘッダ文字位置
            this.dgvList.Columns["kana"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvList.Columns["managerid"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;     // 列ヘッダ文字位置
            this.dgvList.Columns["manager"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置
            this.dgvList.Columns["sort"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvList.Columns["closing_date"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 列ヘッダ文字位置
            this.dgvList.Columns["constract_flag"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // 列ヘッダ文字位置
            this.dgvList.Columns["comment"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置

            //奇数行を黄色にする
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            // 文字位置
            this.dgvList.Columns["closing_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["constract_flag"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["sort"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // フォント設定
            this.dgvList.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);           //フォント設定
            this.dgvList.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);         //フォント設定
            this.dgvList.Columns["ryaku"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定
            this.dgvList.Columns["kana"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);         //フォント設定
            this.dgvList.Columns["managerid"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);    //フォント設定
            this.dgvList.Columns["manager"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);      //フォント設定
            this.dgvList.Columns["sort"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);         //フォント設定
            this.dgvList.Columns["closing_date"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular); //フォント設定
            this.dgvList.Columns["constract_flag"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);//フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvList.MultiSelect = false;                                                                         //複数選択
            this.dgvList.ReadOnly = true;                                                                             //読込専用
            this.dgvList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする

            // 担当者一覧
            DataGridViewButtonColumn colU01 = new()                       // 追加･変更ボタン
            {
                Name = "edit",
                HeaderText = " ",
                Text = "編集",
                UseColumnTextForButtonValue = true,
                Width = 70,
                Visible = true
            };
            DataGridViewTextBoxColumn colU02 = new()                     // 担当者ID
            {
                Name = "id",
                HeaderText = "ID",
                Width = 50,
                Visible = false
            };
            DataGridViewTextBoxColumn colU03 = new()                     // 担当者名
            {
                Name = "name",
                HeaderText = "氏名",
                Width = 120,
                Visible = true
            };

            //DataGridViewButtonColumn colU01 = new DataGridViewButtonColumn();                       // 追加･変更ボタン
            //DataGridViewTextBoxColumn colU02 = new DataGridViewTextBoxColumn();                     // 担当者ID
            //DataGridViewTextBoxColumn colU03 = new DataGridViewTextBoxColumn();                     // 担当者名
            //colU01.Name = "edit";
            //colU01.HeaderText = " ";
            //colU01.Text = "編集";
            //colU01.UseColumnTextForButtonValue = true;
            //colU01.Width = 70;
            //colU01.Visible = true;
            //colU02.Name = "id";
            //colU02.HeaderText = "ID";
            //colU02.Width = 50;
            //colU02.Visible = false;
            //colU03.Name = "name";
            //colU03.HeaderText = "氏名";
            //colU03.Width = 120;
            //colU03.Visible = true;

            this.dgvUserList.Columns.Add(colU01);
            this.dgvUserList.Columns.Add(colU02);
            this.dgvUserList.Columns.Add(colU03);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvUserList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvUserList.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvUserList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            this.dgvUserList.RowTemplate.Height = 25;                                                                         //行高さ
            this.dgvUserList.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvUserList.AllowUserToResizeRows = false;                                                                   //行高さの変更不可
            this.dgvUserList.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示
            this.dgvUserList.Columns["id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;            // 列ヘッダ文字位置
            this.dgvUserList.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置

            //奇数行を黄色にする
            this.dgvUserList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvUserList.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvUserList.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;          //セルの文字表示位置

            this.dgvUserList.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);          //フォント設定
            this.dgvUserList.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvUserList.MultiSelect = false;                                                                         //複数選択
            this.dgvUserList.ReadOnly = true;                                                                             //読込専用
            this.dgvUserList.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvUserList.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvUserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする


        }
        /// <summary>
        /// 専従先情報表示
        /// </summary>
        private void DisplayLocation()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_専従先.id");
                    sb.AppendLine(",Mst_専従先.location_id");
                    sb.AppendLine(",Mst_専従先.name");
                    sb.AppendLine(",Mst_専従先.fullname");
                    sb.AppendLine(",Mst_専従先.kana1");
                    sb.AppendLine(",Mst_専従先.instructor_id");
                    sb.AppendLine(",Mst_社員.fullname AS StaffName");
                    sb.AppendLine(",Mst_専従先.sort");
                    sb.AppendLine(",Mst_専従先.comment");
                    sb.AppendLine(",Mst_専従先.tel_no");
                    sb.AppendLine(",Mst_専従先.fax_no");
                    sb.AppendLine(",Mst_専従先.mailaddress");
                    sb.AppendLine(",Mst_専従先.emergency_tel_no");
                    sb.AppendLine(",Mst_専従先.emergency_memo");
                    sb.AppendLine(",Mst_専従先.closing_date");
                    sb.AppendLine(",Mst_専従先.constract_flag");
                    sb.AppendLine(" FROM Mst_専従先");
                    sb.AppendLine(" LEFT JOIN Mst_社員");
                    sb.AppendLine(" ON Mst_専従先.instructor_id = Mst_社員.staff_id");
                    sb.AppendLine(" ORDER BY");
                    sb.AppendLine(" Mst_専従先.sort");
                    sb.AppendLine(" ASC");

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
                            this.dgvList.Rows[i].Cells["id"].Value = dr["id"].ToString();
                            this.dgvList.Rows[i].Cells["name"].Value = dr["fullname"].ToString();
                            this.dgvList.Rows[i].Cells["ryaku"].Value = dr["name"].ToString();
                            this.dgvList.Rows[i].Cells["kana"].Value = dr["kana1"].ToString();
                            this.dgvList.Rows[i].Cells["managerid"].Value = dr["instructor_id"].ToString();
                            this.dgvList.Rows[i].Cells["manager"].Value = dr["StaffName"].ToString();
                            this.dgvList.Rows[i].Cells["sort"].Value = dr["sort"].ToString();
                            this.dgvList.Rows[i].Cells["comment"].Value = dr["comment"].ToString();
                            this.dgvList.Rows[i].Cells["location_id"].Value = dr["location_id"].ToString();
                            this.dgvList.Rows[i].Cells["tel_no"].Value = dr["tel_no"].ToString();
                            this.dgvList.Rows[i].Cells["fax_no"].Value = dr["fax_no"].ToString();
                            this.dgvList.Rows[i].Cells["mailaddress"].Value = dr["mailaddress"].ToString();
                            this.dgvList.Rows[i].Cells["emergency_tel_no"].Value = dr["emergency_tel_no"].ToString();
                            this.dgvList.Rows[i].Cells["emergency_memo"].Value = dr["emergency_memo"].ToString();
                            // 締日
                            if (dr["closing_date"].ToString().Length > 0) { this.dgvList.Rows[i].Cells["closing_date"].Value = dr["closing_date"].ToString(); }
                            else { this.dgvList.Rows[i].Cells["closing_date"].Value = ""; }
                            // 基本契約走行距離有無
                            if (dr["constract_flag"] != null && dr["constract_flag"].ToString() == "1") { this.dgvList.Rows[i].Cells["constract_flag"].Value = "〇"; }
                            else { this.dgvList.Rows[i].Cells["constract_flag"].Value = ""; }
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
            Id = e.RowIndex;

            if (e.RowIndex < 0) { return; }

            InitializeForm(false);
            // 新規ラベルを非表示→更新モードに

            //クリックされたセルのID取得
            Id = int.Parse(this.dgvList.Rows[e.RowIndex].Cells[0].Value.ToString());

            // 画面表示
            this.txtName.Text = this.dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.txtRyakuName.Text = this.dgvList.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.txtKana1.Text = this.dgvList.Rows[e.RowIndex].Cells[3].Value.ToString();
            Instructor_ID = int.Parse(this.dgvList.Rows[e.RowIndex].Cells[4].Value.ToString());
            this.txtStaffName1.Text = this.dgvList.Rows[e.RowIndex].Cells[5].Value.ToString();
            this.txtClosingDate.Text = this.dgvList.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (this.dgvList.Rows[e.RowIndex].Cells[7].Value.ToString() == "〇") { this.chkContract.Checked = true; }
            else { this.chkContract.Checked = false; }
            this.txtSort.Text = this.dgvList.Rows[e.RowIndex].Cells[8].Value.ToString();                    // 8
            this.txtComment.Text = this.dgvList.Rows[e.RowIndex].Cells[9].Value.ToString();                 // 9
            // 2025/06/24 DEL
            // this.txtUserName1.Text = this.dgvList.Rows[e.RowIndex].Cells[11].Value.ToString();              // 11
            // this.txtUserName2.Text = this.dgvList.Rows[e.RowIndex].Cells[12].Value.ToString();              // 12
            this.txtTelNo.Text = this.dgvList.Rows[e.RowIndex].Cells[11].Value.ToString();                  // 13
            this.txtFaxNo.Text = this.dgvList.Rows[e.RowIndex].Cells[12].Value.ToString();                  // 14
            this.txtMailAddress.Text = this.dgvList.Rows[e.RowIndex].Cells[13].Value.ToString();            // 15
            this.txtEmergency_TelNo.Text = this.dgvList.Rows[e.RowIndex].Cells[14].Value.ToString();        // 16
            this.txtEmergency_Memo.Text = this.dgvList.Rows[e.RowIndex].Cells[15].Value.ToString();         // 17

            // this.dgvList.ClearSelection();

            // 専従先担当者表示
            DispLocationUser();
        }
        /// <summary>
        /// 専従先担当者表示
        /// </summary>
        private void DispLocationUser()
        {
            this.dgvUserList.Rows.Clear();

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_専従先担当者.id");
                    sb.AppendLine(",Mst_専従先担当者.location_id");
                    sb.AppendLine(",Mst_専従先担当者.user_name");
                    sb.AppendLine(" FROM Mst_専従先担当者");
                    sb.AppendLine(" WHERE");
                    sb.AppendLine(" Mst_専従先担当者.location_id = " + Id);
                    sb.AppendLine(" ORDER BY");
                    sb.AppendLine(" Mst_専従先担当者.id");
                    sb.AppendLine(" ASC");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        if (dt_val.Rows.Count == 0)
                        {
                            // MessageBox.Show("0件です。", "結果", MessageBoxButtons.OK);
                            return;
                        }

                        var i = 0;
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvUserList.Rows.Add();
                            this.dgvUserList.Rows[i].Cells["id"].Value = dr["id"].ToString();
                            this.dgvUserList.Rows[i].Cells["name"].Value = dr["user_name"].ToString();
                            i++;
                        }
                    }
                }

                this.dgvUserList.ClearSelection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        /// <summary>
        /// 責任者ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectStaff_Click(object sender, EventArgs e)
        {
            frmSelectStaff fSelectStaff = new()
            {
                TargetTable = "Mst_社員",
                Select_user_name = "",
                Select_user_id = 0
            };
            fSelectStaff.ShowDialog();
            if (fSelectStaff.Select_user_id == 0) { return; }

            // 選択従業員情報取得
            this.Instructor_ID = fSelectStaff.Select_user_id;
            this.txtStaffName1.Text = fSelectStaff.Select_user_name;
        }
        /// <summary>
        /// 新規ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            InitializeForm(true);
            this.dgvList.ClearSelection();
        }
        /// <summary>
        /// 並び順最大値＋１を自動表示
        /// </summary>
        private void DisplaySortMax()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("MAX(sort) AS SMax");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.txtSort.Text = (int.Parse(dr["SMax"].ToString()) + 1).ToString();
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
        /// 保存ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // INSERTフラグ
            Boolean ins_flag = false;
            int ins_id = 0;

            // 未入力判定
            if (this.txtName.Text.Length == 0 || this.txtRyakuName.Text.Length == 0)
            {
                MessageBox.Show("未入力項目がります。", "結果", MessageBoxButtons.OK);
                return;
            }

            ClsMstLocation cls = new()
            {
                Id = 0,
                Location_Id = 0,
                Name = this.txtName.Text,
                Ryaku = this.txtRyakuName.Text,
                Kana = this.txtKana1.Text,
                Instructor_Id = Instructor_ID,
                Sort = int.Parse(this.txtSort.Text),
                Comment = this.txtComment.Text,
                TelNo = this.txtTelNo.Text,
                FaxNo = this.txtFaxNo.Text,
                MailAddress = this.txtMailAddress.Text,
                EmergencyTelNo = this.txtEmergency_TelNo.Text,
                EmergencyMemo = this.txtEmergency_Memo.Text
            };
            //cls.Id = 0;
            //cls.Location_Id = 0;
            //cls.Name = this.txtName.Text;
            //cls.Ryaku = this.txtRyakuName.Text;
            //cls.Kana = this.txtKana1.Text;
            //cls.Instructor_Id = Instructor_ID;
            //cls.Sort = int.Parse(this.txtSort.Text);
            //cls.Comment = this.txtComment.Text;
            //// 2025/06/24 DEL
            //// cls.UserName1 = this.txtUserName1.Text;
            //// cls.UserName2 = this.txtUserName2.Text;
            //cls.TelNo = this.txtTelNo.Text;
            //cls.FaxNo = this.txtFaxNo.Text;
            //cls.MailAddress = this.txtMailAddress.Text;
            //cls.EmergencyTelNo = this.txtEmergency_TelNo.Text;
            //cls.EmergencyMemo = this.txtEmergency_Memo.Text;

            // 締日
            // int i;
            if (int.TryParse(this.txtClosingDate.Text,out int i) == true)
            {
                cls.ClosingDate = i;
            }
            else
            {
                cls.ClosingDate = 20;
            }
            // 基本契約走行距離有無
            if (this.chkContract.Checked == true)
            {
                cls.ConstractFlag = 1;
            }
            else
            {
                cls.ConstractFlag = 0;
            }

            // 新規、更新判定
            if (Id > 0)
            {
                // 更新
                cls.Id = Id;
                cls.Update();
            }
            else
            {
                // 新規登録
                // Id = cls.Insert();
                Id = cls.InsertScalar();    // INSERTしたレコードのID取得
            }

            // =========================================================
            // 専従先専従者については更新しない 2025/11/18
            // =========================================================
            // 管理責任者情報更新
            // Mst_専従先専従者
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" location_id");
                    sb.AppendLine(",staff_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + Id);
                    sb.AppendLine("AND");
                    sb.AppendLine("staff_id = " + Instructor_ID);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // 専従先専従者に登録なし
                        if (dt_val.Rows.Count == 0)
                        {
                            // 専従先専従者へ新規登録
                            sb.Clear();
                            sb.AppendLine("INSERT INTO");
                            sb.AppendLine("Mst_専従先専従者");
                            sb.AppendLine("(");
                            sb.AppendLine(" location_id");
                            sb.AppendLine(",staff_id");
                            sb.AppendLine(",ins_user_id");
                            sb.AppendLine(",ins_date");
                            sb.AppendLine(",delete_flag");
                            sb.AppendLine(") VALUES (");
                            sb.AppendLine(Id.ToString());
                            sb.AppendLine("," + Instructor_ID);
                            sb.AppendLine("," + ClsLoginUser.StaffID);
                            sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                            sb.AppendLine("," + ClsPublic.FLAG_OFF);
                            sb.AppendLine("); SELECT SCOPE_IDENTITY();");
                            // clsSqlDb.DMLUpdate(sb.ToString());
                            ins_id = clsSqlDb.DMLUpdateScalar(sb.ToString());   // INSERT -> ID取得

                            //// ID取得
                            //sb.Clear();
                            //sb.AppendLine("SELECT");
                            //sb.AppendLine("id");
                            //sb.AppendLine("FROM");
                            //sb.AppendLine("Mst_専従先専従者");
                            //sb.AppendLine("WHERE");
                            //sb.AppendLine("location_id = " + Id);
                            //sb.AppendLine("AND");
                            //sb.AppendLine("staff_id = " + Instructor_ID );
                            //sb.AppendLine("AND");
                            //sb.AppendLine("ins_user_id = " + ClsLoginUser.StaffID);

                            //DataTable dt_val2 = clsSqlDb.DMLSelect(sb.ToString());
                            //foreach (DataRow dr in dt_val2.Rows)
                            //{
                            //    // 追加レコードID取得
                            //    ins_id = int.Parse(dr["id"].ToString());
                            //}

                            // INSERTフラグON
                            ins_flag = true;
                        }
                    }
                }

                // 転送確認
                if (MessageBox.Show("登録しました。続けてサーバーに転送（同期）しますか？" + Environment.NewLine + "転送先 [" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Instance + "\\" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Database + "]", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    InitializeForm(true);
                    DisplayLocation();
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
                        // Mst_専従先クラス
                        ClsMstLocation clsMstLocation = new();
                        // 専従先登録
                        clsMstLocation.ExportLocationOneData(Id, clsSqlDb, clsMySqlDb);

                        // 専従先専従者追加登録
                        if (ins_flag == true)
                        {
                            // 専従先専従者へ新規登録
                            sb.Clear();
                            sb.AppendLine("INSERT INTO");
                            sb.AppendLine("Mst_専従先専従者");
                            sb.AppendLine("(");
                            sb.AppendLine(" id");
                            sb.AppendLine(",location_id");
                            sb.AppendLine(",staff_id");
                            sb.AppendLine(",ins_user_id");
                            sb.AppendLine(",ins_date");
                            sb.AppendLine(",delete_flag");
                            sb.AppendLine(") VALUES (");
                            sb.AppendLine(ins_id.ToString());
                            sb.AppendLine("," + Id);
                            sb.AppendLine("," + Instructor_ID);
                            sb.AppendLine("," + ClsLoginUser.StaffID);
                            sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                            sb.AppendLine("," + ClsPublic.FLAG_OFF);
                            sb.AppendLine(")");
                            clsMySqlDb.DMLUpdate(sb.ToString());
                        }
                    }
                    InitializeForm(true);
                    DisplayLocation();
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // IDチェック
            if (Id == 0) { return; }

            // Mst_専従先レコード削除
            ClsMstLocation cls = new()
            {
                Id = Id
            };
            // cls.Id = Id;
            cls.Delete();
            
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // DELETE
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + Id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
                InitializeForm(true);
                DisplayLocation();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMstLocation_Shown(object sender, EventArgs e)
        {
            this.dgvList.ClearSelection();
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
        /// 車両登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocationCar_Click(object sender, EventArgs e)
        {
            if (Id < 0)
            {
                MessageBox.Show("専従先が選択されていません。", "情報", MessageBoxButtons.OK);
                return;
            }

            frmMstLocationCar cls = new()
            {
                Location_id = Id
            };
            cls.ShowDialog();
        }

        /// <summary>
        /// ｶﾅ（半角）入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKana1_TextChanged(object sender, EventArgs e)
        {
            // 入力チェック
            if (this.txtKana1.Text == "ｱ" ||
                this.txtKana1.Text == "ｶ" ||
                this.txtKana1.Text == "ｻ" ||
                this.txtKana1.Text == "ﾀ" ||
                this.txtKana1.Text == "ﾅ" ||
                this.txtKana1.Text == "ﾊ" ||
                this.txtKana1.Text == "ﾏ" ||
                this.txtKana1.Text == "ﾔ" ||
                this.txtKana1.Text == "ﾗ" ||
                this.txtKana1.Text == "ﾜ"
                )
            {
                return;
            }
            // 上記以外の場合は入力をクリア
            this.txtKana1.Text = "";
        }
        /// <summary>
        /// 締日入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClosingDate_TextChanged(object sender, EventArgs e)
        {
            if (this.txtClosingDate.Text == "") { return; }

            // 数字チェック
            if (int.TryParse(this.txtClosingDate.Text, out _) != true)
            {
                this.txtClosingDate.Text = "";
            }
        }
        /// <summary>
        /// 表示順
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSort_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSort.Text == "") { return; }

            // 数字チェック
            if (int.TryParse(this.txtSort.Text, out _) != true)
            {
                this.txtSort.Text = "";
            }
        }
        /// <summary>
        /// 新規追加ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            if (Id <= 0)
            {
                MessageBox.Show("専従先が選択されていません。", "情報", MessageBoxButtons.OK);
                return;
            }

            // 新規追加
            frmMstLocationUser fMstLocationUser = new()
            {
                Location_Id = Id,
                Location_Name = this.txtName.Text,
                User_Id = 0
            };
            fMstLocationUser.ShowDialog();

            // 再表示
            // displayLocation();
            // dgvUserList.Rows.Clear();

            // 再表示
            DispLocationUser();

        }
        /// <summary>
        /// 専従先担当者一覧 DataGridView セルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ボタン列がクリックされたかを確認
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // 0 はボタン列のインデックス
            {
                // ID取得
                var id = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString());

                // 表示
                frmMstLocationUser fMstLocationUser = new()
                {
                    Location_Id = Id,  // 専従先IDを設定
                    Location_Name = this.txtName.Text,
                    User_Id = id       // 担当者IDを設定
                };
                fMstLocationUser.ShowDialog();

                // 再表示
                DispLocationUser();
            }

        }
    }
}
