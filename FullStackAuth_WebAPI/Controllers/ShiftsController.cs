﻿using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShiftsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ShiftsController>
        [HttpGet]
        public IActionResult GetAllShifts()
        {
            try
            {
                


                var shifts = _context.Shifts.ToList();
                // Return the list of shifts as a 200 OK response
                return StatusCode(200, shifts);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("myShifts/{firstName}"),]
        public IActionResult GetAllShifts( string firstName)
        {
            try
            {
                
                var users = _context.Users.Where(c => c.FirstName == firstName).Select(c => new UserForDisplayDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    UserName = c.UserName,
                }).ToList();

                var myShifts = _context.Shifts.Where(c => c.TeamMemberFirstName == firstName).Select(c => new ShiftWithUserFirstNameDto
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
                    TeamMember = _context.Users.Where(c => c.FirstName == firstName).Select(c => new UserForDisplayDto
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        UserName = c.UserName,
                    }).ToList()

            }).ToList();


                // Return the list of shifts as a 200 OK response
                return StatusCode(200, myShifts);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ShiftsController>/5
        [HttpGet("{dateTime}")]
        public IActionResult GetbyTeamMember(string dateTime)
        {
            try
            {
                // Retrieve the shift with the specified date, including the owner object
               
                var shiftsDate = _context.Shifts.Where(c => c.ShiftDate== dateTime).ToList();

                // If the car does not exist, return a 404 not found response
               
                if(shiftsDate == null)
                {
                    return NotFound();
                }
                 return StatusCode(200, shiftsDate);
                
               


            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                
                return StatusCode(500, ex.Message);
            }
        }
        // GET api/<ShiftsController>/5
       

        // POST api/<ShiftsController>
        [HttpPost, Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] Shift data)
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
               
               

                // Add the shift to the database and save changes
                _context.Shifts.Add(data);
                if (!ModelState.IsValid)
                {Console.WriteLine("Please fill out all info");
                    // If the shift model state is invalid, return a 400 bad request response with the model state errors
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();

                // Return the newly created shift as a 201 created response
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {Console.WriteLine("Please fill out all info");
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ShiftsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShiftsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
