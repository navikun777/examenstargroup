using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STARPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace STARPrueba.Controllers
{
    public class AreaController : Controller
    {
        private readonly StarGroupContext Context;
        public AreaController(StarGroupContext context)
        {
            Context = context;
        }
        // GET: AreaController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Area = await Context.Areas.ToListAsync();
            return View(Area);
        }

        // GET: AreaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AreaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Area addarearequest)
        {
            try
            {
                var area = new Area()
                {
                    Nombre = addarearequest.Nombre,
                   
                    //IdCategoriaNavigationId = null
                };
                await Context.Areas.AddAsync(area);
                await Context.SaveChangesAsync();

                return RedirectToAction("Index");
                // return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AreaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AreaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AreaController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Area area = Context.Areas.Find(id);
            return View(area);
        }

        // POST: AreaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Area aut = Context.Areas.Find(id);
                Context.Areas.Remove(aut);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
