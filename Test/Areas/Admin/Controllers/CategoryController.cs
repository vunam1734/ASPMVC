using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<Category> dstheloai = db.Categories.ToList();
            return View(dstheloai);
        }
        private ApplicationDbContext db;

        public IActionResult Create()
        {
            return View();
        }
        public CategoryController(ApplicationDbContext _db)
        {
            db = _db;
        }
        [HttpPost]
        public IActionResult Create(Category objCategory)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(objCategory);
                db.SaveChanges();
                TempData["success"] = "Tạo danh mục thành công";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id, object theloai)
        {
            var objCategory = db.Categories.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            return View(objCategory);
        }
        [HttpPost]
        public IActionResult Edit(Category objCategory)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Update(objCategory);
                db.SaveChanges();
                TempData["success"] = "Chỉnh sửa danh mục thành công";
                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var objCategory = db.Categories.Find(id);
            if (objCategory == null)
            {
                return NotFound();
            }
            return View(objCategory);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var objCategory = db.Categories.Find(id);
            if (objCategory == null)
            {
                return NotFound();
            }
            db.Categories.Remove(objCategory);
            db.SaveChanges();
            TempData["success"] = "Xóa danh mục thành công";
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            return View();
        }

    }
}
