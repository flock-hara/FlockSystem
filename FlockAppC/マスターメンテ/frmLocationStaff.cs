using DocumentFormat.OpenXml.Office2010.Excel;
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
    public partial class frmLocationStaff : Form
    {
        private int ID { get; set; }
        private int Instructor_ID { get; set; }             // 未使用
        private int Car_ID { get; set; }                    // 未使用
        private int Staff_ID { get; set; }                  // 未使用

        // 変更フラグ（追加ボタン押下でtrueに設定）
        private Boolean ChangeInstructor {  get; set; }     // 管理責任者変更ボタン押下時にtrue
        private Boolean ChangeCar { get; set; }             // 専従先車両追加ボタン押下時にtrue
        private Boolean ChangeStaff { get; set; }           // 専従者追加ボタン押下時にtrue

        private readonly StringBuilder sb = new();

        public frmLocationStaff()
        {
            InitializeComponent();
        }

        private void FrmLocationStaff_Load(object sender, EventArgs e)
        {
            // initialize DataGridView
            InitializeDgv();

            InitializeForm();

            // 変更フラグ初期化
            ChangeInstructor = false;
            ChangeCar = false;
            ChangeStaff = false;

            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// 各DataGridViewの設定
        /// </summary>
        private void InitializeDgv()
        {
            InitializeDgvInstructor();
            InitializeDgvLocationCar();
            InitializeDgvLocationStaff();
        }
        /// <summary>
        /// 管理責任者DataGridView設定
        /// </summary>
        private void InitializeDgvInstructor()
        {
            DataGridViewButtonColumn col00 = new()
            {
                Name = "change",
                HeaderText = " ",
                Text = "変更",
                Width = 50,
                UseColumnTextForButtonValue = true,
                Visible = false                          // 不要
            };

            DataGridViewTextBoxColumn col01 = new()
            {
                Name = "id",
                HeaderText = "ID",
                Width = 50,
                Visible = false
            };

            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "office",
                HeaderText = "所属",
                Width = 120,
                Visible = true
            };

            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "group",
                HeaderText = "部門",
                Width = 100,
                Visible = true
            };

            DataGridViewTextBoxColumn col04 = new()
            {
                Name = "name",
                HeaderText = "氏名",
                Width = 120,
                Visible = true
            };

            this.dgvInstructor.Columns.Add(col00);
            this.dgvInstructor.Columns.Add(col01);
            this.dgvInstructor.Columns.Add(col02);
            this.dgvInstructor.Columns.Add(col03);
            this.dgvInstructor.Columns.Add(col04);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvInstructor.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvInstructor.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvInstructor.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            this.dgvInstructor.RowTemplate.Height = 25;                                                                         //行高さ
            this.dgvInstructor.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvInstructor.AllowUserToResizeRows = false;                                                                   //行高さの変更不可
            this.dgvInstructor.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示
            this.dgvInstructor.Columns["id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;            // 列ヘッダ文字位置
            this.dgvInstructor.Columns["office"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvInstructor.Columns["group"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置
            this.dgvInstructor.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置

            //奇数行を黄色にする
            this.dgvInstructor.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvInstructor.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvInstructor.Columns["office"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;          //セルの文字表示位置
            this.dgvInstructor.Columns["group"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;          //セルの文字表示位置
            this.dgvInstructor.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   //セルの文字表示位置

            this.dgvInstructor.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11);           //フォント設定
            this.dgvInstructor.Columns["office"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11);       //フォント設定
            this.dgvInstructor.Columns["group"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11);        //フォント設定
            this.dgvInstructor.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11);         //フォント設定
            //this.dgvInstructor.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);          //フォント設定
            //this.dgvInstructor.Columns["office"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定
            //this.dgvInstructor.Columns["group"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定
            //this.dgvInstructor.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular); //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvInstructor.MultiSelect = false;                                                                         //複数選択
            this.dgvInstructor.ReadOnly = true;                                                                             //読込専用
            this.dgvInstructor.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvInstructor.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            this.dgvInstructor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// 専従先車両DataGridView設定
        /// </summary>
        private void InitializeDgvLocationCar()
        {

            //col00.Name = "add";
            //col00.HeaderText = " ";
            //col00.Text = "追加";
            //col00.Width = 50;
            //col00.UseColumnTextForButtonValue = true;
            //col00.Visible = true;

            DataGridViewButtonColumn col01 = new()
            {
                Name = "delete",
                HeaderText = " ",
                Text = "除外",
                Width = 50,
                UseColumnTextForButtonValue = true,
                Visible = true
            };

            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "id",
                HeaderText = "ID",
                Width = 50,
                Visible = false
            };

            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "car_no",
                HeaderText = "車両番号",
                Width = 100,
                Visible = true
            };

            DataGridViewTextBoxColumn col04 = new()
            {
                Name = "car_name",
                HeaderText = "号車",            // 2024/12/17 UPD
                Width = 100,
                Visible = true
            };

            this.dgvLocationCar.Columns.Add(col01);
            this.dgvLocationCar.Columns.Add(col02);
            this.dgvLocationCar.Columns.Add(col03);
            this.dgvLocationCar.Columns.Add(col04);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvLocationCar.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvLocationCar.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvLocationCar.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            this.dgvLocationCar.RowTemplate.Height = 25;                                                                         //行高さ
            this.dgvLocationCar.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvLocationCar.AllowUserToResizeRows = false;                                                                   //行高さの変更不可
            this.dgvLocationCar.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示
            this.dgvLocationCar.Columns["id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;            // 列ヘッダ文字位置
            this.dgvLocationCar.Columns["car_no"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;        // 列ヘッダ文字位置
            this.dgvLocationCar.Columns["car_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 列ヘッダ文字位置

            //奇数行を黄色にする
            this.dgvLocationCar.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvLocationCar.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvLocationCar.Columns["car_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvLocationCar.Columns["car_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      //セルの文字表示位置

            this.dgvLocationCar.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);          //フォント設定
            this.dgvLocationCar.Columns["car_no"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定
            this.dgvLocationCar.Columns["car_name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvLocationCar.MultiSelect = false;                                                                         //複数選択
            this.dgvLocationCar.ReadOnly = true;                                                                             //読込専用
            this.dgvLocationCar.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvLocationCar.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            // this.dgvLocationCar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// 専従先専従者DataGridView設定
        /// </summary>
        private void InitializeDgvLocationStaff()
        {

            //col00.Name = "add";
            //col00.HeaderText = " ";
            //col00.Text = "追加";
            //col00.Width = 50;
            //col00.UseColumnTextForButtonValue = true;
            //col00.Visible = true;

            DataGridViewButtonColumn col01 = new()
            {
                Name = "delete",
                HeaderText = " ",
                Text = "除外",
                Width = 50,
                UseColumnTextForButtonValue = true,
                Visible = true
            };

            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "id",
                HeaderText = "ID",
                Width = 50,
                Visible = false,
            };

            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "office",
                HeaderText = "所属",
                Width = 120,
                Visible = true
            };

            DataGridViewTextBoxColumn col04 = new()
            {
                Name = "group",
                HeaderText = "部門",
                Width = 100,
                Visible = true
            };

            DataGridViewTextBoxColumn col05 = new()
            {
                Name = "proxy",
                HeaderText = "代務",
                Width = 55,
                Visible = true
            };

            DataGridViewTextBoxColumn col06 = new()
            {
                Name = "name",
                HeaderText = "氏名",
                Width = 120,
                Visible = true
            };

            this.dgvLocationStaff.Columns.Add(col01);
            this.dgvLocationStaff.Columns.Add(col02);
            this.dgvLocationStaff.Columns.Add(col03);
            this.dgvLocationStaff.Columns.Add(col04);
            this.dgvLocationStaff.Columns.Add(col05);
            this.dgvLocationStaff.Columns.Add(col06);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvLocationStaff.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvLocationStaff.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvLocationStaff.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            this.dgvLocationStaff.RowTemplate.Height = 25;                                                                         //行高さ
            this.dgvLocationStaff.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvLocationStaff.AllowUserToResizeRows = false;                                                                   //行高さの変更不可
            this.dgvLocationStaff.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示
            this.dgvLocationStaff.Columns["id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;            // 列ヘッダ文字位置
            this.dgvLocationStaff.Columns["office"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;        // 列ヘッダ文字位置
            this.dgvLocationStaff.Columns["group"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 列ヘッダ文字位置
            this.dgvLocationStaff.Columns["proxy"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 列ヘッダ文字位置
            this.dgvLocationStaff.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 列ヘッダ文字位置

            //奇数行を黄色にする
            this.dgvLocationCar.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvLocationStaff.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvLocationStaff.Columns["office"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        //セルの文字表示位置
            this.dgvLocationStaff.Columns["group"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      //セルの文字表示位置
            this.dgvLocationStaff.Columns["proxy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      //セルの文字表示位置
            this.dgvLocationStaff.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      //セルの文字表示位置

            this.dgvLocationStaff.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);          //フォント設定
            this.dgvLocationStaff.Columns["office"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定
            this.dgvLocationStaff.Columns["group"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定
            this.dgvLocationStaff.Columns["proxy"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定
            this.dgvLocationStaff.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定

            //this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvLocationStaff.MultiSelect = false;                                                                         //複数選択
            this.dgvLocationStaff.ReadOnly = true;                                                                             //読込専用
            this.dgvLocationStaff.AllowUserToAddRows = false;                                                                  //行追加無効
            this.dgvLocationStaff.RowHeadersVisible = false;                                                                   //行ヘッダ非表示
            // this.dgvLocationStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// 画面初期化（クリア）
        /// </summary>
        private void InitializeForm()
        {
            this.lblLocation.Text = "";
            this.dgvInstructor.Rows.Clear();
            this.dgvLocationCar.Rows.Clear();
            this.dgvLocationStaff.Rows.Clear();
            this.btnSelectLocation.Focus();
        }
        /// <summary>
        /// 専従先選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectLocation_Click(object sender, EventArgs e)
        {
            frmSelectLocation fSelectLocation = new()
            {
                TargetTable = "Mst_専従先",
                Select_location_name = "",
                Select_location_id = 0
            };
            fSelectLocation.ShowDialog();

            if (fSelectLocation.Select_location_name == "") return;

            this.ID = fSelectLocation.Select_location_id;
            this.lblLocation.Text = fSelectLocation.Select_location_name;

            // 

            DisplayForm();
        }
        /// <summary>
        /// 専従先情報表示
        /// </summary>
        private void DisplayForm()
        {
            // 管理責任者
            DisplayInstructor();
            // 専従先車両
            DisplayLocattionCar();
            // 専従先専従者
            DisplayLocationStaff();
        }
        /// <summary>
        /// 管理責任者をグリッドに表示
        /// </summary>
        private void DisplayInstructor()
        {
            try
            {
                // 専従先IDをもとに表示
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 管理責任者情報
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_専従先.instructor_id");
                    sb.AppendLine(",Mst_社員.fullname");
                    sb.AppendLine(",Mst_所属.Name As office_name");
                    sb.AppendLine(",Mst_部門.Name As group_name");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先.instructor_id = Mst_社員.staff_id");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_所属");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_社員.office_id = Mst_所属.id");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_部門");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_社員.group_id = Mst_部門.id");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + ID);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        this.dgvInstructor.Rows.Clear();

                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvInstructor.Rows.Add();
                            this.dgvInstructor.Rows[0].Cells["id"].Value = dr["instructor_id"].ToString();
                            this.dgvInstructor.Rows[0].Cells["office"].Value = dr["office_name"].ToString();
                            this.dgvInstructor.Rows[0].Cells["group"].Value = dr["group_name"].ToString();
                            this.dgvInstructor.Rows[0].Cells["name"].Value = dr["fullname"].ToString();
                            break;
                        }
                    }
                }
                this.dgvLocationCar.ClearSelection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 専従先車両をグリッドに表示
        /// </summary>
        private void DisplayLocattionCar()
        {
            try
            {
                // 専従先IDをもとに表示
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 車両情報
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_専従先車両.id");
                    sb.AppendLine(",Mst_専従先車両.no");
                    sb.AppendLine(",Mst_専従先車両.name");
                    sb.AppendLine(" FROM");
                    sb.AppendLine(" Mst_専従先車両");
                    sb.AppendLine(" WHERE");
                    sb.AppendLine(" Mst_専従先車両.location_id = " + ID);
                    sb.AppendLine(" AND");
                    sb.AppendLine(" Mst_専従先車両.delete_flag <> 1");
                    sb.AppendLine(" ORDER BY");
                    sb.AppendLine(" Mst_専従先車両.name");
                    sb.AppendLine(",Mst_専従先車両.no");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        this.dgvLocationCar.Rows.Clear();

                        var i = 0;
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvLocationCar.Rows.Add();
                            this.dgvLocationCar.Rows[i].Cells["id"].Value = dr["id"].ToString();
                            this.dgvLocationCar.Rows[i].Cells["car_no"].Value = dr["no"].ToString();
                            this.dgvLocationCar.Rows[i].Cells["car_name"].Value = dr["name"].ToString();
                            i++;
                        }
                    }
                }
                this.dgvLocationCar.ClearSelection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 専従先専従者をグリッドに表示
        /// </summary>
        private void DisplayLocationStaff()
        {
            try
            {
                // 専従先IDをもとに表示
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 管理責任者情報
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_専従先専従者.staff_id");
                    sb.AppendLine(",Mst_社員.fullname");
                    sb.AppendLine(",Mst_社員.proxy_flag");
                    sb.AppendLine(",Mst_所属.Name As office_name");
                    sb.AppendLine(",Mst_部門.Name As group_name");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先専従者.staff_id = Mst_社員.staff_id");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_所属");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_社員.office_id = Mst_所属.id");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_部門");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_社員.group_id = Mst_部門.id");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_専従先専従者.location_id = " + ID);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("Mst_専従先専従者.staff_id");

                    DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString());

                    this.dgvLocationStaff.Rows.Clear();

                    var i = 0;
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        this.dgvLocationStaff.Rows.Add();
                        this.dgvLocationStaff.Rows[i].Cells["id"].Value = dr["staff_id"].ToString();
                        this.dgvLocationStaff.Rows[i].Cells["office"].Value = dr["office_name"].ToString();
                        this.dgvLocationStaff.Rows[i].Cells["group"].Value = dr["group_name"].ToString();
                        if (dr["proxy_flag"].ToString() == ClsPublic.FLAG_ON.ToString())
                        {
                            // 代務の場合が「〇」
                            this.dgvLocationStaff.Rows[i].Cells["proxy"].Value = "〇";
                        }
                        else
                        {
                            this.dgvLocationStaff.Rows[i].Cells["proxy"].Value = "";
                        }
                        this.dgvLocationStaff.Rows[i].Cells["name"].Value = dr["fullname"].ToString();
                        i++;
                    }
                    dt_val.Dispose();
                }
                this.dgvLocationStaff.ClearSelection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 管理責任者DataGridViewの選択を無効にする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvInstructor_SelectionChanged(object sender, EventArgs e)
        {
            dgvInstructor.ClearSelection();
        }
        /// <summary>
        /// 専従先車両追加ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLocattionCarAdd_Click(object sender, EventArgs e)
        {
            // 専従先車両マスターメンテ画面を表示
            frmMstLocationCar cls = new();
            cls.ShowDialog();

            // 変更フラグ更新
            ChangeCar = true;

            // DataGridView再表示
            DisplayLocattionCar();
        }
        /// <summary>
        /// 管理責任者選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectStaff_Click(object sender, EventArgs e)
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
            ClsMstStaff cMstStaff = new()
            {
                Id = fSelectStaff.Select_user_id
            };
            cMstStaff.GetStaff();

            // 専従先マスタ更新
            UpdateLocationInstructor(ID, fSelectStaff.Select_user_id);

            // 変更フラグ更新
            ChangeInstructor = true;

            // 再表示
            DisplayInstructor();
        }
        /// <summary>
        /// 専従先マスタ更新（管理責任者）
        /// </summary>
        private void UpdateLocationInstructor(int p_location_id, int p_instructor_id)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("SET");
                    sb.AppendLine("instructor_id = " + p_instructor_id);
                    // 2025/11/12↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + p_location_id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 担当者追加ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLocationStaffAdd_Click(object sender, EventArgs e)
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
            ClsMstStaff cMstStaff = new()
            {
                Id = fSelectStaff.Select_user_id
            };
            cMstStaff.GetStaff();

            // 専従先専従者マスタ更新
            UpdateMstLocationStaff(ID, fSelectStaff.Select_user_id);

            // 変更フラグ更新
            ChangeStaff = true;

            // 専従先専従者再表示
            DisplayLocationStaff();
        }
        /// <summary>
        /// 専従先専従者更新
        /// </summary>
        /// <param name="p_location_id"></param>
        /// <param name="p_staff_id"></param>
        private void UpdateMstLocationStaff(int p_location_id, int p_staff_id)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // DELETE → INSERT
                    sb.Clear();
                    sb.AppendLine("DELETE");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + p_location_id);
                    sb.AppendLine("AND");
                    sb.AppendLine("staff_id = " + p_staff_id);

                    clsSqlDb.DMLUpdate(sb.ToString());

                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("(");
                    sb.AppendLine(" location_id");
                    sb.AppendLine(",staff_id");
                    // 2025/11/12↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/12↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(p_location_id.ToString());
                    sb.AppendLine("," + p_staff_id.ToString());
                    // 2025/11/12↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/12↑
                    sb.AppendLine(")");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
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
            // 管理責任者、車両、専従者に変更がある場合、メッセージ表示
            if (ChangeInstructor == true || ChangeCar == true || ChangeStaff == true)
            {
                if (MessageBox.Show("変更がある場合、続けてサーバーに転送（同期）しますか？" + Environment.NewLine + "転送先 [" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Instance + "\\" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Database + "]", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    this.Close();
                    return;
                }
            }
            else
            {
                this.Close();
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
                    // Mst_専従先クラス
                    ClsMstLocation clsMstLocation = new();
                    // 専従先登録
                    clsMstLocation.ExportLocationAllData(clsSqlDb, clsMySqlDb);

                    // Mst_専従先専従者クラス
                    ClsMstStaff clsMstStaff = new();
                    // 専従先専従者登録
                    clsMstStaff.ExportLocationStaffAllData(clsSqlDb, clsMySqlDb);

                    // Mst_専従先車両クラス
                    ClsMstLocationCar clsMstLocationCar = new();
                    // 専従先車両登録
                    clsMstLocationCar.ExportLocationCarAllData(clsSqlDb, clsMySqlDb);
                }
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

            this.Close();
        }
        /// <summary>
        /// 専従先車両「除外」ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvLocationCar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ボタン列がクリックされたかを確認
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // 0 はボタン列のインデックス
            {
                // ID取得
                var location_car_id = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString());
                // MessageBox.Show($"{name} のボタンがクリックされました！");

                // 確認メッセージ
                if (MessageBox.Show("削除します。", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

                // 専従先車両更新
                UpdateLocationCar(location_car_id);

                // 変更フラグ更新
                ChangeStaff = true;

                // 再表示
                DisplayLocattionCar();
            }
        }
        /// <summary>
        /// 専従先車両削除（更新）
        /// </summary>
        private void UpdateLocationCar(int location_car_id)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先車両");
                    sb.AppendLine("SET");
                    // 2025/11/12↓
                    sb.AppendLine(" upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/12↑
                    sb.AppendLine(",delete_flag = " + ClsPublic.FLAG_ON);
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + location_car_id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void DgvLocationStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ボタン列がクリックされたかを確認
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // 0 はボタン列のインデックス
            {
                // ID取得
                var location_staff_id = int.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString());
                // MessageBox.Show($"{name} のボタンがクリックされました！");

                // 確認メッセージ
                if (MessageBox.Show("削除します。", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

                // 専従先専従者削除
                DeleteLocationStaff(ID,location_staff_id);

                // 変更フラグ更新
                ChangeStaff = true;

                // 再表示
                DisplayLocationStaff();

            }
        }
        /// <summary>
        /// 専従先専従者削除
        /// </summary>
        private void DeleteLocationStaff(int p_location_id, int p_location_staff_id)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + p_location_id);
                    sb.AppendLine("AND");
                    sb.AppendLine("staff_id = " + p_location_staff_id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 従業員マスタメンテボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMstStaff_Click(object sender, EventArgs e)
        {
            using (frmMstStaff frm = new())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 専従先車両マスタメンテボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMstLocationCar_Click(object sender, EventArgs e)
        {
            using (frmMstLocationCar frm = new())
            {
                frm.ShowDialog();
            }
        }
    }
}