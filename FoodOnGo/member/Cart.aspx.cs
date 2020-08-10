using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Operations.DAL;
using System.Configuration;
using System.Data;

namespace FoodOnGo.member
{
    public partial class Cart : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    getCart();
                }
            }
            catch { }
        }
        protected void getCart()
        {
            DataSet ds = new DataSet();
            long User = Convert.ToInt64(Session["User"].ToString());
            ds = SqlHelper.ExecuteDataset(con, "tblCart_Get", User , 0,0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptCart.DataSource = ds.Tables[0];
                rptCart.DataBind();
                int sum = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "TotalAmount_Get", Convert.ToInt64(Session["User"]), 0,0));
                try
                {
                    lblTotal.Visible = true;
                    Label1.Text = "Total";
                    lblTotal.Text = "&#8377;"+ Convert.ToString(sum);
                    btnOrder.Visible = true;
                }
                catch
                {

                }

            }
            else
            {
                lblTotal.Visible = false;
                Label1.Text = "Your Cart is Empty";
                btnOrder.Visible = false;
            }
        }

        protected void rptCart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "qtyChange":
                    string[] args = e.CommandArgument.ToString().Split(':');
                    int qty = Convert.ToInt32(args[0]);
                    long iid = Convert.ToInt64(args[1]);
                    long User = Convert.ToInt64(Session["User"]);
                    qtyChange(qty, iid, User);
                    break;
                case "del":
                    long Iid = Convert.ToInt64(e.CommandArgument);
                    long UserId = Convert.ToInt64(Session["User"]);
                    remItem(Iid, UserId);
                    break;
            }
        }
        protected void qtyChange(int qty, long iid, long User)
        {
            if (qty > 0)
            {
                SqlHelper.ExecuteNonQuery(con, "tblCart_qtyChange", qty, iid, User);
                getCart();
            }
            else if (qty == 0)
            {
            }
        }
        protected void remItem(long iid, long User)
        {
            SqlHelper.ExecuteNonQuery(con, "tblCart_Delete_Record", iid, User);
            rptCart.DataSource = null;
            rptCart.DataBind();
            getCart();
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            long UserId = Convert.ToInt64(Session["User"].ToString());
            long OrderId = Convert.ToInt64(SqlHelper.ExecuteScalar(con, "tblOrder_Create", UserId));
            Session["OrderId"] = OrderId;
            SqlHelper.ExecuteNonQuery(con, "tblOrder_NextStep", UserId, OrderId);
            Response.Redirect("Orders.aspx?scale-x="+UserId+"&scale-als="+OrderId);
        }
    }
}