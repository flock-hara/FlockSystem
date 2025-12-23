using FlockAppC.pubClass;
using FlockAppC.tblClass;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlockAppC.マスターメンテ
{
    public partial class frmMstCompany : Form
    {
        public int Id { get; set; }

        private readonly StringBuilder sb = new();

        public frmMstCompany()
        {
            InitializeComponent();
        }

        private void frmMstCompany_Load(object sender, EventArgs e)
        {
            this.cmbCompany.SelectedIndexChanged -= this.cmbCompany_SelectedIndexChanged;

            // Initialize Form
            InitializeForm();

            // 自社選択コンボボックス
            this.cmbCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            SetKbnCmb(this.cmbCompany);

            this.cmbCompany.SelectedIndexChanged += this.cmbCompany_SelectedIndexChanged;

            // 新規
            this.lblNew.Visible = true;

            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// 自社選択コンボボックスをセット
        /// </summary>
        /// <param name="combo"></param>
        public void SetKbnCmb(ComboBox combo)
        {
            DataRow dr;
            DataTable dt = new();

            try
            {
                dt.Columns.Add("Code");
                dt.Columns.Add("Name");

                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    // SQL編集
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" id");
                    sb.AppendLine(",company_name1");
                    sb.AppendLine(",company_name2");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_自社");
                    sb.AppendLine("ORDER BY");
                    sb.AppendLine("id");

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        // SET COMBO
                        // 最初の空行
                        dr = dt.NewRow();
                        dr["Code"] = "0";
                        dr["Name"] = "";
                        dt.Rows.Add(dr);

                        // 結果を読み込みデータテーブルへセット
                        foreach (DataRow drow in dt_val.Rows)
                        {
                            dr = dt.NewRow();
                            dr["Code"] = drow["id"];
                            dr["Name"] = drow["company_name1"] + " " + drow["company_name2"];
                            dt.Rows.Add(dr);
                        }
                    }

                    // コンボボックスにデータテーブルセット
                    combo.DataSource = dt;
                    combo.DisplayMember = "Name";
                    combo.ValueMember = "Code";
                }
            }
            catch (Exception ex)
            {
                // エラー
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 画面初期化
        /// </summary>
        private void InitializeForm()
        {
            this.Id = 0;
            this.txtCompanyName1.Text = "";
            this.txtCompanyName2.Text = "";
            this.txtZipCode1.Text = "";
            this.txtZipCode2.Text = "";
            this.txtAddress1.Text = "";
            this.txtAddress2.Text = "";
            this.txtTelNo1.Text = "";
            this.txtTelNo2.Text = "";
            this.txtTelNo3.Text = "";
            this.txtFaxNo1.Text = "";
            this.txtFaxNo2.Text = "";
            this.txtMailAddress1.Text = "";
            this.txtMailAddress2.Text = "";
            this.txtMailAddress3.Text = "";
            this.txtUrl1.Text = "";
            this.txtUrl2.Text = "";
            this.txtDelegete.Text = "";
            this.txtComment.Text = "";
        }
        /// <summary>
        /// 自社選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = this.cmbCompany.SelectedValue;

            if (value.ToString() != "")
            {
                this.lblNew.Visible = false;

                try
                {
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" id");
                        sb.AppendLine(",company_name1");
                        sb.AppendLine(",company_name2");
                        sb.AppendLine(",zip_code1");
                        sb.AppendLine(",zip_code2");
                        sb.AppendLine(",address1");
                        sb.AppendLine(",address2");
                        sb.AppendLine(",tel1");
                        sb.AppendLine(",tel2");
                        sb.AppendLine(",tel3");
                        sb.AppendLine(",fax1");
                        sb.AppendLine(",fax2");
                        sb.AppendLine(",mail1");
                        sb.AppendLine(",mail2");
                        sb.AppendLine(",mail3");
                        sb.AppendLine(",url1");
                        sb.AppendLine(",url2");
                        sb.AppendLine(",delegete");
                        sb.AppendLine(",comment");
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_自社");
                        sb.AppendLine("WHERE");
                        sb.AppendLine("id = " + value.ToString());

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                this.Id = int.Parse(dr["id"].ToString());
                                this.txtCompanyName1.Text = dr["company_name1"].ToString();
                                this.txtCompanyName2.Text = dr["company_name2"].ToString();
                                this.txtZipCode1.Text = dr["zip_code1"].ToString();
                                this.txtZipCode2.Text = dr["zip_code2"].ToString();
                                this.txtAddress1.Text = dr["address1"].ToString();
                                this.txtAddress2.Text = dr["address2"].ToString();
                                this.txtTelNo1.Text = dr["tel1"].ToString();
                                this.txtTelNo2.Text = dr["tel2"].ToString();
                                this.txtTelNo3.Text = dr["tel3"].ToString();
                                this.txtFaxNo1.Text = dr["fax1"].ToString();
                                this.txtFaxNo2.Text = dr["fax2"].ToString();
                                this.txtMailAddress1.Text = dr["mail1"].ToString();
                                this.txtMailAddress1.Text = dr["mail2"].ToString();
                                this.txtMailAddress1.Text = dr["mail3"].ToString();
                                this.txtUrl1.Text = dr["url1"].ToString();
                                this.txtUrl2.Text = dr["url2"].ToString();
                                this.txtDelegete.Text = dr["delegete"].ToString();
                                this.txtComment.Text = dr["comment"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            else
            {
                this.Id = 0;
                this.lblNew.Visible = false;
            }
        }
        private void btnReg_Click(object sender, EventArgs e)
        {
            if (this.txtCompanyName1.Text == "") return;

            ClsMstCompany cls = new()
            {
                CompanyName1 = this.txtCompanyName1.Text,
                CompanyName2 = this.txtCompanyName2.Text,
                ZipCode1 = this.txtZipCode1.Text,
                ZipCode2 = this.txtZipCode2.Text,
                Address1 = this.txtAddress1.Text,
                Address2 = this.txtAddress2.Text,
                TelNo1 = this.txtTelNo1.Text,
                TelNo2 = this.txtTelNo2.Text,
                TelNo3 = this.txtTelNo3.Text,
                FaxNo1 = this.txtFaxNo1.Text,
                FaxNo2 = this.txtFaxNo2.Text,
                MailAddress1 = this.txtMailAddress1.Text,
                MailAddress2 = this.txtMailAddress2.Text,
                MailAddress3 = this.txtMailAddress3.Text,
                Url1 = this.txtUrl1.Text,
                Url2 = this.txtUrl2.Text,
                Delegete = this.txtDelegete.Text,
                Comment = this.txtComment.Text
            };
            //cls.CompanyName1 = this.txtCompanyName1.Text;
            //cls.CompanyName2 = this.txtCompanyName2.Text;
            //cls.ZipCode1 = this.txtZipCode1.Text;
            //cls.ZipCode2 = this.txtZipCode2.Text;
            //cls.Address1 = this.txtAddress1.Text;
            //cls.Address2 = this.txtAddress2.Text;
            //cls.TelNo1 = this.txtTelNo1.Text;
            //cls.TelNo2 = this.txtTelNo2.Text;
            //cls.TelNo3 = this.txtTelNo3.Text;
            //cls.FaxNo1 = this.txtFaxNo1.Text;
            //cls.FaxNo2 = this.txtFaxNo2.Text;
            //cls.MailAddress1 = this.txtMailAddress1.Text;
            //cls.MailAddress2 = this.txtMailAddress2.Text;
            //cls.MailAddress3 = this.txtMailAddress3.Text;
            //cls.Url1 = this.txtUrl1.Text;
            //cls.Url2 = this.txtUrl2.Text;
            //cls.Delegete = this.txtDelegete.Text;
            //cls.Comment = this.txtComment.Text;

            // IDチェック
            if (this.Id != 0)
            {
                // UPDATE
                cls.ID = this.Id;
                cls.Update();
            }
            else
            {
                // INSERT
                cls.Insert();
            }

            MessageBox.Show("登録しました。", "結果", MessageBoxButtons.OK);
        }

        private void frmMstCompany_Shown(object sender, EventArgs e)
        {
            //// 自社選択コンボボックス
            //this.cmbCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            //SetKbnCmb(this.cmbCompany);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
