using Microsoft.EntityFrameworkCore;
using WebSalesControl.Models;
using WebSalesControl.Models.Enums;

namespace WebSalesControl.Data
{
    public class SeedingService
    {
        private WebSalesControlContext _context;

        public SeedingService(WebSalesControlContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any()) return;

            // Department Table

            Department department1 = new Department(new int(), "Computers");
            Department department2 = new Department(new int(), "Electronics");
            Department department3 = new Department(new int(), "Fashion");
            Department department4 = new Department(new int(), "Books");

            // Seller Table

            Seller seller1 = new Seller(new int(), "James Pet", "jp@gmail.com", new DateTime(1999, 9, 22), 1000.0, department1);
            Seller seller2 = new Seller(new int(), "Tom Bee", "tob@gmail.com", new DateTime(1955, 2, 12), 3500.0, department2);
            Seller seller3 = new Seller(new int(), "Janne Goll", "jgll@gmail.com", new DateTime(2000, 11, 23), 5500.0, department1);
            Seller seller4 = new Seller(new int(), "Wiil Pogg", "willp@gmail.com", new DateTime(1977, 1, 27), 1500.0, department4);
            Seller seller5 = new Seller(new int(), "Luy Pondet", "luyp@gmail.com", new DateTime(1990, 6, 22), 4000.0, department3);
            Seller seller6 = new Seller(new int(), "Mei Zoin", "meiz@gmail.com", new DateTime(1998, 8, 21), 8000.0, department2);

            // SalesRecord Table

            SalesRecord record1 = new SalesRecord(new int(), new DateTime(2018, 09, 25), 11000.0, SalesStatus.Billed, seller1);
            SalesRecord record2 = new SalesRecord(new int(), new DateTime(2018, 09, 4), 7000.0, SalesStatus.Billed, seller5);
            SalesRecord record3 = new SalesRecord(new int(), new DateTime(2018, 09, 13), 4000.0, SalesStatus.Canceled, seller4);
            SalesRecord record4 = new SalesRecord(new int(), new DateTime(2018, 09, 1), 8000.0, SalesStatus.Billed, seller1);
            SalesRecord record5 = new SalesRecord(new int(), new DateTime(2018, 09, 21), 3000.0, SalesStatus.Billed, seller3);
            SalesRecord record6 = new SalesRecord(new int(), new DateTime(2018, 09, 15), 2000.0, SalesStatus.Billed, seller1);
            SalesRecord record7 = new SalesRecord(new int(), new DateTime(2018, 09, 28), 13000.0, SalesStatus.Billed, seller2);
            SalesRecord record8 = new SalesRecord(new int(), new DateTime(2018, 09, 11), 4000.0, SalesStatus.Billed, seller4);
            SalesRecord record9 = new SalesRecord(new int(), new DateTime(2018, 09, 14), 11000.0, SalesStatus.Pending, seller6);
            SalesRecord record10 = new SalesRecord(new int(), new DateTime(2018, 09, 7), 9000.0, SalesStatus.Billed, seller6);
            SalesRecord record11 = new SalesRecord(new int(), new DateTime(2018, 09, 13), 6000.0, SalesStatus.Billed, seller2);
            SalesRecord record12 = new SalesRecord(new int(), new DateTime(2018, 09, 25), 7000.0, SalesStatus.Pending, seller3);
            SalesRecord record13 = new SalesRecord(new int(), new DateTime(2018, 09, 29), 10000.0, SalesStatus.Billed, seller4);
            SalesRecord record14 = new SalesRecord(new int(), new DateTime(2018, 09, 4), 3000.0, SalesStatus.Billed, seller5);
            SalesRecord record15 = new SalesRecord(new int(), new DateTime(2018, 09, 12), 4000.0, SalesStatus.Billed, seller1);
            SalesRecord record16 = new SalesRecord(new int(), new DateTime(2018, 10, 5), 2000.0, SalesStatus.Billed, seller4);
            SalesRecord record17 = new SalesRecord(new int(), new DateTime(2018, 10, 1), 12000.0, SalesStatus.Billed, seller1);
            SalesRecord record18 = new SalesRecord(new int(), new DateTime(2018, 10, 24), 6000.0, SalesStatus.Billed, seller3);
            SalesRecord record19 = new SalesRecord(new int(), new DateTime(2018, 10, 22), 8000.0, SalesStatus.Billed, seller5);
            SalesRecord record20 = new SalesRecord(new int(), new DateTime(2018, 10, 15), 8000.0, SalesStatus.Billed, seller6);
            SalesRecord record21 = new SalesRecord(new int(), new DateTime(2018, 10, 17), 9000.0, SalesStatus.Billed, seller2);
            SalesRecord record22 = new SalesRecord(new int(), new DateTime(2018, 10, 24), 4000.0, SalesStatus.Billed, seller4);
            SalesRecord record23 = new SalesRecord(new int(), new DateTime(2018, 10, 19), 11000.0, SalesStatus.Canceled, seller2);
            SalesRecord record24 = new SalesRecord(new int(), new DateTime(2018, 10, 12), 8000.0, SalesStatus.Billed, seller5);
            SalesRecord record25 = new SalesRecord(new int(), new DateTime(2018, 10, 31), 7000.0, SalesStatus.Billed, seller3);
            SalesRecord record26 = new SalesRecord(new int(), new DateTime(2018, 10, 6), 5000.0, SalesStatus.Billed, seller4);
            SalesRecord record27 = new SalesRecord(new int(), new DateTime(2018, 10, 13), 9000.0, SalesStatus.Pending, seller1);
            SalesRecord record28 = new SalesRecord(new int(), new DateTime(2018, 10, 7), 4000.0, SalesStatus.Billed, seller3);
            SalesRecord record29 = new SalesRecord(new int(), new DateTime(2018, 10, 23), 12000.0, SalesStatus.Billed, seller5);
            SalesRecord record30 = new SalesRecord(new int(), new DateTime(2018, 10, 12), 5000.0, SalesStatus.Billed, seller2);

            // Seeding Process

            _context.Department.AddRange(department1, department2, department3, department4);

            _context.Seller.AddRange(seller1, seller2, seller3, seller4);

            _context.SalesRecord.AddRange(record1, record2, record3, record4, record5,
                                          record6, record7, record8, record9, record10,
                                          record11, record12, record13, record14, record15,
                                          record16, record17, record18, record19, record20,
                                          record20, record21, record22, record23, record24,
                                          record26, record27, record28, record29, record30);

            _context.SaveChanges();
        }
    }
}
