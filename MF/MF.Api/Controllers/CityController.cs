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
using System;
using System.Linq.Expressions;

namespace MF.Api.Controllers
{
    
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService<CityViewModel, City > _cityService;
        public CityController(CityService<CityViewModel, City> cityService)
        {
            _cityService = cityService;
        }

        public Expression<Func<City, bool>> predicate;
        //get all
        [Authorize]
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<CityViewModel> GetAll(ODataQueryOptions<City> _odata)
        {
            if (_odata.Filter != null)
            {
                predicate = ODataQueryOptionsExtensions.GetFilter(_odata);
            }
            if (predicate == null)
            {
                predicate = x => x.Id == x.Id;
            }
            var items = _cityService.GetAll(predicate);
            return items;
        }

        //get by predicate example
        //get all active by Cityname
        [Authorize]
        [HttpGet("GetActiveByFirstName/{firstname}")]
        public IActionResult GetActiveByFirstName(string firstname)
        {
            var items = _cityService.Get(a =>  a.Name == firstname);
            return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _cityService.GetOne(id);
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
        public IActionResult Create([FromBody] CityViewModel City)
        {
            if (City == null)
                return BadRequest();

            var id = _cityService.Add(City);
            return Created($"api/City/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CityViewModel City)
        {
            if (City == null || City.Id != id)
                return BadRequest();

            int retVal = _cityService.Update(City);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(City);
        }

        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int retVal = _cityService.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}


