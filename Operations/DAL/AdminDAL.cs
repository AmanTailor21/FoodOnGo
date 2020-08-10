using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operations.BAL;
using System.Configuration;
namespace Operations.DAL
{
    public class AdminDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public long FuncUpdateChangePass(AdminBAL b1)
        {
            return Convert.ToInt64(SqlHelper.ExecuteScalar(con, "tblAdmin_ChangePassword", b1.EmailId, b1.Password, b1.OldPass));
        }
    }
}
