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

        public ICollection<ProductMonthlySaleRecord> GetMonthlySaleRecords()
        {
            var sales = GetSales();

            var salesByProduct = sales.GroupBy(x => x.Product);

            var productSaleRecords = new List<>();

            // TODO refractor
            foreach (var productSales in salesByProduct)
            {
                var productSaleRecord = new ProductMonthlySaleRecord
                {
                    Product = productSales.Key
                };
                productSaleRecords.Add(productSaleRecord);

                var salesOfProductByMonth = productSales.ToLookup(x => x.Date.Month);

                for (byte i = 1; i != 12; i++)
                {
                    var salesInCurrentMonth = salesOfProductByMonth[i];
                    var saleRecord = new MonthlySaleRecord
                    {
                        Month = i,
                        Year = 2018
                    };
                    productSaleRecord.SaleRecords.Add(saleRecord);

                    foreach (var sale in salesInCurrentMonth)
                    {
                        saleRecord.Quantity += sale.Quantity;
                        saleRecord.TurnOver += sale.Quantity * sale.Price;
                    }
                }
            }

            return productSaleRecords;
        }
    }
}
