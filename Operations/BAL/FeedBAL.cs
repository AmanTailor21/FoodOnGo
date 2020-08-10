using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.BAL
{
    public class FeedBAL
    {
        public long FeedId { get; set; }
        public long UserId { get; set; }
        public long ItemId { get; set; }
        public string FeedTitle { get; set; }
        public string FeedDesc { get; set; }
    }
}
