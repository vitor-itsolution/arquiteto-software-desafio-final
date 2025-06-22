using Empresa1.Api.Models;
using Empresa1.Api.Repositories;
using Empresa1.Api.Services;
using Empresa1.Api.ViewModels;
using Empresa1.Api.ViewModels.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresa1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: (typeof(IEnumerable<CustomerViewModel>)))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var customers = customerService.GetAll();
            return !customers.Any() ? NotFound() : Ok(customers);
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: (typeof(CustomerViewModel)))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await customerService.GetCustomerByIdAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: (typeof(CustomerViewModel)))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("/name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customers = await customerService.GetCustomerByName(name);
            return !customers.Any() ? NotFound() : Ok(customers);
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: (typeof(CustomerTotalViewModel)))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("/count")]
        public async Task<IActionResult> GetCount()
        {
            return Ok(await customerService.CountAsync());
        }

        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerCreateViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCustomer = await customerService.CreateAsync(customer);
            return CreatedAtAction(
                nameof(GetById),
                new { id = createdCustomer?.Id },
                createdCustomer
            );
        }

        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CustomerUpdateViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await customerService.UpdateAsync(customer, id);

            return NoContent();
        }

        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deletedCustomer = await customerService.DeleteAsync(id);
            return deletedCustomer == null ? NotFound() : NoContent();
        }
    }
}