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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        } 

        public async Task UpdateAsync(Seller seller)
        {
            if (!await _context.Seller.AnyAsync(x => x.Id == seller.Id)) throw new NotFoundException("ID not found!");

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
