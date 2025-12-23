using FlockAppC.tblClass;
using System;
using System.Data;
using System.Windows.Forms;

namespace FlockAppC.ScheduleBoard
{
    public partial class frmScheduleBoard : Form
    {
        // セルクリックした時のRowを保持
        private int ScheduleID;

        /// <summary>
        /// インスタンス
        /// </summary>
        public frmScheduleBoard()
        {
            InitializeComponent();
            label1.Visible = false;
        }
        /// <summary>
        /// 追加ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //label1.Visible = true;
            //label1.Text = "ボタンクリックイベント";

            // 追加ボタン時IDは0を指定（static領域にセット）
            frmScheduleBoardDetail.Global.ID = 0;
            //frmScheduleBoardDetail.Global.ID = 5;               // TEST

            // 明細画面表示
            Form frmDetail = new frmScheduleBoardDetail();
            frmDetail.ShowDialog();

            // 予定表示
            DisplayScheduleList();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScheduleBoard_Load(object sender, EventArgs e)
        {

            // DataGridView設定
            SetDgvScheduleList();

            dtpSchedule.Value = DateTime.Now;

            // 予定表示
            DisplayScheduleList();
        }

        /// <summary>
        /// DataGridView 予定一覧設定
        /// </summary>
        private void SetDgvScheduleList()
        {
            // 1列名定義：ID
            var col01 = new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "",
                Width = 1,
                Visible = false
            };
            //DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            //col01.Name = "ID";
            //col01.HeaderText = "";
            //col01.Width = 1;
            //col01.Visible = false;
            dgvScheduleList.Columns.Add(col01);

            // 2列名定義：編集ボタン
            var col02 = new DataGridViewButtonColumn
            {
                Name = "編集",
                UseColumnTextForButtonValue = true,
                Text = "編集",
                Width = 50
            };

            //DataGridViewButtonColumn col02 = new DataGridViewButtonColumn();
            //// 列の名前を設定
            //col02.Name = "編集";
            //// 全てのボタンに"編集"と表示する
            //col02.UseColumnTextForButtonValue = true;
            //col02.Text = "編集";
            //col02.Width = 50;
            //// col02.FlatStyle = FlatStyle.Popup                         'Popup
            dgvScheduleList.Columns.Add(col02);

            // 3列名定義：担当者名
            var col03 = new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "担当者",
                Width = 80,
                Visible = true
            };
            //DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            //col03.Name = "Name";
            //col03.HeaderText = "担当者";
            //col03.Width = 80;
            //col03.Visible = true;
            dgvScheduleList.Columns.Add(col03);

            // 4列名定義：予定
            var col04 = new DataGridViewTextBoxColumn
            {
                Name = "Schedule",
                HeaderText = "予　定",
                Width = 400,
                Visible = true
            };
            //col04.Name = "Schedule";
            //col04.HeaderText = "予　定";
            //col04.Width = 400;
            //col04.Visible = true;
            dgvScheduleList.Columns.Add(col04);

            // 5列名定義：開始時間
            var col05 = new DataGridViewTextBoxColumn
            {
                Name = "StartTime",
                HeaderText = "始時刻",
                Width = 70,
                Visible = true
            };
            //col05.Name = "StartTime";
            //col05.HeaderText = "始時刻";
            //col05.Width = 70;
            //col05.Visible = true;
            dgvScheduleList.Columns.Add(col05);

            // 6列名定義：終了時間
            var col06 = new DataGridViewTextBoxColumn
            {
                Name = "EndTime",
                HeaderText = "終時刻",
                Width = 70,
                Visible = true
            };
            //col06.Name = "EndTime";
            //col06.HeaderText = "終時刻";
            //col06.Width = 70;
            //col06.Visible = true;
            dgvScheduleList.Columns.Add(col06);

            // 7列名定義：帰社予定
            var col07 = new DataGridViewTextBoxColumn
            {
                Name = "Return",
                HeaderText = "帰社予定",
                Width = 80,
                Visible = true
            };
            //col07.Name = "Return";
            //col07.HeaderText = "帰社予定";
            //col07.Width = 80;
            //col07.Visible = true;
            dgvScheduleList.Columns.Add(col07);

            // 8列名定義：帰社予定
            var col08 = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "状況",
                Width = 50,
                Visible = true
            };
            //col08.Name = "Status";
            //col08.HeaderText = "状況";
            //col08.Width = 50;
            //col08.Visible = true;
            dgvScheduleList.Columns.Add(col08);

            //並び替えができないようにする
            foreach (DataGridViewColumn c in dgvScheduleList.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            // その他のプロパティをセット
            dgvScheduleList.EnableHeadersVisualStyles = false;          // Windows Color無効
            dgvScheduleList.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;      // 列ヘッダ色
            dgvScheduleList.RowTemplate.Height = 35;                    // 行高さ
            dgvScheduleList.AllowUserToResizeColumns = false;           // 列幅の変更不可
            dgvScheduleList.AllowUserToResizeRows = false;              // 行高さの変更不可
            dgvScheduleList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;         // 奇数行を黄色にする

            // dgvScheduleList.ScrollBars = False;                      // スクロールバー非表示
            dgvScheduleList.MultiSelect = false;                        // 複数選択：不可
            dgvScheduleList.ReadOnly = false;                           // 書込み：不可
            dgvScheduleList.AllowUserToAddRows = false;                 // ユーザーによる行の追加禁止        
            dgvScheduleList.RowHeadersVisible = false;                  // 行ヘッダ：非表示
            dgvScheduleList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;    // 行が全て選択

            // セルの内容に合わせて、行の高さが自動的に調節されるようにする
            // dgvChange.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Column1"列のセルのテキストを折り返して表示する
            // dgvChange.Columns("before").DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // ヘッダセルの文字表示位置
            DataGridViewCellStyle columnHeaderStyle2 = dgvScheduleList.ColumnHeadersDefaultCellStyle;
            columnHeaderStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Font
            dgvScheduleList.Columns["ID"].DefaultCellStyle.Font = new System.Drawing.Font("メイリオ", 10);
            dgvScheduleList.Columns["Name"].DefaultCellStyle.Font = new System.Drawing.Font("メイリオ", 10);
            dgvScheduleList.Columns["Schedule"].DefaultCellStyle.Font = new System.Drawing.Font("メイリオ", 10);
            dgvScheduleList.Columns["StartTime"].DefaultCellStyle.Font = new System.Drawing.Font("メイリオ", 10);
            dgvScheduleList.Columns["EndTime"].DefaultCellStyle.Font = new System.Drawing.Font("メイリオ", 10);
            dgvScheduleList.Columns["Return"].DefaultCellStyle.Font = new System.Drawing.Font("メイリオ", 10);
            dgvScheduleList.Columns["Status"].DefaultCellStyle.Font = new System.Drawing.Font("メイリオ", 10);
            // Align
            dgvScheduleList.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvScheduleList.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvScheduleList.Columns["Schedule"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvScheduleList.Columns["StartTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvScheduleList.Columns["EndTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvScheduleList.Columns["Return"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvScheduleList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// 予定リスト表示
        /// </summary>
        private void DisplayScheduleList()
        {
            int intRow;
            ClsTrnSchedule clsShd = new();

            // 接続先指定
            // clsShd.DbType = clsPublic.DBNo;
            // 2025/08/26 UPD
            // clsShd.DbType = clsPublic.XSERVER_DB;

            try
            {
                dgvScheduleList.Rows.Clear();       // 表示前にリストクリア

                clsShd.Day = dtpSchedule.Value;
                clsShd.DMLSelectDay();

                if (clsShd.Dt.Rows.Count < 1)
                {
                    // MessageBox.Show("予定はありません。", "結果", MessageBoxButtons.OK);
                    return;
                }

                // 結果読み込み
                intRow = 0;
                foreach (DataRow dr in clsShd.Dt.Rows)
                {
                    dgvScheduleList.Rows.Add();
                    dgvScheduleList.Rows[intRow].Cells["ID"].Value = (int)dr["id"];

                    if (dr["name1"] != DBNull.Value)
                    {
                        dgvScheduleList.Rows[intRow].Cells["Name"].Value = (string)dr["name1"];
                    }
                    else
                    {
                        dgvScheduleList.Rows[intRow].Cells["Name"].Value = "";
                    }
                    dgvScheduleList.Rows[intRow].Cells["Schedule"].Value = (string)dr["schedule"];
                    dgvScheduleList.Rows[intRow].Cells["StartTime"].Value = ((DateTime)dr["schedule_start_time"]).ToString ("HH:mm");
                    dgvScheduleList.Rows[intRow].Cells["EndTime"].Value = ((DateTime)dr["schedule_end_time"]).ToString ("HH:mm");

                    // 00:00の場合はスペース
                    if ((string)dgvScheduleList.Rows[intRow].Cells["StartTime"].Value == "00:00")
                    {
                        dgvScheduleList.Rows[intRow].Cells["StartTime"].Value = "";
                    }
                    if ((string)dgvScheduleList.Rows[intRow].Cells["EndTime"].Value == "00:00")
                    {
                        dgvScheduleList.Rows[intRow].Cells["EndTime"].Value = "";
                    }

                    if (int.Parse(dr["return_flag"].ToString()) == 1)
                    {
                        dgvScheduleList.Rows[intRow].Cells["Return"].Value = "〇";
                    }
                    else
                    {
                        dgvScheduleList.Rows[intRow].Cells["Return"].Value = "";
                    }

                    // ステータス
                    if (int.Parse(dr["Status"].ToString()) == 1)
                    {
                        dgvScheduleList.Rows[intRow].Cells["Status"].Value = "済";
                    }
                    else
                    {
                        dgvScheduleList.Rows[intRow].Cells["Status"].Value = "";
                    }
                    intRow += 1;
                }

                // 未選択状態にする
                dgvScheduleList.ClearSelection();
                // dgvScheduleList.CurrentCell = null;

                // Rowクリア
                ScheduleID = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
        }
        /// <summary>
        /// セル内の内容クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvScheduleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int intRow, intCol;
            intRow = e.RowIndex; intCol = e.ColumnIndex;

            if (intRow <  0) { return; }

            switch (dgvScheduleList.Columns[intCol].Name)
            {
                case "編集":
                    // IDをセットし編集画面を呼び出す
                    frmScheduleBoardDetail.Global.ID = (int)dgvScheduleList.Rows[intRow].Cells[0].Value;
                    using (frmScheduleBoardDetail fShd = new())
                    {
                        fShd.ShowDialog();
                    }
                    DisplayScheduleList();
                    break;
 
                default:
                    break;
            }
        }

        /// <summary>
        /// カレンダー日付変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtpSchedule_ValueChanged(object sender, EventArgs e)
        {
            // 予定表示
            DisplayScheduleList();

        }

        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// セルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvScheduleList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int intRow = e.RowIndex;
            
            if (intRow < 0) { return; }

            // 予定ID保持
            ScheduleID = (int)dgvScheduleList.Rows[intRow].Cells[0].Value;
        }
        /// <summary>
        /// 削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ClsTrnSchedule clsShd = new();

            // 接続先指定
            // clsShd.DbType = clsPublic.DBNo;

            if (ScheduleID >= 0)
            {
                clsShd.Id = ScheduleID;
                clsShd.DMLDelete();

                MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);

                // 予定表示
                DisplayScheduleList();
            }
        }
    }
}
