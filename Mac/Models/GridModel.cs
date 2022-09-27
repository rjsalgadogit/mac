using System.Collections.Generic;

namespace Mac.Models
{
    public class GridModel
    {
        public string TableId { get; set; }

        public string Url { get; set; }

        public List<ColumnModel> Columns { get; set; }

        public int PageSize { get; set; }
    }

    public class ColumnModel
    {
        public string CustomName { get; set; }

        public string DataField { get; set; }
    }
}
