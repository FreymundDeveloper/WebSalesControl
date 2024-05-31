using Microsoft.EntityFrameworkCore;
using WebSalesControl.Data;
using WebSalesControl.Models;

namespace WebSalesControl.Services
{
    public class SalesRecordService
    {
        private readonly WebSalesControlContext _context;

        public SalesRecordService(WebSalesControlContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue) result = result.Where(x => x.Date >= minDate.Value);
            if (maxDate.HasValue) result = result.Where(x => x.Date <= maxDate.Value);

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
