using DotNetMVCEFCode.Models;
using DotNetMVCEFCode.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMVCEFCode.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        // GET:ProductController
        public ActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: ProductController/Create
        public ActionResult Create() {
            return View();
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id) {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddProduct addProduct) {
            try
            {
                Product product = new Product() {
                  Name = addProduct.Name,
                  Description = addProduct.Description,
                  Price = addProduct.Price  
                };
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product) {
            try
            {
                var dbProduct = _context.Products.SingleOrDefault(p => p.Id == product.Id);
                dbProduct.Name = product.Name;
                dbProduct.Description = product.Description;
                dbProduct.Price = product.Price;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product) {
            try
            {
                var dbProduct = _context.Products.SingleOrDefault(p => p.Id == product.Id);
                _context.Products.Remove(dbProduct);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}