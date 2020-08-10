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
    public class CategoryDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        public void FuncInsertCategory(CategoryBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con,"tblCategory_Insert", b1.CategoryName);
        }
        public DataSet FuncGetCategory()
        {
            DataSet dataSet= SqlHelper.ExecuteDataset(con, "tblCategory_Get");
            return dataSet;
        }

        public DataSet FuncGetCategoryById(long hid)
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblCategory_Get_By_Id",hid);
            return dataSet;
        }

        public void FuncDelCategory(long cid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblCategory_Del", cid);
        }

        public void FuncUpdateCategory(CategoryBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblCategory_Update", b1.CategoryId, b1.CategoryName);
        }

        public void FuncChangeStatus(long cid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblCategory_Status", cid);
        }
        public DataSet CategoryMaster_Get_by_PageIndex(CategoryBAL b1)
        {
            return SqlHelper.ExecuteDataset(con, "tblCategory_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }

    }
}
