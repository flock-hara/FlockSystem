using FlockAppC.データ同期;
using FlockAppC.マスターメンテ;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlockAppC.Report
{
    public partial class frmReportMenu : Form
    {
        public frmReportMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReportMenu_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
        }
        /// <summary>
        /// 従業員マスタ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMstStaff_Click(object sender, EventArgs e)
        {
            using (frmMstStaff frm = new())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 従業員一覧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStaffList_Click(object sender, EventArgs e)
        {
            using (frmMstStaffList frm = new())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 専従先
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMstLocation_Click(object sender, EventArgs e)
        {
            using (frmMstLocation frm = new())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 専従先車両
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMstLocationCar_Click(object sender, EventArgs e)
        {
            using (frmMstLocationCar frm = new())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// マスターデータエクスポート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportMaster_Click(object sender, EventArgs e)
        {
            using (frmExportMaster frm = new())
            {
                frm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLocationStaff_Click(object sender, EventArgs e)
        {
            using (frmLocationStaff frm = new())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 日報データ一覧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListReport_Click(object sender, EventArgs e)
        {
            using (frmTrnReportList frm = new())
            {
                frm.ShowDialog();
            }
        }

        private void btnImportReport_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 専従先車両・専従者紐づけ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocationCarStaff_Click(object sender, EventArgs e)
        {
            using (frmMstLocationCarStaff frm = new())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 基本契約時間
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBasicContractTime_Click(object sender, EventArgs e)
        {
            using (frmMstBasicContractTime frm = new frmMstBasicContractTime())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 日報データインポートボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportReport_Click_1(object sender, EventArgs e)
        {
            // インポート画面
            using (frmImportReport cls = new())
            {
                cls.ShowDialog();
            }
        }
        /// <summary>
        /// 日報データエクスポートボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            // エクスポート画面
            using (frmExportReport cls = new())
            {
                cls.ShowDialog();
            }
        }
    }
}
