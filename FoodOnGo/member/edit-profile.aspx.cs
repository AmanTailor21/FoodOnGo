using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Operations.DAL;
using Operations.BAL;

namespace FoodOnGo.member
{
    public partial class edit_profile : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlLoadDOB();
                int year = DateTime.Now.Year;
                ddlDDLoad("Jan", year);
                getInfo();
            }
        }

        protected void getInfo()
        {
            try
            {
                DataSet dataSet = new DataSet();
                dataSet = SqlHelper.ExecuteDataset(con, "tblUser_Get_By_Email", Session["Email"].ToString());
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dataSet.Tables[0].Rows)
                    {
                        txtFirst.Text = Convert.ToString(dr["FirstName"]);
                        txtLast.Text = Convert.ToString(dr["LastName"]);
                        string[] dob = Convert.ToString(dr["DateOfBirth"]).Split('/');
                        ddlDD.SelectedValue = dob[0];
                        ddlMM.SelectedValue = dob[1];
                        ddlYYYY.SelectedValue = dob[2];
                        txtMob.Text = Convert.ToString(dr["MobileNo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlLoadDOB()
        {
            string[] month = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            for (int i = 2018; i >= 1900; i--)
            {

                ddlYYYY.Items.Add(Convert.ToString(i));
            }

            for (int I = 1; I <= 12; I++)
            {
                ddlMM.Items.Add(month[I]);
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            {
                RegisterBAL b1 = new RegisterBAL();
                RegisterDAL d1 = new RegisterDAL();
                b1.EmailId = Session["Email"].ToString();
                b1.FirstName = txtFirst.Text;
                b1.LastName = txtLast.Text;
                b1.Birthdate = ddlDD.SelectedValue + "/" + ddlMM.SelectedValue + "/" + ddlYYYY.SelectedValue;
                b1.MobileNo = txtMob.Text;
                d1.FuncUpdateProfile(b1);
            }
        }
        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDD.Items.Clear();
            if (ddlYYYY.SelectedValue == "YYYY")
            {
                ddlDDLoad(ddlMM.SelectedValue.ToString());
            }
            else
            {
                int yyyy = Convert.ToInt32(ddlYYYY.SelectedValue.ToString());
                ddlDDLoad(ddlMM.SelectedValue.ToString(), yyyy);
            }
        }

        protected void ddlDDLoad(string MM, int YYYY = 2019)
        {
            int Y = YYYY % 4;
            if (MM == "Feb")
            {
                if (Y == 0)
                {
                    for (int I = 01; I <= 29; I++)
                    {
                        ddlDD.Items.Add(Convert.ToString(I));
                    }
                }
                else
                {
                    for (int I = 01; I <= 28; I++)
                    {
                        ddlDD.Items.Add(Convert.ToString(I));
                    }
                }
            }
            else if (MM == "Jan" || MM == "Mar" || MM == "May" || MM == "Jul" || MM == "Aug" || MM == "Oct" || MM == "Dec" || MM == "MM")
            {
                for (int I = 01; I <= 31; I++)
                {
                    ddlDD.Items.Add(Convert.ToString(I));
                }
            }
            else if (MM == "Apr" || MM == "Jun" || MM == "Sep" || MM == "Nov")
            {
                for (int I = 01; I <= 30; I++)
                {
                    ddlDD.Items.Add(Convert.ToString(I));
                }
            }
        }
    }
}