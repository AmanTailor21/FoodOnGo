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
    public class ItemDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        public void FuncInsertItem(ItemBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con,"tblItem_Insert", b1.SubCategoryId,b1.ItemName,b1.ItemImage,b1.ItemDetail,b1.ItemAmount);
        }
        public DataSet FuncGetItem()
        {
            DataSet dataSet= SqlHelper.ExecuteDataset(con, "tblItem_Get");
            return dataSet;
        }

        public DataSet FuncGetItemById(long hid)
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblItem_Get_By_Id",hid);
            return dataSet;
        }

        public void FuncUpdateItem(ItemBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblItem_Update",b1.ItemId,b1.SubCategoryId, b1.ItemName,b1.ItemDetail,b1.ItemAmount,b1.ItemImage);
        }

        public void FuncChangeStatus(long iid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblItem_Status", iid);
        }

        public DataSet ItemMaster_Get_by_PageIndex(ItemBAL b1)
        {
            return SqlHelper.ExecuteDataset(con, "tblItem_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}
