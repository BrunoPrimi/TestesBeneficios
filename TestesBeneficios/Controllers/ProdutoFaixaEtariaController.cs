using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Infra.Data.Context;

namespace TestesBeneficios.Controllers
{
    public class ProdutoFaixaEtariaController : BaseController
    {
        private readonly TesteContext _context;

        public ProdutoFaixaEtariaController(TesteContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
              return _context.FaixaEtaria != null ? 
                          View(await _context.FaixaEtaria.ToListAsync()) :
                          Problem("Entity set 'TesteContext.FaixaEtaria'  is null.");
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FaixaEtaria == null)
            {
                return NotFound();
            }

            var produtofaixaetaria = await _context.FaixaEtaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtofaixaetaria == null)
            {
                return NotFound();
            }

            return View(produtofaixaetaria);
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
        public async Task<IActionResult> Create([Bind("FaixaDe,FaixaAte,Preco,IdProduto")] ProdutoFaixaEtaria produtofaixaetaria)
        {
            ModelState.Remove("Produto");
            if (ModelState.IsValid)
            {
                produtofaixaetaria.Id = Guid.NewGuid();
                _context.Add(produtofaixaetaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtofaixaetaria);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FaixaEtaria == null)
            {
                return NotFound();
            }

            var produtofaixaetaria = await _context.FaixaEtaria.FindAsync(id);
            if (produtofaixaetaria == null)
            {
                return NotFound();
            }
            return View(produtofaixaetaria);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FaixaDe,FaixaAte,Preco")] ProdutoFaixaEtaria produtofaixaetaria)
        {
            if (id != produtofaixaetaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtofaixaetaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produtofaixaetaria.Id))
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
            return View(produtofaixaetaria);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FaixaEtaria == null)
            {
                return NotFound();
            }

            var produtofaixaetaria = await _context.FaixaEtaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtofaixaetaria == null)
            {
                return NotFound();
            }

            return View(produtofaixaetaria);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FaixaEtaria == null)
            {
                return Problem("Entity set 'TesteContext.Produtos'  is null.");
            }
            var produtofaixaetaria = await _context.FaixaEtaria.FindAsync(id);
            if (produtofaixaetaria != null)
            {
                _context.FaixaEtaria.Remove(produtofaixaetaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(Guid id)
        {
          return (_context.FaixaEtaria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
