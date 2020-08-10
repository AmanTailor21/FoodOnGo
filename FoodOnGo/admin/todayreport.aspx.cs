using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Operations.DAL;

namespace FoodOnGo.admin
{
    public partial class todayreport : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            getReport();
        }
        protected void getReport()
        {
            DataSet ds = new DataSet();
            ds =SqlHelper.ExecuteDataset(con,"Report_Today");
            if(ds.Tables[0].Rows.Count>0)
            {
                lblmsg.Visible = false;
                rptToday.DataSource = ds.Tables[0];
                rptToday.DataBind();
            }
            else
            {
                lblmsg.Visible = true;
                rptToday.DataSource = null;
                rptToday.DataBind();
                lblmsg.Text = "There is no orders today";
            }
        }
    }
}