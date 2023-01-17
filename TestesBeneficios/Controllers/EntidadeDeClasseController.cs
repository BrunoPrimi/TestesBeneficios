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
    public class EntidadeDeClasseController : BaseController
    {
       
        private readonly IServicoEntidadeDeClasse _servicoEntidadeDeClasse;

        public EntidadeDeClasseController(IServicoEntidadeDeClasse servicoEntidadeDeClasse)
        {
            
            _servicoEntidadeDeClasse = servicoEntidadeDeClasse;
        }

        public async Task<IActionResult> Index()
        {
            return View( await _servicoEntidadeDeClasse.BuscarTodos());
                       
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var entidadeDeClasse = await _servicoEntidadeDeClasse.BuscarPeloId(id.Value);
            if (entidadeDeClasse == null)
            {
                return NotFound();
            }

            return View(entidadeDeClasse);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntidadeDeClasseDTO entidadeDeClasseDTO)
        {
            if (!entidadeDeClasseDTO.EhValido())
            {
                entidadeDeClasseDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("Produtos");
            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoEntidadeDeClasse.Criar(entidadeDeClasseDTO);
                if (linhasAfetadas > 0 )
                    return RedirectToAction(nameof(Index));
            }
            return View(entidadeDeClasseDTO);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var entidadeDeClasse = await _servicoEntidadeDeClasse.BuscarPeloId(id.Value);
            if (entidadeDeClasse == null)
            {
                return NotFound();
            }
            return View(entidadeDeClasse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EntidadeDeClasseDTO entidadeDeClasseDTO)
        {
            if (id != entidadeDeClasseDTO.Id)
            {
                return NotFound();
            }

            if (!entidadeDeClasseDTO.EhValido())
            {
                entidadeDeClasseDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("EntidadeDeClasses");
            if (ModelState.IsValid)
            {
                await _servicoEntidadeDeClasse.Edit(id, entidadeDeClasseDTO);
                
                return RedirectToAction(nameof(Index));
            }
            return View(entidadeDeClasseDTO);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var entidadeDeClasse = await _servicoEntidadeDeClasse.BuscarPeloId(id.Value);
            if (entidadeDeClasse == null)
            {
                return NotFound();
            }

            return View(entidadeDeClasse);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
           
            var entidadeDeClasse = await _servicoEntidadeDeClasse.BuscarPeloId(id);
            if (entidadeDeClasse != null)
            {
             await _servicoEntidadeDeClasse.Excluir(id);
            }

            
            return RedirectToAction(nameof(Index));
        }

     
    }
}
