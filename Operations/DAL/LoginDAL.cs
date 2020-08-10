using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operations.BAL;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Operations;


namespace Operations.DAL
{
    public class LoginDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FuncLoginInsert(LoginBAL b1)
        {
            SqlHelper.ExecuteScalar(con, "tblLogin_Insert", b1.UserId, b1.EmailID, b1.Password, b1.OTP);

        }
    }
}
