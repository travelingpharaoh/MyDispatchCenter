// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;
        readonly gcsDbContext _gcsContext;
        ICustomerRepository _customers;
        IProductRepository _products;
        IOrdersRepository _orders;
        ICaseRepository _cases;


        public UnitOfWork(ApplicationDbContext context, gcsDbContext gcContext)
        {
            _context = context;
            _gcsContext = gcContext;
        }



        public ICustomerRepository Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new CustomerRepository(_context);

                return _customers;
            }
        }



        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(_context);

                return _products;
            }
        }



        public IOrdersRepository Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrdersRepository(_context);

                return _orders;
            }
        }

        public ICaseRepository Cases
        {
            get
            {
                if (_cases == null)
                    _cases = new CasetRepository(_gcsContext);
                return _cases;
            }
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
