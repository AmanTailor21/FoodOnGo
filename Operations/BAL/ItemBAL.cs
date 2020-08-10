using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.BAL
{
    public class ItemBAL
    {
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDetail { get; set; }
        public string ItemAmount { get; set; }
        public string ItemImage { get; set; }
        public long SubCategoryId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
