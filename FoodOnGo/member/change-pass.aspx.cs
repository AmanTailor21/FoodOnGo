using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Operations;
using Operations.BAL;
using Operations.DAL;
using System.Data;
using System.Data.SqlClient;
namespace FoodOnGo.member
{
    public partial class change_pass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RegisterBAL b1 = new RegisterBAL();
            RegisterDAL d1 = new RegisterDAL();
            b1.EmailId = Session["Email"].ToString();
            b1.Password = txtPass.Text.Trim();
            b1.OldPass = txtOldPass.Text.Trim();
            int cnt = Convert.ToInt32(d1.FuncUpdateChangePass(b1));
            if (cnt > 0)
            {
                lblMSG.Text = CommonFunction.Success_MessageBox("Change Password SucessFully.");
            }
            else
            {
                lblMSG.Text=CommonFunction.Alert_MessageBox("Your Password Not Updated.");
            }
            cleardata();

        }

        protected void cleardata()
        {
            txtCpass.Text = "";
            txtOldPass.Text = "";
            txtPass.Text = "";
        }
    }
    
}