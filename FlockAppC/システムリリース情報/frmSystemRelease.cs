using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC
{
    public partial class frmSystemRelease : Form
    {
        private readonly StringBuilder sb = new();

        public frmSystemRelease()
        {
            InitializeComponent();
        }

        private void frmSystemUpdate_Load(object sender, EventArgs e)
        {

            //DataGridView Setting
            SetdgvList();

            //Display Release Data
            DispReleaseData();

            //Edit Button
            if (ClsLoginUser.SystemControlFlag == 1)
            {
                this.btnAdd.Visible = true;
                this.btnEdit.Visible = true;
            }
        }

        /// <summary>
        /// DataGridView Setting
        /// </summary>
        private void SetdgvList()
        {
            // 1列名定義：ID
            DataGridViewTextBoxColumn col01 = new()
            {
                Name = "ID",
                HeaderText = "",
                Width = 1,
                Visible = false
            };
            //col01.Name = "ID";
            //col01.HeaderText = "";
            //col01.Width = 1;
            //col01.Visible = false;
            this.dgvList.Columns.Add(col01);

            // 2列名定義：日付
            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "Day",
                HeaderText = "リリース日付",
                Width = 150,
                Visible = true
            };
            //col02.Name = "Day";
            //col02.HeaderText = "リリース日付";
            //col02.Width = 150;
            //col02.Visible = true;
            this.dgvList.Columns.Add(col02);

            // 3列名定義：バージョン
            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "Version",
                HeaderText = "バージョン",
                Width = 100,
                Visible = true
            };
            //col03.Name = "Version";
            //col03.HeaderText = "バージョン";
            //col03.Width = 100;
            //col03.Visible = true;
            this.dgvList.Columns.Add(col03);

            // 4列名定義：リリース内容
            DataGridViewTextBoxColumn col04 = new()
            {
                Name = "Release",
                HeaderText = "リリース内容",
                Width = 520,
                Visible = true
            };
            //col04.Name = "Release";
            //col04.HeaderText = "リリース内容";
            //col04.Width = 520;
            //col04.Visible = true;
            this.dgvList.Columns.Add(col04);

            // 5列名定義：備考
            DataGridViewTextBoxColumn col05 = new()
            {
                Name = "Comment",
                HeaderText = "備考",
                Width = 180,
                Visible = true
            };
            //col05.Name = "Comment";
            //col05.HeaderText = "備考";
            //col05.Width = 180;
            //col05.Visible = true;
            this.dgvList.Columns.Add(col05);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            // その他のプロパティをセット
            this.dgvList.EnableHeadersVisualStyles = false;                                                 // Windows Color無効
            this.dgvList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;     // 列ヘッダ色
            this.dgvList.RowTemplate.Height = 45;                                                           // 行高さ
            this.dgvList.AllowUserToResizeColumns = false;                                                  // 列幅の変更不可
            this.dgvList.AllowUserToResizeRows = true;                                                      // 行高さの変更不可
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;         // 奇数行を黄色にする

            // dgvScheduleList.ScrollBars = False;                                                          // スクロールバー非表示
            this.dgvList.MultiSelect = false;                                                               // 複数選択：不可
            this.dgvList.ReadOnly = false;                                                                  // 書込み：不可
            this.dgvList.AllowUserToAddRows = false;                                                        // ユーザーによる行の追加禁止        
            this.dgvList.RowHeadersVisible = false;                                                         // 行ヘッダ：非表示
            this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                           // 行が全て選択

            // セルの内容に合わせて、行の高さが自動的に調節されるようにする
            dgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Column1"列のセルのテキストを折り返して表示する
            this.dgvList.Columns["Release"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;          // 折り返し表示

            // ヘッダセルの文字表示位置
            DataGridViewCellStyle columnHeaderStyle2 = this.dgvList.ColumnHeadersDefaultCellStyle;
            columnHeaderStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Font
            this.dgvList.Columns["Day"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.FONT_TYPE, ClsPublic.GRD_HEADER_FONT_SIZE );
            this.dgvList.Columns["Version"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.FONT_TYPE, ClsPublic.GRD_HEADER_FONT_SIZE);
            this.dgvList.Columns["Release"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.FONT_TYPE, ClsPublic.GRD_HEADER_FONT_SIZE-1);
            this.dgvList.Columns["Comment"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.FONT_TYPE, ClsPublic.GRD_HEADER_FONT_SIZE-1);
            // Align
            this.dgvList.Columns["Day"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["Version"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["Release"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvList.Columns["Comment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        /// <summary>
        /// Release情報表示
        /// </summary>
        private void DispReleaseData()
        {
            int intRow = 0;
            
            this.dgvList.Rows.Clear();  

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_システムリリース情報");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("day Desc");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        intRow = 0;
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvList.Rows.Add();
                            this.dgvList.Rows[intRow].Cells["ID"].Value = dr["id"];
                            this.dgvList.Rows[intRow].Cells["Day"].Value = ((DateTime)dr["day"]).ToString("yyyy/MM/dd");
                            this.dgvList.Rows[intRow].Cells["Version"].Value = dr["version"];
                            this.dgvList.Rows[intRow].Cells["Release"].Value = dr["release"].ToString();
                            this.dgvList.Rows[intRow].Cells["Comment"].Value = dr["comment"].ToString();
                            intRow += 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (frmSystemReleaseDetail fm = new(0))
            {
                fm.ShowDialog();
            }

            //Display Release Data
            DispReleaseData();
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if ( this.dgvList.CurrentRow.Index < 0 ) { return; }

            int iID = int.Parse( this.dgvList.Rows[this.dgvList.CurrentRow.Index].Cells["ID"].ToString());

            using (frmSystemReleaseDetail fm = new(iID))
            {
                fm.ShowDialog();
            }

            //Display Release Data
            DispReleaseData();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
