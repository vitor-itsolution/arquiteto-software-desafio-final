using Empresa1.Api.Models;
using Empresa1.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresa1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: (typeof(IEnumerable<Customer>)))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: (typeof(Customer)))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: (typeof(Customer)))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("/name/{name}")]
        public string GetByName(string name)
        {
            return "value";
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: (typeof(Customer)))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("/count")]
        public string GetCount()
        {
            return "value";
        }

        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpPost]
        public void Post([FromBody] CustomerCreateViewModel customerCreate)
        {
        }

        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody] CustomerUpdateViewModel customerCreate)
        {
        }

        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
        }
    }
}