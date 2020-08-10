using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.BAL
{
    public class SubCategoryBAL
    {
        public long CategoryId { get; set; }
        public long SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
