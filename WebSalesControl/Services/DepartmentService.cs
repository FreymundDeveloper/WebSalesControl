using Microsoft.EntityFrameworkCore;
using WebSalesControl.Data;
using WebSalesControl.Models;

namespace WebSalesControl.Services
{
    public class DepartmentService
    {
        private readonly WebSalesControlContext _context;

        public DepartmentService(WebSalesControlContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
