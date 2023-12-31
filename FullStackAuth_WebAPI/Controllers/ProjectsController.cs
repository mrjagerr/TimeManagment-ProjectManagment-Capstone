﻿using FullStackAuth_WebAPI.Data;
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

                // Return the list of projects as a 200 OK response
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
       
        public IActionResult GetCurrentDaysProject(string dateTime)
        {
            try
            {
                // Retrieve the authenticated user's ID from the JWT token



                // Retrieves all projects and those assigned to that project
                var currentProjects = _context.Projects.Where(c => c.ProjectDate == dateTime).Select(d => new ProjectWithAllShiftsDto
                {
                    Id = d.Id,
                    ProjectDate = d.ProjectDate,
                    WorkLoadCompleted =d.WorkloadCompleted,
                   ShiftForDisplays = _context.Shifts.Where(c => c.ShiftDate.Equals(dateTime)).Select(c => new ShiftForDisplayDto
                    {
                        DepartmentName = c.DepartmentName,
                        ShiftDate = c.ShiftDate,
                        OutOfStock = c.OutOfStock,
                        PriorityFill = c.PriorityFill,
                        ShiftDuration = c.ShiftDuration,
                        TeamMemberFirstName = c.TeamMemberFirstName,
                        WorkLoadValue = c.WorkLoadValue,
                        Id = c.Id,
                        Zone = c.Zone,
                    }).ToList(),
                    WorkLoadAllocation = d.WorkLoadAllocation,
                    TotalWorkloadRequired = d.TotalWorkloadRequired,
                    ProjectName = d.ProjectName,
                    PercentCompleted = d.PercentCompleted,
                   




                }) ;

                //returns current projects
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
               

                // Set the projects's owner ID  the authenticated user's ID we found earlier
                data.OwnerId = userId;
                data.ProjectDate = data.ProjectDate;
                

                // Add the car to the database and save changes
                _context.Projects.Add(data);
                if (!ModelState.IsValid)
                {
                    // If the car model state is invalid, return a 400 bad request response with the model state errors
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();

                // Return the newly created project as a 201 created response
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("edit/{id}"), Authorize(Roles = "Admin")]
        public IActionResult PutWorkLoad(int id, [FromBody] Project data)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                // Find the project to be updated
                Project project = _context.Projects.FirstOrDefault(c => c.Id == id);

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

                // Update the project properties
              
              
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
        [HttpPatch("{id}")]
        public IActionResult Put(int id, [FromBody] Project data)
        {
            try
            {
                // Find the car to be updated
               Project  project = _context.Projects.FirstOrDefault(c => c.Id == id);

                if (project == null)
                {
                    // Return a 404 Not Found error if the car with the specified ID does not exist
                    return NotFound();
                }

              

                 project.WorkloadCompleted += data.WorkloadCompleted;
                
                double workload = project.WorkloadCompleted;
                double totalWorkload = project.TotalWorkloadRequired;
                double  percent = workload / totalWorkload * 100;
                percent = Math.Round(percent);
                project.PercentCompleted = percent;
          


                




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
