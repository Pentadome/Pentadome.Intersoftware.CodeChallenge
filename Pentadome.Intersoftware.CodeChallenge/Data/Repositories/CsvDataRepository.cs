﻿using CsvHelper;
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
    internal sealed class CsvDataRepository
    {
        public static ICollection<Sale> GetSales()
        {
            using var reader = new StreamReader("Data\\CSV\\sales.csv");
            // Dutch culture because numbers look like 3.120,65 and not 3,120.65
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.GetCultureInfo("NL"))
            {
                Delimiter = ";"
            });

            return csv.GetRecords<Sale>().ToList();
        }
    }
}
