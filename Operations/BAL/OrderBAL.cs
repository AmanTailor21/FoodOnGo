using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.BAL
{
    public class OrderBAL
    {
        public string EmailId { get; set; }
        public long UserId{ get; set; }
        public long OrderId{ get; set; }
        public long TrainId{ get; set; }
        public long StationId { get; set; }
        public string SeatNo { get; set; }
        public string Pnr { get; set; }
        public string Journey{ get; set; }
        public string CardNo { get; set; }
        public string CardHolderName { get; set; }
        public string CVV { get; set; }
        public string ExpireDate { get; set; }
    }
}
