using Application.Tables;
using Domain.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        // GET: TableController
        public ActionResult Index()
        {
            IEnumerable<Table> tables = _tableService.GetAll();
            return View(tables);
        }

        // GET: TableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TableAddModel tableAddModel)
        {
            try
            {
                if (_tableService.Add(tableAddModel)) { return RedirectToAction(nameof(Index)); }
                else { return View("Error"); }
            }
            catch
            {
                return View();
            }
        }

        // GET: TableController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TableController/Edit/5
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

        // GET: TableController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TableController/Delete/5
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
