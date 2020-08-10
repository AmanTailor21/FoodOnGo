using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Operations.BAL;
using Operations.DAL;
using System.Data;
using System.Configuration;

namespace FoodOnGo.Admin
{
    public partial class home : System.Web.UI.Page
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DashOrder();
            DashUser();
            DashFeed();
        }

        protected void DashOrder()
        {
            DataSet dataSet = new DataSet();
            dataSet = dataSet = SqlHelper.ExecuteDataset(con, "AdminDashboard_GetOrder");
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    TodayOrder.Text = Convert.ToString(dr["TodayOrder"]);
                    WeekOrder.Text = Convert.ToString(dr["WeekOrder"]);
                    MonthOrder.Text = Convert.ToString(dr["MonthOrder"]);
                    TotalOrder.Text = Convert.ToString(dr["TotalOrder"]);
                }
            }
        }
        protected void DashUser()
        {
            DataSet dataSet = new DataSet();
            dataSet = dataSet = SqlHelper.ExecuteDataset(con, "AdminDashboard_GetUser");
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    TodayUser.Text = Convert.ToString(dr["TodayUser"]);
                    WeekUser.Text = Convert.ToString(dr["WeekUser"]);
                    MonthUser.Text = Convert.ToString(dr["MonthUser"]);
                    TotalUser.Text = Convert.ToString(dr["TotalUser"]);
                }
            }
        }
        protected void DashFeed()
        {
            DataSet dataSet = new DataSet();
            dataSet = dataSet = SqlHelper.ExecuteDataset(con, "AdminDashboard_GetFeedback");
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    TodayFeed.Text = Convert.ToString(dr["TodayFeedback"]);
                    WeekFeed.Text = Convert.ToString(dr["WeekFeedback"]);
                    MonthFeed.Text = Convert.ToString(dr["MonthFeedback"]);
                    TotalFeed.Text = Convert.ToString(dr["TotalFeedback"]);
                }
            }
        }
    }
}