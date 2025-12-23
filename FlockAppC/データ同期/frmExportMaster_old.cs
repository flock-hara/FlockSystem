using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.日報関連
{
    public partial class frmExportMaster_old : Form
    {
        public frmExportMaster_old()
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
            this.lblMessage.Visible = false;

            // チェッククリア （マスター）
            this.lblCheck1.Image = null;            // 従業員
            this.lblCheck2.Image = null;            // 専従先
            this.lblCheck3.Image = null;            // 専従先車両
            this.lblCheck4.Image = null;            // 専従先担当者
            this.lblCheck5.Image = null;            // 所属
            this.lblCheck6.Image = null;            // 部門
            this.lblCheck7.Image = null;            // 自社情報
            this.lblCheck8.Image = null;            // 社用車
            this.lblCheck9.Image = null;            // 区分
            this.lblCheck10.Image = null;           // 休日
            this.lblCheck12.Image = null;           // 専従先車両運転者定義
            this.lblCheck13.Image = null;           // 基本契約時間

            // デフォルトチェック（マスター）
            this.chkStaff.Checked = true;
            this.chkLocation.Checked = true;
            this.chkLocationCar.Checked = true;
            this.chkLocationStaff.Checked = true;
            this.chkOffice.Checked = false;
            this.chkGroup.Checked = false;
            this.chkCompany.Checked = false;
            this.chkCar.Checked = true;
            this.chkKbn.Checked = false;
            this.chkHoliday.Checked = false;
            this.chkLocationCarStaff.Checked = true;
            this.chkBasicContractTime.Checked = true;

            // チェッククリア （勤務表）
            this.lblCheck11.Image = null;
            // デフォルトチェック（勤務表）
            this.chkTask.Checked = true;

            // チェッククリア （その他）
            this.lblCheck21.Image = null;
            this.lblCheck22.Image = null;
            // デフォルトチェック（その他）

            // マスターメンテ権限判定
            if (clsLoginUser.MasterMenteFlag != 1)
            {
                // 実行ボタンを無効にする
                this.btnExportExec.Enabled = false;
                this.btnExportExec2.Enabled = false;
                this.btnExportExec3.Enabled = false;
            }


            this.Location = new Point(0, 0);
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

            // カーソルを砂時計に変更
            Cursor.Current = Cursors.WaitCursor;

            // チェッククリア（イメージ設定クリア）
            this.lblCheck1.Image = null;
            this.lblCheck2.Image = null;
            this.lblCheck3.Image = null;
            this.lblCheck4.Image = null;
            this.lblCheck5.Image = null;
            this.lblCheck6.Image = null;
            this.lblCheck7.Image = null;
            this.lblCheck8.Image = null;
            this.lblCheck9.Image = null;
            this.lblCheck10.Image = null;
            this.lblCheck12.Image = null;
            this.lblCheck13.Image = null;

            // 選択されているマスターのみエクスポート
            if (this.chkStaff.Checked)
            {
                // =====================================================================
                // 従業員マスター、従業員詳細　　2024/10/18済
                // =====================================================================
                ExportMstStaff();
                this.lblCheck1.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkLocation.Checked)
            {
                // =====================================================================
                // 専従先マスター
                // =====================================================================
                ExportMstLocation();
                this.lblCheck2.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkLocationCar.Checked)
            {
                // =====================================================================
                // 専従先車両マスター
                // =====================================================================
                ExportMstLocationCar();
                this.lblCheck3.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkLocationStaff.Checked)
            {
                // =====================================================================
                // 専従先担当者マスター
                // =====================================================================
                ExportMstLocationStaff();
                this.lblCheck4.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkOffice.Checked)
            {
                // =====================================================================
                // 所属マスター
                // =====================================================================
                ExportMstOffice();
                this.lblCheck5.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkGroup.Checked)
            {
                // =====================================================================
                // 部門マスター
                // =====================================================================
                ExportMstGroup();
                this.lblCheck6.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkCompany.Checked)
            {
                // =====================================================================
                // 自社マスター
                // =====================================================================
                ExportMstCompany();
                this.lblCheck7.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkCar.Checked)
            {
                // =====================================================================
                // 社用車マスター
                // =====================================================================
                ExportMstCar();
                this.lblCheck8.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkKbn.Checked)
            {
                // =====================================================================
                // 区分マスター
                // =====================================================================
                ExportMstKbn();
                this.lblCheck9.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkHoliday.Checked)
            {
                // =====================================================================
                // 休日マスター
                // =====================================================================
                ExportMstHoliday();
                this.lblCheck10.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkLocationCarStaff.Checked)
            {
                // =====================================================================
                // 専従先車両運転者定義マスター
                // =====================================================================
                ExportMstLocationCarStaff();
                this.lblCheck12.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkBasicContractTime.Checked)
            {
                // =====================================================================
                // 基本契約時間マスター
                // =====================================================================
                ExportMstBasicContractTime();
                ExportMstBasicContractWeek();
                this.lblCheck13.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }

            this.lblMessage.Visible = true;

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
                // xserverの社員テーブルにSQL Serverの社員情報をエクスポート
                clsMstStaff clsStf = new clsMstStaff();
                clsStf.exportStaffData();
                clsStf = null;

                clsMstStaffDetail clsStfDtl = new clsMstStaffDetail();
                clsStfDtl.exportStaffDetailData();
                clsStfDtl = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 専従先マスタエクスポート
        /// </summary>
        private void ExportMstLocation()
        {
            try
            {
                // xserverの社員テーブルにSQL Serverの社員情報をエクスポート
                clsMstLocation clsStf = new clsMstLocation();
                clsStf.exportLocationData();
                clsStf = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 専従先車両マスタエクスポート
        /// </summary>
        private void ExportMstLocationCar()
        {
            try
            {
                // xserverの社員テーブルにSQL Serverの社員情報をエクスポート
                clsMstLocationCar clsStf = new clsMstLocationCar();
                clsStf.exportLocationCarData();
                clsStf = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 専従先担当マスタエクスポート
        /// </summary>
        private void ExportMstLocationStaff()
        {
            try
            {
                // xserverの社員テーブルにSQL Serverの社員情報をエクスポート
                clsMstStaff clsStf = new clsMstStaff();
                clsStf.exportLocationStaffData();
                clsStf = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 専従先車両運転者定義マスタエクスポート
        /// </summary>
        private void ExportMstLocationCarStaff()
        {
            try
            {
                // xserverの社員テーブルにSQL Serverの社員情報をエクスポート
                clsMstLocationCarStaff clsLcf = new clsMstLocationCarStaff();
                clsLcf.exportLocationCarStaffData();
                clsLcf = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
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
                // xserverのテーブルにSQL Serverの情報をエクスポート
                clsMstBasicContractTime clsBct = new clsMstBasicContractTime();
                clsBct.exportBasicContractTimeData();
                clsBct = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 基本契約曜日マスタエクスポート
        /// </summary>
        private void ExportMstBasicContractWeek()
        {
            try
            {
                // xserverのテーブルにSQL Serverの情報をエクスポート
                clsMstBasicContractWeek clsBct = new clsMstBasicContractWeek();
                clsBct.exportBasicContractWeekData();
                clsBct = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 所属マスタエクスポート
        /// </summary>
        private void ExportMstOffice()
        {
            try
            {
                // xserverの所属テーブルにSQL Serverの所属情報をエクスポート
                clsMstOffice clsStf = new clsMstOffice();
                clsStf.exportOfficeData();
                clsStf = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 部門マスタエクスポート
        /// </summary>
        private void ExportMstGroup()
        {
            try
            {
                // xserverの部門テーブルにSQL Serverの部門情報をエクスポート
                clsMstGroup clsStf = new clsMstGroup();
                clsStf.exportGroupData();
                clsStf = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 自社情報マスタエクスポート
        /// </summary>
        private void ExportMstCompany()
        {
            try
            {
                // xserverの自社情報テーブルにSQL Serverの自社情報をエクスポート
                clsMstCompany clsStf = new clsMstCompany();
                clsStf.exportCompanyData();
                clsStf = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 社用車マスタエクスポート
        /// </summary>
        private void ExportMstCar()
        {
            try
            {
                // xserverの社用車テーブルにSQL Serverの社用車情報をエクスポート
                clsMstCar clsStf = new clsMstCar();
                clsStf.exportCarData();
                clsStf = null;

                // xserverの社用車オイル交換履歴テーブルにSQL Serverの情報をエクスポート
                clsMstCarOil clsStfOil = new clsMstCarOil();
                clsStfOil.exportCarOilData();
                clsStfOil = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 区分マスタエクスポート
        /// </summary>
        private void ExportMstKbn()
        {
            try
            {
                // xserverの区分テーブルにSQL Serverの区分情報をエクスポート
                clsMstKbn clsStf = new clsMstKbn();
                clsStf.exportKbnData();
                clsStf = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 休日マスタエクスポート
        /// </summary>
        private void ExportMstHoliday()
        {
            try
            {
                // xserverの休日テーブルにSQL Serverの休日情報をエクスポート
                clsMstHoliday clsStf = new clsMstHoliday();
                clsStf.exportHolidayData();
                clsStf = null;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex.Message);
                throw;
            }
        }
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
        /// 勤務表関連エクスポート実行ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportExec2_Click(object sender, EventArgs e)
        {
            if (this.chkShift.Checked != true) return;

            // 実行確認メッセージ
            if (MessageBox.Show("エクスポートを実行します。", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            // メッセージ非表示
            this.lblMessage.Visible = false;

            // カーソルを砂時計に変更
            Cursor.Current = Cursors.WaitCursor;

            // チェッククリア（イメージ設定クリア）
            this.lblCheck11.Image = null;

            // 選択されているマスターのみエクスポート
            if (this.chkShift.Checked)
            {
                // 作業予定関連データ（勤務表環境設定、画面サイズ、シフト情報、シフト変更、連絡、勤務表変更日付、勤務表シフト変更履歴）
                // ExportShift();
                this.lblCheck11.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }

            this.lblMessage.Visible = true;

            // 操作後、カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }

        private void btnExportExec3_Click(object sender, EventArgs e)
        {
            // 実行確認メッセージ
            if (MessageBox.Show("エクスポートを実行します。", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            // メッセージ非表示
            this.lblMessage.Visible = false;

            // カーソルを砂時計に変更
            Cursor.Current = Cursors.WaitCursor;

            // チェッククリア（イメージ設定クリア）
            this.lblCheck21.Image = null;
            this.lblCheck22.Image = null;

            // 選択されているマスターのみエクスポート
            if (this.chkMemo.Checked)
            {
                // メモ履歴
                ExportMemo();
                this.lblCheck21.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }
            if (this.chkTask.Checked)
            {
                // 作業タスク関連
                // ExportTask();
                this.lblCheck22.Image = FlockAppC.Properties.Resources.チェックマーク_小;
                this.Refresh();
            }

            this.lblMessage.Visible = true;

            // 操作後、カーソルを元に戻す
            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// メモ履歴エクスポート
        /// </summary>
        private void ExportMemo()
        {
            StringBuilder st = new StringBuilder();

            try
            {
                // 接続中メッセージ
                clsPublic.lblConnect = this.lblConnect;

                using (clsDb clsS = new clsDb(clsPublic.DBNo))                      // SQL Server
                using (clsDb clsM = new clsDb(clsPublic.XSERVER_DB))                // MySQL
                {
                    // MySQL側データを一括削除
                    st.Length = 0;
                    st.AppendLine("TRUNCATE TABLE");
                    st.AppendLine("Trn_メモ履歴");
                    clsM.Sql = st.ToString();
                    clsM.DMLUpdate();

                    // SQL Server側データSELECT
                    st.Length = 0;
                    st.AppendLine("SELECT");
                    st.AppendLine("*");
                    st.AppendLine("FROM");
                    st.AppendLine("Trn_メモ履歴");
                    st.AppendLine("ORDER BY");
                    st.AppendLine("TantoID");
                    st.AppendLine(",MemoNo");
                    clsS.Sql = st.ToString();
                    clsS.DMLSelect();

                    foreach (DataRow dr in clsS.dt.Rows)
                    {
                        // MySQLへINSERT
                        st.Length = 0;
                        st.AppendLine("INSERT INTO");
                        st.AppendLine("Trn_メモ履歴");
                        st.AppendLine("(");
                        st.AppendLine(" MemoNo");
                        st.AppendLine(",Day");
                        st.AppendLine(",Memo");
                        st.AppendLine(",BackColor");
                        st.AppendLine(",TantoID");
                        st.AppendLine(",Height");
                        st.AppendLine(",FontSize");
                        st.AppendLine(",FontColor");
                        st.AppendLine(",FontBold");
                        st.AppendLine(") VALUES (");
                        st.AppendLine(dr["MemoNo"].ToString());
                        st.AppendLine(",'" + DateTime.Parse(dr["Day"].ToString()).ToString("yyyy/MM/dd") + "'");
                        st.AppendLine(",'" + dr["Memo"].ToString() + "'");
                        st.AppendLine("," + int.Parse(dr["BackColor"].ToString()));
                        st.AppendLine("," + int.Parse(dr["TantoID"].ToString()));
                        st.AppendLine("," + int.Parse(dr["Height"].ToString()));
                        st.AppendLine("," + int.Parse(dr["FontSize"].ToString()));
                        st.AppendLine("," + int.Parse(dr["FontColor"].ToString()));
                        st.AppendLine("," + int.Parse(dr["FontBold"].ToString()));
                        st.AppendLine(")");
                        clsM.Sql = st.ToString();
                        clsM.DMLUpdate();
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
