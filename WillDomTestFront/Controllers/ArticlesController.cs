using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WillDomTestFront.Data;
using WillDomTestFront.Models;

namespace WillDomTestFront.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Article> listArticles = _context.Article;
            return View(listArticles);
        }

        [HttpGet]
        public IActionResult Manage()
        {
            IEnumerable<Article> listArticles = _context.Article;
            return View(listArticles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                //if (article.Image!=null)
                //{
                //    string fichero = Path.Combine(_webHostEnvironment.WebRootPath, "imagenes");
                //    string guidImagen = Guid.NewGuid().ToString();
                //    string rutaFinal = Path.Combine(fichero, guidImagen);
                //    article.Image.CopyTo(new FileStream(rutaFinal, FileMode.Create));
                //}
                _context.Article.Add(article);
                _context.SaveChanges();
                TempData["mensaje"] = "El articulo se ha creado correctamente";
                return RedirectToAction("Manage");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var articulo = _context.Article.Find(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Article.Update(article);
                _context.SaveChanges();
                TempData["mensaje"] = "El articulo se ha actualizado correctamente";
                return RedirectToAction("Manage");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var articulo = _context.Article.Find(id);

            if (articulo == null)
            {
                return NotFound();
            }
            return View(articulo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteArticle(int? id)
        {
            var article = _context.Article.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            _context.Article.Remove(article);
            _context.SaveChanges();
            TempData["mensaje"] = "El articulo se ha eliminado correctamente";
            return RedirectToAction("Manage");
            
        }
    }
}
