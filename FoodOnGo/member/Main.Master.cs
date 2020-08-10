using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Operations.BAL;
using Operations.DAL;
using Operations;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FoodOnGo.member
{
    public partial class Main : System.Web.UI.MasterPage
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["Email"] == null)
                    {
                        Response.Redirect("~/login.aspx");
                    }
                    else
                    {
                        Session["Email"] = Session["Email"];
                        Session["User"] = Session["User"];
                        Session["OrderId"] = Session["OrderId"];
                        getCategory();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void getCategory()
        {
            DataSet DSCategory = SqlHelper.ExecuteDataset(connection, "tblCategory_Get_Menu");
            if (DSCategory.Tables[0].Rows.Count > 0)
            {
                rptCategory.DataSource = DSCategory.Tables[0];
                rptCategory.DataBind();
            }
        }

    }
}