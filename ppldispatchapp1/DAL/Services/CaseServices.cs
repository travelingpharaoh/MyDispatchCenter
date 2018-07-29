using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
namespace DAL.Services
{
    public class CaseServices
    {
        private IUnitOfWork _unitOfWork;
        readonly caseAppDbContext _caseAppDb;
        public CaseServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _caseAppDb = (caseAppDbContext) unitOfWork.Cases.GetDbContext();
        }
        public IEnumerable<Case> Find(CaseSearchModel caseQuery)
        {
            IQueryable <Case> cases=_caseAppDb.Cases.AsQueryable();
            DateTime beginDate;
            DateTime endDate;

            if (caseQuery.BeginDate.Length > 0)
            {
                if (DateTime.TryParse(caseQuery.BeginDate, out beginDate))
                {
                    String.Format("{0:yyyy/MM/dd}", beginDate);
                    if (caseQuery.EndDate.Length ==0)
                    {
                        cases = _unitOfWork.Cases.Find(c => c.ResolvedDate >= beginDate).AsQueryable<Case>();
                    }
                    else if (DateTime.TryParse(caseQuery.EndDate, out endDate))
                    {
                        cases = _unitOfWork.Cases.Find(c => c.ResolvedDate >= beginDate && 
                                                        c.ResolvedDate<=endDate).AsQueryable<Case>();
                    }
                    if (caseQuery.Customer > 0)
                        cases = cases.Where<Case>(c => c.Customer == caseQuery.Customer).AsQueryable<Case>();
                    if (caseQuery.Employee>0)
                        cases = cases.Where<Case>(c => c.AssignedTo == caseQuery.Employee).AsQueryable<Case>();
                }
            }
            
            return cases;

        }
    }
}
