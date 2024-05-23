using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSalesControl.Models;

namespace WebSalesControl.Data
{
    public class WebSalesControlContext : DbContext
    {
        public WebSalesControlContext (DbContextOptions<WebSalesControlContext> options)
            : base(options)
        {
        }

        public DbSet<WebSalesControl.Models.Department> Department { get; set; } = default!;
    }
}
