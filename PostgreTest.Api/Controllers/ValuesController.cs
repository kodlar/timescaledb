using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using PostgreTest.Api.Models;

namespace PostgreTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get(string resolution = "60m", long from = 1530409975, long to = 1533196119, string symbol = "BTCTRY")
        {
            using (var t = new NpgsqlConnection("Host=localhost;Database=tutorial;Username=postgres;Password=1"))
            {
                t.Open();
                TradeViewResultModel model = new TradeViewResultModel();
                model.c = new List<decimal>();
                model.h = new List<decimal>();
                model.l = new List<decimal>();
                model.o = new List<decimal>();
                model.s = "ok";
                model.t = new List<long>();
                model.v = new List<decimal>();


                using (var c = new NpgsqlCommand())
                {
                    c.Connection = t;
                    c.CommandText = "select * from fx_tradeview_data('" + resolution + "', " + from + ", " + to + ",'" + symbol + "');";
                    using (var reader = c.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new
                            {
                                CreatedDate = reader.GetInt64(0),
                                Open = reader.GetDecimal(1),
                                High = reader.GetDecimal(2),
                                Low = reader.GetDecimal(3),
                                Close = reader.GetDecimal(4),
                                Volume = reader.GetDecimal(5)
                            };
                            model.c.Add(result.Close);
                            model.h.Add(result.High);
                            model.l.Add(result.Low);
                            model.o.Add(result.Open);
                            model.t.Add(result.CreatedDate);
                            model.v.Add(result.Volume);
                        }
                    }

                    return Ok(model);
                }
            }




        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
