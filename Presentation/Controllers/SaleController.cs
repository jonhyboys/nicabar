using Application.Sales;
using Domain.Sales;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;            
        }

        // GET: SaleController
        public ActionResult Index()
        {
            return View(new List<Sale>());
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SaleAddModel saleAddModel)
        {
            try
            {
                if (_saleService.Add(saleAddModel)) { return RedirectToAction(nameof(Index)); }
                else { return View("Error"); }
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
