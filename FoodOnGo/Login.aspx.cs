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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (lblMsg.Visible == false)
            {
                if (txtOTP.Visible == true)
                {
                    int checkstatus = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblLogin_Check_OTP", txtEmail.Text, txtpass.Text, txtOTP.Text));
                    if (checkstatus == 1)
                    {
                        SqlHelper.ExecuteNonQuery(con, "tblLogin_Update_EmailVerify", txtEmail.Text, 1);
                        Session["Email"] = txtEmail.Text;
                        Session["Login"] = "True";
                        long UserId=Convert.ToInt64(SqlHelper.ExecuteScalar(con, "tblLogin_Get_UserId", txtEmail.Text));
                        Session["User"] = UserId;
                        Response.Redirect("Index.aspx");
                        lblMsg.Visible = false;
                    }
                    else
                    {
                        lblMsg1.Text = "Please Check Your OTP in your Email Id";
                        lblMsg1.Visible = true;
                    }
                }
                else
                {
                    int checkStatus = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblLogin_User_Data", txtEmail.Text, txtpass.Text));
                    if (checkStatus == 1)
                    {
                        lblMsg.Visible = false;
                        Session["Email"] = txtEmail.Text;
                        Session["Login"] = "True";
                        long UserId = Convert.ToInt64(SqlHelper.ExecuteScalar(con, "tblLogin_Get_UserId", txtEmail.Text));
                        Session["User"] = UserId;
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "Please Check your UserId and Password";
                        lblMsg.Visible = true;
                    }
                }
            }
            else
            {
                if (txtOTP.Visible == true)
                {
                    int checkstatus = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblLogin_Check_OTP", txtEmail.Text, txtpass.Text, txtOTP.Text));
                    if (checkstatus == 1)
                    {
                        SqlHelper.ExecuteNonQuery(con, "tblLogin_Update_EmailVerify", txtEmail.Text, 1);
                        Session["Email"] = txtEmail.Text;
                        Session["Login"] = "True";
                        long UserId = Convert.ToInt64(SqlHelper.ExecuteScalar(con, "tblLogin_Get_UserId", txtEmail.Text));
                        Session["User"] = UserId;
                        Response.Redirect("Index.aspx");
                        lblMsg.Visible = false;
                    }
                    else
                    {
                        lblMsg1.Text = "Please Check Your OTP in your Email Id";
                        lblMsg1.Visible = true;
                    }
                }
                else
                {
                    int checkStatus = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblLogin_User_Data", txtEmail.Text, txtpass.Text));
                    if (checkStatus == 1)
                    {
                        lblMsg.Visible = false;
                        Session["Email"] = txtEmail.Text;
                        Session["Login"] = "True";
                        long UserId = Convert.ToInt64(SqlHelper.ExecuteScalar(con, "tblLogin_Get_UserId", txtEmail.Text));
                        Session["User"] = UserId;
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "Please Check your UserId and Password";
                        lblMsg.Visible = true;
                    }
                }
            }
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtOTP.Visible = false;
            }

            int check;
            int statusEmail = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblLogin_Check_Email", txtEmail.Text));
            if (statusEmail == 1)
            {
                lblMsg.Visible = false;
                check = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblLogin_Check_Verify", txtEmail.Text));
                if (check == 0)
                {
                    txtOTP.Visible = true;
                }
                else
                {
                    txtOTP.Visible = false;
                }
            }
            else
            {
                txtOTP.Visible = false;
                lblMsg.Text = "User Id Not Valid.";
                lblMsg.Visible = true;
            }
        }
    }
}