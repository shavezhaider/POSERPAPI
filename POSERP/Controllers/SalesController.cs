using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSERPAPI.Entities.Request;
using POSERPAPI.Manager.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace POSERPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ApiControllerBase
    {

        public SalesController(IMediator mediator) : base(mediator)
        {


        }
        
        [Route("AddSales")]
        [HttpPost]
        public async Task<IActionResult> AddSales([FromBody] SaleRequest productRequest)
        {
            var Query = new CreateSaleCommand(productRequest);
            var result = await CommandAsync(Query);
            return Single(result);
            

        }

        
        [Route("GetSalesList")]
        [HttpGet]
        public async Task<IActionResult> GetSalesList()
        {
            //var Query = new ProductListQuery();
            //var result = await QueryAsync(Query);
            //return Single(result);
            return Ok();

        }
        
        [Route("GetSalesBySalesId/{saleId}")]
        [HttpGet]
        public async Task<IActionResult> GetSalesBySalesId(int saleId)
        {
            //var Query = new ProductByProductIdQuery(productId);
            //var result = await QueryAsync(Query);
            //return Single(result);
            return Ok();

        }
        
    }
}
