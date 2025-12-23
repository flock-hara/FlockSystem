using System;
using System.Windows.Forms;
using FlockAppC.pubClass;

namespace FlockAppC.勤務表
{
    public partial class frmShiftHelpMenu : Form
    {
        public frmShiftHelpMenu()
        {
            // ボタンのイベント登録（共通の処理に遷移させる為）
            btnHelp1.Click += new EventHandler(btnHelp_Click);
            btnHelp2.Click += new EventHandler(btnHelp_Click);
            btnHelp3.Click += new EventHandler(btnHelp_Click);
            btnHelp4.Click += new EventHandler(btnHelp_Click);
            btnHelp5.Click += new EventHandler(btnHelp_Click);
            btnHelp6.Click += new EventHandler(btnHelp_Click);
            btnClose.Click += new EventHandler(btnHelp_Click);

            InitializeComponent();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // sender はクリックされたボタン
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // ボタンの名前やテキストに基づいて処理を分岐できます
                string buttonName = clickedButton.Name;  // ボタンの Name プロパティ
                string buttonText = clickedButton.Text;  // ボタンの表示テキスト

                switch (buttonName)
                {
                    case "btnHelp1":
                        // 勤務表メニューについて
                        ClsPublic.pubHelpID = 1;
                        break;
                    case "btnHelp2":
                        // 変更予定の登録、承認について
                        ClsPublic.pubHelpID = 2;
                        break;
                    case "btnHelp3":
                        // 担当者の追加、削除について
                        ClsPublic.pubHelpID = 3;
                        break;
                    case "btnHelp4":
                        // 勤務表の設定について
                        ClsPublic.pubHelpID = 4;
                        break;
                    case "btnHelp5":
                        // エラー発生時の対処
                        ClsPublic.pubHelpID = 5;
                        break;
                    case "btnHelp6":
                        // PDF変換について
                        ClsPublic.pubHelpID = 6;
                        break;
                    case "btnClose":
                        // 閉じる
                        break;
                    default:
                        MessageBox.Show($"Unknown button clicked: {buttonText}");
                        break;
                }

                pubForm.frmHelpView frm = new();
                frm.ShowDialog();
            }
        }
    }
}
