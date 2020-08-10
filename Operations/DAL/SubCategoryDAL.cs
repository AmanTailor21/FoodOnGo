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
    public class SubCategoryDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FuncInsertSubCategory(SubCategoryBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblSubCategory_Insert", b1.CategoryId,b1.SubCategoryName);
        }
        public DataSet FuncGetSubCategory()
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblSubCategory_Get");
            return dataSet;
        }

        public DataSet FuncGetSubCategoryById(long hid)
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(con, "tblSubCategory_Get_By_Id", hid);
            return dataSet;
        }

        public void FuncUpdateSubCategory(SubCategoryBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblSubCategory_Update",b1.SubCategoryId, b1.CategoryId, b1.SubCategoryName);
        }

        public void FuncChangeStatus(long cid)
        {
            SqlHelper.ExecuteNonQuery(con, "tblSubCategory_Status", cid);
        }

        public DataSet SubCategoryMaster_Get_by_PageIndex(SubCategoryBAL b1)
        {
            return SqlHelper.ExecuteDataset(con, "tblSubCategory_Pagewise", b1.PageIndex, b1.PageSize, b1.Search);
        }
    }
}