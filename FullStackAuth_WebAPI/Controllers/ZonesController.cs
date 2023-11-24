﻿using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {


        private readonly ApplicationDbContext _context;

        public ZonesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ZonesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ZonesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ZonesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ZonesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ZonesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
