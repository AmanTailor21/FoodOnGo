using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operations.BAL;
using System.Configuration;

namespace Operations.DAL
{
    public class FeedDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void FuncAddFeed(FeedBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblFeedback_Add", b1.ItemId,b1.UserId,b1.FeedTitle,b1.FeedDesc);
        }
    }
}