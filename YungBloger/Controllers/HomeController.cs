using ClassLibrary.Data.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YungBloger.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using YungBloger.ViewModels;
using Korzh.EasyQuery.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace YungBloger.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        private readonly UserManager<ArticleUser> _userManager;
        public HomeController(UserManager<ArticleUser> userManager,  ApplicationContext context)
        {
            _userManager = userManager;
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            string id = _userManager.GetUserId(HttpContext.User);
            return View(db.Articls.Where(p => p.UserID == id));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Articls articls)
        {
            articls.DateOfPublication = DateTime.Now;
            articls.UserID = _userManager.GetUserId(HttpContext.User);

            db.Articls.Add(articls);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Articls articls = await db.Articls.FirstOrDefaultAsync(p => p.Id == id);
                if (articls != null)
                    return View(articls);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Articls articls = await db.Articls.FirstOrDefaultAsync(p => p.Id == id);

                if (articls != null)
                    return View(articls);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Articls articls)
        {
            articls.UserID = _userManager.GetUserId(HttpContext.User);
            db.Articls.Update(articls);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Articls articls = await db.Articls.FirstOrDefaultAsync(p => p.Id == id);
                if (articls != null)
                    return View(articls);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Articls articls = await db.Articls.FirstOrDefaultAsync(p => p.Id == id);
                if (articls != null)
                {
                    db.Articls.Remove(articls);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }


        public IActionResult CreateTag()
        {
            string id = _userManager.GetUserId(HttpContext.User);
            ViewData["ArticlsID"] = new SelectList(db.Articls.Where(p => p.UserID == id), "Id", "Heading");
            ViewData["TagID"] = new SelectList(db.Tags, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag(int? articleid, [Bind("articlsID,tagID")] ArticlsTag articlsTag)
        {

            if (ModelState.IsValid)
            {
                db.Add(articlsTag);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult SearchArticl()
        {
            ViewData["TagID"] = new SelectList(db.Tags, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult SearchArticl1(int? TagId)
        {
            return View(db.ArticleTags.Include(p => p.articls).Where(s => s.tagID == TagId).Select(p=>p.articls).ToList());
        }

        public IActionResult CreateComment()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> CreateComment(Coment comment)
        {
            comment.DateAnswer = DateTime.Now;
            comment.UserID = _userManager.GetUserId(HttpContext.User);
            comment.NameUser = User.Identity.Name;

            db.Comments.Add(comment);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult SeeComent()
        {
            return View(db.Comments);
        }


    }
}
