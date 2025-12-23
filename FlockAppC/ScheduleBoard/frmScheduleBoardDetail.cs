using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Data;
using System.Windows.Forms;

namespace FlockAppC.ScheduleBoard
{
    public partial class frmScheduleBoardDetail : Form
    {
        // 予定ID
        // public static int stc_intID;
        public static class Global
        {
            public static int ID;
        }

        public frmScheduleBoardDetail()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmScheduleBoardDetail_Load(object sender, EventArgs e)
        {
            // コンボボックス（担当者）セット
            // FlockApp.modMst.SetTantoCmb2(ref cmbScheduleTanto);
            ClsControll clsCon = new();
            clsCon.SetTantoCmb(cmbScheduleTanto);

            // 画面クリア
            InitialDiaplay();

            // ID > 0の時、予定情報表示
            DisplaySchedule();
        }

        /// <summary>
        /// 画面クリア
        /// </summary>
        private void InitialDiaplay()
        {
            dtpSchedule.Value = DateTime.Now;
            cmbScheduleTanto.SelectedIndex = 0;
            dtpScheduleStartTime.Value = DateTime.Parse("1900/01/01 00:00:00");
            dtpScheduleEndTime.Value = DateTime.Parse("1900/01/01 00:00:00");
            txtSchedule.Text = "";
            chkReturn.Checked = false;
            chkStatus.Checked = false;
        }

        /// <summary>
        /// 予定データ画面表示
        /// </summary>
        private void DisplaySchedule()
        {
            ClsTrnSchedule clsShd = new();

            // ID指定無しの時、処理終了
            if (Global.ID < 1)
            {
                return;
            }

            try
            {
                clsShd.Id = Global.ID;
                clsShd.DMLSelect();

                // 件数０
                if (clsShd.Dt.Rows.Count <= 0) return;

                // 結果を読み込みデータテーブルへセット
                foreach (DataRow dr in clsShd.Dt.Rows)
                {
                    dtpSchedule.Value = DateTime.Parse(dr["day"].ToString());
                    txtSchedule.Text = dr["schedule"].ToString();
                    cmbScheduleTanto.SelectedValue = int.Parse(dr["tanto_id"].ToString());
                    dtpScheduleStartTime.Value = DateTime.Parse(dr["schedule_start_time"].ToString());
                    dtpScheduleEndTime.Value = DateTime.Parse(dr["schedule_end_time"].ToString());
                    if (int.Parse(dr["return_flag"].ToString()) == 1)
                    {
                        chkReturn.Checked = true;
                    }
                    else
                    {
                        chkReturn.Checked = false;
                    }
                    // Status
                    if (int.Parse(dr["status"].ToString()) == 1)
                    {
                        chkStatus.Checked = true;
                    }
                    else
                    {
                        chkStatus.Checked = false;
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
        /// 登録ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReg_Click(object sender, EventArgs e)
        {
            // 入力チェック
            if (CheckInputData() == false)
            {
                return;
            }

            ClsTrnSchedule clsShd = new();

            // 接続先指定
            // clsShd.DbType = clsPublic.DBNo;

            try
            {
                // 予定ID判定
                if (Global.ID == 0)
                {
                    // INSERT
                    clsShd.Day = dtpSchedule.Value;
                    clsShd.Schedule = txtSchedule.Text;
                    clsShd.TantoID = Convert.ToInt32(cmbScheduleTanto.SelectedValue);
                    clsShd.ScheduleStartTime = dtpScheduleStartTime.Value;
                    clsShd.ScheduleEndTime = dtpScheduleEndTime.Value;
                    if (chkReturn.Checked == true)
                    {
                        clsShd.ReturnFlag = 1;
                    }
                    else
                    {
                        clsShd.ReturnFlag = 0;
                    }
                    // Status
                    if (chkStatus.Checked == true)
                    {
                        clsShd.Status = 1;
                    }
                    else
                    {
                        clsShd.Status = 0;
                    }

                    clsShd.DMLInsert();
                }
                else
                {
                    // UPDATE
                    clsShd.Day = (DateTime)dtpSchedule.Value;
                    clsShd.Schedule = txtSchedule.Text;
                    clsShd.TantoID = Convert.ToInt32(cmbScheduleTanto.SelectedValue);
                    clsShd.ScheduleStartTime = (DateTime)dtpScheduleStartTime.Value;
                    clsShd.ScheduleEndTime = (DateTime)dtpScheduleEndTime.Value;
                    if (chkReturn.Checked == true)
                    {
                        clsShd.ReturnFlag = 1;
                    }
                    else
                    {
                        clsShd.ReturnFlag = 0;
                    }
                    // Status
                    if (chkStatus.Checked == true)
                    {
                        clsShd.Status = 1;
                    }
                    else
                    {
                        clsShd.Status = 0;
                    }
                    clsShd.Id = Global.ID;
                    clsShd.DMLUpdate();
                }

                MessageBox.Show("登録しました。", "結果", MessageBoxButtons.OK);

                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns>True:OK  False:NG</returns>
        private Boolean CheckInputData()
        {
            if (txtSchedule .Text == "")
            {
                MessageBox.Show("予定に何も入力されていません。", "チェック結果", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 削除ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ClsTrnSchedule clsShd = new();

            // 接続先指定
            // clsShd.DbType = clsPublic.DBNo;

            // ID有り
            if (Global.ID != 0)
            {
                clsShd.Id = Global.ID;
                clsShd.DMLDelete();

                MessageBox.Show("削除しました。", "結果", MessageBoxButtons.OK);
            }
            this.Close();
            this.Dispose();

        }

        /// <summary>
        /// 閉じるボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close ();
            this.Dispose();    
        }

        /// <summary>
        /// フォーム表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmScheduleBoardDetail_Shown(object sender, EventArgs e)
        {
            txtSchedule.Focus();
        }
    }
}
