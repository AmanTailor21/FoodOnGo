using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.BAL
{
    public class TrainStationBAL
    {
        public long TrainStationId { get; set; }
        public long TrainId { get; set; }
        public long StationId { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public string StopTime { get; set; }
        public long SubCategoryId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
