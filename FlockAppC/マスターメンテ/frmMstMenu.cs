using System;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstMenu : Form
    {
        public frmMstMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 自社情報マスター
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMstCompany_Click(object sender, EventArgs e)
        {
            using (frmMstCompany frm = new frmMstCompany())
            {
                frm.ShowDialog();

            }
        }
        /// <summary>
        /// 所属マスター
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMstOffice_Click(object sender, EventArgs e)
        {
            using (frmMstOffice frm = new frmMstOffice())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 部門マスター
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu3_Click(object sender, EventArgs e)
        {
            using (frmMstGroup frm = new frmMstGroup())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 従業員マスター
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu9_Click(object sender, EventArgs e)
        {
            using (frmMstStaff frm = new frmMstStaff())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 従業員一覧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu10_Click(object sender, EventArgs e)
        {
            using(frmMstStaffList frm = new frmMstStaffList())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 社用車マスター
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu8_Click(object sender, EventArgs e)
        {
            using (frmMstCar frm = new frmMstCar())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 休日マスター
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu6_Click(object sender, EventArgs e)
        {
            using (frmMstHoliday frm = new frmMstHoliday())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 区分マスター
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu7_Click(object sender, EventArgs e)
        {
            using (frmMstKbn frm = new frmMstKbn())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 専従先設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocationStaff_Click(object sender, EventArgs e)
        {
            using (frmLocationStaff frm = new frmLocationStaff())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 専従先マスター
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu13_Click(object sender, EventArgs e)
        {
            using (frmMstLocation frm = new frmMstLocation())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 専従先車両マスター
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocationCar_Click(object sender, EventArgs e)
        {
            using (frmMstLocationCar frm = new frmMstLocationCar())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 起動プロセス設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu21_Click(object sender, EventArgs e)
        {
            using (frmMstProcess frm = new frmMstProcess())
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenuClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        /// <summary>
        /// 専従先車両・専従者設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocationCarStaff_Click(object sender, EventArgs e)
        {
            using (frmMstLocationCarStaff frm = new frmMstLocationCarStaff())
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
    }
}
