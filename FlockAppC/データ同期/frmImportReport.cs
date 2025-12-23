using FlockAppC.tblClass;
using FlockAppC.選択画面;
using System;
using System.Windows.Forms;

namespace FlockAppC.データ同期
{
    public partial class frmImportReport : Form
    {
        private int Location_id { get; set; }
        private string Location_name { get; set; }
        private int Car_id { get; set; }

        public frmImportReport()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmImportReport_Load(object sender, EventArgs e)
        {
            this.dtpDate1.Value = DateTime.Now;
            this.dtpDate2.Value = DateTime.Now;

            // フォームクリア
            InitializeForm();

            // this.Location.Offset(0, 0); 
        }
        /// <summary>
        /// フォームクリア
        /// </summary>
        private void InitializeForm()
        {
            // 各プロパティ値
            this.Location_id = 0;
            this.Location_name = "";
            this.Car_id = 0;

            // 専従先名クリア
            this.lblLocationName.Text = "";
            // 専従先車両クリア
            this.lblCarNo.Text = "";

            // XServer接続メッセージ
            this.lblConnect.Visible = false;

            // インポート完了メッセージ
            this.lblMessage.Visible = false;

            // インポート件数クリア
            this.lblCnt.Text = "";

            // 車両コンボボックス非表示
            this.btnCar.Enabled = false;

            // プログレスバー非表示、値初期化
            this.pgb.Visible = false;
            this.pgb.Minimum = 0;
            this.pgb.Maximum = 100;
            this.pgb.Value = 0;
            this.Dock = DockStyle.Top;
        }

        /// <summary>
        /// 専従先情報表示
        /// </summary>
        private void DisplayLocation()
        {
            frmSelectLocation fSelectLocation = new()
            {
                TargetTable = "Mst_専従先",
                Select_location_name = "",
                Select_location_id = 0
            };
            //fSelectLocation.targetTable = "Mst_専従先";
            //fSelectLocation.select_location_name = "";
            //fSelectLocation.select_location_id = 0;
            fSelectLocation.ShowDialog();

            if (fSelectLocation.Select_location_id > 0)
            {
                this.Location_id = fSelectLocation.Select_location_id;
                this.lblLocationName.Text = fSelectLocation.Select_location_name.ToString();
            }
        }
        /// <summary>
        /// 専従先選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectLocation_Click(object sender, EventArgs e)
        {
            // 専従先選択画面表示
            DisplayLocation();

            // 車両IDクリア、ボタン有効
            if (this.Location_id > 0)
            {
                this.Car_id = 0;
                this.btnCar.Enabled = true;
                this.lblCarNo.Text = "";
            }
        }
        /// <summary>
        /// 専従先車両選択ボタン
        /// </summary>
        private void DisplayLocationCar()
        {
            frmSelectItem fSelectItem = new()
            {
                IntKey = this.Location_id,
                Kbn = 6,                  // 専従先車両
                Value = 0
            };
            fSelectItem.ShowDialog();
            if (fSelectItem.Value == 0) { return; }

            // 車両情報保持
            this.Car_id = fSelectItem.Value;
            this.lblCarNo.Text = fSelectItem.StrVal;
        }
        /// <summary>
        /// 車両選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCar_Click(object sender, EventArgs e)
        {
            // 車両選択画面表示
            DisplayLocationCar();
        }
        /// <summary>
        /// インポート実行ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("日報データをインポートしますか？" + Environment.NewLine + "既に取込まれている日報がある場合は上書きされます。", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            // XServer接続メッセージ表示
            this.lblConnect.Visible = true;
            this.lblConnect.Refresh();

            ClsTrnReport cls = new()
            {
                // 抽出条件設定
                Key_from_day = this.dtpDate1.Value,
                Key_to_day = this.dtpDate2.Value
            };
            // 専従先
            if (this.Location_id > 0) { cls.Key_location_id = this.Location_id; }
            else { cls.Location_id = 0; }
            // 車両
            if (this.Car_id > 0) { cls.Key_car_id = this.Car_id; }
            else { cls.Car_id = 0; }

            // インポート実行
            var cnt = cls.ImportData(ref this.pgb);

            // XServer接続メッセージ
            this.lblConnect.Visible = false;
            this.lblConnect.Refresh();

            // インポート完了メッセージ
            this.lblMessage.Visible = true;
            this.lblMessage.Refresh();
            this.lblCnt.Text = cnt.ToString() + "件";
        }
        /// <summary>
        /// 条件クリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            // フォームクリア
            InitializeForm();
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
