using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pentadome.Intersoftware.CodeChallenge.Data.Models
{
    public sealed class Sale
    {
        public string Product { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }
    }
}
