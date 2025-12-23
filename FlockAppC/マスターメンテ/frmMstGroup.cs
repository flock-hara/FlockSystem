using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstGroup : Form
    {
        public int Id { get; set; }

        private readonly StringBuilder sb = new();

        public frmMstGroup()
        {
            InitializeComponent();
        }

        private void frmMstGroup_Load(object sender, EventArgs e)
        {
            // Initialize DataGridView
            SetDgvList();
            InitializeForm(true);
            DisplayGroup();

            // フォーム表示位置
            this.Location = new Point(0, 0);
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
                Visible = false
            };
            DataGridViewTextBoxColumn col02 = new()
            {
                Name = "name",
                HeaderText = "名称",
                Width = 256,
                Visible = true
            };
            DataGridViewTextBoxColumn col03 = new()
            {
                Name = "sort",
                HeaderText = "並び",
                Width = 50,
                Visible = true
            };

            //DataGridViewTextBoxColumn col01 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col02 = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn col03 = new DataGridViewTextBoxColumn();
            //col01.Name = "id";
            //col01.HeaderText = "ID";
            //col01.Width = 50;
            //col01.Visible = false;
            //col02.Name = "name";
            //col02.HeaderText = "名称";
            //col02.Width = 256;
            //col02.Visible = true;
            //col03.Name = "sort";
            //col03.HeaderText = "並び";
            //col03.Width = 50;
            //col03.Visible = true;

            // this.dgvList.Columns.Add(col00);
            this.dgvList.Columns.Add(col01);
            this.dgvList.Columns.Add(col02);
            this.dgvList.Columns.Add(col03);

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
            this.dgvList.Columns["sort"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;          // 列ヘッダ文字位置

            //奇数行を黄色にする
            this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Moccasin;

            this.dgvList.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvList.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.Columns["sort"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvList.Columns["id"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);          //フォント設定
            this.dgvList.Columns["name"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);        //フォント設定
            this.dgvList.Columns["sort"].DefaultCellStyle.Font = new System.Drawing.Font("游ゴシック", 11, FontStyle.Regular);       //フォント設定

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

            this.txtName.Text = "";
            this.txtSort.Text = "";
            this.lblNew.Visible = flg;

            // 並び順表示
            DisplaySortMax();
        }

        /// <summary>
        /// 部門情報表示
        /// </summary>
        private void DisplayGroup()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_部門.id");
                    sb.AppendLine(",Mst_部門.name");
                    sb.AppendLine(",Mst_部門.sort");
                    sb.AppendLine(" FROM Mst_部門");
                    sb.AppendLine(" ORDER BY");
                    sb.AppendLine(" Mst_部門.sort");
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
                            this.dgvList.Rows[i].Cells["name"].Value = dr["name"].ToString();
                            this.dgvList.Rows[i].Cells["sort"].Value = dr["sort"].ToString();
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
        /// DataGridView セルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            InitializeForm(false);
            // 新規ラベルを非表示→更新モードに

            //クリックされたセルのClassificationID取得
            Id = int.Parse(this.dgvList.Rows[e.RowIndex].Cells[0].Value.ToString());

            // 画面表示
            this.txtName.Text = this.dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.txtSort.Text = this.dgvList.Rows[e.RowIndex].Cells[2].Value.ToString();
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
                    sb.AppendLine("Mst_部門");

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
            // 未入力判定
            if (this.txtName.Text.Length == 0)
            {
                MessageBox.Show("未入力項目がります。", "結果", MessageBoxButtons.OK);
                return;
            }

            ClsMstGroup cls = new()
            {
                Id = 0,
                Name = this.txtName.Text,
                Sort = int.Parse(this.txtSort.Text)
            };

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
                cls.Insert();
            }
            InitializeForm(true);
            DisplayGroup();
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

            // Mst_所属レコード削除
            ClsMstGroup cls = new()
            {
                Id = Id,
            };
            cls.Delete();

            InitializeForm(true);
            DisplayGroup();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
