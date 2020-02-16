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

namespace MF.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly OfficeService<OfficeViewModel, Office> _officeService;
        public OfficeController(OfficeService<OfficeViewModel, Office> officeService)
        {
            _officeService = officeService;
        }

        //get all
        [Authorize]
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<OfficeViewModel> GetAll(ODataQueryOptions<Office> _odata)
        {
            var predicate = ODataQueryOptionsExtensions.GetFilter(_odata);
            if (predicate == null)
            {
                predicate = x => x.Id == x.Id;
            }
            var test = _officeService.DoNothing();
            var items = _officeService.GetAll(predicate);
            return items;
        }

        //get by predicate example
        //get all active by officename
        [Authorize]
        [HttpGet("GetActiveByFirstName/{firstname}")]
        public IActionResult GetActiveByFirstName(string firstname)
        {
            var items = _officeService.Get(a =>  a.Name == firstname);
            return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _officeService.GetOne(id);
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
        public IActionResult Create([FromBody] OfficeViewModel office)
        {
            if (office == null)
                return BadRequest();

            var id = _officeService.Add(office);
            return Created($"api/Office/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OfficeViewModel office)
        {
            if (office == null || office.Id != id)
                return BadRequest();

            int retVal = _officeService.Update(office);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(office);
        }

        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int retVal = _officeService.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}


