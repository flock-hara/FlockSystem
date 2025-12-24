using FlockAppC.pubClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlockAppC
{
    public partial class FrmFlockMenu : Form
    {
        public FrmFlockMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFlockMenu_Load(object sender, EventArgs e)
        {
            // ログイン名
            this.Text = "フロック車両サービス メインメニュー" + "　：ログインユーザー [ " + ClsLoginUser.Name1 + " ]";
            // DB名
            this.Text = this.Text + "　 データベース [" + ClsDbConfig.sqlParam[ClsDbConfig.SQLServerNo].Instance + "\\" + ClsDbConfig.sqlParam[ClsDbConfig.SQLServerNo].Database + "]";

            // Test
            // var txt = "　 データベース [" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Instance + "\\" + ClsDbConfig.mysqlParam[ClsDbConfig.MySQLNo].Database + "]";

            toolStripStatusLabel1.Text = String.Format("時刻 {0}", DateTime.Now.ToShortTimeString());
            stsLabel.Text = "";

            // =============================================================
            // メニュー制御
            // =============================================================
            // 勤怠メニューボタン
            // 2025/12/24 DEL
            // if (ClsLoginUser.AttendanceFlag != 1) { this.btnMnu05.Enabled = false; }
            // 日報メニューボタン
            if (ClsLoginUser.ReportManageFlag != 1) { this.btnMnu06.Enabled = false; }
            // マスターメンテボタン
            if (ClsLoginUser.MasterMenteFlag != 1) { this.btnMnu07.Enabled = false; }
            // データ同期ボタン
            if (ClsLoginUser.MasterMenteFlag != 1) { this.btnMnu08.Enabled = false; }

            // 左上に表示
            this.Location = new Point(0, 0);

            // =============================================================
            // メッセージチェック（現在は無効）
            // =============================================================
            //// 5秒おき
            //// Timer1.Interval = 5000
            //timer1.Interval = 10000;
            //// タイマー開始
            //// timer1.Enabled = true;
            //timer1.Enabled = false;

        }
        /// <summary>
        /// メニューボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            string controlName = "";

            // senderがButtonか判定
            if (sender is Button clickedButton)
            {
                controlName = clickedButton.Name;
            }

            // タイマー開始
            timer1.Enabled = false;

            // ボタンによって各遷移
            var formIsOpen = false;

            switch(controlName)
            {
                case "":
                    break;

                // ===========================================================================
                // 閉じる
                // ===========================================================================
                case "btnMnuClose":
                    this.Close();
                    this.Dispose();
                    break;

                // ===========================================================================
                // シャットダウン
                // ===========================================================================
                case "btnMnuShutdown":
                    ClsPublic.ShutdownMonitorPC();
                    break;

                // ===========================================================================
                // 説明
                // ===========================================================================
                case "btnMnuGuide":
                    ClsPublic.pubHelpID = 98;
                    using (pubForm.frmHelpView frm003 = new())
                    {
                        frm003.ShowDialog();
                    }
                    break;

                // ===========================================================================
                // 再起動
                // ===========================================================================
                case "btnMnuReBoot":
                    ClsPublic.ReBootPC();
                    break;

                // ===========================================================================
                // 勤務表関連
                // ===========================================================================
                case "btnMnu01":
                    // 開いているフォームの中から指定した名前のフォームを探す
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.Name == "frmShiftMenu") // フォームの名前を指定
                        {
                            formIsOpen = true;
                            break;
                        }
                    }
                    // 表示されている場合は処理終了
                    if (formIsOpen) { return; }

                    // フォーム表示
                    using (勤務表.frmShiftMenu frm101 = new())
                    {
                        frm101.ShowDialog();
                    }
                    break;

                case "btnMnu01_1":
                    // 勤務表モニター表示
                    // フラグ更新 1:終了 2:起動
                    ClsPublic.SetControllFlagOnOff(ClsPublic.PRC02, ClsPublic.DISP_ON);
                    break;

                case "btnMnu01_2":
                    // 勤務表モニター非表示
                    // フラグ更新 1:終了 2:起動
                    ClsPublic.SetControllFlagOnOff(ClsPublic.PRC02, ClsPublic.DISP_OFF);
                    break;

                // ===========================================================================
                // 募集掲載関連
                // ===========================================================================
                case "btnMnu02":
                    // 開いているフォームの中から指定した名前のフォームを探す
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.Name == "frmShiftMenu") // フォームの名前を指定
                        {
                            formIsOpen = true;
                            break;
                        }
                    }
                    // 表示されている場合は処理終了
                    if (formIsOpen) { return; }

                    // フォーム表示
                    using (求人関連.frmRecruitMain frm201 = new())
                    {
                        frm201.ShowDialog();
                    }
                    break;

                case "btnMnu02_1":
                    // モニター表示
                    // フラグ更新 1:終了 2:起動
                    ClsPublic.SetControllFlagOnOff(ClsPublic.PRC03, ClsPublic.DISP_ON);
                    break;

                case "btnMnu02_2":
                    // モニター非表示
                    // フラグ更新 1:終了 2:起動
                    ClsPublic.SetControllFlagOnOff(ClsPublic.PRC03, ClsPublic.DISP_OFF);
                    break;

                // ===========================================================================
                // 社用車関連
                // ===========================================================================
                case "btnMnu03":
                    using (社用車関連.frmCar frmCar = new())
                    {
                        frmCar.ShowDialog();
                    }
                    break;

                case "btnMnu03_1":
                    // モニター表示
                    // フラグ更新 1:終了 2:起動
                    ClsPublic.SetControllFlagOnOff(ClsPublic.PRC04, ClsPublic.DISP_ON);
                    break;

                case "btnMnu03_2":
                    // モニター非表示
                    // フラグ更新 1:終了 2:起動
                    ClsPublic.SetControllFlagOnOff(ClsPublic.PRC04, ClsPublic.DISP_OFF);
                    break;

                //// ===========================================================================
                //// 作業タスク、ツール関連
                //// ===========================================================================
                //case "btnMnu04":
                //    // 開いているフォームの中から指定した名前のフォームを探す
                //    foreach (Form form in Application.OpenForms)
                //    {
                //        if (form.Name == "frmDashBoard") // フォームの名前を指定
                //        {
                //            formIsOpen = true;
                //            break;
                //        }
                //    }
                //    // 表示されている場合は処理終了
                //    if (formIsOpen) { return; }

                //    // フォーム表示
                //    using (ダッシュボード.frmDashBoard frm601 = new ダッシュボード.frmDashBoard())
                //    {
                //        frm601.ShowDialog();
                //    }
                //    break;

                //case "btnMnu04_1":
                //    // フラグ更新 1:終了 2:起動
                //    clsPublic.SetControllFlagOnOff(clsPublic.PRC05, clsPublic.DISP_ON);
                //    break;

                //case "btnMnu04_2":
                //    // フラグ更新 1:終了 2:起動
                //    clsPublic.SetControllFlagOnOff(clsPublic.PRC05, clsPublic.DISP_OFF);
                //    break;

                // ===========================================================================
                // 勤怠関連
                // ===========================================================================
                case "btnMnu05":
                    //// 開いているフォームの中から指定した名前のフォームを探す
                    //foreach (Form form in Application.OpenForms)
                    //{
                    //    if (form.Name == "frmAttendanceMenu") // フォームの名前を指定
                    //    {
                    //        formIsOpen = true;
                    //        break;
                    //    }
                    //}
                    //// 表示されている場合は処理終了
                    //if (formIsOpen) { return; }

                    //// フォーム表示
                    //using(勤怠管理.frmAttendanceMenu frm401 = new 勤怠管理.frmAttendanceMenu())
                    //{
                    //    frm401.ShowDialog();
                    //}
                    break;

                // ===========================================================================
                // 作業日報関連
                // ===========================================================================
                case "btnMnu06":
                    // 開いているフォームの中から指定した名前のフォームを探す
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.Name == "frmReportMenu") // フォームの名前を指定
                        {
                            formIsOpen = true;
                            break;
                        }
                    }
                    // 表示されている場合は処理終了
                    if (formIsOpen) { return; }

                    // フォーム表示
                    using (FlockAppC.Report.frmReportMenu frm501 = new())
                    {
                        frm501.ShowDialog();
                    }
                    break;

                // ===========================================================================
                // マスターメンテナンス
                // ===========================================================================
                case "btnMnu07":
                    // 開いているフォームの中から指定した名前のフォームを探す
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.Name == "frmMstMenu") // フォームの名前を指定
                        {
                            formIsOpen = true;
                            break;
                        }
                    }
                    // 表示されている場合は処理終了
                    if (formIsOpen) { return; }

                    // フォーム表示
                    using (マスターメンテ.frmMstMenu frm901 = new())
                    {
                        frm901.ShowDialog();
                    }
                    break;

                // ===========================================================================
                // データ同期
                // ===========================================================================
                case "btnMnu08":
                    // 開いているフォームの中から指定した名前のフォームを探す
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.Name == "frmContemporaryMenu") // フォームの名前を指定
                        {
                            formIsOpen = true;
                            break;
                        }
                    }
                    // 表示されている場合は処理終了
                    if (formIsOpen) { return; }

                    // フォーム表示
                    using (データ同期.frmContemporaryMenu frm701 = new())
                    {
                        frm701.ShowDialog();
                    }
                    break;

                // ===========================================================================
                // その他
                // ===========================================================================
                case "btnMnu09":
                    using(frmSysMenu frm = new())
                    {
                        frm.ShowDialog();
                    }

                    // ログイン名
                    this.Text = "フロック車両サービス メインメニュー" + "　：ログインユーザー [ " + ClsLoginUser.Name1 + " ]";
                    // DB名
                    this.Text = this.Text + "　 データベース [" + ClsDbConfig.sqlParam[ClsDbConfig.SQLServerNo].Instance + "\\" + ClsDbConfig.sqlParam[ClsDbConfig.SQLServerNo].Database + "]";
                    this.Refresh();
                    break;

                // ===========================================================================
                // 行動予定表
                // ===========================================================================
                case "btnMnu10":
                    // 開いているフォームの中から指定した名前のフォームを探す
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.Name == "frmScheduleBoard") // フォームの名前を指定
                        {
                            formIsOpen = true;
                            break;
                        }
                    }
                    // 表示されている場合は処理終了
                    if (formIsOpen) { return; }

                    // フォーム表示
                    using (ScheduleBoard.frmScheduleBoard frm604 = new())
                    {
                        frm604.ShowDialog();
                    }
                    break;
            }
            //// タイマー開始
            //// timer1.Enabled = true;
            //timer1.Enabled = false;
        }
        /// <summary>
        /// タイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    // 受信メッセージチェック
        //    checkReceiveMessage();
        //}
        /// <summary>
        /// フォームアクティブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFlockMenu_Activated(object sender, EventArgs e)
        {
            this.TopMost = false;

        }
        /// <summary>
        /// メッセージ受信チェック
        /// </summary>
        //private void checkReceiveMessage()
        //{
        //    // メッセージはMySQL固定
        //    // var cnt = clsPublic.checkReceiveMessage(clsPublic.DBNo);
        //    var cnt = clsPublic.checkReceiveMessage(clsPublic.XSERVER_DB);

        //    if (cnt >= 1)
        //    {
        //        this.stsLabel.Text = "メッセージあり（" + cnt + "件）";
        //    }
        //    else
        //    {
        //        this.stsLabel.Text = "";
        //    }
        //}
    }
}
