using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Description;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Get / api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers
                .Include(x => x.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
        }

        //Get /api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //Post /api/customers
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageCustomers)]
        [Authorize(Roles = RoleName.CanManageAll)]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //Put /api/customers/1
        [HttpPut]
        [ResponseType(typeof(void))]
        [Authorize(Roles = RoleName.CanManageCustomers)]
        [Authorize(Roles = RoleName.CanManageAll)]
        public IHttpActionResult UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.Accepted);
        }

        //DELETE /api/customers/1
        [HttpDelete]
        [ResponseType(typeof(void))]
        [Authorize(Roles = RoleName.CanManageCustomers)]
        [Authorize(Roles = RoleName.CanManageAll)]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.Accepted);
        }
    }
}
