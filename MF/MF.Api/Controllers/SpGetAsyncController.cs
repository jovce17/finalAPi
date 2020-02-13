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
using MF.Domain.Service.SP;

namespace MF.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class testSPAsyncController : ControllerBase
    {

        private readonly testSP _sp;
        public testSPAsyncController(testSP sp)
        {
            _sp = sp;
        }


        //get all
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<string>> getall()
        {
            var items = await _sp.GetBlogSummaries();
            return items;

        }
        //add
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<int> Create(int id)
        {
            
            var xx = await _sp.DoStaff(id);
            return xx;  //HTTP201 Resource created
        }


    }
}


