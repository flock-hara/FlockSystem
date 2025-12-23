using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.求人関連
{
    public partial class frmRecruitMain : Form
    {
        private readonly StringBuilder sb = new();

        public frmRecruitMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRecruitMain_Load(object sender, EventArgs e)
        {
            InitializeList();
            DisplayPublish(0);

            // 権限判定→ボタン制御
            if (ClsLoginUser.RecruitManageFlag != 1)
            {
                // 権限無しの場合は閲覧のみ可能とする
                this.btnMenu1.Enabled = false;
                this.btnMenu2.Enabled = false;
                this.btnMenu3.Enabled = false;
                this.btnMenu4.Enabled = false;
                this.btnMenu5.Enabled = false;
                this.btnMenu6.Enabled = false;
            }
        }
        /// <summary>
        /// Initialize DataGridView
        /// </summary>
        private void InitializeList()
        {
            // ==========================================
            // 載一覧表示
            // ==========================================
            dgvPublish.Columns.Clear();

            DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();     // 1列目を定義：ID
            DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();     // 2列目を定義：専従先ID
            DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();     // 3列目を定義：専従先名
            DataGridViewTextBoxColumn col04 = new DataGridViewTextBoxColumn();     // 4列目を定義：専従先備考
            DataGridViewTextBoxColumn col05 = new DataGridViewTextBoxColumn();     // 5列目を定義：所属ID
            DataGridViewTextBoxColumn col06 = new DataGridViewTextBoxColumn();     // 6列目を定義：所属名
            DataGridViewTextBoxColumn col07 = new DataGridViewTextBoxColumn();     // 7列目を定義：掲載先
            DataGridViewTextBoxColumn col08 = new DataGridViewTextBoxColumn();     // 8列目を定義：掲載日
            DataGridViewTextBoxColumn col09 = new DataGridViewTextBoxColumn();     // 9列目を定義：欠員人数
            DataGridViewTextBoxColumn col10 = new DataGridViewTextBoxColumn();     // 10列目を定義：欠員人数
            DataGridViewTextBoxColumn col11 = new DataGridViewTextBoxColumn();     // 11列目を定義：PDF
            DataGridViewTextBoxColumn col12 = new DataGridViewTextBoxColumn();     // 12列目を定義：PDF
            DataGridViewTextBoxColumn col13 = new DataGridViewTextBoxColumn();     // 13列目を定義：
            DataGridViewTextBoxColumn col14 = new DataGridViewTextBoxColumn();     // 14列目を定義：備考

            col01.Name = "ID";
            col01.HeaderText = "名前";
            col01.Width = 100;
            col01.ReadOnly = true;
            col01.Visible = false;
            dgvPublish.Columns.Add(col01);

            col02.Name = "LocationID";
            col02.HeaderText = "LocationID";
            col02.Width = 100;
            col02.ReadOnly = true;
            col02.Visible = false;
            dgvPublish.Columns.Add(col02);

            col03.Name = "LocationName";
            col03.HeaderText = "求人元";
            col03.Width = 210;
            col03.ReadOnly = true;
            col03.Visible = true;
            dgvPublish.Columns.Add(col03);

            col04.Name = "LocationComment";
            col04.HeaderText = "";
            col04.Width = 150;
            col04.ReadOnly = true;
            col04.Visible = false;
            dgvPublish.Columns.Add(col04);

            col05.Name = "OfficeID";
            col05.HeaderText = "OfficeID";
            col05.Width = 100;
            col05.ReadOnly = true;
            col05.Visible = false;
            dgvPublish.Columns.Add(col05);

            col06.Name = "OfficeName";
            col06.HeaderText = "所属先";
            col06.Width = 150;
            col06.ReadOnly = true;
            col06.Visible = false;
            dgvPublish.Columns.Add(col06);

            col07.Name = "Publish";
            col07.HeaderText = "掲載先";
            col07.Width = 135;
            col07.ReadOnly = true;
            col07.Visible = true;
            dgvPublish.Columns.Add(col07);

            col08.Name = "PublishDate";
            col08.HeaderText = "掲載日";
            col08.Width = 120;
            col08.ReadOnly = true;
            col08.Visible = true;
            dgvPublish.Columns.Add(col08);

            col09.Name = "Vacancy";
            col09.HeaderText = "欠員数";
            col09.Width = 65;
            col09.ReadOnly = true;
            col09.Visible = true;
            dgvPublish.Columns.Add(col09);

            col10.Name = "Apply";
            col10.HeaderText = "応募";
            col10.Width = 65;
            col10.ReadOnly = true;
            col10.Visible = true;
            dgvPublish.Columns.Add(col10);

            col11.Name = "FilePath1";
            col11.HeaderText = "添付";
            col11.Width = 47;
            col11.ReadOnly = true;
            col11.Visible = true;
            dgvPublish.Columns.Add(col11);

            col12.Name = "FilePath2";
            col12.HeaderText = "PDF";
            col12.Width = 47;
            col12.ReadOnly = true;
            col12.Visible = false;
            dgvPublish.Columns.Add(col12);

            col13.Name = "PublishFlag";
            col13.HeaderText = "colPublishFlag";
            col13.Width = 47;
            col13.ReadOnly = true;
            col13.Visible = false;
            dgvPublish.Columns.Add(col13);

            col14.Name = "Comment";
            col14.HeaderText = "colComment";
            col14.Width = 47;
            col14.ReadOnly = true;
            col14.Visible = false;
            dgvPublish.Columns.Add(col14);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvPublish.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            // 行ヘッダー LIST_FONT_TYPE_GOS
            // dgvPublish.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("メイリオ", 10);
            dgvPublish.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);
            dgvPublish.EnableHeadersVisualStyles = false;                                               // Windows Color無効
            dgvPublish.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;   // 列ヘッダ色
            dgvPublish.RowTemplate.Height = 30;                                                         // 行高さ
            dgvPublish.AllowUserToResizeColumns = false;                                                // 列幅の変更不可
            dgvPublish.AllowUserToResizeRows = false;                                                   // 行高さの変更不可
            dgvPublish.MultiSelect = false;                                                             // 複数選択不可
            dgvPublish.ReadOnly = true;                                                                 // 表示専用
            dgvPublish.AllowUserToAddRows = false;                                                      // 行自動追加不可
            dgvPublish.RowHeadersVisible = false;                                                       // 行ヘッダ非表示

            dgvPublish.Columns["LocationName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // セルの文字表示位置
            dgvPublish.Columns["Publish"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        // セルの文字表示位置
            dgvPublish.Columns["PublishDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // セルの文字表示位置
            dgvPublish.Columns["Vacancy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        // セルの文字表示位置            dgvPublish.Columns("Apply").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter            'セルの文字表示位置
            dgvPublish.Columns["FilePath1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            // セルの文字表示位置
            dgvPublish.Columns["Apply"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;          // セルの文字表示位置

            dgvPublish.Columns["LocationName"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);        // フォント設定
            dgvPublish.Columns["Publish"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);          // フォント設定
            dgvPublish.Columns["PublishDate"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);      // フォント設定
            dgvPublish.Columns["Vacancy"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);          // フォント設定
            dgvPublish.Columns["Apply"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);            // フォント設定
            dgvPublish.Columns["FilePath1"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);              // フォント設定

            // セルの文字表示位置
            DataGridViewCellStyle columnHeaderStyle = dgvPublish.ColumnHeadersDefaultCellStyle;
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPublish.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Bisque;

            // ==========================================
            // 応募者表示
            // ==========================================
            dgvApply.Columns.Clear();

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();                      // 1列目を定義：ID
            DataGridViewTextBoxColumn colHeaderID = new DataGridViewTextBoxColumn();                // 2列目を定義：ヘッダID
            DataGridViewTextBoxColumn colApplyName = new DataGridViewTextBoxColumn();               // 3列目を定義：応募者
            DataGridViewTextBoxColumn colApplyDate = new DataGridViewTextBoxColumn();               // 3列目を定義：応募日付
            DataGridViewTextBoxColumn colRireki = new DataGridViewTextBoxColumn();                  // 4列目を定義：履歴書
            DataGridViewTextBoxColumn colRireki2 = new DataGridViewTextBoxColumn();                 // 5列目を定義：履歴書
            DataGridViewTextBoxColumn colInterviewDate = new DataGridViewTextBoxColumn();           // 6列目を定義：面接日
            DataGridViewTextBoxColumn colResult = new DataGridViewTextBoxColumn();                  // 7列目を定義：面接結果
            DataGridViewTextBoxColumn colResult2 = new DataGridViewTextBoxColumn();                 // 8列目を定義：面接結果
            DataGridViewTextBoxColumn colKensinScheduleDate = new DataGridViewTextBoxColumn();      // 9列目を定義：健診日
            DataGridViewTextBoxColumn colKensinFlag = new DataGridViewTextBoxColumn();              // 10列目を定義：健診受診
            DataGridViewTextBoxColumn colKensinFlag2 = new DataGridViewTextBoxColumn();             // 11列目を定義：健診受診
            DataGridViewTextBoxColumn colInCompanyScheduleDate = new DataGridViewTextBoxColumn();   // 12列目を定義：入社予定日
            DataGridViewTextBoxColumn colInCompanyDate = new DataGridViewTextBoxColumn();           // 13列目を定義：入社日
            DataGridViewTextBoxColumn colFilePath1 = new DataGridViewTextBoxColumn();               // 14列目を定義：PDF
            DataGridViewTextBoxColumn colFilePath2 = new DataGridViewTextBoxColumn();               // 15列目を定義：PDF
            DataGridViewTextBoxColumn colComment = new DataGridViewTextBoxColumn();                 // 16列目を定義：補足
            DataGridViewTextBoxColumn colInterviewDateFlag = new DataGridViewTextBoxColumn();       // 17列目を定義：補足
            DataGridViewTextBoxColumn colKensinScheduleDateFlag = new DataGridViewTextBoxColumn();  // 18列目を定義：補足
            DataGridViewTextBoxColumn colInCompanyScheduleDateFlag = new DataGridViewTextBoxColumn(); // 19列目を定義：補足
            DataGridViewTextBoxColumn colInCompanyDateFlag = new DataGridViewTextBoxColumn();       // 20列目を定義：補足

            colID.Name = "ID";
            colID.HeaderText = "ID";
            colID.Width = 100;
            colID.ReadOnly = true;
            colID.Visible = false;
            dgvApply.Columns.Add(colID);

            colHeaderID.Name = "HeaderID";
            colHeaderID.HeaderText = "HeaderID";
            colHeaderID.Width = 100;
            colHeaderID.ReadOnly = true;
            colHeaderID.Visible = false;
            dgvApply.Columns.Add(colHeaderID);

            colApplyName.Name = "ApplyName";
            colApplyName.HeaderText = "応募者";
            colApplyName.Width = 110;
            colApplyName.ReadOnly = true;
            colApplyName.Visible = true;
            dgvApply.Columns.Add(colApplyName);

            colApplyDate.Name = "ApplyDate";
            colApplyDate.HeaderText = "応募日付";
            colApplyDate.Width = 120;
            colApplyDate.ReadOnly = true;
            colApplyDate.Visible = true;
            dgvApply.Columns.Add(colApplyDate);

            colRireki.Name = "Rireki";
            colRireki.HeaderText = "履歴書";
            colRireki.Width = 70;
            colRireki.ReadOnly = true;
            colRireki.Visible = true;
            dgvApply.Columns.Add(colRireki);

            colRireki2.Name = "Rireki2";
            colRireki2.HeaderText = "履歴書";
            colRireki2.Width = 70;
            colRireki2.ReadOnly = true;
            colRireki2.Visible = false;
            dgvApply.Columns.Add(colRireki2);

            colInterviewDate.Name = "InterviewDate";
            colInterviewDate.HeaderText = "面接日";
            colInterviewDate.Width = 120;
            colInterviewDate.ReadOnly = true;
            colInterviewDate.Visible = true;
            dgvApply.Columns.Add(colInterviewDate);

            colResult.Name = "Result";
            colResult.HeaderText = "結果";
            colResult.Width = 70;
            colResult.ReadOnly = true;
            colResult.Visible = true;
            dgvApply.Columns.Add(colResult);

            colResult2.Name = "Result2";
            colResult2.HeaderText = "結果";
            colResult2.Width = 70;
            colResult2.ReadOnly = true;
            colResult2.Visible = false;
            dgvApply.Columns.Add(colResult2);

            colKensinScheduleDate.Name = "KensinScheduleDate";
            colKensinScheduleDate.HeaderText = "健診日";
            colKensinScheduleDate.Width = 120;
            colKensinScheduleDate.ReadOnly = true;
            colKensinScheduleDate.Visible = true;
            dgvApply.Columns.Add(colKensinScheduleDate);

            colKensinFlag.Name = "KensinFlag";
            colKensinFlag.HeaderText = "受診";
            colKensinFlag.Width = 75;
            colKensinFlag.ReadOnly = true;
            colKensinFlag.Visible = false;
            dgvApply.Columns.Add(colKensinFlag);

            colKensinFlag2.Name = "KensinFlag2";
            colKensinFlag2.HeaderText = "受診";
            colKensinFlag2.Width = 75;
            colKensinFlag2.ReadOnly = true;
            colKensinFlag2.Visible = false;
            dgvApply.Columns.Add(colKensinFlag2);

            colInCompanyScheduleDate.Name = "InCompanyScheduleDate";
            colInCompanyScheduleDate.HeaderText = "入社予定日";
            colInCompanyScheduleDate.Width = 120;
            colInCompanyScheduleDate.ReadOnly = true;
            colInCompanyScheduleDate.Visible = true;
            dgvApply.Columns.Add(colInCompanyScheduleDate);

            colInCompanyDate.Name = "InCompanyDate";
            colInCompanyDate.HeaderText = "入社日";
            colInCompanyDate.Width = 120;
            colInCompanyDate.ReadOnly = true;
            colInCompanyDate.Visible = false;
            dgvApply.Columns.Add(colInCompanyDate);

            colFilePath1.Name = "FilePath1";
            colFilePath1.HeaderText = "添付";
            colFilePath1.Width = 47;
            colFilePath1.ReadOnly = true;
            colFilePath1.Visible = true;
            dgvApply.Columns.Add(colFilePath1);

            colFilePath2.Name = "FilePath2";
            colFilePath2.HeaderText = "PDF";
            colFilePath2.Width = 47;
            colFilePath2.ReadOnly = true;
            colFilePath2.Visible = false;
            dgvApply.Columns.Add(colFilePath2);

            colComment.Name = "Comment";
            colComment.HeaderText = "補足";
            colComment.Width = 150;
            colComment.ReadOnly = true;
            colComment.Visible = false;
            dgvApply.Columns.Add(colComment);

            colInterviewDateFlag.Name = "InterviewDateFlag";
            colInterviewDateFlag.HeaderText = "";
            colInterviewDateFlag.Width = 150;
            colInterviewDateFlag.ReadOnly = true;
            colInterviewDateFlag.Visible = false;
            dgvApply.Columns.Add(colInterviewDateFlag);

            colKensinScheduleDateFlag.Name = "KensinScheduleDateFlag";
            colKensinScheduleDateFlag.HeaderText = "";
            colKensinScheduleDateFlag.Width = 150;
            colKensinScheduleDateFlag.ReadOnly = true;
            colKensinScheduleDateFlag.Visible = false;
            dgvApply.Columns.Add(colKensinScheduleDateFlag);

            colInCompanyScheduleDateFlag.Name = "InCompanyScheduleDateFlag";
            colInCompanyScheduleDateFlag.HeaderText = "";
            colInCompanyScheduleDateFlag.Width = 150;
            colInCompanyScheduleDateFlag.ReadOnly = true;
            colInCompanyScheduleDateFlag.Visible = false;
            dgvApply.Columns.Add(colInCompanyScheduleDateFlag);

            colInCompanyDateFlag.Name = "InCompanyDateFlag";
            colInCompanyDateFlag.HeaderText = "";
            colInCompanyDateFlag.Width = 150;
            colInCompanyDateFlag.ReadOnly = true;
            colInCompanyDateFlag.Visible = false;
            dgvApply.Columns.Add(colInCompanyDateFlag);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvApply.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            // 行ヘッダー
            // dgvApply.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("メイリオ", 10)
            dgvApply.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);
            dgvApply.EnableHeadersVisualStyles = false;                                                 // Windows Color無効
            dgvApply.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;     // 列ヘッダ色
            dgvApply.RowTemplate.Height = 30;                                                           // 行高さ
            dgvApply.AllowUserToResizeColumns = false;                                                  // 列幅の変更不可
            dgvApply.AllowUserToResizeRows = false;                                                     // 行高さの変更不可
            // dgvApply.ScrollBars = false;                                                                // スクロールバー非表示
            dgvApply.MultiSelect = false;                                                               // 複数選択不可
            dgvApply.ReadOnly = true;                                                                   // 表示専用
            dgvApply.AllowUserToAddRows = false;                                                        // 行自動追加不可
            dgvApply.RowHeadersVisible = false;                                                         // 行ヘッダ非表示

            dgvApply.Columns["ApplyName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;               // セルの文字表示位置
            dgvApply.Columns["ApplyDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;               // セルの文字表示位置
            dgvApply.Columns["Rireki"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                  // セルの文字表示位置
            dgvApply.Columns["InterviewDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           // セルの文字表示位置
            dgvApply.Columns["Result"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                  // セルの文字表示位置
            dgvApply.Columns["KensinScheduleDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      // セルの文字表示位置
            dgvApply.Columns["KensinFlag"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;              // セルの文字表示位置
            dgvApply.Columns["InCompanyScheduleDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   // セルの文字表示位置
            dgvApply.Columns["InCompanyDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           // セルの文字表示位置
            dgvApply.Columns["FilePath1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;               // セルの文字表示位置
            dgvApply.Columns["Comment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                 // セルの文字表示位置

            dgvApply.Columns["ApplyName"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);             // フォント設定
            dgvApply.Columns["ApplyDate"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);             // フォント設定
            dgvApply.Columns["Rireki"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);                // フォント設定
            dgvApply.Columns["InterviewDate"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);         // フォント設定
            dgvApply.Columns["Result"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);                // フォント設定
            dgvApply.Columns["KensinScheduleDate"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);    // フォント設定
            dgvApply.Columns["KensinFlag"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);            // フォント設定
            dgvApply.Columns["InCompanyScheduleDate"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10); // フォント設定
            dgvApply.Columns["InCompanyDate"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);         // フォント設定
            dgvApply.Columns["FilePath1"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);             // フォント設定
            dgvApply.Columns["Comment"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.LIST_FONT_TYPE_GOS, 10);               // フォント設定

            // セルの文字表示位置
            DataGridViewCellStyle columnHeaderStyle2 = dgvApply.ColumnHeadersDefaultCellStyle;
            // Dim columnHeaderStyle As DataGridViewCellStyle = dgvApply.ColumnHeadersDefaultCellStyle
            columnHeaderStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvApply.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.PapayaWhip;

            //With pclsPubIF
            //    .ID = -1
            //    .SenjuID = -1
            //    .Publish = ""
            //    .PublishDate = "1900/01/01"
            //    .Vacancy = -1
            //    .Pic = ""
            //    .Pdf = ""
            //    .PublishFlag = 0
            //    .Comment = ""
            //    .SenjuComment = ""
            //End With
        }
        /// <summary>
        /// 応募内容表示
        /// </summary>
        private void DisplayPublish(int p_flag)
        {
            dgvPublish.Rows.Clear();

            try
            {
                //st.Length = 0;
                //st.AppendLine("SELECT");
                //st.AppendLine(" Trn_求人掲載.ID AS ID");
                //st.AppendLine(",Trn_求人掲載.LocationID");
                //st.AppendLine(",Trn_求人掲載.LocationName");
                //st.AppendLine(",Trn_求人掲載.Publish");
                //st.AppendLine(",Trn_求人掲載.PublishDate");
                //st.AppendLine(",Trn_求人掲載.Vacancy");
                //st.AppendLine(",Trn_求人掲載.Filepath1");
                //st.AppendLine(",Trn_求人掲載.FilePath2");
                //st.AppendLine(",Trn_求人掲載.PublishFlag");
                //st.AppendLine(",Trn_求人掲載.Comment");
                //st.AppendLine(",Trn_求人掲載.LocationComment");
                //st.AppendLine(",Trn_求人応募者.HeaderID");
                //st.AppendLine("FROM");
                //st.AppendLine("Trn_求人掲載");
                //st.AppendLine("LEFT JOIN");
                //st.AppendLine("Trn_求人応募者");
                //st.AppendLine("ON");
                //st.AppendLine("Trn_求人掲載.ID = Trn_求人応募者.HeaderID");
                ////st.AppendLine("AND");
                ////st.AppendLine("Trn_求人応募者.RirekiFlag = 1");
                //st.AppendLine("WHERE");

                //if (p_flag == 0)
                //{
                //    // 掲載中
                //    st.AppendLine("PublishFlag = 0");
                //}
                //else
                //{
                //    // 掲載終了分
                //    st.AppendLine("PublishFlag = 1");
                //}
                //st.AppendLine("ORDER BY");
                //st.AppendLine("LocationID");
                //st.AppendLine(",LocationComment");
                //st.AppendLine(",PublishDate");

                int row = 0;
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Trn_求人掲載.id AS id");
                    sb.AppendLine(",Trn_求人掲載.location_id");
                    sb.AppendLine(",Trn_求人掲載.location_name");
                    sb.AppendLine(",Trn_求人掲載.publish");
                    sb.AppendLine(",Trn_求人掲載.publish_date");
                    sb.AppendLine(",Trn_求人掲載.vacancy");
                    sb.AppendLine(",Trn_求人掲載.file_path1");
                    sb.AppendLine(",Trn_求人掲載.file_path2");
                    sb.AppendLine(",Trn_求人掲載.publish_flag");
                    sb.AppendLine(",Trn_求人掲載.comment");
                    sb.AppendLine(",Trn_求人掲載.location_comment");
                    sb.AppendLine(",Trn_求人応募者.header_id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_求人掲載");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Trn_求人応募者");
                    sb.AppendLine("ON");
                    sb.AppendLine("Trn_求人掲載.id = Trn_求人応募者.header_id");
                    sb.AppendLine("WHERE");

                    if (p_flag == 0)
                    {
                        // 掲載中
                        sb.AppendLine("publish_flag = 0");
                    }
                    else
                    {
                        // 掲載終了分
                        sb.AppendLine("publish_flag = 1");
                    }
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine(" location_id");
                    sb.AppendLine(",location_comment");
                    sb.AppendLine(",publish_date");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvPublish.Rows.Add();
                            this.dgvPublish.Rows[row].Cells["ID"].Value = dr["id"].ToString();
                            this.dgvPublish.Rows[row].Cells["LocationID"].Value = dr["location_id"].ToString();
                            if (dr["location_comment"].ToString() != "")
                            {
                                this.dgvPublish.Rows[row].Cells["LocationName"].Value = dr["location_name"] + " (" + dr["location_comment"] + ")";
                            }
                            else
                            {
                                this.dgvPublish.Rows[row].Cells["LocationName"].Value = dr["location_name"];
                            }
                            this.dgvPublish.Rows[row].Cells["LocationComment"].Value = dr["location_comment"];
                            this.dgvPublish.Rows[row].Cells["Publish"].Value = dr["publish"];

                            // 掲載日
                            if (DateTime.Parse(dr["publish_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.dgvPublish.Rows[row].Cells["PublishDate"].Value = ""; }
                            else { this.dgvPublish.Rows[row].Cells["PublishDate"].Value = DateTime.Parse(dr["publish_date"].ToString()).ToString("yyyy/MM/dd"); }

                            this.dgvPublish.Rows[row].Cells["Vacancy"].Value = dr["vacancy"];

                            // ヘッダーIDがNULL→応募者なし
                            if (dr["header_id"] != null && dr["header_id"].ToString() != "")
                            {
                                this.dgvPublish.Rows[row].Cells["Apply"].Value = "〇";
                            }
                            else
                            {
                                this.dgvPublish.Rows[row].Cells["Apply"].Value = "";
                            }

                            if (dr["file_path1"].ToString() != "")
                            {
                                this.dgvPublish.Rows[row].Cells["FilePath1"].Value = "〇";
                            }
                            this.dgvPublish.Rows[row].Cells["Filepath2"].Value = dr["file_path2"];
                            this.dgvPublish.Rows[row].Cells["PublishFlag"].Value = dr["publish_flag"];
                            this.dgvPublish.Rows[row].Cells["Comment"].Value = dr["comment"];
                            row++;
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
        /// 掲載一覧クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPublish_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = int.Parse(this.dgvPublish.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            DisplayApply(id);

            this.dgvApply.CurrentCell = null;
        }
        /// <summary>
        /// 応募者一覧表示
        /// </summary>
        /// <param name="p_id"></param>
        private void DisplayApply(int p_id)
        {
            int row = 0;
            
            this.dgvApply.Rows.Clear();

            try
            {
                //st.Length = 0;
                //st.AppendLine("SELECT");
                //st.AppendLine("ID");
                //st.AppendLine(",HeaderID");
                //st.AppendLine(",ApplyName");
                //st.AppendLine(",ApplyDate");
                //st.AppendLine(",RirekiFlag");
                //st.AppendLine(",InterviewDate");
                //st.AppendLine(",Result");
                //st.AppendLine(",KensinScheduleDate");
                //st.AppendLine(",KensinFlag");
                //st.AppendLine(",InCompanyScheduleDate");
                //st.AppendLine(",InCompanyDate");
                //st.AppendLine(",FilePath1");
                //st.AppendLine(",FilePath2");
                //st.AppendLine(",Comment");
                //st.AppendLine(",InterviewDateFlag");
                //st.AppendLine(",KensinScheduleDateFlag");
                //st.AppendLine(",InCompanyScheduleDateFlag");
                //st.AppendLine(",InCompanyDateFlag");
                //st.AppendLine(" FROM Trn_求人応募者");
                //st.AppendLine(" WHERE");
                //st.AppendLine(" HeaderID = " + p_id);
                //st.AppendLine(" ORDER BY ID");

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",header_id");
                    sb.AppendLine(",apply_name");
                    sb.AppendLine(",apply_date");
                    sb.AppendLine(",rireki_flag");
                    sb.AppendLine(",interview_date");
                    sb.AppendLine(",result");
                    sb.AppendLine(",kensin_schedule_date");
                    sb.AppendLine(",kensin_flag");
                    sb.AppendLine(",in_company_schedule_date");
                    sb.AppendLine(",in_company_date");
                    sb.AppendLine(",file_path1");
                    sb.AppendLine(",file_path2");
                    sb.AppendLine(",comment");
                    sb.AppendLine(",interview_date_flag");
                    sb.AppendLine(",kensin_schedule_date_flag");
                    sb.AppendLine(",in_company_schedule_date_flag");
                    sb.AppendLine(",in_company_date_flag");
                    sb.AppendLine(" FROM Trn_求人応募者");
                    sb.AppendLine(" WHERE");
                    sb.AppendLine(" header_id = " + p_id);
                    sb.AppendLine(" ORDER BY id");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvApply.Rows.Add();                                       // 行追加
                                                                                            // ID
                            this.dgvApply.Rows[row].Cells["ID"].Value = dr["id"];
                            // 掲載ID
                            this.dgvApply.Rows[row].Cells["HeaderID"].Value = dr["header_id"];
                            // 応募者名
                            this.dgvApply.Rows[row].Cells["ApplyName"].Value = dr["apply_name"];
                            // 応募日付
                            if (DateTime.Parse(dr["apply_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.dgvApply.Rows[row].Cells["ApplyDate"].Value = ""; }
                            else { this.dgvApply.Rows[row].Cells["ApplyDate"].Value = DateTime.Parse(dr["apply_date"].ToString()).ToString("yyyy/MM/dd"); }
                            // 面接日付
                            if (DateTime.Parse(dr["interview_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.dgvApply.Rows[row].Cells["InterviewDate"].Value = ""; }
                            else { this.dgvApply.Rows[row].Cells["InterviewDate"].Value = DateTime.Parse(dr["interview_date"].ToString()).ToString("yyyy/MM/dd"); }
                            // 履歴書有無
                            switch (int.Parse(dr["rireki_flag"].ToString()))
                            {
                                case -1:
                                    this.dgvApply.Rows[row].Cells["Rireki"].Value = "";
                                    break;

                                case 0:
                                    this.dgvApply.Rows[row].Cells["Rireki"].Value = "無し";
                                    break;

                                case 1:
                                    this.dgvApply.Rows[row].Cells["Rireki"].Value = "有り";
                                    break;
                            }
                            this.dgvApply.Rows[row].Cells["Rireki2"].Value = dr["rireki_flag"];
                            // 面接結果
                            switch (int.Parse(dr["result"].ToString()))
                            {
                                case 0:
                                    this.dgvApply.Rows[row].Cells["Result"].Value = "";
                                    break;
                                case 1:
                                    this.dgvApply.Rows[row].Cells["Result"].Value = "〇";
                                    break;
                                case 2:
                                    // 値２はない
                                    this.dgvApply.Rows[row].Cells["Result"].Value = "×";
                                    break;
                            }
                            this.dgvApply.Rows[row].Cells["Result2"].Value = dr["result"];
                            // 健康診断予定日
                            if (DateTime.Parse(dr["kensin_schedule_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.dgvApply.Rows[row].Cells["KensinScheduleDate"].Value = ""; }
                            else { this.dgvApply.Rows[row].Cells["KensinScheduleDate"].Value = DateTime.Parse(dr["kensin_schedule_date"].ToString()).ToString("yyyy/MM/dd"); }
                            // 診断結果受領
                            switch (int.Parse(dr["kensin_flag"].ToString()))
                            {
                                case -1:
                                    this.dgvApply.Rows[row].Cells["KensinFlag"].Value = "";
                                    break;
                                case 0:
                                    this.dgvApply.Rows[row].Cells["KensinFlag"].Value = "未";
                                    break;
                                case 1:
                                    this.dgvApply.Rows[row].Cells["KensinFlag"].Value = "受";
                                    break;
                            }
                            this.dgvApply.Rows[row].Cells["KensinFlag2"].Value = dr["kensin_flag"];
                            // 入社予定日
                            if (DateTime.Parse(dr["in_company_schedule_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.dgvApply.Rows[row].Cells["InCompanyScheduleDate"].Value = ""; }
                            else { this.dgvApply.Rows[row].Cells["InCompanyScheduleDate"].Value = DateTime.Parse(dr["in_company_schedule_date"].ToString()).ToString("yyyy/MM/dd"); }
                            // 入社日
                            if (DateTime.Parse(dr["in_company_date"].ToString()).ToString("yyyy/MM/dd") == "1900/01/01") { this.dgvApply.Rows[row].Cells["InCompanyDate"].Value = ""; }
                            else { this.dgvApply.Rows[row].Cells["InCompanyDate"].Value = DateTime.Parse(dr["in_company_date"].ToString()).ToString("yyyy/MM/dd"); }

                            if (dr["file_path1"].ToString() != "")
                            {
                                this.dgvApply.Rows[row].Cells["FilePath1"].Value = "〇";
                            }
                            this.dgvApply.Rows[row].Cells["FilePath2"].Value = dr["file_path2"];
                            this.dgvApply.Rows[row].Cells["Comment"].Value = dr["comment"];
                            row++;
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
        /// 掲載終了分チェックボックス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEnd.Checked == true) { DisplayPublish(1); }
            else { DisplayPublish(0); }
        }
        /// <summary>
        /// 掲載追加ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu1_Click(object sender, EventArgs e)
        {
            frmRecruitPublish frm = new()
            {
                Header_id = 0
            };
            frm.ShowDialog();
            DisplayPublish(0);
        }
        /// <summary>
        /// 掲載編集ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu2_Click(object sender, EventArgs e)
        {
            if (this.dgvPublish.SelectedRows.Count < 1) { return; }

            DataGridViewRow selectedRow = dgvPublish.SelectedRows[0];
            var id = int.Parse(selectedRow.Cells[0].Value.ToString());

            frmRecruitPublish frm = new()
            {
                Header_id = id
            };
            frm.ShowDialog();
            DisplayPublish(0);
        }
        /// <summary>
        /// 掲載削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu3_Click(object sender, EventArgs e)
        {
            if (this.dgvPublish.SelectedRows.Count < 1) { return; }

            DataGridViewRow selectedRow = dgvPublish.SelectedRows[0];
            var id = int.Parse(selectedRow.Cells[0].Value.ToString());

            if (MessageBox.Show("選択されている掲載先を削除します。","確認",MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_求人掲載");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }

                MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
                DisplayPublish(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        /// <summary>
        /// 応募者追加ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu4_Click(object sender, EventArgs e)
        {
            // ============================================================================
            // 掲載情報
            // ============================================================================
            if (this.dgvPublish.SelectedRows.Count < 1) { return; }

            DataGridViewRow selectedRow = dgvPublish.SelectedRows[0];
            var header_id = int.Parse(selectedRow.Cells[0].Value.ToString());
            var location_id = int.Parse(selectedRow.Cells["LocationID"].Value.ToString());
            var location_name = selectedRow.Cells["LocationName"].Value.ToString();
            // var location_comment = selectedRow.Cells["LocationComment"].Value.ToString();
            var publish = selectedRow.Cells["Publish"].Value.ToString();
            var publish_date = selectedRow.Cells["PublishDate"].Value.ToString();

            frmRecruitApply frm = new()
            {
                Id = 0,
                Header_id = header_id,
                Location_id = location_id,
                Location_name = location_name,
                Publish_name = publish,
                Publish_date = publish_date
            };
            frm.ShowDialog();

            // 再表示
            DisplayPublish(0);
            SelectPublish(header_id);
            DisplayApply(header_id);
        }
        /// <summary>
        /// 指定ヘッダーを選択状態にする
        /// </summary>
        /// <param name="p_header_id"></param>
        private void SelectPublish(int p_header_id)
        {
            for (var row = 0; row < this.dgvPublish.Rows.Count; row++)
            {
                if (int.Parse(this.dgvPublish.Rows[row].Cells["ID"].Value.ToString()) == p_header_id)
                {
                    // ID一致で選択状態にする
                    this.dgvPublish.Rows[row].Selected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 応募者編集ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu5_Click(object sender, EventArgs e)
        {
            // 選択チェック
            if (this.dgvPublish.SelectedRows.Count < 1) { return; }
            if (this.dgvApply.SelectedRows.Count < 1) { return; }

            // ============================================================================
            // 掲載情報
            // ============================================================================
            DataGridViewRow selectedRow = dgvPublish.SelectedRows[0];
            var header_id = int.Parse(selectedRow.Cells[0].Value.ToString());
            var location_id = int.Parse(selectedRow.Cells["LocationID"].Value.ToString());
            var location_name = selectedRow.Cells["LocationName"].Value.ToString();
            var publish = selectedRow.Cells["Publish"].Value.ToString();
            var publish_date = selectedRow.Cells["PublishDate"].Value.ToString();

            // ============================================================================
            // 応募者情報
            // ============================================================================
            selectedRow = dgvApply.SelectedRows[0];
            var id = int.Parse(selectedRow.Cells[0].Value.ToString());

            frmRecruitApply frm = new()
            {
                Id = id,
                Header_id = header_id,
                Location_id = location_id,
                Location_name = location_name,
                Publish_name = publish,
                Publish_date = publish_date
            };
            frm.ShowDialog();

            // 再表示
            DisplayPublish(0);
            SelectPublish(header_id);
            DisplayApply(header_id);
        }
        /// <summary>
        /// 応募者削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu6_Click(object sender, EventArgs e)
        {
            // 選択チェック
            if (this.dgvPublish.SelectedRows.Count < 1) { return; }
            if (this.dgvApply.SelectedRows.Count < 1) { return; }

            // ============================================================================
            // 応募者情報
            // ============================================================================
            DataGridViewRow selectedRow = dgvApply.SelectedRows[0];
            var id = int.Parse(selectedRow.Cells[0].Value.ToString());

            if (MessageBox.Show("選択されている応募者を削除します。", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Trn_求人応募者");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("id = " + id);
                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            // 再表示
            int header_id = int.Parse(this.dgvPublish.Rows[this.dgvPublish.SelectedRows[0].Index].Cells["ID"].Value.ToString());
            DisplayPublish(0);
            DisplayApply(header_id);
        }

        private void dgvApply_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;

            //int id = int.Parse(this.dgvApply.Rows[e.RowIndex].Cells["ID"].Value.ToString());
        }

        private void btnMenu10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 一覧表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (frmPublishList frm = new())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 自動スクロール
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPublish_SelectionChanged(object sender, EventArgs e)
        {
            //// 選択された行のインデックスを取得
            //int selectedRowIndex = this.dgvPublish.SelectedRows[0].Index;

            //// 表示可能な行数の半分を取得
            //int visibleRowCount = this.dgvPublish.DisplayedRowCount(false);
            //int middleRowIndex = Math.Max(0, selectedRowIndex - (visibleRowCount / 2));

            //// 選択行を中央に表示するようにスクロール
            //this.dgvPublish.FirstDisplayedScrollingRowIndex = middleRowIndex;
        }
    }
}
