using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Operations.DAL;
using Operations.BAL;
using System.Configuration;
using Operations;
using System.Data;
using System.Data.SqlClient;

namespace FoodOnGo
{
    public partial class forgetpass : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(con, "tblLogin_CheckF_Verify", email);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                string OTP = CommonFunction.GenerateCode(5);
                CommonFunction.SendEmailPassword(txtEmail.Text, "Forget Password", "<h4>Food On Go</h4> - You Submitted a Forgot Password Request", password,OTP);
                SqlHelper.ExecuteNonQuery(con, "tblLogin_Update_EmailVerify_OTP", txtEmail.Text,OTP,0);
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblmsg2.Visible = true;
                lblmsg2.Text = "UserId Not Exists";
            }
        }
    }
}