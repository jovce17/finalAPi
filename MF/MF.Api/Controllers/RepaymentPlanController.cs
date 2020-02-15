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

namespace MF.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RepaymentPlanController : ControllerBase
    {
        private readonly RepaymentPlanService<RepaymentPlanViewModel, RepaymentPlan > _repaymentPlanService;
        public RepaymentPlanController(RepaymentPlanService<RepaymentPlanViewModel, RepaymentPlan> repaymentPlanService)
        {
            _repaymentPlanService = repaymentPlanService;
        }

        //get all
        [Authorize]
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<RepaymentPlanViewModel> GetAll()
        {
            var test = _repaymentPlanService.DoNothing();
            var items = _repaymentPlanService.GetAll();
            return items;
        }

        //get by predicate example
        //get all active by RepaymentPlanname
        //[Authorize]
        //[HttpGet("GetActiveByFirstName/{firstname}")]
        //public IActionResult GetActiveByFirstName(string firstname)
        //{
        //    var items = _repaymentPlanService.Get(a =>  a.Name == firstname);
        //    return Ok(items);
        //}

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _repaymentPlanService.GetOne(id);
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
        public IActionResult Create([FromBody] RepaymentPlanViewModel RepaymentPlan)
        {
            if (RepaymentPlan == null)
                return BadRequest();

            var id = _repaymentPlanService.Add(RepaymentPlan);
            return Created($"api/RepaymentPlan/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RepaymentPlanViewModel RepaymentPlan)
        {
            if (RepaymentPlan == null || RepaymentPlan.Id != id)
                return BadRequest();

            int retVal = _repaymentPlanService.Update(RepaymentPlan);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(RepaymentPlan);
        }

        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int retVal = _repaymentPlanService.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}


