using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosCRUD.Models;

namespace ProductosCRUD.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ProductosContext _pContext;

        public CategoriaController(ProductosContext context)
        {
            _pContext = context;
        }
        // GET: Categoria
        public async Task<IActionResult> Index()
        {
            var categorias = _pContext.Categoria;
            return View(await categorias.ToListAsync());
        }

        // GET: Categoria/Create
        public IActionResult CreateOrEdit(int id=0)
        {
            if (id == 0)
                return View(new Categoria());
            else
                return View(_pContext.Categoria.Find(id));

        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> CreateOrEdit([Bind("CategoriaId,Nombre,Descripcion")] Categoria categoria)
        {
            try
            {
                if (categoria.CategoriaId == 0)
                    _pContext.Add(categoria);
                else
                    _pContext.Update(categoria);

                await _pContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(categoria);
            }
        }

        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _pContext.Categoria.FindAsync(id);

            _pContext.Categoria.Remove(categoria);

            await _pContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}