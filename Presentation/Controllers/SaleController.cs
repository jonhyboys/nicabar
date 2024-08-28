﻿using Application.Sales;
using Application.Tables;
using Domain.Sales;
using Domain.Tables;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly ITableService _tableService;

        public SaleController(
            ISaleService saleService,
            ITableService tableService)
        {
            _saleService = saleService;
            _tableService = tableService;
        }

        // GET: SaleController
        public ActionResult Index()
        {
            IEnumerable<Table> Tables = _tableService.GetAll();
            return View(Tables);
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            SaleViewModel viewModel = new SaleViewModel() {
                Tables = _tableService.GetAll()
            };
            return View(viewModel);
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
