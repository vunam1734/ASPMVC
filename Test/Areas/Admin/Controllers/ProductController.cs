using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IHostingEnvironment host;
        public ProductController(ApplicationDbContext _db, IHostingEnvironment _host)
        {
            db = _db;
            host = _host;
        }

        public IActionResult Index(int? page)
        {
            int pagesize = 10;
            int pageIndex;
            pageIndex = page == null ? 1 : (int)page;

            var lstproduct = db.Products.Include(x => x.Category).ToList();
            var pagecount = (int)Math.Ceiling((double)lstproduct.Count() / pagesize + (lstproduct.Count % pagesize > 0 ? 1 : 0));

            ViewBag.PageSum = pagecount;
            ViewBag.PageIndex = pageIndex;
            return View(lstproduct.Skip((pageIndex - 1) * pagesize).Take(pagesize).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.lstcategory = db.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string path = Path.Combine(host.WebRootPath, @"images/products");
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    obj.ImageUrl = @"images/products/" + filename;
                }
                db.Products.Add(obj);
                db.SaveChanges();
                TempData["success"] = "Thêm sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ViewBag.Lstcategory = db.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            return View();
        }
        public IActionResult Edit(int id)
        {
            var objProduct = db.Products.Find(id);
            if (objProduct == null)
                return NotFound();
            ViewBag.LstCategory = db.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            return View(objProduct);
        }
        [HttpPost]
        public IActionResult Edit(Product obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string path = Path.Combine(host.WebRootPath, @"images/products");
                    using (var filestream = new FileStream(Path.

                        Combine(path, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    if (!String.IsNullOrEmpty(obj.ImageUrl))
                    {
                        var oldFilePath = Path.Combine(host.WebRootPath, obj.ImageUrl);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }
                    obj.ImageUrl = @"images/products/" + filename;
                }
                db.Products.Update(obj);
                db.SaveChanges();
                TempData["success"] = "Chỉnh sửa sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ViewBag.LstCategory = db.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var objProduct = db.Products.Find(id);
            if (objProduct == null)
                return NotFound();
            if (!string.IsNullOrEmpty(objProduct.ImageUrl))
            {
                var oldFilePatch = Path.Combine(host.WebRootPath, objProduct.ImageUrl);
                if (System.IO.File.Exists(oldFilePatch))
                {
                    System.IO.File.Delete(oldFilePatch);
                }
            }
            db.Products.Remove(objProduct);
            db.SaveChanges();
            TempData["success"] = "Xóa sản phẩm thành công";

            return RedirectToAction("Index");
        }
    }
}