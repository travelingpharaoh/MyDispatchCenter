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
    public class CaseController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;

        private const string GetOrderByIdActionName = "GetUserById";
        public CaseController(IUnitOfWork unitOfWork, ILogger<CustomerController> logger, IEmailer emailer)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult Get()
        {
            var allCases = _unitOfWork.Cases.GetAll();
            return Ok(Mapper.Map<IEnumerable<CaseViewModel>>(allCases));
        }

    }
}
