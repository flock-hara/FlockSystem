using FlockAppC.pubClass;
using System;
using System.Data;
using System.Windows.Forms;

namespace FlockAppC.pubForm
{
    public partial class frmSelectItem : Form
    {
        // SelectItem 一応30個選択可能対応
        public string[] pSelectID = new string[30];
        public string[] pSelectItem = new string[30];
        public int P_SelectCount { get; set; }
        public string P_SQL { get; set; }
        public string P_Title { get; set; }
        public int P_DBType { get; set; }

        public frmSelectItem()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSelectItem_Load(object sender, EventArgs e)
        {
            SetdgvSelectItem();
        }
        /// <summary>
        /// DataGridView設定
        /// </summary>
        private void SetdgvSelectItem()
        {
            DataGridViewTextBoxColumn col01 = new();
            DataGridViewTextBoxColumn col02 = new();

            col01.Name = "ID";
            col01.HeaderText = "ID";
            col01.Width = 1;
            col01.Visible = false;
            this.dgvItem.Columns.Add(col01);

            col02.Name = "Item";
            // col02.HeaderText = "Item";
            col02.HeaderText = this.P_Title;
            col02.Width = 140;
            col02.Visible = true;
            this.dgvItem.Columns.Add(col02);


            //並び替えができないようにする
            foreach (DataGridViewColumn c in this.dgvItem.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvItem.EnableHeadersVisualStyles = false;                                                   //Windows Color無効
            this.dgvItem.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;       //列ヘッダ色
            this.dgvItem.RowTemplate.Height = 20;                                                             //行高さ
            this.dgvItem.AllowUserToResizeColumns = false;                                                    //列幅の変更不可
            this.dgvItem.AllowUserToResizeRows = false;                                                       //行高さの変更不可PaleTurquoise
            this.dgvItem.Columns["Item"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置

            //奇数行を黄色にする
            // this.dgvClassificationList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;
            this.dgvItem.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dgvItem.Columns["Item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            //セルの文字表示位置
            this.dgvItem.Columns["Item"].DefaultCellStyle.Font = new System.Drawing.Font(ClsPublic.TASK_FONT_TYPE, 8);           //フォント設定

            //this.dgvItem.ScrollBars = false;                                        //スクロールバー非表示
            this.dgvItem.MultiSelect = true;                                          //複数選択
            this.dgvItem.ReadOnly = true;                                             //読込専用
            this.dgvItem.AllowUserToAddRows = false;                                  //行追加無効
            this.dgvItem.RowHeadersVisible = false;                                   //行ヘッダ非表示
            this.dgvItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;     //行選択時は１行全て選択状態にする
        }
        /// <summary>
        /// アイテムを一覧に表示する
        /// </summary>
        private void DispItem()
        {
            int intRow = 0;

            this.dgvItem.Rows.Clear();

            // 接続中メッセージ
            ClsPublic.lblConnect = this.lblConnect;

            try
            {
                if (P_SQL == "") { return; }

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    using (DataTable dt_val = clsSqlDb.DMLSelect(P_SQL))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.dgvItem.Rows.Add();
                            this.dgvItem.Rows[intRow].Cells["ID"].Value = dr["id"];
                            this.dgvItem.Rows[intRow].Cells["Item"].Value = dr["item"];
                            intRow++;
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
        /// <summary>
        /// 一覧クリックイベント：IDとアイテム名称を保持する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDecision_Click(object sender, EventArgs e)
        {
            int intCnt = 0;
            foreach (DataGridViewRow dr in dgvItem.SelectedRows)
            {
                pSelectID[intCnt] = this.dgvItem.Rows[dr.Index].Cells["ID"].Value.ToString();
                pSelectItem[intCnt] = this.dgvItem.Rows[dr.Index].Cells["Item"].Value.ToString();
                intCnt++;
            }
            P_SelectCount = intCnt;

            this.Close();
        }
        /// <summary>
        /// 閉じるボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// アイテム表示時のDB接続メッセージ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSelectItem_Shown(object sender, EventArgs e)
        {
            // 接続中メッセージ
            this.lblConnect.Visible = true;
            this.lblConnect.Refresh();

            DispItem();

            for (int intCnt = 0; intCnt < 30; intCnt++)
            {
                pSelectID[intCnt] = "";
                pSelectItem[intCnt] = "";
            }
            P_SelectCount = 0;

            // 接続中メッセージ
            this.lblConnect.Visible = false;
            this.lblConnect.Refresh();
        }
    }
}
