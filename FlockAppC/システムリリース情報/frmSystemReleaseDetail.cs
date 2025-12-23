using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC
{
    public partial class frmSystemReleaseDetail : Form
    {
        readonly int SelectID;

        private readonly StringBuilder sb = new();

        public frmSystemReleaseDetail(int iID)
        {
            //ID保持
            SelectID = iID;

            InitializeComponent();
        }

        private void FrmSystemReleaseDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (SelectID != 0)
                {
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        sb.AppendLine("SELECT * FROM Trn_システムリリース情報 WHERE id = " + SelectID);

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                this.txtDay.Text = ((DateTime)dr["day"]).ToString("yyyy/MM/dd");
                                this.txtVersion.Text = dr["version"].ToString();
                                this.txtRelease.Text = dr["release"].ToString();
                                this.txtComment.Text = dr["comment"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    if (SelectID != 0)
                    {
                        //UPDATE
                        sb.Clear();
                        sb.AppendLine("UPDATE Trn_システムリリース情報 SET");
                        sb.AppendLine(" day = '" + this.txtDay.Text + "'");
                        sb.AppendLine(",version = " + this.txtVersion.Text);
                        sb.AppendLine(",release = '" + this.txtRelease.Text + "'");
                        sb.AppendLine(",comment = '" + this.txtComment.Text + "'");
                        sb.AppendLine("WHERE id = " + SelectID);
                    }
                    else
                    {
                        //INSERT
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Trn_システムリリース情報 ");
                        sb.AppendLine("(day,version,release,comment)");
                        sb.AppendLine("VALUES (");
                        sb.AppendLine("'" + this.txtDay.Text + "'");
                        sb.AppendLine("," + this.txtVersion.Text);
                        sb.AppendLine(",'" + this.txtRelease.Text + "'");
                        sb.AppendLine(",'" + this.txtComment.Text + "')");
                    }

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK);
                throw;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
