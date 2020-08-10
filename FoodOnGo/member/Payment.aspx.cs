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
    public partial class Payment : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        int currmonth = DateTime.Today.Month;
        int curryear = DateTime.Today.Year;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["OrderId"] != null)
                    {
                        getCart();
                        fillDate();
                    }
                    else
                    {
                        Response.Redirect("Index.aspx");
                    }
                }
            }
            catch{}
        }
        protected void getCart()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(con, "tblCart_Get", Convert.ToInt64(Session["User"].ToString()), 1, Convert.ToInt64(Session["OrderId"]));
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptOrder.DataSource = ds.Tables[0];
                rptOrder.DataBind();
                lblOrderNo.Text = ds.Tables[0].Rows[0]["OrderId"].ToString();
            }
            lblTotal.Text = Convert.ToString(SqlHelper.ExecuteScalar(con, "TotalAmount_Get", Convert.ToInt64(Session["User"]), 1, Convert.ToInt64(Session["OrderId"])));
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            OrderBAL b1 = new OrderBAL();
            OrderDAL d1 = new OrderDAL();
            b1.UserId = Convert.ToInt64(Session["User"]);
            b1.OrderId = Convert.ToInt64(Session["OrderId"]);
            b1.CardNo = txtCard.Text;
            b1.CardHolderName = txtCardHolder.Text;
            b1.CVV = txtCVV.Text;
            b1.ExpireDate = Convert.ToString(ddlMonth.SelectedItem) + "/" + Convert.ToString(ddlYear.SelectedItem);
            d1.FuncMakePayment(b1);
            Session["OrderId"] = null;
            Response.Redirect("ViewOrder.aspx?Oid="+lblOrderNo.Text);
        }
        #region datemanagement
        protected void fillDate()
        {
            int m = DateTime.Today.Month;
            int y = DateTime.Today.Year;
            ddlLoad(m, y);
        }
        protected void ddlLoad(int m, int y)
        {
            month(m);
            year(y);
        }
        protected void year(int y)
        {
            int ny = y + 10;
            for (int i = y; i <= ny; i++)
            {

                ddlYear.Items.Add(Convert.ToString(i));
            }
        }
        protected void month(int m)
        {
            ddlMonth.Items.Clear();
            for (int i = m; i <= 12; i++)
            {
                ddlMonth.Items.Add(Convert.ToString(i));
            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(ddlYear.SelectedValue);
            if (y != curryear)
            {
                month(1);
            }
            else
            {
                month(currmonth);
            }
        }
        #endregion
    }
}