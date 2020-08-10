using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Operations.BAL;
using Operations.DAL;
using Operations;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FoodOnGo
{
    public partial class visitor : System.Web.UI.MasterPage
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            getCategory();
            getSlider();
            getFeedback();
        }
        protected void getSlider()
        {
            getItalianSlider();
            getChineseSlider();
        }
        protected void getCategory()
        {
            DataSet DSCategory = SqlHelper.ExecuteDataset(connection, "tblCategory_Get_Menu");
            if (DSCategory.Tables[0].Rows.Count > 0)
            {
                rptCategory.DataSource = DSCategory.Tables[0];
                rptCategory.DataBind();
            }
        }
        protected void getChineseSlider()
        {
            try
            {
                DataSet DSCategory = SqlHelper.ExecuteDataset(connection, "tblItem_Slider","Chinese");
                if (DSCategory.Tables[0].Rows.Count > 0)
                {
                    ChineseSlider.DataSource = DSCategory.Tables[0];
                    ChineseSlider.DataBind();
                }
            }
            catch(Exception ex)
            {

            }
        }
        protected void getItalianSlider()
        {
            try
            {
                DataSet DSCategory = SqlHelper.ExecuteDataset(connection, "tblItem_Slider","Italian");
                if (DSCategory.Tables[0].Rows.Count > 0)
                {
                    ItalianSlider.DataSource = DSCategory.Tables[1];
                    ItalianSlider.DataBind();
                }
            }
            catch(Exception ex)
            {

            }
        }
        protected void getFeedback()
        {
            try
            {
                DataSet DSCategory = SqlHelper.ExecuteDataset(connection, "tblFeedback_Get");
                if (DSCategory.Tables[0].Rows.Count > 0)
                {
                    rptFeedback.DataSource = DSCategory.Tables[0];
                    rptFeedback.DataBind();
                }
            }
            catch(Exception ex)
            {

            }
        }

        //protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    try
        //    {
        //        Label CategoryId = (e.Item.FindControl("lblCid") as Label);
        //        Repeater rptsubcategory = e.Item.FindControl("rptsubCategory") as Repeater;
        //        DataSet ds = SqlHelper.ExecuteDataset(connection, "tblSubCategory_Get_By_CategoryId_Menu", Convert.ToInt64(CategoryId.Text));
        //        rptsubcategory.DataSource = ds.Tables[0];
        //        rptsubcategory.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //}
    }
}