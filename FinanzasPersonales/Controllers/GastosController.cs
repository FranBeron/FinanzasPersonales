using FinanzasPersonales.Data;
using FinanzasPersonales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanzasPersonales.Controllers
{
    public class GastosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GastosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get 
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Gasto> listGasto = _context.Gasto;
            CategoriaGasto lst = _context.CategoriaGastos.ToList().FirstOrDefault();
            listGasto.Select(o => o.Categoria = lst);
            return View(listGasto.OrderByDescending(p => p.FechaGasto.Date));
        }
        //Http Get 
        [HttpGet]
        public IActionResult Resumen(Gasto gsto)
        {
            var mesActual = DateTime.Now.Month;
            var anioActual = DateTime.Now.Year;
            var gastos = _context.Gasto.ToList();
            var ingresos = _context.Ingreso.ToList();

            var TotalMontoGastos = 0;
            var TotalMontoIngresos = 0;
            foreach (var gasto in gastos)
            {
                if (mesActual == gasto.FechaGasto.Date.Month && anioActual == gasto.FechaGasto.Year)
                {
                    TotalMontoGastos = TotalMontoGastos + gasto.Monto;
                }
            }

            ViewData["GastosResumen"] = TotalMontoGastos;

            foreach (var ingreso in ingresos)
            {
                if (mesActual == ingreso.FechaIngreso.Date.Month && anioActual == ingreso.FechaIngreso.Year)
                {
                    TotalMontoIngresos = TotalMontoIngresos+ ingreso.Monto;
                }
            }
            ViewData["IngresosResumen"] = TotalMontoIngresos;

            return View();
        } 

        //Http Get Create
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> cat = (from CategoriaGasto in _context.CategoriaGastos select new SelectListItem() { Text = CategoriaGasto.Name, Value = CategoriaGasto.Id.ToString() }).ToList();
            ViewBag.Categoria = cat.Select(o => o.Text.ToString());
            ViewData["Categoria"] = cat;

            return View();
        }

        //Http Post Create
        [HttpPost]
        public IActionResult Create(Gasto gasto)
        {
            var categoriaId = Convert.ToInt32(Request.Form["Categoria"].ToString());
            var BuscarCategoria = _context.CategoriaGastos.Where(o => o.Id == categoriaId).FirstOrDefault();
            gasto.Categoria = BuscarCategoria;

            _context.Gasto.Add(gasto);
            _context.SaveChanges();
            TempData["mensaje"] = "Registrado Correctamente";
            return RedirectToAction("Index");
        }
        //Http Get Create
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            IEnumerable<SelectListItem> cat = (from CategoriaGasto in _context.CategoriaGastos select new SelectListItem() { Text = CategoriaGasto.Name, Value = CategoriaGasto.Id.ToString() }).ToList();
            ViewBag.Categoria = cat.Select(o => o.Text.ToString());
            ViewData["Categoria"] = cat;

            var gasto = _context.Gasto.Find(id);

            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener Gasto
            if (gasto == null)
            {
                return NotFound();
            }

            return View(gasto);
        }

        //Http Post Edit
        [HttpPost]
        public IActionResult Edit(Gasto gasto)
        {
            var categoriaId = Convert.ToInt32(Request.Form["Categoria"].ToString());
            var BuscarCategoria = _context.CategoriaGastos.Where(o => o.Id == categoriaId).FirstOrDefault();
            gasto.Categoria = BuscarCategoria;
            _context.Gasto.Update(gasto);
            _context.SaveChanges();
            TempData["mensaje"] = "Modificado correctamente";
            return RedirectToAction("Index");

        }

        //Http Get Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {

            var gasto = _context.Gasto.Find(id);
            var categoriaGasto = _context.CategoriaGastos.ToList();
            foreach (var item in categoriaGasto)
            {
                if (item.Id == gasto.Categoria.Id)
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
            if (gasto == null)
            {
                return NotFound();
            }
            return View(gasto);
        }

        //Http Post Delete
        [HttpPost]
        public IActionResult DeleteGasto(int? id)
        {

            //Obtener ingreso
            var gasto = _context.Gasto.Find(id);
            if (gasto == null)
            {
                return NotFound();
            }

            _context.Gasto.Remove(gasto);
            _context.SaveChanges();

            TempData["mensaje"] = "Eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
