using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Operations.BAL;
using Operations.DAL;

namespace FoodOnGo.member
{
    public partial class ViewOrder : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long id = Convert.ToInt64(Request["Oid"]);
                if (id != 0)
                {
                    getOrder(id);
                }
                else
                {
                    //Response.Redirect("index.aspx");
                }
            }
        }
        protected void getOrder(long id)
        {
            DataSet ds = new DataSet();
            long uid = Convert.ToInt64(Session["User"]);
            ds = SqlHelper.ExecuteDataset(con, "ViewOrder_Get", id,uid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptOrder.DataSource = ds.Tables[0];
                rptOrder.DataBind();
                lblOrderNo.Text = ds.Tables[0].Rows[0]["OrderId"].ToString();
                string Train = ds.Tables[0].Rows[0]["TC"].ToString() + "-" + ds.Tables[0].Rows[0]["TN"].ToString();
                string Station = ds.Tables[0].Rows[0]["SC"].ToString() + "-" + ds.Tables[0].Rows[0]["SN"].ToString();
                string Time = ds.Tables[0].Rows[0]["SAT"].ToString() + "-" + ds.Tables[0].Rows[0]["SDT"].ToString() + " Stops For " + ds.Tables[0].Rows[0]["ST"].ToString()+"m";
                lbltrain.Text = Train;
                lblstation.Text = Station;
                lbljourney.Text = ds.Tables[0].Rows[0]["JourneyDate"].ToString();
                lblst.Text = Time;
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["PaymentStatus"]) == true)
                {
                    lblPayment.Text = "Completed";
                }
                else
                {
                    lblPayment.Text = "Pending";
                }
            }
            lblTotal.Text = Convert.ToString(SqlHelper.ExecuteScalar(con, "Order_TotalAmount_Get", id));
        }
    }
}