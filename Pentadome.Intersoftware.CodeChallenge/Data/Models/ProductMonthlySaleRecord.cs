using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pentadome.Intersoftware.CodeChallenge.Data.Models
{
    public class ProductMonthlySaleRecord
    {
        private ICollection<MonthlySaleRecord> _saleRecords;

        public string Product { get; init; }

        public ICollection<MonthlySaleRecord> SaleRecords
        {
            get => _saleRecords ??= new List<MonthlySaleRecord>();
            set => _saleRecords = value;
        }
    }
}
