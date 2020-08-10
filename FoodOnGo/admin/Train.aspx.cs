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
    public partial class Train : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.Text = "Insert";
                ddlLoad();
                getTrainData(1);
            }
            
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (hid1.Value == "")
            {
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblTrain_Check", txtTrainCode.Text));
                if (cnt > 0)
                {
                    lblWarn.Text = "Already Exist";
                }
                else
                {
                    TrainBAL b1 = new TrainBAL();
                    b1.TrainCode = txtTrainCode.Text;
                    b1.TrainName = txtTrainName.Text;
                    b1.TrainStartId = Convert.ToInt64(ddlStartStation.SelectedValue);
                    b1.TrainEndId = Convert.ToInt64(ddlEndStation.SelectedValue);
                    b1.Duration = Convert.ToString(ddlDurationHH.SelectedValue) + ":" + Convert.ToString(ddlDurationMM.SelectedValue);
                    b1.StartTime = Convert.ToString(ddlStartTimeHH.SelectedValue) + ":" + Convert.ToString(ddlStartTimeMM.SelectedValue);
                    b1.EndTime = Convert.ToString(ddlEndTimeHH.SelectedValue) + ":" + Convert.ToString(ddlEndTimeMM.SelectedValue);
                    TrainDAL d1 = new TrainDAL();
                    d1.FuncInsertTrain(b1);
                    lblWarn.Text = "";
                }
            }
            else
            {
                TrainBAL b1 = new TrainBAL();
                b1.TrainId = Convert.ToInt64(hid1.Value);
                b1.TrainCode = txtTrainCode.Text;
                b1.TrainName = txtTrainName.Text;
                b1.TrainStartId = Convert.ToInt64(ddlStartStation.SelectedValue);
                b1.TrainEndId = Convert.ToInt64(ddlEndStation.SelectedValue);
                b1.Duration = Convert.ToString(ddlDurationHH.SelectedValue) + ":" + Convert.ToString(ddlDurationMM.SelectedValue);
                b1.StartTime = Convert.ToString(ddlStartTimeHH.SelectedValue) + ":" + Convert.ToString(ddlStartTimeMM.SelectedValue);
                b1.EndTime = Convert.ToString(ddlEndTimeHH.SelectedValue) + ":" + Convert.ToString(ddlEndTimeMM.SelectedValue);
                TrainDAL d1 = new TrainDAL();
                d1.FuncUpdateTrain(b1);
                btnSubmit.Text = "Insert";
            }
            Cleardata();
            getTrainData(1);
        }

        protected void ddlBind(DropDownList ddl,string Text,string Value,string Default)
        {
            DataSet SDataSet = new DataSet();
            SDataSet = SqlHelper.ExecuteDataset(con, "tblStation_Get");
            if (SDataSet.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = SDataSet.Tables[0];
                ddl.DataTextField = Text;
                ddl.DataValueField = Value;
                ddl.DataBind();
                ddl.Items.Insert(0, Default);
            }
        }

        protected void GetTrain()
        {
            TrainDAL d1 = new TrainDAL();
            DataSet dataSet = new DataSet();
            dataSet = d1.FuncGetTrain();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptTrain.DataSource = dataSet.Tables[0];
                rptTrain.DataBind();
            }
        }

        protected void GetTrainById(string hid1)
        {
            TrainDAL d1 = new TrainDAL();
            DataSet dataSet = new DataSet();
            long hid = Convert.ToInt64(hid1);
            dataSet = d1.FuncGetTrainById(hid);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    txtTrainCode.Text = Convert.ToString(dr["TrainCode"]);
                    txtTrainName.Text = Convert.ToString(dr["TrainName"]);
                    ddlStartStation.SelectedValue = Convert.ToString(dr["TrainStartId"]);
                    ddlStartCode.SelectedValue = Convert.ToString(dr["TrainStartId"]);
                    ddlEndStation.SelectedValue = Convert.ToString(dr["TrainEndId"]);
                    ddlEndCode.SelectedValue = Convert.ToString(dr["TrainEndId"]);
                    string[] Duration = (Convert.ToString(dr["Duration"])).Split(':');
                    ddlDurationHH.SelectedValue = Duration[0];
                    ddlDurationMM.SelectedValue = Duration[1];
                    string[] StartTime = (Convert.ToString(dr["StartTime"])).Split(':');
                    ddlStartTimeHH.SelectedValue = StartTime[0];
                    ddlStartTimeMM.SelectedValue = StartTime[1];
                    string[] EndTime = (Convert.ToString(dr["EndTime"])).Split(':');
                    ddlEndTimeHH.SelectedValue = EndTime[0];
                    ddlEndTimeMM.SelectedValue = EndTime[1];
                }
            }
            btnSubmit.Text = "Update";
        }

        protected void RptTrain_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            TrainDAL d1 = new TrainDAL();
            long tid = Convert.ToInt64(e.CommandArgument);
            switch (e.CommandName)
            {
                case "edit":
                    hid1.Value = Convert.ToString(e.CommandArgument);
                    GetTrainById(hid1.Value);
                    break;
                case "status":
                    d1.FuncChangeStatus(tid);
                    getTrainData(1);
                    break;
            }
        }

        protected void Cleardata()
        {
            txtTrainCode.Text = "";
            txtTrainName.Text = "";
            ddlClear();
            ddlLoad();
            hid1.Value = "";
        }

        protected void ddlLoad()
        {
            ddlBind(ddlStartCode, "StationCode", "StationId", "-Select Start Station-");
            ddlBind(ddlStartStation, "StationName", "StationId", "-Select Start Station-");
            ddlBind(ddlEndCode, "StationCode", "StationId", "-Select End Station-");
            ddlBind(ddlEndStation, "StationName", "StationId", "-Select End Station-");
            BindTime();
        }

        protected void ddlClear()
        {
            ddlDurationHH.Items.Clear();
            ddlStartTimeHH.Items.Clear();
            ddlEndTimeHH.Items.Clear();
            ddlDurationMM.Items.Clear();
            ddlStartTimeMM.Items.Clear();
            ddlEndTimeMM.Items.Clear();
            ddlStartCode.Items.Clear();
            ddlEndCode.Items.Clear();
            ddlStartStation.Items.Clear();
            ddlEndStation.Items.Clear();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet CatDataset = SqlHelper.ExecuteDataset(con, "tblTrain_Search", txtSearch.Text);
            if (CatDataset.Tables[0].Rows.Count > 0)
            {
                rptTrain.DataSource = CatDataset.Tables[0];
                rptTrain.DataBind();
            }
        }

        protected void ddlEndCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEndStation.SelectedIndex = ddlEndCode.SelectedIndex;
        }

        protected void ddlEndStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEndCode.SelectedIndex = ddlEndStation.SelectedIndex;
        }

        protected void ddlStartStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlStartCode.SelectedIndex = ddlStartStation.SelectedIndex;
        }

        protected void ddlStartCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlStartStation.SelectedIndex = ddlStartCode.SelectedIndex;
        }

        protected void BindTime()
        {
            for (int H = 00; H <= 23; H++)
            {
                ddlStartTimeHH.Items.Insert(H, H.ToString("0#"));
                ddlEndTimeHH.Items.Insert(H, H.ToString("0#"));
            }
            for (int M = 00; M <= 59; M++)
            {
                ddlDurationMM.Items.Insert(M, M.ToString("0#"));
                ddlStartTimeMM.Items.Insert(M, M.ToString("0#"));
                ddlEndTimeMM.Items.Insert(M, M.ToString("0#"));
            }
            for (int H = 00; H <= 96; H++)
            {
                ddlDurationHH.Items.Insert(H, H.ToString("0#"));
            }

            ddlStartTimeHH.Items.Insert(0, "HH");
            ddlEndTimeHH.Items.Insert(0, "HH");
            ddlDurationHH.Items.Insert(0, "HH");
            ddlStartTimeMM.Items.Insert(0,"MM");
            ddlEndTimeMM.Items.Insert(0, "MM");
            ddlDurationMM.Items.Insert(0, "MM");
        }
        #region Pageing
        protected void getTrainData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet Traindataset = new DataSet();
                Traindataset = SqlHelper.ExecuteDataset(con, "tblTrain_Get");
                TrainBAL b1 = new TrainBAL();
                TrainDAL d1 = new TrainDAL();
                b1.TrainId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.TrainMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptTrain.DataSource = comDataset.Tables[0];
                        rptTrain.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptTrain.DataSource = null;
                    rptTrain.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptTrain.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTrainData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            getTrainData(pageIndex);
        }

        #endregion
    }
}