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
using Microsoft.AspNet.OData;

namespace MF.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ContactAsyncController : ControllerBase
    {
        private readonly ContactServiceAsync<ContactViewModel, Contact> _contactServiceAsync;
        public ContactAsyncController(ContactServiceAsync<ContactViewModel, Contact> contactServiceAsync)
        {
            _contactServiceAsync = contactServiceAsync;
        }


        //get all
        [Authorize]
        [HttpGet]
        [EnableQuery()]
        public async Task<IEnumerable<ContactViewModel>> GetAll()
        {
            var items = await _contactServiceAsync.GetAll();
            return items;
        }

        //get by predicate example
        //get all active by contactname
        [Authorize]
        [HttpGet("GetActiveByFirstName/{firstname}")]
        public async Task<IActionResult> GetActiveByFirstName(string firstname)
        {
            var items = await _contactServiceAsync.Get(a =>  a.Name == firstname);
            return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _contactServiceAsync.GetOne(id);
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
        public async Task<IActionResult> Create([FromBody] ContactViewModel contact)
        {
            if (contact == null)
                return BadRequest();

            var id = await _contactServiceAsync.Add(contact);
            return Created($"api/Contact/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactViewModel contact)
        {
            if (contact == null || contact.Id != id)
                return BadRequest();

            int retVal = await _contactServiceAsync.Update(contact);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(contact);
        }

        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int retVal = await _contactServiceAsync.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}


