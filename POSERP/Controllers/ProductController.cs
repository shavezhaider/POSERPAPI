using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSERPAPI.Entities.Request;
using POSERPAPI.Manager.Command;
using POSERPAPI.Manager.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSERPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        public ProductController(IMediator mediator) : base(mediator)
        {


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRequest"></param>
        /// <returns></returns>
        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest productRequest)
        {
            var Query = new CreateProductCommand(productRequest);
            var result = await CommandAsync(Query);
            return Single(result);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetProductList")]
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var Query = new ProductListQuery();
            var result = await QueryAsync(Query);
            return GetItems(result);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [Route("GetProductByProductId/{productId}")]
        [HttpGet]
        public async Task<IActionResult> GetProductByProductId(int productId)
        {
            if (productId == default)
                return BadRequest();
            var Query = new ProductByProductIdQuery(productId);
            var result = await QueryAsync(Query);
            
            return Single(result);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        [Route("DeleteProductByProductId/{productId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductByProductId(int productId)
        {
            //var Query = new CreateProductCommand(productRequest);
            //var result = await CommandAsync(Query);
            //return Single(result);
            return Ok();

        }


    }
}