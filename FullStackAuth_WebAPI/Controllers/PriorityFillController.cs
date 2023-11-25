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
    public class PriorityFillController : ControllerBase
    {


        private readonly ApplicationDbContext _context;

        public PriorityFillController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<PriorityFillController>
        [HttpGet]
        public IActionResult GetAllPriorityFill()
        {
            try
            {
                //Includes entire Owner object--insecure!
                //var cars = _context.Cars.Include(c => c.Owner).ToList();


                var priorityFills = _context.PriorityFills.ToList();

                // Return the list of cars as a 200 OK response
                return StatusCode(200, priorityFills);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PriorityFillController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PriorityFillController>
        [HttpPost, Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] PriorityFill data)
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
                _context.PriorityFills.Add(data);
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

        // PUT api/<PriorityFillController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PriorityFillController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
