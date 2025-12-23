using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FlockAppC
{
    internal static class Program
    {

        // ① Win32 APIの定義（ここが重要）
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // フォームがロードされたら前面に出す（但し上手く動作しない。。。）
            frmLogin form = new frmLogin();
            form.Shown += (s, e) =>
            {
                form.Activate();
                form.BringToFront();
                SetForegroundWindow(form.Handle);
            };
            Application.Run(form);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());
        }
    }
}
