using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.CodeDom;
using System.Drawing;
using System.Windows.Forms;

namespace FlockAppC.データ同期
{
    public partial class frmExportMaster : Form
    {
        public frmExportMaster()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmExportMaster_Load(object sender, EventArgs e)
        {
            // メッセージ非表示
            // this.lblMessage.Visible = false;
            // this.lblConnect.Visible = false;

            // チェッククリア （マスター）
            this.lblCheck1.Image = null;            // 従業員
            this.lblCheck2.Image = null;            // 専従先
            this.lblCheck3.Image = null;            // 専従先車両
            this.lblCheck4.Image = null;            // 専従先専従者
            // this.lblCheck5.Image = null;         // 所属
            // this.lblCheck6.Image = null;         // 部門
            // this.lblCheck7.Image = null;         // 自社情報
            this.lblCheck8.Image = null;            // 社用車
            this.lblCheck9.Image = null;            // 区分
            // this.lblCheck10.Image = null;        // 休日
            this.lblCheck12.Image = null;           // 専従先車両運転者定義
            this.lblCheck13.Image = null;           // 基本契約時間
            // this.lblCheck14.Image = null;        // 専従先車両走行契約
            this.lblCheck15.Image = null;           // 専従先担当者

            // デフォルトチェック（マスター）
            this.chkStaff.Checked = true;
            this.chkLocation.Checked = true;
            this.chkLocationCar.Checked = true;
            this.chkLocationStaff.Checked = true;
            // this.chkOffice.Checked = false;
            // this.chkGroup.Checked = false;
            // this.chkCompany.Checked = false;
            this.chkCar.Checked = true;
            this.chkKbn.Checked = true;
            // this.chkHoliday.Checked = false;
            this.chkLocationCarStaff.Checked = true;
            this.chkBasicContractTime.Checked = true;
            // this.chkLocationCarContract.Checked = true;
            this.chkLocationUser.Checked = true;

            // マスターメンテ権限判定
            if (ClsLoginUser.MasterMenteFlag != 1)
            {
                // 実行ボタンを無効にする
                this.btnExportExec.Enabled = false;
            }

            // フォームクリア
            InitializeForm();

            this.Location = new Point(0, 0);
        }
        private void InitializeForm()
        {
            // XServer接続メッセージ
            this.lblConnect.Visible = false;

            // インポート完了メッセージ
            this.lblMessage.Visible = false;

            // プログレスバー非表示、値初期化
            this.pgb.Visible = false;
            InitializePBar();
        }
        /// <summary>
        /// プログレスバー初期化
        /// </summary>
        private void InitializePBar()
        {
            this.pgb.Minimum = 0;
            this.pgb.Maximum = 100;
            this.pgb.Value = 0;
            this.Dock = DockStyle.Top;
        }

        /// <summary>
        /// エクスポート実行ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportExec_Click(object sender, EventArgs e)
        {
            // 実行確認メッセージ
            if (MessageBox.Show("エクスポートを実行します。", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            // メッセージ非表示
            this.lblMessage.Visible = false;

            // XServer接続ﾒｯｾｰｼﾞ表示
            this.lblConnect.Visible = true;
            this.lblConnect.Refresh();

            // カーソルを砂時計に変更
            Cursor.Current = Cursors.WaitCursor;

            // チェッククリア（イメージ設定クリア）
            this.lblCheck1.Image = null;
            this.lblCheck2.Image = null;
            this.lblCheck3.Image = null;
            this.lblCheck4.Image = null;
            // this.lblCheck5.Image = null;
            // this.lblCheck6.Image = null;
            // this.lblCheck7.Image = null;
            this.lblCheck8.Image = null;
            this.lblCheck9.Image = null;
            // this.lblCheck10.Image = null;
            this.lblCheck12.Image = null;
            this.lblCheck13.Image = null;
            // this.lblCheck14.Image = null;
            this.lblCheck15.Image = null;

            // 選択されているマスターのみエクスポート
            if (this.chkStaff.Checked)
            {
                // =====================================================================
                // 従業員マスター、従業員詳細　　2024/10/18済
                // =====================================================================
                ExportMstStaff();
                this.lblCheck1.Image = Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkCar.Checked)
            {
                // =====================================================================
                // 社用車マスター
                // =====================================================================
                ExportMstCar();
                this.lblCheck8.Image = Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkLocation.Checked)
            {
                // =====================================================================
                // 専従先マスター
                // =====================================================================
                ExportMstLocation();
                this.lblCheck2.Image = Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkLocationCar.Checked)
            {
                // =====================================================================
                // 専従先車両マスター
                // =====================================================================
                ExportMstLocationCar();
                this.lblCheck3.Image = Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkLocationStaff.Checked)
            {
                // =====================================================================
                // 専従先専従者マスター
                // =====================================================================
                ExportMstLocationStaff();
                this.lblCheck4.Image = Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkLocationCarStaff.Checked)
            {
                // =====================================================================
                // 専従先車両運転者定義マスター　2026/1/9 時点で未使用。エクスポート処理も変更前のまま。
                // =====================================================================
                //ExportMstLocationCarStaff();
                //this.lblCheck12.Image = Properties.Resources.チェックマーク_小;
                //this.Refresh();
            }
            if (this.chkBasicContractTime.Checked)
            {
                // =====================================================================
                // 基本契約時間マスター
                // =====================================================================
                ExportMstBasicContractTime();
                ExportMstBasicContractWeek();
                this.lblCheck13.Image = Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkLocationUser.Checked)
            {
                // =====================================================================
                // 専従先担当者マスター
                // =====================================================================
                ExportMstLocationUser();
                this.lblCheck15.Image = Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            //if (this.chkLocationCarContract.Checked)
            //{
            //    // =====================================================================
            //    // 専従先車両走行契約マスター
            //    // =====================================================================
            //    ExportMstLocationCarContract();
            //    this.lblCheck14.Image = FlockAppC.Properties.Resources.チェックマーク_小;
            //    this.Refresh();
            //}
            //if (this.chkOffice.Checked)
            //{
            //    // =====================================================================
            //    // 所属マスター
            //    // =====================================================================
            //    ExportMstOffice();
            //    this.lblCheck5.Image = FlockAppC.Properties.Resources.チェックマーク_小;
            //    this.Refresh();
            //}
            //if (this.chkGroup.Checked)
            //{
            //    // =====================================================================
            //    // 部門マスター
            //    // =====================================================================
            //    ExportMstGroup();
            //    this.lblCheck6.Image = FlockAppC.Properties.Resources.チェックマーク_小;
            //    this.Refresh();
            //}
            //if (this.chkCompany.Checked)
            //{
            //    // =====================================================================
            //    // 自社マスター
            //    // =====================================================================
            //    ExportMstCompany();
            //    this.lblCheck7.Image = FlockAppC.Properties.Resources.チェックマーク_小;
            //    this.Refresh();
            //}
            if (this.chkKbn.Checked)
            {
                // =====================================================================
                // 区分マスター
                // =====================================================================
                ExportMstKbn();
                this.lblCheck9.Image = Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            //if (this.chkHoliday.Checked)
            //{
            //    // =====================================================================
            //    // 休日マスター
            //    // =====================================================================
            //    ExportMstHoliday();
            //    this.lblCheck10.Image = FlockAppC.Properties.Resources.チェックマーク_小;
            //    this.Refresh();
            //}

            // 完了メッセージ表示
            this.lblMessage.Visible = true;

            // XServer接続メッセージ非表示
            this.lblConnect.Visible = false;
            this.lblConnect.Refresh();

            // 操作後、カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// 従業員マスタエクスポート
        /// </summary>
        private void ExportMstStaff()
        {
            try
            {
                // プログレスバー初期化
                InitializePBar();

                // xserverの社員テーブルにSQL Serverの社員情報をエクスポート
                this.lblMessage.Text = "従業員マスターエクスポート中...";
                ClsMstStaff clsStf = new();
                clsStf.ExportStaffData(ref this.pgb);
                clsStf = null;

                // 詳細情報は現段階では不要
                // clsMstStaffDetail clsStfDtl = new clsMstStaffDetail();
                // clsStfDtl.exportStaffDetailData();
                // clsStfDtl = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
            finally 
            {
                this.lblMessage.Text = "エクスポートが完了しました。";
            }
        }
        /// <summary>
        /// 専従先マスタエクスポート
        /// </summary>
        private void ExportMstLocation()
        {
            try
            {
                // プログレスバー初期化
                InitializePBar();

                // xserverの社員テーブルにSQL Serverの社員情報をエクスポート
                this.lblMessage.Text = "専従先マスターエクスポート中...";
                ClsMstLocation clsStf = new();
                clsStf.ExportLocationData(ref this.pgb);
                clsStf = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
            finally
            {
                this.lblMessage.Text = "エクスポートが完了しました。";
            }
        }
        /// <summary>
        /// 専従先車両マスタエクスポート
        /// </summary>
        private void ExportMstLocationCar()
        {
            try
            {
                // プログレスバー初期化
                InitializePBar();

                // xserverの社員テーブルにSQL Serverの社員情報をエクスポート
                this.lblMessage.Text = "専従先車両マスターエクスポート中...";
                ClsMstLocationCar clsStf = new();
                clsStf.ExportLocationCarData(ref this.pgb);
                clsStf = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
            finally
            {
                this.lblMessage.Text = "エクスポートが完了しました。";
            }
        }
        /// <summary>
        /// 専従先専従者マスタエクスポート
        /// </summary>
        private void ExportMstLocationStaff()
        {
            try
            {
                // プログレスバー初期化
                InitializePBar();

                // xserverの社員テーブルにSQL Serverの社員情報をエクスポート
                this.lblMessage.Text = "専従先専従者マスターエクスポート中...";
                ClsMstStaff clsStf = new();
                clsStf.ExportLocationStaffData(ref this.pgb);
                clsStf = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
            finally
            {
                this.lblMessage.Text = "エクスポートが完了しました。";
            }   
        }
        /// <summary>
        /// 専従先車両運転者定義マスタエクスポート
        /// </summary>
        private void ExportMstLocationCarStaff()
        {
            try
            {
                // プログレスバー初期化
                InitializePBar();

                // xserverの社員テーブルにSQL Serverの社員情報をエクスポート
                ClsMstLocationCarStaff clsLcf = new();
                clsLcf.ExportLocationCarStaffData(ref this.pgb);
                clsLcf = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 基本契約時間マスタエクスポート
        /// </summary>
        private void ExportMstBasicContractTime()
        {
            try
            {
                // プログレスバー初期化
                InitializePBar();

                // xserverのテーブルにSQL Serverの情報をエクスポート
                this.lblMessage.Text = "基本契約時間マスターエクスポート中...";
                ClsMstBasicContractTime clsBct = new();
                clsBct.ExportBasicContractTimeData(ref this.pgb);
                clsBct = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
            finally
            {
                this.lblMessage.Text = "エクスポートが完了しました。";
            }
        }
        /// <summary>
        /// 基本契約曜日マスタエクスポート
        /// </summary>
        private void ExportMstBasicContractWeek()
        {
            try
            {
                // プログレスバー初期化
                InitializePBar();

                // xserverのテーブルにSQL Serverの情報をエクスポート
                this.lblMessage.Text = "基本契約曜日マスターエクスポート中...";
                ClsMstBasicContractWeek clsBct = new();
                clsBct.ExportBasicContractWeekData(ref this.pgb);
                clsBct = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
            finally
            {
                this.lblMessage.Text = "エクスポートが完了しました。";
            }
        }
        /// <summary>
        /// 専従先担当者マスタエクスポート
        /// </summary>
        private void ExportMstLocationUser()
        {
            try
            {
                // プログレスバー初期化
                InitializePBar();

                // xserverの社員テーブルにSQL Serverの社員情報をエクスポート
                this.lblMessage.Text = "専従先担当者マスターエクスポート中...";
                ClsMstLocationUser clsLcf = new();
                clsLcf.ExportLocationUserData(ref this.pgb);
                clsLcf = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
            finally
            {
                this.lblMessage.Text = "エクスポートが完了しました。";
            }
        }
        /// <summary>
        /// 専従先車両走行契約マスタエクスポート
        /// </summary>
        //private void ExportMstLocationCarContract()
        //{
        //    try
        //    {
        //        // プログレスバー初期化
        //        InitializePBar();

        //        // xserverのテーブルにSQL Serverの情報をエクスポート
        //        clsMstLocationCarContract clsLcc = new clsMstLocationCarContract();
        //        clsLcc.exportLocationCarContractData(ref this.pgb);
        //        clsLcc = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLogger.Log(ex.Message);
        //        throw;
        //    }
        //}
        /// <summary>
        /// 所属マスタエクスポート
        /// </summary>
        //private void ExportMstOffice()
        //{
        //    try
        //    {
        //        // xserverの所属テーブルにSQL Serverの所属情報をエクスポート
        //        clsMstOffice clsStf = new clsMstOffice();
        //        clsStf.exportOfficeData();
        //        clsStf = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLogger.Log(ex.Message);
        //        throw;
        //    }
        //}
        /// <summary>
        /// 部門マスタエクスポート
        /// </summary>
        //private void ExportMstGroup()
        //{
        //    try
        //    {
        //        // xserverの部門テーブルにSQL Serverの部門情報をエクスポート
        //        clsMstGroup clsStf = new clsMstGroup();
        //        clsStf.exportGroupData();
        //        clsStf = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLogger.Log(ex.Message);
        //        throw;
        //    }
        //}
        /// <summary>
        /// 自社情報マスタエクスポート
        /// </summary>
        //private void ExportMstCompany()
        //{
        //    try
        //    {
        //        // xserverの自社情報テーブルにSQL Serverの自社情報をエクスポート
        //        clsMstCompany clsStf = new clsMstCompany();
        //        clsStf.exportCompanyData();
        //        clsStf = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLogger.Log(ex.Message);
        //        throw;
        //    }
        //}
        /// <summary>
        /// 社用車マスタエクスポート
        /// </summary>
        private void ExportMstCar()
        {
            try
            {
                // プログレスバー初期化
                InitializePBar();

                // xserverの社用車テーブルにSQL Serverの社用車情報をエクスポート
                this.lblMessage.Text = "社用車マスターエクスポート中..."; 
                ClsMstCar clsStf = new();
                clsStf.ExportCarData(ref this.pgb);
                clsStf = null;

                // xserverの社用車オイル交換履歴テーブルにSQL Serverの情報をエクスポート
                // clsMstCarOil clsStfOil = new clsMstCarOil();
                // clsStfOil.exportCarOilData();
                // clsStfOil = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
            finally
            {
                this.lblMessage.Text = "エクスポートが完了しました。";
            }
        }
        /// <summary>
        /// 区分マスタエクスポート
        /// </summary>
        private void ExportMstKbn()
        {
            try
            {
                // プログレスバー初期化
                InitializePBar();

                // xserverの区分テーブルにSQL Serverの区分情報をエクスポート
                this.lblMessage.Text = "区分マスターエクスポート中...";
                ClsMstKbn clsStf = new();
                clsStf.ExportKbnData(ref this.pgb);
                clsStf = null;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
            finally
            {
                this.lblMessage.Text = "エクスポートが完了しました。";
            }
        }
       
        /// <summary>
        /// 休日マスタエクスポート
        /// </summary>
        //private void ExportMstHoliday()
        //{
        //    try
        //    {
        //        // xserverの休日テーブルにSQL Serverの休日情報をエクスポート
        //        clsMstHoliday clsStf = new clsMstHoliday();
        //        clsStf.exportHolidayData();
        //        clsStf = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLogger.Log(ex.Message);
        //        throw;
        //    }
        //}
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 全てチェックボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.chkStaff.Checked = true;               // 従業員
            this.chkLocation.Checked = true;            // 専従先
            this.chkLocationCar.Checked = true;         // 専従先車両
            this.chkLocationStaff.Checked = true;       // 専従先専従者
            this.chkCar.Checked = true;                 // 社用車
            this.chkKbn.Checked = true;                 // 区分
            this.chkLocationCarStaff.Checked = true;    // 専従先車両運転者定義
            this.chkBasicContractTime.Checked = true;   // 基本契約時間
            this.chkLocationUser.Checked = true;        // 専従先担当者
        }
        /// <summary>
        /// チェック解除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnCheck_Click(object sender, EventArgs e)
        {
            this.chkStaff.Checked = false;               // 従業員
            this.chkLocation.Checked = false;            // 専従先
            this.chkLocationCar.Checked = false;         // 専従先車両
            this.chkLocationStaff.Checked = false;       // 専従先専従者
            this.chkCar.Checked = false;                 // 社用車
            this.chkKbn.Checked = false;                 // 区分
            this.chkLocationCarStaff.Checked = false;    // 専従先車両運転者定義
            this.chkBasicContractTime.Checked = false;   // 基本契約時間
            this.chkLocationUser.Checked = false;        // 専従先担当者
        }
    }
}
