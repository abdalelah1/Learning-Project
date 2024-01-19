    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using sql2.Data;
using sql2.Models;

namespace sql2.Controllers
    {
        public class itemsController : Controller
        {
        public itemsController(AppDbcontext db)
        {
            _db = db;
        }
        private readonly AppDbcontext _db;
        // GET: /<controller>/
        public IActionResult Index()
            {
            IEnumerable<Models.items> itemlist = _db.items.ToList();
                return View(itemlist);
            }
        public IActionResult New(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
public IActionResult New(items item)
{
    if (item.name=="100")
    {
        ModelState.AddModelError("Name","name can't equal 100   ");
    }
    if (ModelState.IsValid)
    {
        _db.items.Add(item);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    return View(item); // إرجاع العرض في حالة فشل التحقق من النموذج
}
        }
    }

