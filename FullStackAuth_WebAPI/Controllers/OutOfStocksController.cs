using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutOfStocksController : ControllerBase
    {


        private readonly ApplicationDbContext _context;

        public OutOfStocksController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<OutOfStocksController>
        [HttpGet]
        public IActionResult GetAllOutOfStocks()
        {
            try
            {
                //Includes entire Owner object--insecure!
                //var cars = _context.Cars.Include(c => c.Owner).ToList();


                var outOfStocks = _context.OutOfStocks.ToList();

                // Return the list of cars as a 200 OK response
                return StatusCode(200, outOfStocks);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<OutOfStocksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OutOfStocksController>
        [HttpPost, Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] OutOfStocks data)
        {
            try
            {
                // Retrieve the authenticated user's ID from the JWT token
                string userId = User.FindFirstValue("id");


                // If the user ID is null or empty, the user is not authenticated, so return a 401 unauthorized response
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }


                // Set the car's owner ID  the authenticated user's ID we found earlier
                data.DepartmentName = data.DepartmentName;

                // Add the car to the database and save changes
                _context.OutOfStocks.Add(data);
                if (!ModelState.IsValid)
                {
                    // If the car model state is invalid, return a 400 bad request response with the model state errors
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();

                // Return the newly created car as a 201 created response
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<OutOfStocksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OutOfStocksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
