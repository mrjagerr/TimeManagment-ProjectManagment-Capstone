using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase




    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProjectsController>
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                //Includes entire Owner object--insecure!
                //var cars = _context.Cars.Include(c => c.Owner).ToList();


                var projects = _context.Projects.ToList();

                // Return the list of cars as a 200 OK response
                return Ok( projects);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ProjectsController>/5
        [HttpGet("CurrentDaysProjects/{dateTime}")]
       
        public IActionResult GetUsersCars(DateTime dateTime)
        {
            try
            {
                // Retrieve the authenticated user's ID from the JWT token



                // Retrieve all cars that belong to the authenticated user, including the owner object
                var currentProjects = _context.Projects.Where(c => c.ProjectDate.Equals(dateTime)).Select(d => new ProjectWithAllShiftsDto
                {
                    Id = d.Id,
                    ProjectDate = d.ProjectDate,
                    Shift = _context.Shifts.Select(d => new ShiftWithAllDailyProjectsDto
                    {
                        TeamMemberFirstName = d.TeamMemberFirstName,
                        ShiftDuration = d.ShiftDuration,
                        DailyProject = _context.DailyProjects.Select(d => new DailyProjectWithZoneOOSPrioDto
                        {
                            Id = d.Id,
                            ProjectDate = d.ProjectDate,
                            DepartmentName = d.DepartmentName,
                            Zones = _context.Zones.Select(c => new ZoneDto
                            {
                                AreaToZone = c.AreaToZone,
                                DepartmentName = c.DepartmentName,
                                WorkloadValue = c.WorkloadValue,
                                ProjectDate = c.ProjectDate,

                            }).ToList(),
                            PriorityFill = _context.PriorityFills.Select(c => new PriorityFillDto
                            {
                                PriorityRemaining = c.PriorityRemaining,
                                DepartmentName = c.DepartmentName,
                                ProjectDate = c.ProjectDate,
                                TotalPriorityFill = c.TotalPriorityFill,
                                WorkLoadValue = c.WorkLoadValue

                            }).ToList(),
                            outOfStocks = _context.OutOfStocks.Select(c => new OutOfStockDto
                            {
                                TotalOosFill = c.TotalOosFill,
                                TotalOosRemaining = c.OosRemaining,
                                DepartmentName = c.DepartmentName,
                                ProjectDate = c.ProjectDate,

                                WorkLoadValue = c.WorkLoadValue

                            }).ToList(),
                        }).ToList(),

                    }).ToList(),

                    
                  
                    ProjectName = d.ProjectName,
                    TotalWorkloadRequired = d.TotalWorkloadRequired,
                    WorkLoadAllocation = d.WorkLoadAllocation,  

                });

                // Return the list of cars as a 200 OK response
                return StatusCode(200, currentProjects);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ProjectsController>
        [HttpPost, Authorize(Roles= "Admin")]
        public IActionResult Post([FromBody] Project data)
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
                _context.Projects.Add(data);
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

        // PUT api/<ProjectsController>/5
        [HttpPut("{projectName}"), Authorize(Roles = "Admin")]
        public IActionResult Put(string projectName, [FromBody] Project data)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                // Find the car to be updated
                Project project  = _context.Projects.FirstOrDefault(c => c.ProjectName == projectName);

                if (project == null)
                {
                    // Return a 404 Not Found error if the car with the specified ID does not exist
                    return NotFound();
                }

                // Check if the authenticated user is the owner of the car
                
                if (string.IsNullOrEmpty(userId) || project.OwnerId != userId)
                {
                    // Return a 401 Unauthorized error if the authenticated user is not the owner of the car
                    return Unauthorized();
                }

                // Update the car properties
              
              
                project.WorkLoadAllocation = data.WorkLoadAllocation;
                project.TotalWorkloadRequired = data.TotalWorkloadRequired;
              

                if (!ModelState.IsValid)
                {
                    // Return a 400 Bad Request error if the request data is invalid
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();

                // Return a 201 Created status code and the updated car object
                return StatusCode(201, project);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error with the error message if an exception occurs
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
