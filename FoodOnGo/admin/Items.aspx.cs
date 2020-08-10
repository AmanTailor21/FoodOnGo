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

namespace FoodOnGo.admin
{
    public partial class Items : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.Text = "Insert";
                CategoryBind();
                getItemData(1);
            }
            
        }

        protected void CategoryBind()
        {
            ddlSubCategory.Enabled = false;
            ddlSubCategory.Items.Insert(0,"-Select SubCategory-");
            DataSet CDataSet = new DataSet();
            CDataSet = SqlHelper.ExecuteDataset(con, "tblCategory_Get");
            if (CDataSet.Tables[0].Rows.Count > 0)
            {
                ddlCategory.DataSource = CDataSet.Tables[0];
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "-Select Category-");
            }
        }

        protected void SubCatBind()
        {
            DataSet SCDataSet = new DataSet();
            long cid=Convert.ToInt64(ddlCategory.SelectedValue);
            SCDataSet = SqlHelper.ExecuteDataset(con, "tblSubCategory_Get_Data",cid);
            if (SCDataSet.Tables[0].Rows.Count > 0)
            {
                ddlSubCategory.DataSource = SCDataSet.Tables[0];
                ddlSubCategory.DataTextField = "SubCategoryName";
                ddlSubCategory.DataValueField = "SubCategoryId";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, "-Select SubCategory-");
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (hid1.Value == "")
            {
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblItem_Check",Convert.ToInt64(ddlSubCategory.SelectedValue), txtIName.Text));
                if (cnt > 0)
                {
                    lblWarn.Text = "Already Exist";
                }
                else
                {
                    string ImageName;
                    ItemBAL b1 = new ItemBAL();
                    b1.SubCategoryId = Convert.ToInt64(ddlSubCategory.SelectedValue);
                    b1.ItemName = txtIName.Text;
                    ImageName = ImageSave();
                    if (ImageName != "")
                    {
                        b1.ItemImage = ImageName;
                    }
                    else
                    {

                    }
                    b1.ItemDetail = txtIDetails.Text;
                    b1.ItemAmount = txtIAmt.Text;
                    ItemDAL d1 = new ItemDAL();
                    d1.FuncInsertItem(b1);
                    lblWarn.Text = "";
                }
            }
            else
            {
                ItemBAL b2 = new ItemBAL();
                b2.ItemId = Convert.ToInt64(hid1.Value);
                b2.SubCategoryId = Convert.ToInt64(ddlSubCategory.SelectedValue);
                b2.ItemName = txtIName.Text;
                string ImageName;
                ImageName = ImageSave();
                b2.ItemImage=ImageName;
                b2.ItemDetail = txtIDetails.Text;
                b2.ItemAmount = txtIAmt.Text;
                ItemDAL d2 = new ItemDAL();
                d2.FuncUpdateItem(b2);
                IImage.Enabled = true;
                btnSubmit.Text = "Insert";
            }
            Cleardata();
            getItemData(1);
        }
        
        protected string ImageSave()
        {
            string name;
            name = Convert.ToString(System.DateTime.Now.ToString("dd/MM/yyyy hh mm ss")).Replace("/","").Replace(" ","");
            string ItemImageName = name + ".jpg";
            if (IImage.HasFile)
            {

                if (IImage.PostedFile.ContentLength < 3072000)
                {
                    IImage.SaveAs(Server.MapPath("~/item_img/" + ItemImageName));
                }
                else
                {
                    ItemImageName = "";
                }
                return ItemImageName;
            }
            else
            {
                return null;
            }
            
        }
        protected void GetItem()
        {
            ItemDAL d1 = new ItemDAL();
            DataSet dataSet = new DataSet();
            dataSet = d1.FuncGetItem();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptItem.DataSource = dataSet.Tables[0];
                rptItem.DataBind();
            }
        }

        protected void GetSubItemById(string hid1)
        {
            ItemDAL d1 = new ItemDAL();
            DataSet dataSet = new DataSet();
            long hid = Convert.ToInt64(hid1);
            dataSet = d1.FuncGetItemById(hid);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    ddlCategory.SelectedValue = Convert.ToString(dr["CategoryId"]);
                    if (ddlCategory.SelectedIndex != 0)
                    {
                        SubCatBind();
                        ddlSubCategory.SelectedValue = Convert.ToString(dr["SubCategoryId"]);
                    }
                    hidImageNameGet.Value =Convert.ToString(dr["ItemImage"]);
                    txtIName.Text = Convert.ToString(dr["ItemName"]);
                    txtIDetails.Text = Convert.ToString(dr["ItemDetails"]);
                    txtIAmt.Text = Convert.ToString(dr["ItemAmount"]);
                }
                ddlSubCategory.Enabled = true;
            }
            btnSubmit.Text = "Update";
        }

        protected void RptItem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ItemDAL d1 = new ItemDAL();
            long iid = Convert.ToInt64(e.CommandArgument);
            switch (e.CommandName)
            {
                case "edit":
                    hid1.Value = Convert.ToString(e.CommandArgument);
                    GetSubItemById(hid1.Value);
                    break;
                case "status":
                    d1.FuncChangeStatus(iid);
                    Cleardata();
                    getItemData(1);
                    break;
            }
        }

        protected void Cleardata()
        {
            ddlSubCategory.Items.Clear();
            ddlSubCategory.Items.Insert(0, "-Select SubCategory-");
            ddlSubCategory.Enabled = false;
            ddlSubCategory.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            txtIName.Text = "";
            txtIDetails.Text = "";
            txtIAmt.Text = "";
            hid1.Value = "";
            hidImageNameGet.Value = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getItemData(1);
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategory.Enabled = false;
            ddlSubCategory.Items.Clear();
            ddlSubCategory.Items.Insert(0,"-Select SubCategory-");
            long cid = Convert.ToInt64(ddlCategory.SelectedValue);
            if (cid > 0)
            {
                SubCatBind();
                ddlSubCategory.Enabled = true;
            }
        }

        #region Pageing
        protected void getItemData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet Itemdataset = new DataSet();
                Itemdataset = SqlHelper.ExecuteDataset(con, "tblItem_Get");
                ItemBAL b1 = new ItemBAL();
                ItemDAL d1 = new ItemDAL();
                b1.ItemId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.ItemMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptItem.DataSource = comDataset.Tables[0];
                        rptItem.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptItem.DataSource = null;
                    rptItem.DataBind();
                }
            }
            catch (Exception ex)
            {
                ltrMsg.Text = ex.Message;
            }
        }

        private void PopulatePager(int recordCount, int currentPage)
        {
            List<ListItem> pages = new List<ListItem>();
            int startIndex, endIndex;
            int pagerSpan = 5;

            //Calculate the Start and End Index of pages to be displayed.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(cboPageSize.SelectedValue));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
            endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            //Add the First Page Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("First", "1"));
            }

            //Add the Previous Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }

            //Add the Next Button.
            if (currentPage < pageCount)
            {
                pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
            }

            //Add the Last Button.
            if (currentPage != pageCount)
            {
                pages.Add(new ListItem("Last", pageCount.ToString()));
            }

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptItem.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            getItemData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            getItemData(pageIndex);
        }

        #endregion

    }
}