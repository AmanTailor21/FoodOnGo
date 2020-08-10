using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Operations.BAL;
using Operations.DAL;
using System.Drawing;

namespace FoodOnGo.member
{
    public partial class Orders : System.Web.UI.Page
    {

        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        int curryear = DateTime.Today.Year;
        int currmonth = DateTime.Today.Month;
        int currdate = DateTime.Today.Day;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["OrderId"] != null)
                    {
                        getCart();
                        TrainBind();
                        fillDate();
                    }
                    else
                    {
                        Response.Redirect("Index.aspx");
                    }
                }
            }
            catch
            {

            }
        }
        protected void getCart()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(con, "tblCart_Get", Convert.ToInt64(Session["User"].ToString()), 1, Convert.ToInt64(Session["OrderId"]));
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptOrder.DataSource = ds.Tables[0];
                rptOrder.DataBind();
                lblOrderNo.Text = ds.Tables[0].Rows[0]["OrderId"].ToString();
            }
            lblTotal.Text = Convert.ToString(SqlHelper.ExecuteScalar(con, "TotalAmount_Get", Convert.ToInt64(Session["User"]), 1, Convert.ToInt64(Session["OrderId"])));
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
        #region datemanagement
        protected void fillDate()
        {
            int d = DateTime.Today.Day;
            int m = DateTime.Today.Month;
            int y = DateTime.Today.Year;
            Day(d, m, y);
            ddlLoad(m, y);
        }
        protected void Day(int d = 0, int m = 0, int y = 0)
        {
            ddlDay.Items.Clear();
            int i = d;
            int Y = y % 4;
            if (m == 2)
            {
                if (Y == 0)
                {
                    for (int I = i; I <= 29; I++)
                    {
                        ddlDay.Items.Add(Convert.ToString(I));
                    }
                }
                else
                {
                    for (int I = i; I <= 28; I++)
                    {
                        ddlDay.Items.Add(Convert.ToString(I));
                    }
                }
            }
            else if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12 || m == 0)
            {
                for (int I = i; I <= 31; I++)
                {
                    ddlDay.Items.Add(Convert.ToString(I));
                }
            }
            else if (m == 4 || m == 6 || m == 9 || m == 11)
            {
                for (int I = i; I <= 30; I++)
                {
                    ddlDay.Items.Add(Convert.ToString(I));
                }
            }
        }
        protected void ddlLoad(int m, int y)
        {
            month(m);
            year(y);
        }
        protected void year(int y)
        {
            int ny = y + 1;
            for (int i = y; i <= ny; i++)
            {

                ddlYear.Items.Add(Convert.ToString(i));
            }
        }
        protected void month(int m)
        {
            ddlMonth.Items.Clear();
            for (int i = m; i <= 12; i++)
            {
                ddlMonth.Items.Add(Convert.ToString(i));
            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(ddlYear.SelectedValue);
            if (y != curryear)
            {
                month(1);
            }
            else
            {
                month(currmonth);
                Day(currdate, currmonth, curryear);
            }
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int m = Convert.ToInt32(ddlMonth.SelectedValue);
            int y = Convert.ToInt32(ddlYear.SelectedValue);
            if (m == 2)
            {
                if (m != currmonth)
                {
                    Day(1, 2, y);
                }
                else
                {
                    Day(currdate, currmonth, curryear);
                }
            }
            else
            {
                if (m != currmonth)
                {
                    Day(1, 0, y);
                }
                else
                {
                    Day(currdate, currmonth, curryear);
                }
            }
        }
        #endregion

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            OrderBAL b1 = new OrderBAL();
            OrderDAL d1 = new OrderDAL();
            b1.UserId = Convert.ToInt64(Session["User"]);
            b1.OrderId = Convert.ToInt64(Session["OrderId"]);
            b1.TrainId = Convert.ToInt64(ddltrain.SelectedValue);
            b1.StationId = Convert.ToInt64(ddlStation.SelectedValue);
            b1.SeatNo = txtseatno.Text;
            b1.Pnr = txtPNR.Text;
            b1.Journey = Convert.ToString(ddlDay.SelectedValue) + "/" + Convert.ToString(ddlMonth.SelectedValue) + "/" + Convert.ToString(ddlYear.SelectedValue);
            d1.DeliverFunction(b1);
            Response.Redirect("Payment.aspx");
        }
    }
}