﻿using Microsoft.AspNetCore.Mvc;
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
    public class LoanController : ControllerBase
    {
        private readonly LoanService<LoanViewModel, Loan > _loanService;
        public LoanController(LoanService<LoanViewModel, Loan> loanService)
        {
            _loanService = loanService;
        }

        public Expression<Func<Loan, bool>> predicate;
        //get all
        [Authorize]
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<LoanViewModel> GetAll(ODataQueryOptions<Loan> _odata)
        {
            if (_odata.Filter != null)
            {
                predicate = ODataQueryOptionsExtensions.GetFilter(_odata);
            }
            if (predicate == null)
            {
                predicate = x => x.Id == x.Id;
            }
            var test = _loanService.DoNothing();
            var items = _loanService.GetAll(predicate);
            return items;
        }

        //get by predicate example
        //get all active by Loanname
        [Authorize]
        [HttpGet("GetActiveByFirstName/{firstname}")]
        public IActionResult GetActiveByFirstName(string firstname)
        {
            var items = _loanService.Get(a =>  a.AgreementNumber == firstname);
            return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _loanService.GetOne(id);
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
        public IActionResult Create([FromBody] LoanViewModel Loan)
        {
            if (Loan == null)
                return BadRequest();

            var id = _loanService.Add(Loan);
            return Created($"api/Loan/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LoanViewModel Loan)
        {
            if (Loan == null || Loan.Id != id)
                return BadRequest();

            int retVal = _loanService.Update(Loan);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(Loan);
        }

        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int retVal = _loanService.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}


