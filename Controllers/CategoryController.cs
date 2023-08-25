using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        //[Authorize]  //AUTHORIZE EKLEME,GİRİŞ OLMADAN BU SAYFA GOZUKMEZ 

        public IActionResult Index(string p) //parametre arama işlemi için
        {
            if (string.IsNullOrEmpty(p))
            {
                return View(categoryRepository.List(x=>x.CategoryName==p));
            }
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category cat)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(cat);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);
            Category ct = new Category()
            {
                CategoryName= x.CategoryName,
                CategoryDescription= x.CategoryDescription,
                CategoryID= x.CategoryID
            };

            return View(ct);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p) 
        {
            var x = categoryRepository.TGet(p.CategoryID);
            x.CategoryName = p.CategoryName;
            x.CategoryDescription= p.CategoryDescription;
            x.Status= true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
