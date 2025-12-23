namespace FlockAppC.pubForm
{
    partial class frmHelpView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelpView));
            this.wb2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.wb2)).BeginInit();
            this.SuspendLayout();
            // 
            // wb2
            // 
            this.wb2.AllowExternalDrop = true;
            this.wb2.CreationProperties = null;
            this.wb2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wb2.Location = new System.Drawing.Point(2, 4);
            this.wb2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.wb2.Name = "wb2";
            this.wb2.Size = new System.Drawing.Size(910, 745);
            this.wb2.TabIndex = 0;
            this.wb2.ZoomFactor = 1D;
            // 
            // frmHelpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 750);
            this.Controls.Add(this.wb2);
            this.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmHelpView";
            this.Text = "操作説明";
            this.Load += new System.EventHandler(this.FrmHelpView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wb2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 wb2;
    }
}