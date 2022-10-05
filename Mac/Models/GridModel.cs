using System.Collections.Generic;

namespace Mac.Models
{
    public class GridModel
    {
        public string TableId { get; set; }

        public string ReadAllRowDataUrl { get; set; }

        public string ReadRowDataUrl { get; set; }

        public string DeleteRowDataUrl { get; set; }

        public string SaveRowDataUrl { get; set; }

		public List<ColumnModel> Columns { get; set; }

        public int PageSize { get; set; }
    }

    public class ColumnModel
    {
		public string DataField { get; set; }

        public string DataRowCustom { get; set; }

        public string DataType { get; set; }

		public string ColumnNameCustom { get; set; }

        public string ColumnName { get { return !string.IsNullOrEmpty(ColumnNameCustom) ? ColumnNameCustom : DataField; } }

        public bool IsKey { get; set; }
    }
}
