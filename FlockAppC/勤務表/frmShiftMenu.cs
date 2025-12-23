using FlockAppC.pubClass;
using FlockAppC.pubForm;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FlockAppC.勤務表
{
    public partial class frmShiftMenu : Form
    {
        public frmShiftMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShiftMenu_Load(object sender, EventArgs e)
        {
            // 動作設定取得
            ClsPublic.GetConfig();

            // アプリケーションルートパス
            string xml_file_path_ = @"C:\FLOCK\フロックAPP\FlockSysConf.xml";
            // xmlを読み込め。
            XDocument xml_ = XDocument.Load(xml_file_path_);
            // ルートタグを変数に
            XElement root_element_ = xml_.Element("appSettings");
            // アプリケーションルートパス
            ClsPublic.pubAppPath = root_element_.Element("ScheduleEditPath").Value;

            // 承認権限無しの場合 C#
            if (ClsLoginUser.ConfirmFlag == 0)
            {
                this.btnMnu07.Enabled = false;
                this.btnMnu08.Enabled = false;
            }

            // 月替わり処理　　※今後はログインのタイミングで実施
            ClsPublic.ChangeMonthProc();

            // 勤務表タイムスタンプチェック
            if (ClsPublic.CompTimeStamp(ClsPublic.stcConfig[0].FilePath) != 0 || ClsPublic.CompTimeStamp(ClsPublic.stcConfig[1].FilePath) != 0)
            {
                this.lblMsg.Visible = true;
            }
        }
        /// <summary>
        /// メニュー制御
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu_Click(object sender, EventArgs e)
        {
            string controlName = "";

            // sender を Button 型にキャスト
            Button clickedButton = sender as Button;

            // null チェックを行い、コントロール名を取得
            if (clickedButton != null)
            {
                controlName = clickedButton.Name;
            }

            switch(controlName)
            {
                // ===============================================
                // 閉じるボタン
                // ===============================================
                case "btnMnuClose":
                    this.Close();
                    this.Dispose();
                    break;

                // ===============================================
                // シフト変更登録ボタン
                // ===============================================
                case "btnMnu01":
                    frmScheduleEdit frmScheduleEdit = new();
                    frmScheduleEdit.ShowDialog();
                    break;

                // ===============================================
                // シフト変更履歴ボタン
                // ===============================================
                case "btnMnu02":
                    frmShiftHistory frmShiftHistory = new();
                    frmShiftHistory.ShowDialog();
                    break;

                // ===============================================
                // 勤務表表示(ｴｸｾﾙ)
                // ===============================================
                case "btnMnu03":
                    frmDisplayShiftExcel frmDisplayShiftExcel = new();
                    frmDisplayShiftExcel.ShowDialog();
                    break;

                // ===============================================
                // 勤務表PDF変換
                // ===============================================
                case "btnMnu04":
                    frmShiftPDF frmShiftPDF = new();
                    frmShiftPDF.ShowDialog();
                    break;

                // ===============================================
                // 勤務表表示Ⅱ
                // ===============================================
                case "btnMnu05":
                    frmShiftSchedulePreview frmShiftSchedulePreview = new();
                    frmShiftSchedulePreview.Show();
                    break;

                // ===============================================
                // 定時連絡登録
                // ===============================================
                case "btnMnu06":
                    frmRegContact frmRegContact = new();
                    frmRegContact.ShowDialog();
                    break;

                // ===============================================
                // 勤務表（エクセル）取り込み
                // ===============================================
                case "btnMnu07":

                    if (MessageBox.Show("勤務表（エクセル）をシステムに取り込みます。" + Environment.NewLine + "現在登録されている内容は上書きされます。", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }

                    // インポート処理
                    importShiftData();
                    break;

                // ===============================================
                // 環境設定
                // ===============================================
                case "btnMnu08":
                    frmShiftConfig frmShiftConfig = new();
                    frmShiftConfig.ShowDialog();
                    break;

                // ===============================================
                // 説明
                // ===============================================
                case "btnMnuGuide":
                    ClsPublic.pubHelpID = 1;

                    frmHelpView frm = new();
                    frm.ShowDialog();
                    frm.Dispose();
                    break;
            }
        }
        /// <summary>
        /// シフト表(ｴｸｾﾙ)取込み
        /// </summary>
        private void importShiftData()
        {
            // ================================================================
            // 処理中メッセージボックス
            // ================================================================
            frmMessageBox frmMsg = new()
            {
                F_size_height = 95,
                F_button_case = 0,
                L_value = "取り込み中 ....."
            };
            frmMsg.Show();
            frmMsg.Refresh();

            ClsImportProc cls = new();
            cls.Import();

            // 処理中メッセージクローズ
            frmMsg.Close();
            frmMsg.Dispose();

            ClsPublic.UpdateTimeStamp(ClsPublic.stcConfig[0].FilePath);
            ClsPublic.UpdateTimeStamp(ClsPublic.stcConfig[1].FilePath);

            // 勤務表変更フラグ更新
            ClsPublic.UpdateShiftFlag(ClsPublic.FLAG_ON);

            // ================================================================
            // 終了メッセージボックス
            // ================================================================
            frmMsg = new pubForm.frmMessageBox()
            {
                F_size_height = 133,
                F_button_case = 1,
                L_value = "取り込みが終了しました。"
            };
            // frmMsg.f_position = 2;
            frmMsg.ShowDialog();
            frmMsg.Dispose();
        }
    }
}
