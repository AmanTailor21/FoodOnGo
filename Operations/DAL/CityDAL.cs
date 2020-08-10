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
    public class CityDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FuncInsertCity(CityBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblCity_Insert", b1.StateId,b1.CityName);
        }
        public DataSet FuncGetCity()
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblCity_Get");
            return dataSet;
        }

        public DataSet FuncGetCityById(long hid)
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblCity_Get_By_Id", hid);
            return dataSet;
        }

        public void FuncUpdateCity(CityBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblCity_Update",b1.CityId, b1.StateId, b1.CityName);
        }

        public void FuncChangeStatus(long cid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblCity_Status", cid);
        }

        public DataSet CityMaster_Get_by_PageIndex(CityBAL b1)
        {
            return SqlHelper.ExecuteDataset(con, "tblCity_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}