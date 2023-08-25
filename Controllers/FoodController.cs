using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c= new Context();
        public IActionResult Index(int page=1) //parametre sayfalama işlemi sırasında yazıldı. //Sayfalama işlemi için X.paged.mvc core paketrini kur
        {
            
            return View(foodRepository.Tlist("Category").ToPagedList(page,3)); //INCLUDE METODUNU DÖNDÜRÜYOR. l harfi kuçük dikkat . .TopagedList sayfalama işlemi için sonradan eklendi includedanbagımsız
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.val = values;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(Food fd) 
        {
            foodRepository.TAdd(fd);
            return RedirectToAction("Index"); 
        }
        public IActionResult FoodDelete(int id)
        {
            foodRepository.TRemove(new Food {FoodID=id });
            return RedirectToAction("Index");
        }
        public IActionResult FoodGet(int id)
        {
            var x=foodRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.val = values;

            Food f = new Food()
            {
                FoodID=x.FoodID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImageURL = x.ImageURL,
            };
            return View(f);
        }
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodRepository.TGet(p.FoodID);
            x.Name= p.Name;
            x.Price= p.Price;
            x.Stock= p.Stock;
            x.Description= p.Description;
            x.ImageURL= p.ImageURL;
            x.CategoryID= p.CategoryID;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
