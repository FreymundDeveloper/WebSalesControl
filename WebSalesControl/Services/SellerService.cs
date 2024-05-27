using WebSalesControl.Data;
using WebSalesControl.Models;

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
    }
}
