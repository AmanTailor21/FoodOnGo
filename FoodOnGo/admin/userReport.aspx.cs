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
    public partial class userreport : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void getReport()
        {
            DataSet ds = new DataSet();
            ds =SqlHelper.ExecuteDataset(con,"Report_UserWise",txtUser.Text);
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
                lblmsg.Text = "No Order Records";
            }
        }

        protected void lnkUser_Click(object sender, EventArgs e)
        {
            if(txtUser.Text!="")
            {
                getReport();
            }
        }
    }
}