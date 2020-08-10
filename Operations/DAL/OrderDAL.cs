using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operations.BAL;
using System.Configuration;
namespace Operations.DAL
{
    public class OrderDAL
    {
        protected string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public void DeliverFunction(OrderBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "tblOrder_UpdateDeliver", b1.UserId,b1.OrderId, b1.TrainId, b1.StationId,b1.SeatNo,b1.Pnr,b1.Journey);
        }
        public void FuncMakePayment(OrderBAL b1)
        {
            SqlHelper.ExecuteNonQuery(con, "payOrder", b1.UserId,b1.OrderId, b1.CardNo,b1.CardHolderName,b1.CVV,b1.ExpireDate);
        }
    }
}
