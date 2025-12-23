using FlockAppC.pubClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlockAppC
{
    public partial class frmSysMenu : Form
    {
        public frmSysMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// IPチェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIpCheck_Click(object sender, EventArgs e)
        {
            //IPアドレスチェック( C# )
            frmIPCheck frmIPCheck = new();
            frmIPCheck.ShowDialog();
        }
        /// <summary>
        /// リリース情報
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRelease_Click(object sender, EventArgs e)
        {
            //リリース情報( C# )
            frmSystemRelease fSystemRelease = new();
            fSystemRelease.ShowDialog();
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMenu99_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(); 
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSysMenu_Load(object sender, EventArgs e)
        {
            if (ClsLoginUser.SystemControlFlag == 0)
            {
                this.dgvDBList.Enabled = false;
                this.dgvDBList2.Enabled = false;
                this.btnChangeDB.Enabled = false;
            }
            else
            {
                this.dgvDBList.Enabled = true;
                this.dgvDBList2.Enabled = true;
                this.btnChangeDB.Enabled = true;
            }

            SetDgvDBList();
            DspDgvDBList();
        }
        /// <summary>
        /// DBリスト設定
        /// </summary>
        private void SetDgvDBList()
        {
            // カラムクリア
            dgvDBList.Columns.Clear();

            DataGridViewTextBoxColumn col01 = new();
            DataGridViewTextBoxColumn col02 = new();

            col01.Name = "id";
            col01.HeaderText = "";
            col01.Width = 90;
            col01.Visible = false;

            col02.Name = "name";
            col02.HeaderText = "接続DB";
            col02.Width = 255;
            col02.Visible = true;


            this.dgvDBList.Columns.Add(col01);
            this.dgvDBList.Columns.Add(col02);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvDBList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvDBList.EnableHeadersVisualStyles = false;                                                                        // Windows Color無効
            this.dgvDBList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                            // 列ヘッダ色
            this.dgvDBList.RowTemplate.Height = 20;                                                                                  // 行高さ
            this.dgvDBList.AllowUserToResizeColumns = false;                                                                         // 列幅の変更不可
            this.dgvDBList.AllowUserToResizeRows = false;                                                                            // 行高さの変更不可
            this.dgvDBList.ColumnHeadersVisible = true;                                                                              // 列ヘッダ非表示
            this.dgvDBList.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                   // 列ヘッダ文字位置

            // 奇数行を黄色にする
            // this.dgvUserList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvDBList.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;                     //セルの文字表示位置

            this.dgvDBList.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);      //フォント設定

            // Column1列のセルのテキストを折り返して表示する
            this.dgvDBList.Columns["name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //this.dgvSelect1.ScrollBars = false;                                                                                    //スクロールバー非表示
            this.dgvDBList.MultiSelect = false;                                                                                      //複数選択
            this.dgvDBList.ReadOnly = true;                                                                                          //読込専用
            this.dgvDBList.AllowUserToAddRows = false;                                                                               //行追加無効
            this.dgvDBList.RowHeadersVisible = false;                                                                                //行ヘッダ非表示
            this.dgvDBList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                                  //行選択時は１行全て選択状態にする

            ///////////////////////////////////////////////////////////////////////
            // MySQL
            ///////////////////////////////////////////////////////////////////////
            // カラムクリア
            dgvDBList2.Columns.Clear();

            DataGridViewTextBoxColumn col010 = new();
            DataGridViewTextBoxColumn col020 = new();

            col010.Name = "id";
            col010.HeaderText = "";
            col010.Width = 90;
            col010.Visible = false;

            col020.Name = "name";
            col020.HeaderText = "接続DB";
            col020.Width = 255;
            col020.Visible = true;

            this.dgvDBList2.Columns.Add(col010);
            this.dgvDBList2.Columns.Add(col020);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvDBList2.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvDBList2.EnableHeadersVisualStyles = false;                                                                        // Windows Color無効
            this.dgvDBList2.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;                            // 列ヘッダ色
            this.dgvDBList2.RowTemplate.Height = 20;                                                                                  // 行高さ
            this.dgvDBList2.AllowUserToResizeColumns = false;                                                                         // 列幅の変更不可
            this.dgvDBList2.AllowUserToResizeRows = false;                                                                            // 行高さの変更不可
            this.dgvDBList2.ColumnHeadersVisible = true;                                                                              // 列ヘッダ非表示
            this.dgvDBList2.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                   // 列ヘッダ文字位置

            // 奇数行を黄色にする
            // this.dgvUserList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvDBList2.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;                     //セルの文字表示位置

            this.dgvDBList2.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);      //フォント設定

            // Column1列のセルのテキストを折り返して表示する
            this.dgvDBList2.Columns["name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //this.dgvSelect1.ScrollBars = false;                                                                                    //スクロールバー非表示
            this.dgvDBList2.MultiSelect = false;                                                                                      //複数選択
            this.dgvDBList2.ReadOnly = true;                                                                                          //読込専用
            this.dgvDBList2.AllowUserToAddRows = false;                                                                               //行追加無効
            this.dgvDBList2.RowHeadersVisible = false;                                                                                //行ヘッダ非表示
            this.dgvDBList2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                                  //行選択時は１行全て選択状態にする
        }

        private void DspDgvDBList()
        {
            this.dgvDBList.Rows.Add();
            this.dgvDBList.Rows[0].Cells["id"].Value = "1";
            this.dgvDBList.Rows[0].Cells["name"].Value = "SQL Server (FLOCKDB)";
            this.dgvDBList.Rows.Add();
            this.dgvDBList.Rows[1].Cells["id"].Value = "2";
            this.dgvDBList.Rows[1].Cells["name"].Value = "SQL Server (テスト用)";

            this.dgvDBList.ClearSelection();

            ///////////////////////////////////////////////////////////////////////
            // MySQL
            ///////////////////////////////////////////////////////////////////////
            this.dgvDBList2.Rows.Add();
            this.dgvDBList2.Rows[0].Cells["id"].Value = "1";
            this.dgvDBList2.Rows[0].Cells["name"].Value = "MySQL (flock_sysdb)";
            this.dgvDBList2.Rows.Add();
            this.dgvDBList2.Rows[1].Cells["id"].Value = "2";
            this.dgvDBList2.Rows[1].Cells["name"].Value = "MySQL (テスト用)";

            this.dgvDBList2.ClearSelection();
        }

        private void BtnChangeDB_Click(object sender, EventArgs e)
        {
            // string db, dbname;
            // string[] arr;
            // ====================================================================================
            // DB情報
            // ====================================================================================
            if (this.dgvDBList.CurrentCell != null)
            {
                switch(this.dgvDBList.CurrentRow.Index)
                {
                    case 0:
                        ClsDbConfig.SQLServerNo = 0;
                        break;
                    case 1:
                        ClsDbConfig.SQLServerNo = 1;
                        break;
                }
            }
            // MySQL
            if (this.dgvDBList2.CurrentCell != null)
            {
                switch (this.dgvDBList2.CurrentRow.Index)
                {
                    case 0:
                        ClsDbConfig.MySQLNo = 0;
                        break;
                    case 1:
                        ClsDbConfig.MySQLNo = 1;
                        break;
                }
            }
        }
    }
}
