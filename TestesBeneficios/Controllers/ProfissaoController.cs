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
    public class ProfissaoController : BaseController
    {
       
        private readonly IServicoProfissao _servicoProfissao;

        public ProfissaoController(IServicoProfissao servicoProfissao)
        {
            
            _servicoProfissao = servicoProfissao;
        }

        public async Task<IActionResult> Index()
        {
            return View( await _servicoProfissao.BuscarTodos());
                       
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var profissao = await _servicoProfissao.BuscarPeloId(id.Value);
            if (profissao == null)
            {
                return NotFound();
            }

            return View(profissao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfissaoDTO profissaoDTO)
        {
            if (!profissaoDTO.EhValido())
            {
                profissaoDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("Produtos");
            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoProfissao.Criar(profissaoDTO);
                if (linhasAfetadas > 0 )
                    return RedirectToAction(nameof(Index));
            }
            return View(profissaoDTO);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var profissao = await _servicoProfissao.BuscarPeloId(id.Value);
            if (profissao == null)
            {
                return NotFound();
            }
            return View(profissao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProfissaoDTO profissaoDTO)
        {
            if (id != profissaoDTO.Id)
            {
                return NotFound();
            }

            if (!profissaoDTO.EhValido())
            {
                profissaoDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("Produtos");
            if (ModelState.IsValid)
            {
                await _servicoProfissao.Edit(id, profissaoDTO);
                
                return RedirectToAction(nameof(Index));
            }
            return View(profissaoDTO);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var profissao = await _servicoProfissao.BuscarPeloId(id.Value);
            if (profissao == null)
            {
                return NotFound();
            }

            return View(profissao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
           
            var profissao = await _servicoProfissao.BuscarPeloId(id);
            if (profissao != null)
            {
             await _servicoProfissao.Excluir(id);
            }

            
            return RedirectToAction(nameof(Index));
        }

     
    }
}
