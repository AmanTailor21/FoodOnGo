using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Operations.DAL;
using System.Configuration;

namespace FoodOnGo
{
    public partial class WeDeliverAt : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TrainBind();
            }
        }
        #region locationmanagement
        protected void TrainBind()
        {
            ddlStationCode.Enabled = false;
            ddlStation.Enabled = false;
            ddlStationCode.Items.Insert(0, "-Code-");
            ddlStation.Items.Insert(0, "-Station-");
            DataSet SDataSet = new DataSet();
            SDataSet = SqlHelper.ExecuteDataset(con, "tblTrain_Get");
            if (SDataSet.Tables[0].Rows.Count > 0)
            {
                ddltrain.DataSource = SDataSet.Tables[0];
                ddltrainCode.DataSource = SDataSet.Tables[0];
                ddltrainCode.DataTextField = "TrainCode";
                ddltrain.DataTextField = "TrainName";
                ddltrainCode.DataValueField = "TrainId";
                ddltrain.DataValueField = "TrainId";
                ddltrainCode.DataBind();
                ddltrain.DataBind();
                ddltrainCode.Items.Insert(0, "-Code-");
                ddltrain.Items.Insert(0, "-Train-");
            }
        }
        protected void StationBind(long tid)
        {
            DataSet SDataSet = new DataSet();
            SDataSet = SqlHelper.ExecuteDataset(con, "tblTrainStation_Get_By_TrainId", tid);
            if (SDataSet.Tables[0].Rows.Count > 0)
            {
                ddlStation.DataSource = SDataSet.Tables[0];
                ddlStationCode.DataSource = SDataSet.Tables[0];
                ddlStationCode.DataTextField = "SC";
                ddlStation.DataTextField = "SN";
                ddlStationCode.DataValueField = "StationId";
                ddlStation.DataValueField = "StationId";
                ddlStationCode.DataBind();
                ddlStation.DataBind();
                ddlStationCode.Items.Insert(0, "-Code-");
                ddlStation.Items.Insert(0, "-Station-");
            }
        }

        protected void ddlStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlStationCode.SelectedIndex = ddlStation.SelectedIndex;
        }
        protected void ddltrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddltrainCode.SelectedIndex = ddltrain.SelectedIndex;
            ddlStationCode.Enabled = false;
            ddlStation.Enabled = false;
            ddlStationCode.Items.Clear();
            ddlStation.Items.Clear();
            long tid = 0;
            try
            {
                tid = Convert.ToInt64(ddltrain.SelectedValue);
            }
            catch
            {
            }
            if (tid > 0)
            {
                StationBind(tid);
                ddlStationCode.Enabled = true;
                ddlStation.Enabled = true;
            }
            else
            {
                ddlStationCode.Items.Insert(0, "-Code-");
                ddlStation.Items.Insert(0, "-Station-");
            }
        }

        protected void ddlStationCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlStation.SelectedIndex = ddlStationCode.SelectedIndex;
        }
        protected void ddltrainCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddltrain.SelectedIndex = ddltrainCode.SelectedIndex;
            ddlStationCode.Enabled = false;
            ddlStation.Enabled = false;
            ddlStationCode.Items.Clear();
            ddlStation.Items.Clear();
            long tid = 0;
            try
            {
                tid = Convert.ToInt64(ddltrain.SelectedValue);
            }
            catch
            {
            }
            if (tid > 0)
            {
                StationBind(tid);
                ddlStationCode.Enabled = true;
                ddlStation.Enabled = true;
            }
            else
            {
                ddlStationCode.Items.Insert(0, "-Code-");
                ddlStation.Items.Insert(0, "-Station-");
            }
        }
        #endregion
    }
}