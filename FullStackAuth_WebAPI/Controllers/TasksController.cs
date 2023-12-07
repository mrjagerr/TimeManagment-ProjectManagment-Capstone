using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<TasksController>
        [HttpGet, Authorize]
        public IActionResult GetAllCars()
        {
            try
            {
                string userId = User.FindFirstValue("id");

                //Retrieve all cars from the database, using Dtos
                var tasks = _context.Tasks.Select(t => new TaskWithUserDto
                {
                    Id = t.Id,
                    Goal = t.Goal,
                    GoalAssignedTo = t.GoalAssignedTo,
                    Poster = new UserForDisplayDto
                    {
                        Id = t.OwnerId,
                        FirstName = t.Owner.FirstName,
                        LastName = t.Owner.LastName,

                    }


                }).ToList();


                // Return the list of cars as a 200 OK response
                return StatusCode(200, tasks);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }

        }


        // POST api/<TasksController>
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] TaskList data)
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
                data.OwnerId = userId;


                // Add the car to the database and save changes
                _context.Tasks.Add(data);
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("Please fill out all info");
                    // If the car model state is invalid, return a 400 bad request response with the model state errors
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();

                // Return the newly created car as a 201 created response
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please fill out all info");
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }
        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Find the car to be deleted
                TaskList task = _context.Tasks.FirstOrDefault(c => c.Id == id);
                if (task == null)
                {
                    // Return a 404 Not Found error if the car with the specified ID does not exist
                    return NotFound();
                }

                // Check if the authenticated user is the owner of the car


                // Remove the car from the database
                _context.Tasks.Remove(task);
                _context.SaveChanges();

                // Return a 204 No Content status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error with the error message if an exception occurs
                return StatusCode(500, ex.Message);
            }
        }
    }
}
