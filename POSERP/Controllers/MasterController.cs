using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSERPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ApiControllerBase
    {
       

        public  MasterController(IMediator mediator):base(mediator)
        {
            
        }
        /// <summary>
        /// Get customer type 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCustomerType()
        {
            var a = 0;
            var dd = 1 / a;
            return Ok();// Single(null);
        }
      

    }
}
