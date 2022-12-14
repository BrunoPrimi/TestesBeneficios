using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Controllers;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Infra.Data.Context;

namespace TestesBeneficios
{
    [Authorize]
    public class BeneficiarioController : BaseController
    {
        private readonly TesteContext _context;

        public BeneficiarioController(TesteContext context)
        {
            _context = context;
        }

        // GET: Beneficiario
        public async Task<IActionResult> Index()
        {
              return _context.Beneficiarios != null ? 
                          View(await _context.Beneficiarios.ToListAsync()) :
                          Problem("Entity set 'TesteContext.Beneficiarios'  is null.");
        }

        // GET: Beneficiario/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Beneficiarios == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beneficiario == null)
            {
                return NotFound();
            }

            return View(beneficiario);
        }

        // GET: Beneficiario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beneficiario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Beneficiario beneficiario)
        {
            if (ModelState.IsValid)
            {
                beneficiario.Id = Guid.NewGuid();
                _context.Add(beneficiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beneficiario);
        }

        // GET: Beneficiario/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Beneficiarios == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiarios.FindAsync(id);
            if (beneficiario == null)
            {
                return NotFound();
            }
            return View(beneficiario);
        }

        // POST: Beneficiario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Cpf,NomeMae,Rg,DataNascimento,Status")] Beneficiario beneficiario)
        {
            if (id != beneficiario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficiario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficiarioExists(beneficiario.Id))
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
            return View(beneficiario);
        }

        // GET: Beneficiario/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Beneficiarios == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beneficiario == null)
            {
                return NotFound();
            }

            return View(beneficiario);
        }

        // POST: Beneficiario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Beneficiarios == null)
            {
                return Problem("Entity set 'TesteContext.Beneficiarios'  is null.");
            }
            var beneficiario = await _context.Beneficiarios.FindAsync(id);
            if (beneficiario != null)
            {
                _context.Beneficiarios.Remove(beneficiario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeneficiarioExists(Guid id)
        {
          return (_context.Beneficiarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
