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
        [HttpGet("{bDate}")]
        public IActionResult Get(string bDate, [FromQuery] CaseQuerySearch querySearch)
        {
           //var allCases = _unitOfWork.Cases.GetAll();
            IEnumerable<Case> cases;
            DateTime beginDate;
            DateTime endDate;
            if (bDate.Length > 0)
            {
                if (DateTime.TryParse(bDate, out beginDate))
                {
                    String.Format("{0:yyyy/MM/dd}", beginDate);
                }
                else
                    return BadRequest();
                if ((querySearch.EndDate.Length>0)&&(DateTime.TryParse(querySearch.EndDate, out endDate))) 
                {

                }
                else
                    return BadRequest();
                cases = _unitOfWork.Cases.Find(c => c.ResolvedDate >= beginDate);
                if (cases.Count() > 0)
                    return Ok(Mapper.Map<IEnumerable<CaseViewModel>>(cases));
                else
                    return NotFound();
            }
            

            return NotFound();
        }

    }
}
