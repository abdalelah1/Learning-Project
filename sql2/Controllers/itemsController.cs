using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sql2.Data;
using sql2.Models;

namespace sql2.Controllers
{
    public class itemsController : Controller
    {
        public void CreateSelectList(int selectID=1)
        {
         List<Category> categories = _db.categories.ToList(); 
         SelectList listItems=new SelectList(categories,"Id","Name",selectID);
         ViewBag.CategoryList=listItems;
        }
        public itemsController(AppDbcontext db)
        {
            _db = db;
        }
        private readonly AppDbcontext _db;
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Models.items> itemlist = _db.items.Include(c=> c.Category).ToList();
            return View(itemlist);
        }
        public IActionResult New()
        {   CreateSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(items item)
        {  System.Console.WriteLine("************************************");
            System.Console.WriteLine(item.categoryid);
             System.Console.WriteLine("************************************");
            if (item.name == "100")
            {
                ModelState.AddModelError("Name", "name can't equal 100   ");
            }
            if (ModelState.IsValid)
            {
                _db.items.Add(item);
                _db.SaveChanges();
                TempData["Success"]=" Data has been added succeffuly";

                return RedirectToAction("Index");
            }
            return View(item); // إرجاع العرض في حالة فشل التحقق من النموذج
        }
        public IActionResult edit(int? id)
        {
            System.Console.WriteLine("hi");
            System.Console.WriteLine(id);
            if (id == 0 || id == null)
            {
                return NotFound();

            }
            var item = _db.items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CreateSelectList(item.id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edit(items item)
        {
            if (item.name == "100")
            {
                ModelState.AddModelError("Name", "name can't equal 100   ");
            }
            if (ModelState.IsValid)
            {
                _db.items.Update(item);
                _db.SaveChanges();
                TempData["Success"]=" Data has been Edited succeffuly";

                return RedirectToAction("Index");
            }
            return View(item); // إرجاع العرض في حالة فشل التحقق من النموذج
        }
        public IActionResult Delete(int? id)
        {
            System.Console.WriteLine("hi");
            System.Console.WriteLine(id);
            if (id == 0 || id == null)
            {
                return NotFound();

            }
            var item = _db.items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CreateSelectList(item.id);
            return View(item);
        }
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? id)
        {
            System.Console.WriteLine("this is the function");
            var item=_db.items.Find(id);
            if (item==null)
            {
                return NotFound();
            }
            _db.Remove(item);
            _db.SaveChanges();
            TempData["Success"]=" Data has been deleted succeffuly";
            
            return RedirectToAction("Index");
        }
    }

}

