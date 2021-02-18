using CsvHelper;
using CsvHelper.Configuration;
using Pentadome.Intersoftware.CodeChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pentadome.Intersoftware.CodeChallenge.Data.Repositories
{
    public sealed class CsvDataRepository
    {
        public ICollection<Sale> GetSales()
        {
            using var reader = new StreamReader("Data\\CSV\\sales.csv");
            // Dutch culture because numbers look like 3.120,65 and not 3,120.65
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.GetCultureInfo("NL"))
            {
                Delimiter = ";"
            });

            return csv.GetRecords<Sale>().ToList();
        }

        public ICollection<MonthlySaleRecord> GetMonthlySaleRecords()
        {
            var sales = GetSales();

            var salesByProductByMonthPerYear = sales.GroupBy(x => (year: x.Date.Year, month: x.Date.Month, product: x.Product));

            var monthlySaleRecords = new List<MonthlySaleRecord>();
            foreach (var salesInMonth in salesByProductByMonthPerYear)
            {
                var quantity = 0;
                decimal turnOver = 0;

                foreach (var sale in salesInMonth)
                {
                    quantity += sale.Quantity;
                    turnOver += sale.Price * sale.Quantity;
                }

                monthlySaleRecords.Add(new MonthlySaleRecord
                {
                    Month = (byte)salesInMonth.Key.month,
                    Year = salesInMonth.Key.year,
                    Product = salesInMonth.Key.product,
                    Quantity = quantity,
                    TurnOver = (long)turnOver
                });
            }
            return monthlySaleRecords;
        }
    }
}
