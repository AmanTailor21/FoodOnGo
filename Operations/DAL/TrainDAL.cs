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
    public class TrainDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        public void FuncInsertTrain(TrainBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con,"tblTrain_Insert", b1.TrainCode,b1.TrainName,b1.TrainStartId,b1.TrainEndId,b1.Duration,b1.StartTime,b1.EndTime);
        }
        public DataSet FuncGetTrain()
        {
            DataSet dataSet= SqlHelper.ExecuteDataset(con, "tblTrain_Get");
            return dataSet;
        }

        public DataSet FuncGetTrainById(long tid)
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblTrain_Get_By_Id",tid);
            return dataSet;
        }

        public void FuncUpdateTrain(TrainBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblTrain_Update", b1.TrainId, b1.TrainCode, b1.TrainName, b1.TrainStartId, b1.TrainEndId, b1.Duration, b1.StartTime, b1.EndTime);
        }

        public void FuncChangeStatus(long tid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblTrain_Status", tid);
        }
        public DataSet TrainMaster_Get_by_PageIndex(TrainBAL b1)
        {
            return SqlHelper.ExecuteDataset(con, "tblTrain_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
