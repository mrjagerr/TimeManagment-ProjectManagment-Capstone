﻿using FullStackAuth_WebAPI.Data;
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
                var tasks = _context.Tasks.Select(c => new TaskWithUserDto
                {
                    Id = c.Id,
                    Goal = c.Goal,
                    GoalAssignedTo = c.GoalAssignedTo,
                    TeamMember = _context.Users.Where(c => c.Id == userId).Select(c => new UserForDisplayDto
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        UserName = c.UserName,
                    }).ToList(),
                    

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
        public void Delete(int id)
        {
        }
    }
}
