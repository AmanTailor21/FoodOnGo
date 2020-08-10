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
    public class TrainStationDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        public void FuncInsertTrainStation(TrainStationBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con,"tblTrainStation_Insert",b1.TrainId,b1.StationId,b1.Arrival,b1.Departure, b1.StopTime);
        }
        public DataSet FuncGetTrainStation()
        {
            DataSet dataSet= SqlHelper.ExecuteDataset(con, "tblTrainStation_Get");
            return dataSet;
        }

        public DataSet FuncGetTrainStationById(long hid)
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblTrainStation_Get_By_Id",hid);
            return dataSet;
        }

        public void FuncUpdateTrainStation(TrainStationBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblTrainStation_Update",b1.TrainStationId,b1.TrainId, b1.StationId, b1.Arrival, b1.Departure, b1.StopTime);
        }

        public void FuncChangeStatus(long tsid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblTrainStation_Status", tsid);
        }

        public DataSet TrainStationMaster_Get_by_PageIndex(TrainStationBAL b1)
        {
            return SqlHelper.ExecuteDataset(con, "tblTrainStation_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
