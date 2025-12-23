using FlockAppC.pubClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlockAppC.pubForm 
{
    public partial class frmHelpView : Form
    {
        public frmHelpView()
        {
            InitializeComponent();
        }

        private void FrmHelpView_Load(object sender, EventArgs e)
        {
            // アプリケーションルートパス
            string strFileName = ClsPublic.pubRootPath + @"\EXE\Help\";

            switch(ClsPublic.pubHelpID  )
            {
                case 1:
                    strFileName += "勤務表マニュアル.pdf";
                        break;
                case 2:
                    strFileName += "勤務表登録.pdf";
                    break;
                case 3:
                    strFileName += "勤務表担当追加.pdf";
                    break;
                case 4:
                    strFileName += "勤務表設定.pdf";
                    break;
                case 5:
                    strFileName += "勤務表エラー対処.pdf";
                    break;
                case 6:
                    strFileName += "PDF変換.pdf";
                    break;


                case 21:
                    strFileName += "マスタメンテマニュアル.pdf";
                    break;
                case 22:
                    strFileName += "従業員登録.pdf";
                    break;
                case 23:
                    strFileName += "社用車登録.pdf";
                    break;


                case 31:
                    strFileName += "社用車管理メニュー.pdf";
                    break;
                case 32:
                    strFileName += "走行記録インポート.pdf";
                    break;
                case 33:
                    strFileName += "走行記録編集.pdf";
                    break;


                case 41:
                    strFileName += "作業登録概要.pdf";
                    break;
                case 42:
                    strFileName += "作業登録画面構成.pdf";
                    break;
                case 43:
                    strFileName += "作業登録画面説明.pdf";
                    break;
                case 44:
                    strFileName += "作業登録マスター登録手順.pdf";
                    break;
                case 45:
                    strFileName += "作業登録手順.pdf";
                    break;
                case 51:
                    strFileName += "作業編集マニュアル.pdf";
                    break;


                case 98:
                    strFileName += "メインメニューマニュアル.pdf";
                    break;

                case 99:
                    strFileName += "ログインマニュアル.pdf;";
                        break;

                default:
                    break;
            }
            this.wb2.Source = new Uri(strFileName);

            // form表示位置
            this.Location = new Point(0, 0);
        }
    }
}
