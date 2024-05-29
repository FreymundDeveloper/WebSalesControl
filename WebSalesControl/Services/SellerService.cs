using Microsoft.EntityFrameworkCore;
using WebSalesControl.Data;
using WebSalesControl.Models;
using WebSalesControl.Services.Exceptions;

namespace WebSalesControl.Services
{
    public class SellerService
    {
        private readonly WebSalesControlContext _context;

        public SellerService(WebSalesControlContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id)!;
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        } 

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id)) throw new NotFoundException("ID not found!");

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
