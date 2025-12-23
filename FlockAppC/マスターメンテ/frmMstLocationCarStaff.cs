using FlockAppC.pubClass;
using FlockAppC.選択画面;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstLocationCarStaff : Form
    {
        private int Location_id {  get; set; }              // 選択専従先ID

        private readonly StringBuilder sb = new();

        public frmMstLocationCarStaff()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMstLocationCarStaff_Load(object sender, EventArgs e)
        {
            // Initialize DataGridView
            SetDgvList();

            this.lblLocation.Text = "";
            this.lblInstructorName.Text = "";
            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// DataGridView設定
        /// </summary>
        private void SetDgvList()
        {
            #region "Column定義"
            DataGridViewTextBoxColumn col01 = new()              // 専従者名
            {
                // 専従者名
                Name = "staff_name",
                HeaderText = "専従者",
                Width = 110,
                Visible = true,
                ReadOnly = true
            };
            DataGridViewTextBoxColumn col02 = new()              // 専従者ID
            {
                // 専従者ID
                Name = "staff_id",
                HeaderText = "専ID",
                Width = 20,
                Visible = false,
                ReadOnly = true
            };
            DataGridViewButtonColumn col00 = new()                // 「全て」ボタン
            {
                // 編集ボタン
                Name = "edit",
                HeaderText = " ",
                Text = "全て",
                Width = 50,
                UseColumnTextForButtonValue = false,
                Visible = true
            };
            DataGridViewCheckBoxColumn col03 = new()            // 車両選択チェックボックス
            {
                // 車両選択チェックボックス(1)
                Name = "car_select1",
                HeaderText = "",
                Width = 140,
                Visible = true,
                ReadOnly = false,

            };
            DataGridViewTextBoxColumn col04 = new()              // 車両ID
            {

            };
            DataGridViewCheckBoxColumn col05 = new()            // 車両選択チェックボックス
            {

            };
            DataGridViewTextBoxColumn col06 = new()              // 車両ID
            {

            };
            DataGridViewCheckBoxColumn col07 = new()            // 車両選択チェックボックス
            {

            };
            DataGridViewTextBoxColumn col08 = new()              // 車両ID
            {

            };
            DataGridViewCheckBoxColumn col09 = new()            // 車両選択チェックボックス
            {

            };
            DataGridViewTextBoxColumn col10 = new()              // 車両ID
            {

            };
            DataGridViewCheckBoxColumn col11 = new()            // 車両選択チェックボックス
            {

            };
            DataGridViewTextBoxColumn col12 = new()              // 車両ID
            {

            };
            DataGridViewCheckBoxColumn col13 = new()            // 車両選択チェックボックス
            {

            };
            DataGridViewTextBoxColumn col14 = new()              // 車両ID
            {

            };
            DataGridViewCheckBoxColumn col15 = new()            // 車両選択チェックボックス
            {

            };
            DataGridViewTextBoxColumn col16 = new()              // 車両ID
            {

            };
            DataGridViewCheckBoxColumn col17 = new()            // 車両選択チェックボックス
            {

            };
            DataGridViewTextBoxColumn col18 = new()              // 車両ID
            {

            };
            DataGridViewCheckBoxColumn col19 = new()            // 車両選択チェックボックス
            {

            };
            DataGridViewTextBoxColumn col20 = new()              // 車両ID
            {

            };
            DataGridViewCheckBoxColumn col21 = new()            // 車両選択チェックボックス
            {

            };
            DataGridViewTextBoxColumn col22 = new()              // 車両ID
            {

            };
            DataGridViewCheckBoxColumn col23 = new()            // 車両選択チェックボックス
            {

            };
            DataGridViewTextBoxColumn col24 = new()              // 車両ID
            {

            };
            DataGridViewCheckBoxColumn col25 = new()            // 車両選択チェックボックス
            {

            };
            DataGridViewTextBoxColumn col26 = new()              // 車両ID
            {

            };
            #endregion

            #region "各Column プロパティ定義"



            // 車両ID(1)
            col04.Name = "car_id1";
            col04.HeaderText = "車1ID";
            col04.Width = 20;
            col04.Visible = false;
            col04.ReadOnly = true;

            // =============================
            // 車両選択チェックボックス(2)
            // =============================
            col05.Name = "car_select2";
            col05.HeaderText = "";
            col05.Width = 140;
            col05.Visible = true;
            col05.ReadOnly = false;
            // 車両ID(2)
            col06.Name = "car_id2";
            col06.HeaderText = "車2ID";
            col06.Width = 20;
            col06.Visible = false;
            col06.ReadOnly = true;

            // =============================
            // 車両選択チェックボックス(3)
            // =============================
            col07.Name = "car_select3";
            col07.HeaderText = "";
            col07.Width = 140;
            col07.Visible = true;
            col07.ReadOnly = false;
            // 車両ID(3)
            col08.Name = "car_id3";
            col08.HeaderText = "車3ID";
            col08.Width = 20;
            col08.Visible = false;
            col08.ReadOnly = true;

            // =============================
            // 車両選択チェックボックス(4)
            // =============================
            col09.Name = "car_select4";
            col09.HeaderText = "";
            col09.Width = 140;
            col09.Visible = true;
            col09.ReadOnly = false;
            // 車両ID(4)
            col10.Name = "car_id4";
            col10.HeaderText = "車4ID";
            col10.Width = 20;
            col10.Visible = false;
            col10.ReadOnly = true;

            // =============================
            // 車両選択チェックボックス(5)
            // =============================
            col11.Name = "car_select5";
            col11.HeaderText = "";
            col11.Width = 140;
            col11.Visible = true;
            col11.ReadOnly = false;
            // 車両ID(5)
            col12.Name = "car_id5";
            col12.HeaderText = "車5ID";
            col12.Width = 20;
            col12.Visible = false;
            col12.ReadOnly = true;

            // =============================
            // 車両選択チェックボックス(6)
            // =============================
            col13.Name = "car_select6";
            col13.HeaderText = "";
            col13.Width = 140;
            col13.Visible = true;
            col13.ReadOnly = false;
            // 車両ID(6)
            col14.Name = "car_id6";
            col14.HeaderText = "車6ID";
            col14.Width = 20;
            col14.Visible = false;
            col14.ReadOnly = true;

            // =============================
            // 車両選択チェックボックス(7)
            // =============================
            col15.Name = "car_select7";
            col15.HeaderText = "";
            col15.Width = 140;
            col15.Visible = true;
            col15.ReadOnly = false;
            // 車両ID(7)
            col16.Name = "car_id7";
            col16.HeaderText = "車7ID";
            col16.Width = 20;
            col16.Visible = false;
            col16.ReadOnly = true;

            // =============================
            // 車両選択チェックボックス(8)
            // =============================
            col17.Name = "car_select8";
            col17.HeaderText = "";
            col17.Width = 140;
            col17.Visible = true;
            col17.ReadOnly = false;
            // 車両ID(8)
            col18.Name = "car_id8";
            col18.HeaderText = "車8ID";
            col18.Width = 20;
            col18.Visible = false;
            col18.ReadOnly = true;

            // =============================
            // 車両選択チェックボックス(9)
            // =============================
            col19.Name = "car_select9";
            col19.HeaderText = "";
            col19.Width = 140;
            col19.Visible = true;
            col19.ReadOnly = false;
            // 車両ID(9)
            col20.Name = "car_id9";
            col20.HeaderText = "車9ID";
            col20.Width = 20;
            col20.Visible = false;
            col20.ReadOnly = true;

            // =============================
            // 車両選択チェックボックス(10)
            // =============================
            col21.Name = "car_select10";
            col21.HeaderText = "";
            col21.Width = 140;
            col21.Visible = true;
            col21.ReadOnly = false;
            // 車両ID(10)
            col22.Name = "car_id10";
            col22.HeaderText = "車10ID";
            col22.Width = 20;
            col22.Visible = false;
            col22.ReadOnly = true;

            // =============================
            // 車両選択チェックボックス(11)
            // =============================
            col23.Name = "car_select11";
            col23.HeaderText = "";
            col23.Width = 140;
            col23.Visible = true;
            col23.ReadOnly = false;
            // 車両ID(11)
            col24.Name = "car_id11";
            col24.HeaderText = "車11ID";
            col24.Width = 20;
            col24.Visible = false;
            col24.ReadOnly = true;

            // =============================
            // 車両選択チェックボックス(12)
            // =============================
            col25.Name = "car_select12";
            col25.HeaderText = "";
            col25.Width = 140;
            col25.Visible = true;
            col25.ReadOnly = false;
            // 車両ID(12)
            col26.Name = "car_id12";
            col26.HeaderText = "車12ID";
            col26.Width = 20;
            col26.Visible = false;
            col26.ReadOnly = true;
            #endregion

            #region "Column Add"
            this.dgvList.Columns.Add(col01);
            this.dgvList.Columns.Add(col02);
            this.dgvList.Columns.Add(col00);
            this.dgvList.Columns.Add(col03);
            this.dgvList.Columns.Add(col04);
            this.dgvList.Columns.Add(col05);
            this.dgvList.Columns.Add(col06);
            this.dgvList.Columns.Add(col07);
            this.dgvList.Columns.Add(col08);
            this.dgvList.Columns.Add(col09);
            this.dgvList.Columns.Add(col10);
            this.dgvList.Columns.Add(col11);
            this.dgvList.Columns.Add(col12);
            this.dgvList.Columns.Add(col13);
            this.dgvList.Columns.Add(col14);
            this.dgvList.Columns.Add(col15);
            this.dgvList.Columns.Add(col16);
            this.dgvList.Columns.Add(col17);
            this.dgvList.Columns.Add(col18);
            this.dgvList.Columns.Add(col19);
            this.dgvList.Columns.Add(col20);
            this.dgvList.Columns.Add(col21);
            this.dgvList.Columns.Add(col22);
            this.dgvList.Columns.Add(col23);
            this.dgvList.Columns.Add(col24);
            this.dgvList.Columns.Add(col25);
            this.dgvList.Columns.Add(col26);
            #endregion

            //===========================================================================================
            // 列ヘッダー
            //===========================================================================================
            #region "列ヘッダー定義"
            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvList.EnableHeadersVisualStyles = false;                                                               //Windows Color無効
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                   //列ヘッダ色
            this.dgvList.AllowUserToResizeColumns = false;                                                                //列幅の変更不可
            this.dgvList.AllowUserToResizeRows = true;                                                                    //行高さの変更不可
            this.dgvList.ColumnHeadersVisible = true;                                                                     //列ヘッダ非表示
            this.dgvList.ColumnHeadersHeight = 40;                                                                        //列ヘッダ高さ   
            this.dgvList.Columns["staff_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 列ヘッダ文字位置
            this.dgvList.Columns["staff_id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 列ヘッダ文字位置

            this.dgvList.Columns["car_select1"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["car_id1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置

            this.dgvList.Columns["car_select2"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["car_id2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置

            this.dgvList.Columns["car_select3"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["car_id3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置

            this.dgvList.Columns["car_select4"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select4"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["car_id4"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置

            this.dgvList.Columns["car_select5"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select5"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["car_id5"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置

            this.dgvList.Columns["car_select6"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select6"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["car_id6"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置

            this.dgvList.Columns["car_select7"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select7"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["car_id7"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置

            this.dgvList.Columns["car_select8"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select8"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["car_id8"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置

            this.dgvList.Columns["car_select9"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select9"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 列ヘッダ文字位置
            this.dgvList.Columns["car_id9"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;       // 列ヘッダ文字位置

            this.dgvList.Columns["car_select10"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select10"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 列ヘッダ文字位置
            this.dgvList.Columns["car_id10"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 列ヘッダ文字位置

            this.dgvList.Columns["car_select11"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select11"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 列ヘッダ文字位置
            this.dgvList.Columns["car_id11"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 列ヘッダ文字位置

            this.dgvList.Columns["car_select12"].HeaderCell.Style.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);  // 列ヘッダ文字位置
            this.dgvList.Columns["car_select12"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;  // 列ヘッダ文字位置
            this.dgvList.Columns["car_id12"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;      // 列ヘッダ文字位置

            #endregion

            //===========================================================================================
            // 列
            //===========================================================================================
            #region "列表示位置"
            this.dgvList.Columns["staff_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["staff_id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select6"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id6"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select7"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id7"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select8"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id8"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select9"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id9"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select10"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id10"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select11"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id11"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_select12"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["car_id12"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            #endregion

            #region "列表示フォント"
            this.dgvList.Columns["staff_name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Bold);       //フォント設定
            this.dgvList.Columns["staff_id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);      //フォント設定
            this.dgvList.Columns["car_select1"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);   //フォント設定
            this.dgvList.Columns["car_id1"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["car_select2"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);   //フォント設定
            this.dgvList.Columns["car_id2"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["car_select3"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);   //フォント設定
            this.dgvList.Columns["car_id3"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["car_select4"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);   //フォント設定
            this.dgvList.Columns["car_id4"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["car_select5"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);   //フォント設定
            this.dgvList.Columns["car_id5"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["car_select6"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);   //フォント設定
            this.dgvList.Columns["car_id6"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["car_select7"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);   //フォント設定
            this.dgvList.Columns["car_id7"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["car_select8"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);   //フォント設定
            this.dgvList.Columns["car_id8"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["car_select9"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);   //フォント設定
            this.dgvList.Columns["car_id9"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);       //フォント設定
            this.dgvList.Columns["car_select10"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);  //フォント設定
            this.dgvList.Columns["car_id10"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);      //フォント設定
            this.dgvList.Columns["car_select11"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);  //フォント設定
            this.dgvList.Columns["car_id11"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);      //フォント設定
            this.dgvList.Columns["car_select12"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);  //フォント設定
            this.dgvList.Columns["car_id12"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);      //フォント設定
            #endregion

            //===========================================================================================
            // 行
            //===========================================================================================
            #region "行定義"
            this.dgvList.RowTemplate.Height = 30;                                                                         //行高さ

            //奇数行を黄色にする
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            // this.dgvSelect1.ScrollBars = false;                                                                        //スクロールバー非表示
            this.dgvList.MultiSelect = false;                                                                             //複数選択
            // this.dgvList.ReadOnly = true;                                                                              //読込専用
            this.dgvList.AllowUserToAddRows = false;                                                                      //行追加無効
            this.dgvList.RowHeadersVisible = false;                                                                       //行ヘッダ非表示
            // this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                      //行選択時は１行全て選択状態にする
            #endregion
        }
        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearLocation_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        /// <summary>
        /// フォームクリア
        /// </summary>
        private void ClearForm()
        {
            this.Location_id = 0;
            this.lblLocation.Text = "";
            this.lblInstructorName.Text = "";
            // 一覧クリア
            this.dgvList.Rows.Clear();
            // 列ヘッダクリア
            for (var i = 2; i < 25; i++)
            {
                this.dgvList.Columns[i].HeaderText = "";
                this.dgvList.Columns[i].Visible = true;
                i++;
            }
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
            // InitializeForm(true);
            this.dgvList.Rows.Clear();

            // 未選択は処理終了
            if (fSelectLocation.Select_location_id <= 0) { return; }

            // 選択情報保持、表示
            this.Location_id = fSelectLocation.Select_location_id;
            this.lblLocation.Text = fSelectLocation.Select_location_name.ToString();

            // 画面表示
            DisplayList();
        }
        /// <summary>
        /// 一覧表示
        /// </summary>
        private void DisplayList()
        {
            int p_row = 0;          // 取得した情報を画面に表示際に取得するrow（チェックボックスにチェックを入れる）
            int p_col = 0;          // 取得した情報を画面に表示際に取得するcol（チェックボックスにチェックを入れる）
            int row = 0;            
            int col = 0;

            // 一覧クリア
            this.dgvList.Rows.Clear();
            // 列ヘッダクリア:開始col -> 3
            for(var i = 3; i < 26; i++)
            {
                this.dgvList.Columns[i].HeaderText = "";
                this.dgvList.Columns[i].Visible = true;
                i++;
            }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo ))
                {
                    // 選択専従先所属の従業員取得
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Mst_専従先専従者.id");
                    sb.AppendLine(", Mst_専従先専従者.location_id");
                    sb.AppendLine(", Mst_専従先専従者.staff_id");
                    sb.AppendLine(", Mst_専従先.fullname");
                    sb.AppendLine(", Mst_社員1.fullname AS StaffName");
                    sb.AppendLine(", Mst_専従先.instructor_id");
                    sb.AppendLine(", Mst_社員2.fullname AS 責任者名");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先専従者");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先専従者.location_id = Mst_専従先.id");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員 AS Mst_社員1");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先専従者.staff_id = Mst_社員1.staff_id");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_社員 AS Mst_社員2");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先.instructor_id = Mst_社員2.staff_id");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_専従先専従者.location_id = " + this.Location_id);
                    sb.AppendLine("AND");
                    sb.AppendLine("Mst_専従先専従者.staff_id<> Mst_専従先.instructor_id");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("Mst_専従先専従者.staff_id");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            if (row == 0) { this.lblInstructorName.Text = dr["責任者名"].ToString(); }

                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[row].Cells[2].Value = "全て";
                            this.dgvList.Rows[row].Cells["staff_name"].Value = dr["StaffName"].ToString();
                            this.dgvList.Rows[row].Cells["staff_id"].Value = dr["staff_id"].ToString();
                            row++;
                        }
                    }
                }

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 選択専従先の車両取得
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Mst_専従先車両.id");
                    sb.AppendLine(", Mst_専従先車両.no");
                    sb.AppendLine(", Mst_専従先車両.fullname");
                    sb.AppendLine(", Mst_専従先車両.name");
                    sb.AppendLine(", Mst_専従先車両.car_name");
                    sb.AppendLine(", Mst_専従先車両.location_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先車両");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_専従先車両.location_id = " + this.Location_id);
                    sb.AppendLine("AND");
                    sb.AppendLine("Mst_専従先車両.delete_flag = " + ClsPublic.FLAG_OFF);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("Mst_専従先車両.no");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        col = 3;
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Columns[col].HeaderText = dr["no"].ToString() + " : " + dr["name"].ToString();

                            for (row = 0; row < this.dgvList.Rows.Count; row++)
                            {
                                switch (col)
                                {
                                    case 3:                 // 車両1
                                        this.dgvList.Rows[row].Cells["car_id1"].Value = dr["id"].ToString();
                                        break;
                                    case 5:                 // 車両2
                                        this.dgvList.Rows[row].Cells["car_id2"].Value = dr["id"].ToString();
                                        break;
                                    case 7:                 // 車両3
                                        this.dgvList.Rows[row].Cells["car_id3"].Value = dr["id"].ToString();
                                        break;
                                    case 9:                 // 車両4
                                        this.dgvList.Rows[row].Cells["car_id4"].Value = dr["id"].ToString();
                                        break;
                                    case 11:                 // 車両5
                                        this.dgvList.Rows[row].Cells["car_id5"].Value = dr["id"].ToString();
                                        break;
                                    case 13:                 // 車両6
                                        this.dgvList.Rows[row].Cells["car_id6"].Value = dr["id"].ToString();
                                        break;
                                    case 15:                 // 車両7
                                        this.dgvList.Rows[row].Cells["car_id7"].Value = dr["id"].ToString();
                                        break;
                                    case 17:                 // 車両8
                                        this.dgvList.Rows[row].Cells["car_id8"].Value = dr["id"].ToString();
                                        break;
                                    case 19:                 // 車両9
                                        this.dgvList.Rows[row].Cells["car_id9"].Value = dr["id"].ToString();
                                        break;
                                    case 21:                 // 車両10
                                        this.dgvList.Rows[row].Cells["car_id10"].Value = dr["id"].ToString();
                                        break;
                                    case 23:                // 車両11
                                        this.dgvList.Rows[row].Cells["car_id11"].Value = dr["id"].ToString();
                                        break;
                                    case 25:                // 車両12
                                        this.dgvList.Rows[row].Cells["car_id12"].Value = dr["id"].ToString();
                                        break;

                                }
                            }
                            col += 2;
                        }
                    }

                    // 12車両に満たない場合、列を非表示
                    for (var i = col; i < 26; i++)
                    {
                        this.dgvList.Columns[i].Visible = false;
                        i++;
                    }

                    // ====================================
                    // 紐づけ情報を読み込み、画面に反映
                    // ====================================
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" location_id");
                    sb.AppendLine(",car_id");
                    sb.AppendLine(",staff_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先車両運転者定義");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + this.Location_id);
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("staff_id");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            p_row = 0;
                            p_col = 0;
                            // チェックボックスの位置を取得
                            GetRowCol(int.Parse(dr["car_id"].ToString()),
                                      int.Parse(dr["staff_id"].ToString()),
                                      ref p_row,
                                      ref p_col);

                            // チェックボックスをチェック状態にする
                            this.dgvList.Rows[p_row].Cells[p_col].Value = true;
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
        /// チェックを入れるチェックボックスの位置を取得
        /// </summary>
        /// <param name="p_car_id"></param>
        /// <param name="p_staff_id"></param>
        /// <param name="p_row"></param>
        /// <param name="p_col"></param>
        private void GetRowCol(int p_car_id, int p_staff_id, ref int p_row, ref int p_col)
        {
            int car_id;
            int staff_id = 0;
            int row = 0;
            int col;

            try
            {   
                for(row = 0; row < this.dgvList.Rows.Count; row++)
                {
                    // 専従者ID
                    staff_id = int.Parse(this.dgvList.Rows[row].Cells[1].Value.ToString());

                    for (col = 4; col < 27; col++)
                    {
                        if (this.dgvList.Columns[col-1].Visible == true)
                        {
                            if (this.dgvList.Rows[row].Cells[col].Value != null)
                            {
                                car_id = int.Parse(this.dgvList.Rows[row].Cells[col].Value.ToString());

                                // 各ID比較
                                if (p_car_id == car_id && p_staff_id == staff_id)
                                {
                                    p_row = row;
                                    p_col = col - 1;
                                    return;
                                }
                            }
                        }
                        col++;
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
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            int row = 0;
            int col;
            int staff_id = 0;
            int car_id;
            bool isChecked = false;

            // 専従先未選択の場合は処理終了
            if (this.Location_id <= 0) { return; }

            // 車両・専従者紐づけ情報保存　→　Mst_専従先車両運転者定義
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // ===============================
                    // 対象の専従先の紐づけ情報を削除
                    // ===============================
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_専従先車両運転者定義");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + this.Location_id);

                    clsSqlDb.DMLUpdate(sb.ToString());

                    // ===============================
                    // 紐づけ情報保存 INSERT
                    // ===============================
                    // 表示レコード件数分処理
                    for (row = 0; row < this.dgvList.Rows.Count; row++)
                    {
                        // 最大列数(12)分処理
                        for (col = 3; col < 26; col++)
                        {
                            if (this.dgvList.Columns[col].Visible == true)
                            {
                                // 行と列を指定してセルの値を取得
                                isChecked = Convert.ToBoolean(this.dgvList.Rows[row].Cells[col].Value);

                                // チェックの場合は保存
                                if (isChecked == true)
                                {
                                    // 専従者ID,車両ID取得
                                    staff_id = int.Parse(this.dgvList.Rows[row].Cells[1].Value.ToString());
                                    car_id = int.Parse(this.dgvList.Rows[row].Cells[col + 1].Value.ToString());

                                    sb.Clear();
                                    sb.AppendLine("INSERT INTO");
                                    sb.AppendLine("Mst_専従先車両運転者定義");
                                    sb.AppendLine("(");
                                    sb.AppendLine(" location_id");
                                    sb.AppendLine(",car_id");
                                    sb.AppendLine(",staff_id");
                                    // 2025/11/12↓
                                    sb.AppendLine(",ins_user_id");
                                    sb.AppendLine(",ins_date");
                                    sb.AppendLine(",delete_flag");
                                    // 2025/11/12↑
                                    sb.AppendLine(") VALUES (");
                                    sb.AppendLine(this.Location_id.ToString());
                                    sb.AppendLine("," + car_id);
                                    sb.AppendLine("," + staff_id);
                                    // 2025/11/12↓
                                    sb.AppendLine("," + ClsLoginUser.StaffID);
                                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                                    // 2025/11/12↑
                                    sb.AppendLine(")");

                                    clsSqlDb.DMLUpdate(sb.ToString());
                                }
                            }
                            col++;
                        }
                    }
                }
                MessageBox.Show("保存しました。", "結果", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// セルクリック（ボタン）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string s = "";

            // ボタン列がクリックされたかを確認
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                s = this.dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (s == "全て")
                {
                    this.dgvList.Rows[e.RowIndex].Cells[3].Value = true;
                    this.dgvList.Rows[e.RowIndex].Cells[5].Value = true;
                    this.dgvList.Rows[e.RowIndex].Cells[7].Value = true;
                    this.dgvList.Rows[e.RowIndex].Cells[9].Value = true;
                    this.dgvList.Rows[e.RowIndex].Cells[11].Value = true;
                    this.dgvList.Rows[e.RowIndex].Cells[13].Value = true;
                    this.dgvList.Rows[e.RowIndex].Cells[15].Value = true;
                    this.dgvList.Rows[e.RowIndex].Cells[17].Value = true;
                    this.dgvList.Rows[e.RowIndex].Cells[19].Value = true;
                    this.dgvList.Rows[e.RowIndex].Cells[21].Value = true;
                    this.dgvList.Rows[e.RowIndex].Cells[23].Value = true;
                    this.dgvList.Rows[e.RowIndex].Cells[25].Value = true;

                    this.dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "解除";
                }
                else
                {
                    this.dgvList.Rows[e.RowIndex].Cells[3].Value = false;
                    this.dgvList.Rows[e.RowIndex].Cells[5].Value = false;
                    this.dgvList.Rows[e.RowIndex].Cells[7].Value = false;
                    this.dgvList.Rows[e.RowIndex].Cells[9].Value = false;
                    this.dgvList.Rows[e.RowIndex].Cells[11].Value = false;
                    this.dgvList.Rows[e.RowIndex].Cells[13].Value = false;
                    this.dgvList.Rows[e.RowIndex].Cells[15].Value = false;
                    this.dgvList.Rows[e.RowIndex].Cells[17].Value = false;
                    this.dgvList.Rows[e.RowIndex].Cells[19].Value = false;
                    this.dgvList.Rows[e.RowIndex].Cells[21].Value = false;
                    this.dgvList.Rows[e.RowIndex].Cells[23].Value = false;
                    this.dgvList.Rows[e.RowIndex].Cells[25].Value = false;

                    this.dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "全て";
                }
            }
        }
    }
}
