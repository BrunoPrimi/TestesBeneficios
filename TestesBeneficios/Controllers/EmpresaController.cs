using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
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

        public async Task<IActionResult> Index()
        {
            return View( await _servicoEmpresa.BuscarTodos());
                       
        }

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpresaDTO empresaDTO)
        {
            if (!empresaDTO.EhValido())
            {
                empresaDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("Produtos");
            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoEmpresa.Criar(empresaDTO);
                if (linhasAfetadas > 0 )
                    return RedirectToAction(nameof(Index));
            }
            return View(empresaDTO);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EmpresaDTO empresaDTO)
        {
            if (id != empresaDTO.Id)
            {
                return NotFound();
            }

            if (!empresaDTO.EhValido())
            {
                empresaDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("Produtos");
            if (ModelState.IsValid)
            {
                await _servicoEmpresa.Edit(id, empresaDTO);
                
                return RedirectToAction(nameof(Index));
            }
            return View(empresaDTO);
        }

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
