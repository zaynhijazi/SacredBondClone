using EllipticCurve.Utils;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SacredBond.App.Models.Admin
{
    public class DataTablesRequest
    {
        public int Draw { get; set; }

        public List<Column> Columns { get; set; } = new List<Column>();

        public List<Order> Order { get; set; } = new List<Order>();

        public int Start { get; set; }

        public int Length { get; set; }

        public Search Search { get; set; } = new Search();
    }

    public class Column
    {
        public string Data { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public bool Searchable { get; set; }

        public bool Orderable { get; set; }

        public Search Search { get; set; } = new Search();
    }

    public class Order
    {
        public int Column { get; set; }

        public string Dir { get; set; } = string.Empty;
    }

    public class Search
    {
        public string Value { get; set; } = string.Empty;

        public bool IsRegex { get; set; }
    }
}
