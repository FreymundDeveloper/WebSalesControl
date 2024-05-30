using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        private async Task<IActionResult> ValidateIdAsync(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id not provided!" });

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null) return RedirectToAction(nameof(Error), new { message = "Id not found!" });

            return View(obj);
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller) 
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) 
        {
            return await ValidateIdAsync(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id) 
        {
            return await ValidateIdAsync(id);
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            var validate = await ValidateIdAsync(id);
            var obj = await _sellerService.FindByIdAsync(id!.Value);

            if (validate is not RedirectToActionResult)
            {
                List<Department> departments = await _departmentService.FindAllAsync();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
                return View(viewModel);
            }
            else return validate;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            if (id != seller.Id) return RedirectToAction(nameof(Error), new { message = "Id mismatch!" });

            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
