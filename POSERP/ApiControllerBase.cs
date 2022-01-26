using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSERPAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _imediator;

        public ApiControllerBase(IMediator mediator)
        {
            _imediator = mediator;

        }
        protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await _imediator.Send(query);
        }

        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            return await _imediator.Send(command);
        }

        protected IActionResult Single<T>(T result)
        {
            return IsNull(result) ? NoContent() as IActionResult : Ok(result);
        }

        protected IActionResult GetItems<T>(IEnumerable<T> results)
        {
            return IsNullOrEmptyList(results) ? NoContent() as IActionResult : Ok(results);
        }
        protected static bool IsNull<T>(T value)
        {
            return value == null || value.Equals(default(T));
        }

        protected static bool IsNullOrEmptyList<T>(IEnumerable<T> items)
        {
            return items == null || !items.Any();
        }
        protected static bool IsEmptyOrNull(string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;
            else
                return false;            
        }
        protected static bool IsNullOrEmpty<T>(IEnumerable<T> item)
        {
            return item == null || !item.Any();
        }
    }
    

}
