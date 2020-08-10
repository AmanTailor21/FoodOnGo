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
    public partial class PayMode : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.Text = "Insert";
                GetPayMode();
            }
            
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (hid1.Value == "")
            {
                PayModeBAL b1 = new PayModeBAL();
                b1.PayModeName = txtCName.Text;
                PayModeDAL d1 = new PayModeDAL();
                d1.FuncInsertPayMode(b1);
            }
            else
            {
                PayModeBAL b1 = new PayModeBAL();
                b1.PayModeId = Convert.ToInt64(hid1.Value);
                b1.PayModeName = txtCName.Text;
                PayModeDAL d1 = new PayModeDAL();
                d1.FuncUpdatePayMode(b1);
                btnSubmit.Text = "Insert";
            }
            Cleardata();
            GetPayMode();
        }

        protected void GetPayMode()
        {
            PayModeDAL d1 = new PayModeDAL();
            DataSet dataSet = new DataSet();
            dataSet = d1.FuncGetPayMode();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                rptPayMode.DataSource = dataSet.Tables[0];
                rptPayMode.DataBind();
            }
        }

        protected void GetCatById(string hid1)
        {
            PayModeDAL d1 = new PayModeDAL();
            DataSet dataSet = new DataSet();
            long hid = Convert.ToInt64(hid1);
            dataSet = d1.FuncGetPayModeById(hid);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    txtCName.Text = Convert.ToString(dr["PayModeName"]);
                }
            }
            btnSubmit.Text = "Update";
        }

        protected void RptPayMode_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PayModeDAL d1 = new PayModeDAL();
            long cid = Convert.ToInt64(e.CommandArgument);
            switch (e.CommandName)
            {
                case "delete":
                    d1.FuncDelPayMode(cid);
                    Cleardata();
                    GetPayMode();
                    break;
                case "edit":
                    hid1.Value = Convert.ToString(e.CommandArgument);
                    GetCatById(hid1.Value);
                    break;
                case "status":
                    d1.FuncChangeStatus(cid);
                    GetPayMode();
                    break;
            }
        }

        protected void Cleardata()
        {
            txtCName.Text = "";
            hid1.Value = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet CatDataset = SqlHelper.ExecuteDataset(con, "tblPayMode_Search", txtSearch.Text);
            if (CatDataset.Tables[0].Rows.Count > 0)
            {
                rptPayMode.DataSource = CatDataset.Tables[0];
                rptPayMode.DataBind();
            }
        }
    }
}