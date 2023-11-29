using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyProjectsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public DailyProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<DailyProjectsController>
        [HttpGet]
        public IActionResult GetAllDailyProjects()
        {
            try
            {
                


                var dailyProjects = _context.DailyProjects.ToList();

                
                return Ok(dailyProjects);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<DailyProjectsController>/5
        [HttpGet("CurrentDaysProjects/{dateTime}/{department}/{firstName}")]

        public IActionResult GetbyDepartmentDate(DateTime dateTime,string department, string firstName)
        {
            try
            {
                // Retrieve the authenticated user's ID from the JWT token



                //retrieves the project linked to the date

               
                

                var todaysProject = _context.DailyProjects.Where(c => c.ProjectDate == dateTime && c.DepartmentName == department).Select(d => new DailyProjectWithZoneOOSPrioDto
                {
                    Id = d.Id,
                    ProjectDate = d.ProjectDate,
                    DepartmentName = d.DepartmentName,
                    Zones = _context.Zones.Where(c => c.ProjectDate == dateTime && c.DepartmentName == department).Select(c => new ZoneDto
                    {
                        AreaToZone = c.AreaToZone,
                        DepartmentName = c.DepartmentName,
                        WorkloadValue = c.WorkloadValue,
                        ProjectDate = c.ProjectDate,

                    }).ToList(),
                    PriorityFill = _context.PriorityFills.Where(c => c.ProjectDate == dateTime && c.DepartmentName == department).Select( c=> new PriorityFillDto
                    {
                       PriorityRemaining = c.PriorityRemaining,
                       DepartmentName = c.DepartmentName,
                       ProjectDate= c.ProjectDate,
                       TotalPriorityFill = c.TotalPriorityFill,
                       WorkLoadValue =c.WorkLoadValue

                    }) . ToList(), 
                    outOfStocks = _context.OutOfStocks.Where(c => c.ProjectDate == dateTime && c.DepartmentName == department).Select( c=> new OutOfStockDto
                    {
                       TotalOosFill = c.TotalOosFill,
                       TotalOosRemaining =c.OosRemaining, 
                        DepartmentName = c.DepartmentName,
                        ProjectDate = c.ProjectDate,
                  
                        WorkLoadValue = c.WorkLoadValue

                    }).ToList(),
                   TeamMember = _context.Users.Where(c => c.FirstName ==firstName).Select(c => new UserForDisplayDto
                   {
                       FirstName = c.FirstName,
                       LastName = c.LastName,
                       isTeamLead =c.isTeamLead
                   }).ToList()


                }); 
                if (todaysProject == null)
                {
                    return NotFound();
                }

            
              
             

                // Return the list of cars as a 200 OK response
                return StatusCode(200, todaysProject);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<DailyProjectsController>
        [HttpPost, Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] DailyProject data)
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
                data.ProjectDate = data.ProjectDate;
               

                // Add the car to the database and save changes
                _context.DailyProjects.Add(data);
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

        // PUT api/<DailyProjectsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DailyProjectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
