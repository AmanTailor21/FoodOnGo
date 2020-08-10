using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.BAL
{
    public class TrainBAL
    {
        public long TrainId { get; set; }
        public string TrainCode { get; set; }
        public string TrainName { get; set; }
        public long TrainStartId { get; set; }
        public long TrainEndId { get; set; }
        public string Duration { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
