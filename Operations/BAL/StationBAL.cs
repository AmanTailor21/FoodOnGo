using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.BAL
{
    public class StationBAL
    {
        public long StationId { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
