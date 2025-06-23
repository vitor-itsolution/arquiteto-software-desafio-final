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
            var operationResult = customerService.GetAll();
            return StatusCode(operationResult.StatusCode, operationResult.Data);
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: (typeof(CustomerViewModel)))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var operationResult = await customerService.GetCustomerByIdAsync(id);
            
            return StatusCode(operationResult.StatusCode, operationResult.Data);
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: (typeof(CustomerViewModel)))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("/name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var operationResult = await customerService.GetCustomerByName(name);
            return StatusCode(operationResult.StatusCode, operationResult.Data);
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: (typeof(CustomerTotalViewModel)))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("/count")]
        public async Task<IActionResult> GetCount()
        {
            var operationResult = await customerService.CountAsync();
            return StatusCode(operationResult.StatusCode, operationResult.Data);
        }

        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerCreateViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var operationResult = await customerService.CreateAsync(customer);
            
            if (!operationResult.Success)
                return StatusCode(operationResult.StatusCode, operationResult);
            
            return CreatedAtAction(
                nameof(GetById),
                new { id = operationResult?.Data?.Id },
                operationResult?.Data
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

            var operationResult = await customerService.UpdateAsync(customer, id);
            
            if (!operationResult.Success)
                return StatusCode(operationResult.StatusCode, operationResult);

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

            var operationResult = await customerService.DeleteAsync(id);
            
            if (!operationResult.Success)
                return StatusCode(operationResult.StatusCode, operationResult);
            
            return NoContent();
        }
    }
}