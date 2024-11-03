using Application.Sales;
using Domain.Sales;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class InvoiceController : Controller
    {
        ISaleService _saleService;

        public InvoiceController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_saleService.GetAllUnpayed());
        }

        [HttpPut()]
        public ActionResult Pay(Guid id)
        {
            return Json(_saleService.Pay(id));
        }
    }
}
