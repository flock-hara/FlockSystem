using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlockAppC.データ同期
{
    public partial class frmContemporaryMenu : Form
    {
        public frmContemporaryMenu()
        {
            InitializeComponent();
        }

        private void FrmContemporaryMenu_Load(object sender, EventArgs e)
        {
            // ボタンテキスト編集
            this.btnExportMaster.Text = "マスターデータ" + Environment.NewLine + "一括エクスポート";
            this.btnImportReport.Text = "日報データ" + Environment.NewLine + "インポート";

            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// エクスポートボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExportMaster_Click(object sender, EventArgs e)
        {
            frmExportMaster frm = new();
            frm.ShowDialog();
        }
        /// <summary>
        /// 日報データボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImportReport_Click(object sender, EventArgs e)
        {
            // インポート画面
            frmImportReport cls = new();
            cls.ShowDialog();
        }
        /// <summary>
        /// 走行記録データインポート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImportCarRun_Click(object sender, EventArgs e)
        {
            // インポート画面
            frmCarRun cls = new();
            cls.ShowDialog();
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            // フォームクローズ
            this.Close();
        }
        /// <summary>
        /// 過去データ削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteData_Click(object sender, EventArgs e)
        {
            // データ削除画面
            fmrDeleteXData cls = new();
            cls.ShowDialog();
        }
    }
}
