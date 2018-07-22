using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using ppldispatchapp1.ViewModels;
using AutoMapper;
using DAL.Models;
using Microsoft.Extensions.Logging;
using ppldispatchapp1.Helpers;
using Microsoft.Extensions.Options;


namespace ppldispatchapp1.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;

        private const string GetOrderByIdActionName = "GetUserById";
        public OrderController(IUnitOfWork unitOfWork, ILogger<CustomerController> logger, IEmailer emailer)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult Get()
        {
            var allOrders = _unitOfWork.Orders.GetAll();
            return Ok(Mapper.Map<IEnumerable<OrderViewModel>>(allOrders));
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Order
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
