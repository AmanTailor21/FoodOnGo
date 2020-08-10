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
    public class StationDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        public void FuncInsertStation(StationBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con,"tblStation_Insert", b1.StationCode,b1.StationName);
        }
        public DataSet FuncGetStation()
        {
            DataSet dataSet= SqlHelper.ExecuteDataset(con, "tblStation_Get");
            return dataSet;
        }

        public DataSet FuncGetStationById(long hid)
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblStation_Get_By_Id",hid);
            return dataSet;
        }

        public void FuncDelStation(long cid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblStation_Del", cid);
        }

        public void FuncUpdateStation(StationBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblStation_Update", b1.StationId,b1.StationCode, b1.StationName);
        }

        public void FuncChangeStatus(long cid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblStation_Status", cid);
        }

        public DataSet StationMaster_Get_by_PageIndex(StationBAL b1)
        {
            return SqlHelper.ExecuteDataset(con, "tblStation_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
