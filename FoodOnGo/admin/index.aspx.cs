using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Operations;
using System.Data;
using Operations.DAL;
using System.Data.SqlClient;
using System.Configuration;

namespace FoodOnGo.admin
{
    public partial class index : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet Ds = new DataSet();
            Ds = SqlHelper.ExecuteDataset(con, "tblAdmin_Get_Data", txtEmailId.Text, txtPassword.Text);
            if (Ds.Tables[0].Rows.Count > 0)
            {
                Session["UserName"] = Ds.Tables[0].Rows[0]["Name"].ToString();
                Session["UserId"] = Ds.Tables[0].Rows[0]["LoginId"].ToString();
                Response.Redirect("~/admin/home.aspx");
            }

        }
    }
}