using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operations.BAL;
using System.Configuration;

namespace Operations.DAL
{
    public class CartDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FuncAddToCart(CartBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblCart_Add", b1.ItemId,b1.UserId,b1.Quantity,b1.Rate);
        }
    }
}
