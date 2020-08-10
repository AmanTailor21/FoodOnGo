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
    public partial class Station : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.Text = "Insert";
                getStationData(1);
            }
            
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (hid1.Value == "")
            {
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblStation_Check", txtSCode.Text,txtSName.Text));
                if (cnt > 0)
                {
                    lblWarn.Text = "Already Exist";
                }
                else
                {
                    StationBAL b1 = new StationBAL();
                    b1.StationCode = txtSCode.Text;
                    b1.StationName = txtSName.Text;
                    StationDAL d1 = new StationDAL();
                    d1.FuncInsertStation(b1);
                    lblWarn.Text = "";
                }
            }
            else
            {
                StationBAL b1 = new StationBAL();
                b1.StationId = Convert.ToInt64(hid1.Value);
                b1.StationCode = txtSCode.Text;
                b1.StationName = txtSName.Text;
                StationDAL d1 = new StationDAL();
                d1.FuncUpdateStation(b1);
                btnSubmit.Text = "Insert";
            }
            Cleardata();
            getStationData(1);
        }

        protected void GetStation()
        {
            StationDAL d1 = new StationDAL();
            DataSet dataSet = new DataSet();
            dataSet = d1.FuncGetStation();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptStation.DataSource = dataSet.Tables[0];
                rptStation.DataBind();
            }
        }

        protected void GetStationById(string hid1)
        {
            StationDAL d1 = new StationDAL();
            DataSet dataSet = new DataSet();
            long hid = Convert.ToInt64(hid1);
            dataSet = d1.FuncGetStationById(hid);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    txtSCode.Text = Convert.ToString(dr["StationCode"]);
                    txtSName.Text = Convert.ToString(dr["StationName"]);
                }
            }
            btnSubmit.Text = "Update";
        }

        protected void RptStation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            StationDAL d1 = new StationDAL();
            long cid = Convert.ToInt64(e.CommandArgument);
            switch (e.CommandName)
            {
                case "delete":
                    d1.FuncDelStation(cid);
                    Cleardata();
                    getStationData(1);
                    break;
                case "edit":
                    hid1.Value = Convert.ToString(e.CommandArgument);
                    GetStationById(hid1.Value);
                    break;
                case "status":
                    d1.FuncChangeStatus(cid);
                    getStationData(1);
                    break;
            }
        }

        protected void Cleardata()
        {
            txtSCode.Text = "";
            txtSName.Text = "";
            hid1.Value = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet StationDataset = SqlHelper.ExecuteDataset(con, "tblStation_Search", txtSearch.Text);
            if (StationDataset.Tables[0].Rows.Count > 0)
            {
                rptStation.DataSource = StationDataset.Tables[0];
                rptStation.DataBind();
            }
        }
        #region Pageing
        protected void getStationData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet Stationdataset = new DataSet();
                Stationdataset = SqlHelper.ExecuteDataset(con, "tblStation_Get");
                StationBAL b1 = new StationBAL();
                StationDAL d1 = new StationDAL();
                b1.StationId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.StationMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptStation.DataSource = comDataset.Tables[0];
                        rptStation.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptStation.DataSource = null;
                    rptStation.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptStation.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            getStationData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            getStationData(pageIndex);
        }

        #endregion
    }
}