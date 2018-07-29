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
using DAL.Services;
using Microsoft.Extensions.Options;

namespace ppldispatchapp1.Controllers
{
    [Route("api/[controller]")]
    public class CaseController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        public CaseController(IUnitOfWork unitOfWork, ILogger<CustomerController> logger, IEmailer emailer)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Order
        [HttpGet("{bDate}")]
        public IActionResult Get(string bDate, [FromQuery] CaseSearchModel querySearch)
        {
           //var allCases = _unitOfWork.Cases.GetAll();
            IEnumerable<Case> cases;
            CaseServices caseServices = new CaseServices(_unitOfWork);
            querySearch.BeginDate = bDate;
            cases = caseServices.Find(querySearch);
            if (cases.Count() > 0)
                return Ok(Mapper.Map<IEnumerable<CaseViewModel>>(cases));
            else
                return NotFound();

        }

    }
}
