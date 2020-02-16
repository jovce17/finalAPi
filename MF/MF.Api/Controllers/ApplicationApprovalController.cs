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
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using System.Linq.Expressions;
using System;

namespace MF.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApplicationApprovalController : ControllerBase
    {
        private readonly ApplicationApprovalService<ApplicationApprovalViewModel, ApplicationApproval > _applicationApprovalService;
        public ApplicationApprovalController(ApplicationApprovalService<ApplicationApprovalViewModel, ApplicationApproval> applicationApprovalService)
        {
            _applicationApprovalService = applicationApprovalService;
        }

        public Expression<Func<ApplicationApproval, bool>> predicate;
        //get all
        [Authorize]
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<ApplicationApprovalViewModel> GetAll(ODataQueryOptions<ApplicationApproval> _odata)
        {
            if (_odata.Filter != null)
            {
                predicate = ODataQueryOptionsExtensions.GetFilter(_odata);
            }
            if (predicate == null)
            {
                predicate = x => x.Id == x.Id;
            }
            var test = _applicationApprovalService.DoNothing();
            var items = _applicationApprovalService.GetAll(predicate);
            return items;
        }

        //get by predicate example
        //get all active by ApplicationApprovalname
        //[Authorize]
        //[HttpGet("GetActiveByFirstName/{firstname}")]
        //public IActionResult GetActiveByFirstName(string firstname)
        //{
        //    var items = _applicationApprovalService.Get(a =>  a.Name == firstname);
        //    return Ok(items);
        //}

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _applicationApprovalService.GetOne(id);
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
        public IActionResult Create([FromBody] ApplicationApprovalViewModel ApplicationApproval)
        {
            if (ApplicationApproval == null)
                return BadRequest();

            var id = _applicationApprovalService.Add(ApplicationApproval);
            return Created($"api/ApplicationApproval/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ApplicationApprovalViewModel ApplicationApproval)
        {
            if (ApplicationApproval == null || ApplicationApproval.Id != id)
                return BadRequest();

            int retVal = _applicationApprovalService.Update(ApplicationApproval);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(ApplicationApproval);
        }

        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int retVal = _applicationApprovalService.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}


