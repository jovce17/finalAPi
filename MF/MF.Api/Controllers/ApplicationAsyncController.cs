using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using MF.Domain;
using MF.Entity.Context;
using MF.Domain.Service;
using Microsoft.Extensions.Logging;
using Serilog;
using MF.Entity;
using System.Threading.Tasks;

namespace MF.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApplicationAsyncController : ControllerBase
    {
        private readonly ApplicationServiceAsync<ApplicationViewModel, Application> _applicationServiceAsync;
        public ApplicationAsyncController(ApplicationServiceAsync<ApplicationViewModel, Application> applicationServiceAsync)
        {
            _applicationServiceAsync = applicationServiceAsync;
        }


        //get all
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<ApplicationViewModel>> GetAll()
        {
            var items = await _applicationServiceAsync.GetAll();
            return items;
        }

        //get by predicate example
        //get all active by applicationname
        [Authorize]
        [HttpGet("GetActiveByFirstName/{firstname}")]
        public async Task<IActionResult> GetActiveByFirstName(string firstname)
        {
            var items = await _applicationServiceAsync.Get(a =>  a.ApplicationNumber == firstname);
            return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _applicationServiceAsync.GetOne(id);
            if (item == null)
            {
                Log.Error("GetById({ ID}) NOT FOUND", id);
                return NotFound();
            }

            return Ok(item);
        }

        //add
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationViewModel application)
        {
            if (application == null)
                return BadRequest();

            var id = await _applicationServiceAsync.Add(application);
            return Created($"api/Application/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ApplicationViewModel application)
        {
            if (application == null || application.Id != id)
                return BadRequest();

            int retVal = await _applicationServiceAsync.Update(application);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(application);
        }

        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int retVal = await _applicationServiceAsync.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}


