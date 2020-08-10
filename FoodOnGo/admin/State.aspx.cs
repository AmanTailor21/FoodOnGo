using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Operations.BAL;
using Operations.DAL;
using System.Configuration;

namespace FoodOnGo.admin
{
    public partial class State : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.Text = "Insert";
                getStateData(1);
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (hid1.Value == "")
            {
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblState_Check", txtSName.Text));
                if (cnt > 0)
                {
                    lblWarn.Text = "Already Exist";
                }
                else
                {
                    StateBAL b1 = new StateBAL();
                    b1.StateName = txtSName.Text;
                    StateDAL d1 = new StateDAL();
                    d1.FuncInsertState(b1);
                    lblWarn.Text = "";
                }
            }
            else
            {
                StateBAL b1 = new StateBAL();
                b1.StateId = Convert.ToInt64(hid1.Value);
                b1.StateName = txtSName.Text;
                StateDAL d1 = new StateDAL();
                d1.FuncUpdateState(b1);
                btnSubmit.Text = "Insert";
            }
            Cleardata();
            getStateData(1);
        }

        protected void GetState()
        {
            StateDAL d1 = new StateDAL();
            DataSet dataSet = new DataSet();
            dataSet = d1.FuncGetState();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptState.DataSource = dataSet.Tables[0];
                rptState.DataBind();
            }
        }

        protected void GetStateById(string hid1)
        {
            StateDAL d1 = new StateDAL();
            DataSet dataSet = new DataSet();
            long hid = Convert.ToInt64(hid1);
            dataSet = d1.FuncGetStateById(hid);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    txtSName.Text = Convert.ToString(dr["StateName"]);
                }
            }
            btnSubmit.Text = "Update";
        }

        protected void RptState_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            StateDAL d1 = new StateDAL();
            long cid = Convert.ToInt64(e.CommandArgument);
            switch (e.CommandName)
            {
                case "delete":
                    d1.FuncDelState(cid);
                    Cleardata();
                    getStateData(1);
                    break;
                case "edit":
                    hid1.Value = Convert.ToString(e.CommandArgument);
                    GetStateById(hid1.Value);
                    break;
                case "status":
                    d1.FuncChangeStatus(cid);
                    getStateData(1);
                    break;
            }
        }

        protected void Cleardata()
        {
            txtSName.Text = "";
            hid1.Value = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet StateDataset = SqlHelper.ExecuteDataset(con, "tblState_Search", txtSearch.Text);
            if (StateDataset.Tables[0].Rows.Count > 0)
            {
                rptState.DataSource = StateDataset.Tables[0];
                rptState.DataBind();
            }
        }
        #region Pageing
        protected void getStateData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet Statedataset = new DataSet();
                Statedataset = SqlHelper.ExecuteDataset(con, "tblState_Get");
                StateBAL b1 = new StateBAL();
                StateDAL d1 = new StateDAL();
                b1.StateId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.StateMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptState.DataSource = comDataset.Tables[0];
                        rptState.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptState.DataSource = null;
                    rptState.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptState.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            getStateData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            getStateData(pageIndex);
        }

        #endregion
    }
}