using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Operations.BAL;
using Operations.DAL;
using Operations;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FoodOnGo
{
    public partial class Register : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlLoadDOB();
                ddlDDLoad("Jan",2019);
            }
            if(Session["User"]!=null)
            {
                Response.Redirect("Index.aspx");
            }
        }
        protected void ddlLoadDOB()
        {
            string[] month = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            
            for (int i = 2018; i >= 1900; i--)
            {

                ddlYYYY.Items.Add(Convert.ToString(i));
            }

            for (int I = 1; I <= 12; I++)
            {
                ddlMM.Items.Add(month[I]);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblUser_Check", txtemail.Text));
            if (cnt > 0)
            {
                Response.Redirect("#");
            }
            else
            {
                RegisterBAL b1 = new RegisterBAL();
                RegisterDAL d1 = new RegisterDAL();
                b1.EmailId = txtemail.Text.Trim();
                b1.MobileNo = txtmob.Text.Trim();
                b1.FirstName = txtfname.Text.Trim();
                b1.LastName = txtlname.Text.Trim();
                b1.Gender = ddlGender.SelectedValue.ToString();
                b1.Birthdate = ddlDD.SelectedValue.ToString() + "/" + ddlMM.SelectedValue.ToString() + "/" + ddlYYYY.SelectedValue.ToString();
                b1.Password = txtpass.Text.Trim();

                long UserID = d1.FuncInsertUser(b1);

                string OTP = CommonFunction.GenerateCode(5);

                LoginBAL BL = new LoginBAL();
                LoginDAL DL = new LoginDAL();
                BL.UserId = UserID;
                BL.EmailID = txtemail.Text.Trim();
                BL.Password = txtpass.Text.Trim();
                BL.OTP = OTP;
                DL.FuncLoginInsert(BL);

                CommonFunction.SendEmail(txtemail.Text, "Email Verification", "Welcome to <h4>Food On Go</h4>", OTP);
                Response.Redirect("CheckEmail.aspx");
            }
        }
        #region date_dropdowns
        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDD.Items.Clear();
            if(ddlYYYY.SelectedValue=="YYYY")
            {
                ddlDDLoad(ddlMM.SelectedValue.ToString());
            }
            else
            {
                int yyyy = Convert.ToInt32(ddlYYYY.SelectedValue.ToString());
                ddlDDLoad(ddlMM.SelectedValue.ToString(), yyyy);
            }
        }

        protected void ddlDDLoad(string MM,int YYYY=2019)
        {
            int Y = YYYY % 4;
            if (MM == "Feb")
            {
                if (Y == 0)
                {
                    for (int I = 01; I <= 29; I++)
                    {
                        ddlDD.Items.Add(Convert.ToString(I));
                    }
                }
                else
                {
                    for (int I = 01; I <= 28; I++)
                    {
                        ddlDD.Items.Add(Convert.ToString(I));
                    }
                }
            }
            else if (MM == "Jan" || MM == "Mar" || MM == "May" || MM == "Jul" || MM == "Aug" || MM == "Oct" || MM == "Dec"|| MM == "MM")
            {
                for (int I = 01; I <= 31; I++)
                {
                    ddlDD.Items.Add(Convert.ToString(I));
                }
            }
            else if ( MM == "Apr" || MM == "Jun" || MM == "Sep" || MM == "Nov")
            {
                for (int I = 01; I <= 30; I++)
                {
                    ddlDD.Items.Add(Convert.ToString(I));
                }
            }
        }
        #endregion
    }
}