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
    public class StateDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        public void FuncInsertState(StateBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con,"tblState_Insert", b1.StateName);
        }
        public DataSet FuncGetState()
        {
            DataSet dataSet= SqlHelper.ExecuteDataset(con, "tblState_Get");
            return dataSet;
        }

        public DataSet FuncGetStateById(long hid)
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblState_Get_By_Id",hid);
            return dataSet;
        }

        public void FuncDelState(long sid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblState_Del", sid);
        }

        public void FuncUpdateState(StateBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblState_Update", b1.StateId, b1.StateName);
        }

        public void FuncChangeStatus(long sid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblState_Status", sid);
        }

        public DataSet StateMaster_Get_by_PageIndex(StateBAL b1)
        {
            return SqlHelper.ExecuteDataset(con, "tblState_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
