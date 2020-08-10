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
    public class PayModeDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        public void FuncInsertPayMode(PayModeBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con,"tblPayMode_Insert", b1.PayModeName);
        }
        public DataSet FuncGetPayMode()
        {
            DataSet dataSet= SqlHelper.ExecuteDataset(con, "tblPayMode_Get");
            return dataSet;
        }

        public DataSet FuncGetPayModeById(long hid)
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblPayMode_Get_By_Id",hid);
            return dataSet;
        }

        public void FuncDelPayMode(long cid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblPayMode_Del", cid);
        }

        public void FuncUpdatePayMode(PayModeBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblPayMode_Update", b1.PayModeId, b1.PayModeName);
        }

        public void FuncChangeStatus(long cid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblPayMode_Status", cid);
        }
    }
}
