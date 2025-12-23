using FlockAppC.tblClass;
using System;
using System.Windows.Forms;

namespace FlockAppC.データ同期
{
    public partial class fmrDeleteXData : Form
    {
        public fmrDeleteXData()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FmrDeleteXData_Load(object sender, EventArgs e)
        {
            // デフォルトで現在日より3ヶ月前の日付を表示
            DateTime today = DateTime.Now;
            DateTime threeMonthsAgo = today.AddMonths(-3);
            dtpDate.Value = threeMonthsAgo;

            chkCar.Checked = false;
            chkReport.Checked = false;
        }
        /// <summary>
        /// 削除実行ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExec_Click(object sender, EventArgs e)
        {
            // データ未選択
            if (chkCar.Checked == false && chkReport.Checked == false)
            {
                return;
            }

            // 確認メッセージ
            if (MessageBox.Show("選択したデータを削除しますか？", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

            // 接続メッセージ
            // XServer接続メッセージ表示
            this.lblConnect.Visible = true;
            this.lblConnect.Refresh();

            // 走行記録データ
            if (chkCar.Checked == true)
            {
                ClsTrnCarRun cls = new()
                {
                    Delete_date = dtpDate.Value,
                };
                cls.DeleteDate();
            }

            // 日報データ(MySQL側)
            if (chkReport.Checked == true)
            {
                ClsTrnReport cls = new()
                {
                    Delete_date = dtpDate.Value,
                };
                cls.DeleteDate();
            }

            // XServer接続メッセージ
            this.lblConnect.Visible = false;
            this.lblConnect.Refresh();
        }
    }
}
