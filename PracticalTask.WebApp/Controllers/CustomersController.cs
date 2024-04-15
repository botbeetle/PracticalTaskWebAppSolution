using Microsoft.AspNetCore.Mvc;
using PracticalTask.WebApp.Core.DataModels.Sheets;
using PracticalTask.WebApp.Core.DataRepositories.Contracts;
using PracticalTask.WebApp.Data.Models;
using PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;

namespace PracticalTask.WebApp.Controllers;


[Route("api/[controller]")]
[ApiController]
public sealed class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<CustomersController>? _logger;

    public CustomersController(ICustomerRepository customerRepository, ILogger<CustomersController>? logger = null)
    {
        ArgumentNullException.ThrowIfNull(customerRepository);

        _customerRepository = customerRepository;
        _logger = logger;
    }


    // GET: api/Customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDtoGet>>> GetCustomers()
    {
        try
        {
            var customers = await _customerRepository.GetAllAsync<CustomerDtoGet>();
            return Ok(customers);
        }
        catch (Exception exp)
        {
            _logger?.LogError(string.Empty, exp);
            return StatusCode(500);
        }
    }



    // GET: api/Customers/?StartIndex=0&SheetNumber=1&SheetSize=10
    [HttpGet("GetSheet")]
    public async Task<ActionResult<SheetResult<CustomerDtoGet>>> GetCustomersSheets([FromQuery] SheetQuery pageQuery)
    {
        try
        {
            var pagedHotelsResult = await _customerRepository.GetAllAsync<CustomerDtoGet>(pageQuery);
            return Ok(pagedHotelsResult);
        }
        catch (Exception exp)
        {
            _logger?.LogError($"SheetQuery -> {pageQuery}", exp);
            return StatusCode(500);
        }
    }



    // GET: api/Customers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDtoGet>> GetCustomer(int id)
    {
        if (id == 0)
        {
            return BadRequest($"Invalid request parameter: id = {id}");
        }

        try
        {
            var customer = await _customerRepository.GetAsync<CustomerDtoGet>(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        catch (Exception exp)
        {
            _logger?.LogError($"Id -> {id}", exp, exp);
            return StatusCode(500);
        }
    }


    // PUT: api/Customers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCustomer(int id, CustomerDtoUpdate customer)
    {
        if (id == 0)
        {
            return BadRequest($"Invalid request parameter: id = {id}");
        }

        if (id != customer.Id)
        {
            return BadRequest($"Invalid request parameter: {id} != {customer.Id}");
        }

        try
        {
            var result = await _customerRepository.UpdateAsync(id, customer);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
        catch (Exception exp)
        {
            _logger?.LogError($"Id -> {id}; customer -> {customer}", exp);
            return StatusCode(500);
        }
    }


    // POST: api/Customers
    [HttpPost]
    public async Task<ActionResult<Customer>> PostCustomer(CustomerDtoCreate customer)
    {
        try
        {
            var country = await _customerRepository.CreateAsync<CustomerDtoCreate, CustomerDtoGet>(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = country.Id }, country);
        }
        catch (Exception exp)
        {
            _logger?.LogError($"Customer -> {customer}", exp);
            return StatusCode(500);
        }
    }


    // DELETE: api/Customers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        if (id == 0)
        {
            return BadRequest($"Invalid request parameter: id = {id}");
        }

        try
        {
            var result = await _customerRepository.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
        catch (Exception exp)
        {
            _logger?.LogError($"Id -> {id};", exp);
            return StatusCode(500);
        }
    }
}