using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.勤務表
{
    public partial class frmScheduleComment : Form
    {
        public DateTime Day {  get; set; }

        private readonly StringBuilder sb = new();

        public frmScheduleComment()
        {
            InitializeComponent();
        }

        private void frmScheduleComment_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// バックカラー設定（コンボボックス）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBackColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // 背景色の設定
            e.DrawBackground();

            // 項目のテキスト取得
            string itemText = cmbBackColor.Items[e.Index].ToString();

            // 背景色をアイテムごとに変更
            System.Drawing.Color backgroundColor;

            if (itemText == "Yellow") { backgroundColor = Color.Yellow; }
            else if (itemText == "Orange") { backgroundColor = Color.Orange; }
            else { backgroundColor = SystemColors.Window; }

            // 背景を塗りつぶす
            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

            // テキストを描画
            e.Graphics.DrawString(itemText, e.Font, Brushes.Black, e.Bounds);

            // フォーカスがある場合に枠線を描画
            e.DrawFocusRectangle();
        }
        /// <summary>
        /// フォントカラー（コンボボックス）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFontColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics grfx = e.Graphics;
            System.Drawing.Rectangle rect = e.Bounds;

            switch (e.Index)
            {
                case 0:
                    grfx.DrawString(cmbFontColor.Items[e.Index].ToString(), e.Font, new SolidBrush(System.Drawing.Color.Black), rect);
                    break;
                case 1:
                    grfx.DrawString(cmbFontColor.Items[e.Index].ToString(), e.Font, new SolidBrush(System.Drawing.Color.Red), rect);
                    break;
                case 2:
                    grfx.DrawString(cmbFontColor.Items[e.Index].ToString(), e.Font, new SolidBrush(System.Drawing.Color.Blue), rect);
                    break;
                default:
                    break;
            }
            e.DrawFocusRectangle();
        }

        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontProperty();
        }
        private void cmbFontColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontProperty();
        }
        private void cmbFontBold_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontProperty();
        }
        private void cmbBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFontProperty();
        }
        /// <summary>
        /// フォントプロパティ設定
        /// </summary>
        private void SetFontProperty()
        {
            switch (this.cmbFontSize.SelectedIndex)
            {
                case 0:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 8, FontStyle.Regular);
                    break;
                case 1:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 9, FontStyle.Regular);
                    break;
                case 2:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 10, FontStyle.Regular);
                    break;
                case 3:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 12, FontStyle.Regular);
                    break;
                case 4:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 14, FontStyle.Regular);
                    break;
                default:
                    this.txtShiftEntry.Font = new System.Drawing.Font("游ゴシック", 12, FontStyle.Regular);
                    break;
            }

            switch (this.cmbFontColor.SelectedIndex)
            {
                case 0:
                    this.txtShiftEntry.ForeColor = System.Drawing.Color.Black;
                    break;
                case 1:
                    this.txtShiftEntry.ForeColor = System.Drawing.Color.Red;
                    break;
                case 2:
                    this.txtShiftEntry.ForeColor = System.Drawing.Color.Blue;
                    break;
                default:
                    this.txtShiftEntry.ForeColor = System.Drawing.Color.Black;
                    break;
            }

            switch (this.cmbBackColor.SelectedIndex)
            {
                case 0:
                    this.txtShiftEntry.BackColor = SystemColors.Window;
                    break;
                case 1:
                    this.txtShiftEntry.BackColor = System.Drawing.Color.Yellow;
                    break;
                case 2:
                    this.txtShiftEntry.BackColor = System.Drawing.Color.Orange;
                    break;
                default:
                    this.txtShiftEntry.BackColor = SystemColors.Window;
                    break;
            }

            // 標準の場合は処理終了
            if (this.cmbFontBold.SelectedIndex == 0) { return; }

            // 表示に反映させる
            // 現在のフォントを覚えておく
            System.Drawing.Font oldFont = this.txtShiftEntry.Font;
            // 現在のフォントにBoldを付加したフォントを作成する
            // なおBoldを取り消す場合は、「oldFont.Style And Not FontStyle.Bold」とする
            Font newFont = new(oldFont, oldFont.Style | FontStyle.Bold);

            // Boldを付加したフォントを設定する
            txtShiftEntry.Font = newFont;
            // 前のフォントを解放する
            oldFont.Dispose();
        }
        /// <summary>
        /// フォーム表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScheduleComment_Shown(object sender, EventArgs e)
        {

            // フォントサイズ
            this.cmbFontSize.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFontSize.Items.Add("24");
            this.cmbFontSize.Items.Add("26");
            this.cmbFontSize.Items.Add("28");
            this.cmbFontSize.Items.Add("36");
            this.cmbFontSize.Items.Add("48");
            this.cmbFontSize.SelectedIndex = 3;

            // フォントカラー
            this.cmbFontColor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFontColor.Items.Add("Black");
            this.cmbFontColor.Items.Add("Red");
            this.cmbFontColor.Items.Add("Blue");
            this.cmbFontColor.SelectedIndex = 0;

            // フォント太字
            this.cmbFontBold.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFontBold.Items.Add("普通");
            this.cmbFontBold.Items.Add("太字");
            this.cmbFontBold.SelectedIndex = 0;

            // バックカラー
            this.cmbBackColor.DrawMode = DrawMode.OwnerDrawFixed;
            this.cmbBackColor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBackColor.Items.Add("");
            this.cmbBackColor.Items.Add("Yellow");
            this.cmbBackColor.Items.Add("Orange");
            // DrawItemイベントハンドラを設定
            cmbBackColor.DrawItem += new DrawItemEventHandler(cmbBackColor_DrawItem);
            this.cmbBackColor.SelectedIndex = 0;

            // this.dtpDate.ValueChanged += this.dtpDate_ValueChanged;

            this.dtpDate.Value = Day;
            // this.txtShiftEntry.Text = "";

            this.txtShiftEntry.Focus();
        }
        /// <summary>
        /// 登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        { 
            ClsTrnScheduleEntry cls1 = new();

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // 勤務表シフト変更に登録済みか確認
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("Count(*) AS CNT");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表シフト変更");
                    sb.AppendLine("WHERE");
                    sb.AppendLine(" delete_flag <> " + ClsPublic.FLAG_ON);
                    sb.AppendLine("AND");
                    sb.AppendLine(" day = '" + this.dtpDate.Value + "'" );
                    sb.AppendLine("AND");
                    sb.AppendLine(" col = 2");           // 備考列

                    DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString());

                    if (dt_val.Rows.Count > 0)
                    {
                        // 登録済みの場合はデータ削除
                        sb.Clear();
                        sb.AppendLine("UPDATE");
                        sb.AppendLine("Trn_勤務表シフト変更");
                        sb.AppendLine("SET");
                        // 2025/11/12↓
                        sb.AppendLine(" upd_user_id = " + ClsLoginUser.StaffID);
                        sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                        // 2025/11/12↑
                        sb.AppendLine(" delete_flag = " + ClsPublic.FLAG_ON);
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" day = '" + this.dtpDate.Value + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine(" col = 2");

                        clsSqlDb.DMLUpdate(sb.ToString());
                    }

                    // 勤務表シフト情報をもとに勤務表シフト変更を登録
                    sb.Length = 0;
                    sb.AppendLine(" day = '" + this.dtpDate.Value + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine(" col = 2");
                    cls1.Select2(sb.ToString());

                    // 勤務表シフト変更登録
                    ClsTrnScheduleChange cls2 = new()
                    {
                        RegDate = DateTime.Now,
                        RegUserID = ClsLoginUser.ID,
                        RegUserName = ClsLoginUser.Name1,
                        TantoID = 0,
                        TantoName = "ｺﾒﾝﾄ",
                        Day = this.dtpDate.Value,
                        BeforeContent = cls1.Value,
                        AfterContent = this.txtShiftEntry.Text,
                        Row = cls1.Row,
                        Col = cls1.Col,
                        Comment = "",
                        FileName = cls1.FilePath,
                        SheetName = cls1.SheetName,
                        CommentFlag = ClsPublic.FLAG_ON,
                        DeleteFlag = ClsPublic.FLAG_OFF,
                        ConfirmFlag = ClsPublic.FLAG_OFF,
                        ConfirmUserID = 0,
                        ConfirmUserName = "",
                        BeforeBackColor = cls1.BackColor,
                        BeforeFontSize = cls1.FontSize,
                        BeforeFontColor = cls1.FontColor,
                        BeforeFontBold = cls1.FontBold,
                        AfterBackColor = this.cmbBackColor.Text,
                        AfterFontSize = int.Parse(this.cmbFontSize.Text),
                        AfterFontColor = this.cmbFontColor.Text,
                        AfterFontBold = this.cmbFontBold.Text,
                        Year = cls1.Year,
                        Month = cls1.Month
                    };

                    cls2.Insert();

                    // 変更履歴登録
                    ClsTrnScheduleChangeHistory cls3 = new()
                    {
                        RegDate = DateTime.Now,
                        RegUserID = ClsLoginUser.ID,
                        RegUserName = ClsLoginUser.Name1,
                        TantoID = 0,
                        TantoName = "ｺﾒﾝﾄ",
                        Day = this.dtpDate.Value,
                        BeforeContent = cls2.BeforeContent,
                        AfterContent = cls2.AfterContent,
                        Status = "変更"
                    };
                    cls3.Insert();

                }
                // 更新フラグ
                ClsPublic.UpdateShiftFlag(ClsPublic.FLAG_ON);

                MessageBox.Show("登録しました。", "結果", MessageBoxButtons.OK);
                this.Close();
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
        private void btnMenu10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 日付変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            var flg = false;

            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" before_content");
                    sb.AppendLine(",after_content");
                    sb.AppendLine(",after_font_size");
                    sb.AppendLine(",after_font_color");
                    sb.AppendLine(",after_font_bold");
                    sb.AppendLine(",after_back_color");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Trn_勤務表シフト変更");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("delete_flag = " + ClsPublic.FLAG_OFF);
                    sb.AppendLine("AND");
                    sb.AppendLine("day = '" + this.dtpDate.Value + "'");
                    sb.AppendLine("AND");
                    sb.AppendLine("col = 2");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            this.txtShiftEntry.Text = dr["after_content"].ToString();

                            switch (dr["after_back_color"].ToString())
                            {
                                case "":
                                    this.cmbBackColor.SelectedIndex = 0;
                                    break;
                                case "Yellow":
                                    this.cmbBackColor.SelectedIndex = 1;
                                    break;
                                case "Orange":
                                    this.cmbBackColor.SelectedIndex = 2;
                                    break;
                                default:
                                    this.cmbBackColor.SelectedIndex = 0;
                                    break;
                            }

                            switch (dr["after_font_color"].ToString())
                            {
                                case "Black":
                                    this.cmbFontColor.SelectedIndex = 0;
                                    break;
                                case "Red":
                                    this.cmbFontColor.SelectedIndex = 1;
                                    break;
                                case "Blue":
                                    this.cmbFontColor.SelectedIndex = 2;
                                    break;
                                default:
                                    this.cmbFontColor.SelectedIndex = 0;
                                    break;
                            }

                            switch (dr["after_font_size"].ToString())
                            {
                                case "24":
                                    this.cmbFontSize.SelectedIndex = 0;
                                    break;
                                case "26":
                                    this.cmbFontSize.SelectedIndex = 1;
                                    break;
                                case "28":
                                    this.cmbFontSize.SelectedIndex = 2;
                                    break;
                                case "36":
                                    this.cmbFontSize.SelectedIndex = 3;
                                    break;
                                case "48":
                                    this.cmbFontSize.SelectedIndex = 4;
                                    break;
                                default:
                                    this.cmbFontSize.SelectedIndex = 3;
                                    break;
                            }

                            switch (dr["after_font_bold"].ToString())
                            {
                                case "普通":
                                    this.cmbFontBold.SelectedIndex = 0;
                                    break;
                                case "太字":
                                    this.cmbFontBold.SelectedIndex = 1;
                                    break;
                                default:
                                    this.cmbFontBold.SelectedIndex = 0;
                                    break;
                            }

                            flg = true;
                            break;
                        }
                    }

                    // シフト変更に未登録ならシフト情報から取得
                    if (flg != true)
                    {
                        DataTable dt_val2;

                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" value");
                        sb.AppendLine(",font_size");
                        sb.AppendLine(",font_color");
                        sb.AppendLine(",font_bold");
                        sb.AppendLine(",back_color");
                        sb.AppendLine("FROM");
                        sb.AppendLine("Trn_勤務表シフト情報");
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" day = '" + this.dtpDate.Value + "'");
                        sb.AppendLine("AND");
                        sb.AppendLine(" col = 2");

                        using (dt_val2 = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            foreach (DataRow dr in dt_val2.Rows)
                            {
                                this.txtShiftEntry.Text = dr["value"].ToString();

                                switch (dr["back_color"].ToString())
                                {
                                    case "":
                                        this.cmbBackColor.SelectedIndex = 0;
                                        break;
                                    case "Yellow":
                                        this.cmbBackColor.SelectedIndex = 1;
                                        break;
                                    case "Orange":
                                        this.cmbBackColor.SelectedIndex = 2;
                                        break;
                                    default:
                                        this.cmbBackColor.SelectedIndex = 0;
                                        break;
                                }

                                switch (dr["font_color"].ToString())
                                {
                                    case "Black":
                                        this.cmbFontColor.SelectedIndex = 0;
                                        break;
                                    case "Red":
                                        this.cmbFontColor.SelectedIndex = 1;
                                        break;
                                    case "Blue":
                                        this.cmbFontColor.SelectedIndex = 2;
                                        break;
                                    default:
                                        this.cmbFontColor.SelectedIndex = 0;
                                        break;
                                }

                                switch (dr["font_size"].ToString())
                                {
                                    case "24":
                                        this.cmbFontSize.SelectedIndex = 0;
                                        break;
                                    case "26":
                                        this.cmbFontSize.SelectedIndex = 1;
                                        break;
                                    case "28":
                                        this.cmbFontSize.SelectedIndex = 2;
                                        break;
                                    case "36":
                                        this.cmbFontSize.SelectedIndex = 3;
                                        break;
                                    case "48":
                                        this.cmbFontSize.SelectedIndex = 4;
                                        break;
                                    default:
                                        this.cmbFontSize.SelectedIndex = 3;
                                        break;
                                }

                                switch (dr["font_bold"].ToString())
                                {
                                    case "普通":
                                        this.cmbFontBold.SelectedIndex = 0;
                                        break;
                                    case "太字":
                                        this.cmbFontBold.SelectedIndex = 1;
                                        break;
                                    default:
                                        this.cmbFontBold.SelectedIndex = 0;
                                        break;
                                }
                            }
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
    }
}
