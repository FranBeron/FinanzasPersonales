using FinanzasPersonales.Data;
using FinanzasPersonales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanzasPersonales.Controllers
{
    public class IngresosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngresosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get Create
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Ingreso> listIngresos=_context.Ingreso;
            CategoriaIngreso lst = _context.CategoriaIngresos.ToList().FirstOrDefault();
            listIngresos.Select(o => o.Categoria = lst);
            return View(listIngresos.OrderByDescending(p => p.FechaIngreso.Date));
        }

        //Http Get Create
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> cat = (from CategoriaIngreso in _context.CategoriaIngresos select new SelectListItem() { Text = CategoriaIngreso.Name, Value = CategoriaIngreso.Id.ToString() }).ToList();
            ViewBag.Categoria = cat.Select(o => o.Text.ToString());
            ViewData["Categoria"] = cat;
            return View();
        }

        //Http Post Create
        [HttpPost]
        public IActionResult Create(Ingreso ingreso)
        {
                var categoriaId = Convert.ToInt32(Request.Form["Categoria"].ToString());
                var BuscarCategoria = _context.CategoriaIngresos.Where(o => o.Id == categoriaId).FirstOrDefault();
                ingreso.Categoria = BuscarCategoria;

                _context.Ingreso.Add(ingreso);
                _context.SaveChanges();
                TempData["mensaje"] = "Registrado correctamente";
                return RedirectToAction("Index");
        }
        //Http Get Create
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            IEnumerable<SelectListItem> cat = (from CategoriaIngreso in _context.CategoriaIngresos select new SelectListItem() { Text = CategoriaIngreso.Name, Value = CategoriaIngreso.Id.ToString() }).ToList();
            ViewBag.Categoria = cat.Select(o => o.Text.ToString());
            ViewData["Categoria"] = cat;

            if (id== null||id == 0)
            {
                return NotFound();
            }

            //Obtener ingreso
            var ingreso = _context.Ingreso.Find(id);
            if (ingreso == null)
            {
                return NotFound();
            }
            return View(ingreso);
        }

        //Http Post Edit
        [HttpPost]
        public IActionResult Edit(Ingreso ingreso)
        {
                var categoriaId = Convert.ToInt32(Request.Form["Categoria"].ToString());
                var BuscarCategoria = _context.CategoriaIngresos.Where(o => o.Id == categoriaId).FirstOrDefault();
                ingreso.Categoria = BuscarCategoria;
                _context.Ingreso.Update(ingreso);
                _context.SaveChanges();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
        }


        //Http Get Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var ingreso = _context.Ingreso.Find(id);
            var categoriaIngresoo = _context.CategoriaIngresos.ToList();
            foreach (var item in categoriaIngresoo)
            {
                if (item.Id == ingreso.Categoria.Id)
                {
                    ViewBag.Categoria = item;

                    ViewData["Categoria"] = item.Name;
                }
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener ingreso
            if (ingreso == null)
            {
                return NotFound();
            }
            return View(ingreso);
        }

        //Http Post Delete
        [HttpPost]
        public IActionResult DeleteIngreso(int? id)
        {
            //Obtener ingreso
            var ingreso = _context.Ingreso.Find(id);
            if (ingreso == null)
            {
                return NotFound();
            }

            _context.Ingreso.Remove(ingreso);
            _context.SaveChanges();

            TempData["mensaje"] = "Eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
