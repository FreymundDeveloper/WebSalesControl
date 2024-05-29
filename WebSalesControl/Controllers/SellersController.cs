using Microsoft.AspNetCore.Mvc;
using WebSalesControl.Models;
using WebSalesControl.Models.ViewModels;
using WebSalesControl.Services;
using WebSalesControl.Services.Exceptions;

namespace WebSalesControl.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        private IActionResult ValidateId(int? id)
        {
            if (id == null) return NotFound();

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) return NotFound();

            return View(obj);
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) 
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) 
        {
            return ValidateId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) 
        {
            return ValidateId(id);
        }

        public IActionResult Edit(int? id) 
        {
            var validate = ValidateId(id);

            if (validate != NotFound())
            {
                List<Department> departments = _departmentService.FindAll();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = _sellerService.FindById(id!.Value), Departments = departments };
                return View(viewModel);
            }
            else return validate;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id) return BadRequest();

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
