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
    public class RegisterDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public long FuncInsertUser(RegisterBAL b1)
        {
            return Convert.ToInt64(SqlHelper.ExecuteScalar(con, "tblUser_Insert",b1.FirstName, b1.LastName, b1.EmailId, b1.Password, b1.Birthdate, b1.Gender, b1.MobileNo));
        }
        public long FuncUpdateChangePass(RegisterBAL b1)
        {
            return Convert.ToInt64(SqlHelper.ExecuteScalar(con, "tblUser_ChangePassword",b1.EmailId,b1.Password,b1.OldPass));
        }
        public void FuncUpdateProfile(RegisterBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblUser_Update_Profile",b1.EmailId,b1.FirstName,b1.LastName,b1.Birthdate,b1.MobileNo);
        }
        
    }
}
