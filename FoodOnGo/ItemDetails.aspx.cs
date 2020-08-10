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

namespace FoodOnGo
{
    public partial class ItemDetails : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            long iid = Convert.ToInt64(Request["Id"]);
            if (!IsPostBack)
            {
                if (iid > 0)
                {
                    getDetails(iid);
                }
                else
                {
                    rptDetails.DataSource = null;
                    rptDetails.DataBind();
                }
            }
        }

        protected void getDetails(long iid)
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblItem_Details_Get_By_Id", iid);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptDetails.DataSource = dataSet.Tables[0];
                rptDetails.DataBind();
            }
        }

        protected void AddToCart(long iid)
        {
            CartBAL b1 = new CartBAL();
            CartDAL d1 = new CartDAL();
            b1.ItemId = iid;
            b1.UserId = Convert.ToInt64(Session["User"]);
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(con, "tblItem_Retrieve_Data", iid);
            b1.Quantity = 1;
            b1.Rate = Convert.ToDecimal(ds.Tables[0].Rows[0]["ItemAmount"]);
            d1.FuncAddToCart(b1);
        }
       
        protected void rptDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    long IId = Convert.ToInt64(e.CommandArgument);
                    AddToCart(IId);
                    break;
            }
        }

        protected void btnFeed_Click(object sender, EventArgs e)
        {
            FeedBAL b1 = new FeedBAL();
            FeedDAL d1 = new FeedDAL();
            b1.ItemId = Convert.ToInt64(Request["Id"]);
            b1.UserId = Convert.ToInt64(Session["User"]);
            b1.FeedTitle = txtfeedtitle.Text;
            b1.FeedDesc = txtfeedback.Text;
            d1.FuncAddFeed(b1);
        }
    }
}