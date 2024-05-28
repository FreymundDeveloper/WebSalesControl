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

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
