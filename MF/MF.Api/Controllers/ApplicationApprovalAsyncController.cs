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
    public class ApplicationApprovalAsyncController : ControllerBase
    {
        private readonly ApplicationApprovalServiceAsync<ApplicationApprovalViewModel, ApplicationApproval> _applicationApprovalServiceAsync;
        public ApplicationApprovalAsyncController(ApplicationApprovalServiceAsync<ApplicationApprovalViewModel, ApplicationApproval> applicationApprovalServiceAsync)
        {
            _applicationApprovalServiceAsync = applicationApprovalServiceAsync;
        }


        //get all
        [Authorize]
        [HttpGet]
        [EnableQuery()]
        public async Task<IEnumerable<ApplicationApprovalViewModel>> GetAll()
        {
            var items = await _applicationApprovalServiceAsync.GetAll();
            return items;
        }

        //get by predicate example
        //get all active by applicationApprovalname
        //[Authorize]
        //[HttpGet("GetActiveByFirstName/{firstname}")]
        //public async Task<IActionResult> GetActiveByFirstName(string firstname)
        //{
        //    var items = await _applicationApprovalServiceAsync.Get(a =>  a.Name == firstname);
        //    return Ok(items);
        //}

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _applicationApprovalServiceAsync.GetOne(id);
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
        public async Task<IActionResult> Create([FromBody] ApplicationApprovalViewModel applicationApproval)
        {
            if (applicationApproval == null)
                return BadRequest();

            var id = await _applicationApprovalServiceAsync.Add(applicationApproval);
            return Created($"api/ApplicationApproval/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ApplicationApprovalViewModel applicationApproval)
        {
            if (applicationApproval == null || applicationApproval.Id != id)
                return BadRequest();

            int retVal = await _applicationApprovalServiceAsync.Update(applicationApproval);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(applicationApproval);
        }

        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int retVal = await _applicationApprovalServiceAsync.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}


