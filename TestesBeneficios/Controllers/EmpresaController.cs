using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Servicos.Interfaces;
using TestesBeneficios.Infra.Data.Context;

namespace TestesBeneficios.Controllers
{
    [Authorize]
    public class EmpresaController : BaseController
    {
       
        private readonly IServicoEmpresa _servicoEmpresa;

        public EmpresaController(IServicoEmpresa servicoEmpresa)
        {
            
            _servicoEmpresa = servicoEmpresa;
        }

        // GET: Empresa
        public async Task<IActionResult> Index()
        {
            return View( await _servicoEmpresa.BuscarTodos());
                       
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var empresa = await _servicoEmpresa.BuscarPeloId(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpresaDTO empresaDTO)
        {
            ModelState.Remove("Produtos");
            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoEmpresa.Criar(empresaDTO);
                if (linhasAfetadas > 0 )
                    return RedirectToAction(nameof(Index));
            }
            return View(empresaDTO);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var empresa = await _servicoEmpresa.BuscarPeloId(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EmpresaDTO empresaDTO)
        {
            if (id != empresaDTO.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Produtos");
            if (ModelState.IsValid)
            {
                await _servicoEmpresa.Edit(id, empresaDTO);
                
                return RedirectToAction(nameof(Index));
            }
            return View(empresaDTO);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var empresa = await _servicoEmpresa.BuscarPeloId(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
           
            var empresa = await _servicoEmpresa.BuscarPeloId(id);
            if (empresa != null)
            {
             await _servicoEmpresa.Excluir(id);
            }

            
            return RedirectToAction(nameof(Index));
        }

     
    }
}
