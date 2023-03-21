using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STARPrueba.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace STARPrueba.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly StarGroupContext _context;
        public EmpleadoController(StarGroupContext context)
        {
            _context = context;
        }
        // GET: EmpleadoController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Empleado= await _context.Empleados.ToListAsync();
            return View(Empleado);
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            var drowArea = _context.Areas.ToList();
            ViewData["IdArea"] = (List<STARPrueba.Models.Area>)drowArea.ToList();
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado addempleadorequest)
        {
            try
            {
                var empleado = new Empleado()
                {
                    Nombre = addempleadorequest.Nombre,
                    ApePaterno = addempleadorequest.ApePaterno,
                    ApeMaterno = addempleadorequest.ApeMaterno,
                    Edad = addempleadorequest.Edad,
                    Direccion = addempleadorequest.Direccion,
                    Email = addempleadorequest.Email,
                    AreaId = addempleadorequest.AreaId,
                    //IdCategoriaNavigationId = null

                };
                await _context.Empleados.AddAsync(empleado);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(Id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,Nombre,ApePaterno,ApeMaterno,Edad,Direccion,Email")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }
            
               empleado.AreaId = 1;
               
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                    return View();
                }
                return RedirectToAction(nameof(Index));
            //}
            return View(empleado);
        }
        //[HttpGet]
        //public IActionResult Edit(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return NotFound();
        //    }
        //    //GetById
        //    Empleado emplead = _context.Empleados.Find(Id);
        //    if (emplead == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(emplead);
        //}
        // GET: EmpleadoController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            return View(empleado);
           
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Empleado emp = _context.Empleados.Find(id);
                _context.Empleados.Remove(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
