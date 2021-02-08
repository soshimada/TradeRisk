using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeRisk.Domain.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Risk { get; set; }
        public string Sector { get; set; }
        public string Operator { get; set; }
        public double Value { get; set; }
    }
}
