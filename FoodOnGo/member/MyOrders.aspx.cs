using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Operations.DAL;
using System.Configuration;

namespace FoodOnGo.member
{
    public partial class MyOrders : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MyOrdersLoad();
            }
        }
        protected void MyOrdersLoad()
        {
            DataSet ds = new DataSet();
            long UserId = Convert.ToInt64(Session["User"]);
            ds = SqlHelper.ExecuteDataset(con,"MyOrders_Get", UserId);
            if(ds.Tables[0].Rows.Count>0)
            {
                rptOrders.DataSource = ds.Tables[0];
                rptOrders.DataBind();
            }
        }

        protected void rptOrders_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch(e.CommandName)
            {
                case "view":
                    long oid = Convert.ToInt64(e.CommandArgument);
                    Session["OrderId"] = oid;
                    DataSet ds1 = SqlHelper.ExecuteDataset(con, "Order_Check", oid);
                    if(ds1.Tables[0].Rows.Count > 0)
                    {
                        long train = Convert.ToInt64(ds1.Tables[0].Rows[0]["TrainId"]);
                        string pay = Convert.ToString(ds1.Tables[0].Rows[0]["PaymentStatus"]);
                        if (train != 0)
                        {
                            if (pay == "True")
                            {
                                Response.Redirect("ViewOrder.aspx?Oid=" + oid);
                            }
                            else
                            {
                                Response.Redirect("Payment.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("Orders.aspx");
                        }
                        
                    }
                    break;
                case "cancel":
                    break;
            }
        }
    }
}