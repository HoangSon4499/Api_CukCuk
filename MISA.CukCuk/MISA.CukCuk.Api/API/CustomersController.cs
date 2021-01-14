using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.API
{
    public class CustomersController : EntityController<Customer>
    {
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var res = _dbConnector.Insert<Customer>(customer);
            return Ok(res);
        }

        public override IActionResult Get()
        // override có thể ghi đè lên lớp cha
        {
            return base.Get();
        }
    }
}
