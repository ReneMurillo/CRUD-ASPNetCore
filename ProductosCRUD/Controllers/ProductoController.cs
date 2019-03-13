using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductosCRUD.Models;

namespace ProductosCRUD.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductosContext _context;

        public ProductoController(ProductosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var productos = _context.Producto
                .Include(x => x.Categoria);
            return View(await productos.ToListAsync());
        }

        // GET: Producto/Create
        public IActionResult CreateOrEdit(int id = 0)
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Nombre");
            if (id == 0)
                return View(new Producto());
            else
                return View(_context.Producto.Find(id));
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit([Bind("ProductoId,Codigo,Descripcion,PrecioVenta,CategoriaId")] Producto producto)
        {
            try
            {
                if (producto.ProductoId == 0)
                    _context.Add(producto);
                else
                    _context.Update(producto);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(producto);
            }
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.Producto.FindAsync(id);

            _context.Producto.Remove(producto);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}