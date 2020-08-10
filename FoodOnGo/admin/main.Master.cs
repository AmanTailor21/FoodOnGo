using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodOnGo.admin
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserId"] == null)
                    {
                        Response.Redirect("~/admin/index.aspx");
                    }
                    else
                    {
                        lblUserName.Text = Session["UserName"].ToString();
                        lblUserLogin.Text = Session["UserId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/admin/index.aspx");
                throw ex;
            }
        }
    }
}