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
    public partial class SubCategory : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.Text = "Insert";
                CategoryBind();
                getSubCategoryData(1);
            }
            
        }

        protected void CategoryBind()
        {
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

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (hid1.Value == "")
            {
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblSubCategory_Check", Convert.ToInt64(ddlCategory.SelectedValue),txtSCName.Text));
                if (cnt > 0)
                {
                    lblWarn.Text = "Already Exist";
                }
                else
                {
                    SubCategoryBAL b1 = new SubCategoryBAL();
                    b1.CategoryId = Convert.ToInt64(ddlCategory.SelectedValue);
                    b1.SubCategoryName = txtSCName.Text;
                    SubCategoryDAL d1 = new SubCategoryDAL();
                    d1.FuncInsertSubCategory(b1);
                    lblWarn.Text = "";
                }
            }
            else
            {
                SubCategoryBAL b2 = new SubCategoryBAL();
                b2.SubCategoryId = Convert.ToInt64(hid1.Value);
                b2.CategoryId = Convert.ToInt64(ddlCategory.SelectedValue);
                b2.SubCategoryName =txtSCName.Text;
                SubCategoryDAL d2 = new SubCategoryDAL();
                d2.FuncUpdateSubCategory(b2);
                btnSubmit.Text = "Insert";
            }
            Cleardata();
            getSubCategoryData(1);
        }

        protected void GetSubCategory()
        {
            SubCategoryDAL d1 = new SubCategoryDAL();
            DataSet dataSet = new DataSet();
            dataSet = d1.FuncGetSubCategory();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptSubCategory.DataSource = dataSet.Tables[0];
                rptSubCategory.DataBind();
            }
        }

        protected void GetSubCatById(string hid1)
        {
            SubCategoryDAL d1 = new SubCategoryDAL();
            DataSet dataSet = new DataSet();
            long hid = Convert.ToInt64(hid1);
            dataSet = d1.FuncGetSubCategoryById(hid);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    ddlCategory.SelectedValue = Convert.ToString(dr["CategoryId"]);
                    txtSCName.Text = Convert.ToString(dr["SubCategoryName"]);
                }
            }
            btnSubmit.Text = "Update";
        }

        protected void RptSubCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            SubCategoryDAL d1 = new SubCategoryDAL();
            long sid = Convert.ToInt64(e.CommandArgument);
            switch (e.CommandName)
            {
                case "edit":
                    hid1.Value = Convert.ToString(e.CommandArgument);
                    GetSubCatById(hid1.Value);
                    break;
                case "status":
                    d1.FuncChangeStatus(sid);
                    getSubCategoryData(1);
                    break;
            }
        }

        protected void Cleardata()
        {
            txtSCName.Text = "";
            ddlCategory.SelectedIndex = 0;
            hid1.Value = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet subcatDataset = SqlHelper.ExecuteDataset(con, "tblSubCategory_Search", txtSearch.Text);
            if (subcatDataset.Tables[0].Rows.Count > 0)
            {
                rptSubCategory.DataSource = subcatDataset.Tables[0];
                rptSubCategory.DataBind();
            }
            else
            {
                rptSubCategory.DataSource = subcatDataset.Tables[0];
                Response.Write("<script>Document.GetElementById('NoSrc').Value='No Record Found';</script>");
                rptSubCategory.DataBind();       
            }
        }
        #region Pageing
        protected void getSubCategoryData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet SubCategorydataset = new DataSet();
                SubCategorydataset = SqlHelper.ExecuteDataset(con, "tblSubCategory_Get");
                SubCategoryBAL b1 = new SubCategoryBAL();
                SubCategoryDAL d1 = new SubCategoryDAL();
                b1.SubCategoryId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.SubCategoryMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptSubCategory.DataSource = comDataset.Tables[0];
                        rptSubCategory.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptSubCategory.DataSource = null;
                    rptSubCategory.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptSubCategory.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSubCategoryData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            getSubCategoryData(pageIndex);
        }

        #endregion
    }
}