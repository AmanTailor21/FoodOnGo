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
    public partial class City : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.Text = "Insert";
                StateBind();
                getCityData(1);
            }
            
        }

        protected void StateBind()
        {
            DataSet CDataSet = new DataSet();
            CDataSet = SqlHelper.ExecuteDataset(con, "tblState_Get");
            if (CDataSet.Tables[0].Rows.Count > 0)
            {
                ddlState.DataSource = CDataSet.Tables[0];
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateId";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "-Select State-");
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (hid1.Value == "")
            {
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblCity_Check", Convert.ToInt64(ddlState.SelectedValue), txtCityName.Text));
                if (cnt > 0)
                {
                    lblWarn.Text = "Already Exist";
                }
                else
                {
                    CityBAL b1 = new CityBAL();
                    b1.StateId = Convert.ToInt64(ddlState.SelectedValue);
                    b1.CityName = txtCityName.Text;
                    CityDAL d1 = new CityDAL();
                    d1.FuncInsertCity(b1);
                    lblWarn.Text = "";
                }
            }
            else
            {
                CityBAL b2 = new CityBAL();
                b2.CityId = Convert.ToInt64(hid1.Value);
                b2.StateId = Convert.ToInt64(ddlState.SelectedValue);
                b2.CityName = txtCityName.Text;
                CityDAL d2 = new CityDAL();
                d2.FuncUpdateCity(b2);
                btnSubmit.Text = "Insert";
            }
            Cleardata();
            getCityData(1);
        }

        protected void GetCity()
        {
            CityDAL d1 = new CityDAL();
            DataSet dataSet = new DataSet();
            dataSet = d1.FuncGetCity();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptCity.DataSource = dataSet.Tables[0];
                rptCity.DataBind();
            }
        }

        protected void GetSubCatById(string hid1)
        {
            CityDAL d1 = new CityDAL();
            DataSet dataSet = new DataSet();
            long hid = Convert.ToInt64(hid1);
            dataSet = d1.FuncGetCityById(hid);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    ddlState.SelectedValue = Convert.ToString(dr["StateId"]);
                    txtCityName.Text = Convert.ToString(dr["CityName"]);
                }
            }
            btnSubmit.Text = "Update";
        }

        protected void RptCity_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            CityDAL d1 = new CityDAL();
            long sid = Convert.ToInt64(e.CommandArgument);
            switch (e.CommandName)
            {
                case "edit":
                    hid1.Value = Convert.ToString(e.CommandArgument);
                    GetSubCatById(hid1.Value);
                    break;
                case "status":
                    d1.FuncChangeStatus(sid);
                    getCityData(1);
                    break;
            }
        }

        protected void Cleardata()
        {
            txtCityName.Text = "";
            ddlState.SelectedIndex = 0;
            hid1.Value = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getCityData(1);
        }
        #region Pageing
        protected void getCityData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet Citydataset = new DataSet();
                Citydataset = SqlHelper.ExecuteDataset(con, "tblCity_Get");
                CityBAL b1 = new CityBAL();
                CityDAL d1 = new CityDAL();
                b1.CityId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.CityMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptCity.DataSource = comDataset.Tables[0];
                        rptCity.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptCity.DataSource = null;
                    rptCity.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptCity.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCityData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            getCityData(pageIndex);
        }

        #endregion
    }
}