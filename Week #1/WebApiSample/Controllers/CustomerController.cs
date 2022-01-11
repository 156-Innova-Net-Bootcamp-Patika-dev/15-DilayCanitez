using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApiSample.DataAccessLayer.Context;
using WebApiSample.ModelOperations.AddCustomer;
using WebApiSample.ModelOperations.DeleteCustomer;
using WebApiSample.ModelOperations.GetCustomers;
using WebApiSample.ModelOperations.UpdateCustomer;
using WebApiSample.Models;

namespace WebApiSample.Controllers
{
    [ApiController] //HTTP Response döneceğini belirtmek için kullanılan attribute
    [Route("api/[controller]s")]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;
        //Inmemory Database is used for this project to generate sample data.
        //Database details(context and sample data) are located in the DataAccessLayer.dll
        //Mapper is used to map the object transformation.
        public CustomerController(CustomerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Gets all the customers from the database.
        //.../api/Customers
        [HttpGet]
        public IActionResult GetCustomers()
        {
            GetCustomersQuery query = new GetCustomersQuery(_context,_mapper);
            query.Handle();
            return Ok(query.ListVM);
        }
        //gets selected customer by id.
        //...//api/Customers/{id}
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                GetCustomersQuery query = new GetCustomersQuery(_context,_mapper);
                query.Handle(id);
                return Ok(query.Customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        //Used to add a new customer to the database.
        //.../api/Customers        
        [HttpPost]
        public IActionResult AddCustomer([FromBody] CreateCustomerModel model)
        {
            try
            {
                AddCustomerCommand command = new AddCustomerCommand(_context,_mapper);
                command.Model = model;
                AddCustomerCommandValidator validator = new AddCustomerCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Used to update a customer in accordance with id.
        //...//api/Customers/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, UpdateCustomerModel model)
        {
            try
            {
                UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
                command.CustomerId = id;
                command.Model = model;
                UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Deletes a customer from sample database.
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
                command.CustomerId = id;
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
