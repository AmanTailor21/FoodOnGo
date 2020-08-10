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
    public partial class TrainStation : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.Text = "Insert";
                ddlLoad();
                getTrainStationData(1);
            }
            
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (hid1.Value == "")
            {
                int cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(con, "tblTrainStation_Check", Convert.ToInt64(ddlTrain.SelectedValue), Convert.ToInt64(ddlStation.SelectedValue)));
                if (cnt > 0)
                {
                    lblWarn.Text = "Already Exist";
                }
                else
                {
                    TrainStationBAL b1 = new TrainStationBAL();
                    b1.TrainId = Convert.ToInt64(ddlTrain.SelectedValue);
                    b1.StationId = Convert.ToInt64(ddlStation.SelectedValue);
                    b1.Arrival= Convert.ToString(ddlArrivalTimeHH.SelectedValue) + ":" + Convert.ToString(ddlArrivalTimeMM.SelectedValue);
                    b1.Departure = Convert.ToString(ddlDepartureTimeHH.SelectedValue) + ":" + Convert.ToString(ddlDepartureTimeMM.SelectedValue);
                    b1.StopTime= txtStopTime.Text;
                    TrainStationDAL d1 = new TrainStationDAL();
                    d1.FuncInsertTrainStation(b1);
                    lblWarn.Text = "";
                }
            }
            else
            {
                TrainStationBAL b1 = new TrainStationBAL();
                b1.TrainId = Convert.ToInt64(ddlTrain.SelectedValue);
                b1.StationId = Convert.ToInt64(ddlStation.SelectedValue);
                b1.Arrival = Convert.ToString(ddlArrivalTimeHH.SelectedValue) + ":" + Convert.ToString(ddlArrivalTimeMM.SelectedValue);
                b1.Departure = Convert.ToString(ddlDepartureTimeHH.SelectedValue) + ":" + Convert.ToString(ddlDepartureTimeMM.SelectedValue);
                b1.StopTime = txtStopTime.Text;
                TrainStationDAL d1 = new TrainStationDAL();
                d1.FuncUpdateTrainStation(b1);
                btnSubmit.Text = "Insert";
            }
            Cleardata();
            getTrainStationData(1);
        }

        protected void ddlBind(DropDownList ddl,string Text,string Value,string Default,string table)
        {
            DataSet SDataSet = new DataSet();
            SDataSet = SqlHelper.ExecuteDataset(con, "tbl"+table+"_Get");
            if (SDataSet.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = SDataSet.Tables[0];
                ddl.DataTextField = Text;
                ddl.DataValueField = Value;
                ddl.DataBind();
                ddl.Items.Insert(0, Default);
            }
        }

        protected void GetTrainStation()
        {
            TrainStationDAL d1 = new TrainStationDAL();
            DataSet dataSet = new DataSet();
            dataSet = d1.FuncGetTrainStation();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptTrainStation.DataSource = dataSet.Tables[0];
                rptTrainStation.DataBind();
            }
        }

        protected void GetTrainStationById(string hid1)
        {
            TrainStationDAL d1 = new TrainStationDAL();
            DataSet dataSet = new DataSet();
            long hid = Convert.ToInt64(hid1);
            dataSet = d1.FuncGetTrainStationById(hid);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    ddlTrainCode.SelectedValue = Convert.ToString(dr["TrainId"]);
                    ddlTrain.SelectedValue= Convert.ToString(dr["TrainId"]);
                    ddlStation.SelectedValue = Convert.ToString(dr["StationId"]);
                    ddlStationCode.SelectedValue = Convert.ToString(dr["StationId"]);
                    string[] Arrival = (Convert.ToString(dr["SAT"])).Split(':');
                    ddlArrivalTimeHH.SelectedValue = Arrival[0];
                    ddlArrivalTimeMM.SelectedValue = Arrival[1];
                    string[] StartTime = (Convert.ToString(dr["SDT"])).Split(':');
                    ddlDepartureTimeHH.SelectedValue = StartTime[0];
                    ddlDepartureTimeMM.SelectedValue = StartTime[1];
                    txtStopTime.Text = Convert.ToString(dr["ST"]);
                }
            }
            btnSubmit.Text = "Update";
        }

        protected void RptTrainStation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            TrainStationDAL d1 = new TrainStationDAL();
            long tid = Convert.ToInt64(e.CommandArgument);
            switch (e.CommandName)
            {
                case "edit":
                    hid1.Value = Convert.ToString(e.CommandArgument);
                    GetTrainStationById(hid1.Value);
                    break;
                case "status":
                    d1.FuncChangeStatus(tid);
                    getTrainStationData(1);
                    break;
            }
        }

        protected void Cleardata()
        {
            ddlClear();
            ddlLoad();
            hid1.Value = "";
        }

        protected void ddlLoad()
        {
            ddlBind(ddlTrainCode, "TrainCode", "TrainId", "-Select Train-","Train");
            ddlBind(ddlTrain, "TrainName", "TrainId", "-Select Train-","Train");
            ddlBind(ddlStationCode, "StationCode", "StationId", "-Select Station-","Station");
            ddlBind(ddlStation, "StationName", "StationId", "-Select Station-","Station");
            BindTime();
        }

        protected void ddlClear()
        {
            ddlArrivalTimeHH.Items.Clear();
            ddlDepartureTimeHH.Items.Clear();
            ddlArrivalTimeMM.Items.Clear();
            ddlDepartureTimeMM.Items.Clear();
            ddlTrainCode.Items.Clear();
            ddlStationCode.Items.Clear();
            ddlTrain.Items.Clear();
            ddlStation.Items.Clear();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet CatDataset = SqlHelper.ExecuteDataset(con, "tblTrainStation_Search", txtSearch.Text);
            if (CatDataset.Tables[0].Rows.Count > 0)
            {
                rptTrainStation.DataSource = CatDataset.Tables[0];
                rptTrainStation.DataBind();
            }
        }

        protected void ddlStationCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlStation.SelectedIndex = ddlStationCode.SelectedIndex;
        }

        protected void ddlStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlStationCode.SelectedIndex = ddlStation.SelectedIndex;
        }

        protected void ddlTrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTrainCode.SelectedIndex = ddlTrain.SelectedIndex;
        }

        protected void ddlTrainCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTrain.SelectedIndex = ddlTrainCode.SelectedIndex;
        }

        protected void BindTime()
        {
            for (int H = 00; H <= 23; H++)
            {
                ddlArrivalTimeHH.Items.Insert(H, H.ToString("0#"));
                ddlDepartureTimeHH.Items.Insert(H, H.ToString("0#"));
            }
            for (int M = 00; M <= 59; M++)
            {
                ddlArrivalTimeMM.Items.Insert(M, M.ToString("0#"));
                ddlDepartureTimeMM.Items.Insert(M, M.ToString("0#"));
            }
            ddlArrivalTimeHH.Items.Insert(0, "HH");
            ddlDepartureTimeHH.Items.Insert(0, "HH");
            ddlArrivalTimeMM.Items.Insert(0,"MM");
            ddlDepartureTimeMM.Items.Insert(0, "MM");
        }
        #region Pageing
        protected void getTrainStationData(int pageIndex)
        {
            try
            {
                rptPager.DataSource = null;
                rptPager.DataBind();

                DataSet TrainStationdataset = new DataSet();
                TrainStationdataset = SqlHelper.ExecuteDataset(con, "tblTrainStation_Get");
                TrainStationBAL b1 = new TrainStationBAL();
                TrainStationDAL d1 = new TrainStationDAL();
                b1.TrainStationId = 0;
                b1.PageIndex = pageIndex;
                b1.PageSize = Convert.ToInt16(cboPageSize.SelectedValue);
                b1.Search = txtSearch.Text.Trim();
                DataSet comDataset = d1.TrainStationMaster_Get_by_PageIndex(b1);
                if (comDataset != null && comDataset.Tables.Count > 0)
                {
                    if (comDataset.Tables[0].Rows.Count > 0)
                    {
                        rptTrainStation.DataSource = comDataset.Tables[0];
                        rptTrainStation.DataBind();
                        int iRecordCount = Convert.ToInt16(comDataset.Tables[0].Rows[0]["RecordCount"]);
                        PopulatePager(iRecordCount, pageIndex);
                    }
                }
                else
                {
                    rptTrainStation.DataSource = null;
                    rptTrainStation.DataBind();
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

            ltrRecordFound.Text = "Displaying " + currentPage.ToString() + " to " + rptTrainStation.Items.Count.ToString() + " of " + recordCount.ToString() + " Records";
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        protected void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTrainStationData(1);
        }
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            getTrainStationData(pageIndex);
        }

        #endregion
    }
}