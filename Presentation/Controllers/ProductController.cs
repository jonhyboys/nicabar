using Application.Products;
using Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            IEnumerable<Product> products = _productService.GetAll();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductAddModel productAddModel)
        {
            try
            {
                if (_productService.Add(productAddModel)) { return RedirectToAction(nameof(Index)); }
                else { return View("Error"); }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(Guid id)
        {
            Product product = _productService.GetById(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Product product)
        {
            try
            {
                if (_productService.Update(product)) { return RedirectToAction(nameof(Index)); }
                else { return View("Error"); }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(Guid id)
        {
            if(_productService.Delete(id)) { return RedirectToAction(nameof(Index)); }
            else { return View("Error"); }
        }
    }
}
