using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pentadome.Intersoftware.CodeChallenge.Data.Models
{
    public class MonthlySaleRecord
    {
        public string Product { get; set; }

        /// <summary>
        /// 1 to 12
        /// </summary>
        public byte Month { get; set; }

        public int Year { get; set; }

        public int Quantity { get; set; }

        public long TurnOver { get; set; }
    }
}
