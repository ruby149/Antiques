using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using antiques.Models;
using Microsoft.AspNetCore.Mvc;

namespace antiques.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        
        public IActionResult Index()
        {
            var products = _repo.GetAllProducts();
            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var product = _repo.GetProduct(id);
            return View(product);
        }
       

        public IActionResult CreateProduct () 
        {
            var prod = _repo.AssignCategory();
            return View(prod);
        }

        public IActionResult InsertProduct()
        {
            var prod = _repo.AssignCategory();

            return View(prod);
        }
        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
           _repo.CreateProduct(productToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult EditProduct(int id)
        {
            Product prod = _repo.GetProduct(id);
            prod.Categories = _repo.GetAllCategories();
            if (prod == null)
            {
                return View("ProductNotFound");
            }

            return View(prod);
        }
        public IActionResult UpdateProduct(int id)
        {
            Product prod = _repo.GetProduct(id);

            if (prod == null)
            {
                return View("ProductNotFound");
            }

            return View(prod);
        }
        public IActionResult UpdateProductToDatabase(Product product)
        {
            _repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        public IActionResult DeleteProduct(Product product)
        {
            _repo.DeleteProduct(product);
            return RedirectToAction("Index");
        }






    }
}
