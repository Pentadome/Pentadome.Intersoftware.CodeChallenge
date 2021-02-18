using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pentadome.Intersoftware.CodeChallenge.Authentication;
using Pentadome.Intersoftware.CodeChallenge.Data.Models;
using Pentadome.Intersoftware.CodeChallenge.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pentadome.Intersoftware.CodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        // [Authorize(Roles = ApplicationRole.Admin)]
        [Route("GetAll")]
        public ICollection<Sale> GetAllSales()
        {
            return CsvDataRepository.GetSales();
        }
    }
}
