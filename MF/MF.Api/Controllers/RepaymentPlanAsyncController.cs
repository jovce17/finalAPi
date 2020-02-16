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
using Microsoft.AspNet.OData.Query;
using System.Linq.Expressions;
using System;

namespace MF.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RepaymentPlanAsyncController : ControllerBase
    {
        private readonly RepaymentPlanServiceAsync<RepaymentPlanViewModel, RepaymentPlan> _repaymentPlanServiceAsync;
        public RepaymentPlanAsyncController(RepaymentPlanServiceAsync<RepaymentPlanViewModel, RepaymentPlan> repaymentPlanServiceAsync)
        {
            _repaymentPlanServiceAsync = repaymentPlanServiceAsync;
        }


        public Expression<Func<RepaymentPlan, bool>> predicate;
        //get all
        [Authorize]
        [HttpGet]
        [EnableQuery()]
        public async Task<IEnumerable<RepaymentPlanViewModel>> GetAll(ODataQueryOptions<RepaymentPlan> _odata)
        {
            if (_odata.Filter != null)
            {
                predicate = ODataQueryOptionsExtensions.GetFilter(_odata);
            }
            if (predicate == null)
            {
                predicate = x => x.Id == x.Id;
            }
            var items = await _repaymentPlanServiceAsync.GetAll(predicate);
            return items;
        }

        //get by predicate example
        //get all active by repaymentPlanname
        //[Authorize]
        //[HttpGet("GetActiveByFirstName/{firstname}")]
        //public async Task<IActionResult> GetActiveByFirstName(string firstname)
        //{
        //    var items = await _repaymentPlanServiceAsync.Get(a =>  a.Name == firstname);
        //    return Ok(items);
        //}

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _repaymentPlanServiceAsync.GetOne(id);
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
        public async Task<IActionResult> Create([FromBody] RepaymentPlanViewModel repaymentPlan)
        {
            if (repaymentPlan == null)
                return BadRequest();

            var id = await _repaymentPlanServiceAsync.Add(repaymentPlan);
            return Created($"api/RepaymentPlan/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RepaymentPlanViewModel repaymentPlan)
        {
            if (repaymentPlan == null || repaymentPlan.Id != id)
                return BadRequest();

            int retVal = await _repaymentPlanServiceAsync.Update(repaymentPlan);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(repaymentPlan);
        }

        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int retVal = await _repaymentPlanServiceAsync.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}


