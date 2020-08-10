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
    public partial class monthreport : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getReport(true);
            }
        }
        protected void getReport(bool x)
        {
            DataSet ds = new DataSet();
            if (x == true)
            {
                lblHead.Text ="This Month Report";
                ds = SqlHelper.ExecuteDataset(con, "Report_Month");
            }
            else
            {
                lblHead.Text ="Last Month Report";
                ds = SqlHelper.ExecuteDataset(con, "Report_Month", "1");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblmsg.Visible = false;
                rptMonth.DataSource = ds.Tables[0];
                rptMonth.DataBind();
            }
            else
            {
                lblmsg.Visible = true;
                rptMonth.DataSource = null;
                rptMonth.DataBind();
                lblmsg.Text = "There is no orders this Month";
            }
        }

        protected void lnkPastMonth_Click(object sender, EventArgs e)
        {
            getReport(false);
        }

        protected void lnkThisMonth_Click(object sender, EventArgs e)
        {
            getReport(true);
        }

        protected void rptMonth_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}