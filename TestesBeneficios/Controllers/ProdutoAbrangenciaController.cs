using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Infra.Data.Context;

namespace TestesBeneficios.Controllers
{
    [Authorize]
    public class ProdutoAbrangenciaController : BaseController
    {
        private readonly TesteContext _context;

        public ProdutoAbrangenciaController(TesteContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
              return _context.Abrangencia != null ? 
                          View(await _context.Abrangencia.ToListAsync()) :
                          Problem("Entity set 'TesteContext.Abrangencia'  is null.");
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Abrangencia == null)
            {
                return NotFound();
            }

            var produtoabrangencia = await _context.Abrangencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoabrangencia == null)
            {
                return NotFound();
            }

            return View(produtoabrangencia);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(_context.Produtos.ToList(), "Id", "Nome");

            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cidade,UF,IdProduto")] ProdutoAbrangencia produtoabrangencia)
        {
            ModelState.Remove("Produto");
            if (ModelState.IsValid)
            {
                produtoabrangencia.Id = Guid.NewGuid();
                _context.Add(produtoabrangencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ProdutoId = new SelectList(_context.Produtos.ToList(), "Id", "Nome");
            return View(produtoabrangencia);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Abrangencia == null)
            {
                return NotFound();
            }

            var produtoabrangencia = await _context.Abrangencia.FindAsync(id);
            if (produtoabrangencia == null)
            {
                return NotFound();
            }
            return View(produtoabrangencia);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Cidade,UF")] ProdutoAbrangencia produtoabrangencia)
        {
            if (id != produtoabrangencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoabrangencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produtoabrangencia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ProdutoId = new SelectList(_context.Produtos.ToList(), "Id", "Nome");
            return View(produtoabrangencia);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Abrangencia == null)
            {
                return NotFound();
            }

            var produtoabrangencia = await _context.Abrangencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoabrangencia == null)
            {
                return NotFound();
            }

            return View(produtoabrangencia);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Abrangencia == null)
            {
                return Problem("Entity set 'TesteContext.Abragencia'  is null.");
            }
            var produtoabrangencia = await _context.Abrangencia.FindAsync(id);
            if (produtoabrangencia != null)
            {
                _context.Abrangencia.Remove(produtoabrangencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(Guid id)
        {
          return (_context.Abrangencia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
