using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Operations.BAL;
using Operations.DAL;
using Operations;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FoodOnGo
{
    public partial class Details : System.Web.UI.Page
    {

        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            long cid = Convert.ToInt64(Request["CId"]);
            if(!IsPostBack)
            {
              if(cid>0)
                {
                    getProduct(cid);
                }
            }
        }

        protected void getProduct(long cid)
        {
            DataSet DsProduct = SqlHelper.ExecuteDataset(con, "tblItem_Get_By_CategoryId",cid);
            rptItems.DataSource = DsProduct.Tables[0];
            rptItems.DataBind();
            
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
        protected void rptItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    long IId = Convert.ToInt64(e.CommandArgument);
                    AddToCart(IId);
                    break;
            }
        }
    }
}