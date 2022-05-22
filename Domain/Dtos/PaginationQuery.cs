using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PaginationQuery
    {
        // page number
        [DefaultValue(1)]
        public int pageIndex { get; set; }

        // record per page
        [DefaultValue(12)]
        public int pageSize { get; set; }
    }
}
