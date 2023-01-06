using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Servicos.Implementacoes;
using TestesBeneficios.Domain.Servicos.Interfaces;
using TestesBeneficios.Infra.Data.Context;

namespace TestesBeneficios.Controllers
{
    [Authorize]
    public class ProdutoController : BaseController
    {


        private readonly IServicoProduto _servicoProduto;

        private readonly IServicoEmpresa _servicoEmpresa;

        public ProdutoController(IServicoProduto servicoProduto, IServicoEmpresa servicoEmpresa)
        {

            _servicoProduto = servicoProduto;
            _servicoEmpresa = servicoEmpresa;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _servicoProduto.BuscarTodos());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _servicoProduto.BuscarPeloId(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Usuario/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.EmpresaId = new SelectList(await _servicoEmpresa.BuscarTodos(), "Id", "RazaoSocial");

            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoDTO produtoDTO)
        {
            if (!produtoDTO.EhValido())
            {
                produtoDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("Empresa");
            ModelState.Remove("FaixaEtaria");
            ModelState.Remove("Abrangencias");

            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoProduto.Criar(produtoDTO);
                if (linhasAfetadas > 0)
                    return RedirectToAction(nameof(Index));
            }
            ViewBag.EmpresaId = new SelectList(await _servicoEmpresa.BuscarTodos(), "Id", "RazaoSocial");
            return View(produtoDTO);

        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _servicoProduto.BuscarPeloId(id.Value);
            if (produto == null)
            {
                return NotFound();
            }
            ViewBag.EmpresaId = new SelectList(await _servicoEmpresa.BuscarTodos(), "Id", "RazaoSocial");
            return View(produto);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Codigo,IdEmpresa,Abrangencia")] ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
            {
                return NotFound();
            }

            if (!produtoDTO.EhValido())
            {
                produtoDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("Empresa");
            ModelState.Remove("FaixaEtaria");
            ModelState.Remove("Abrangencias");

            if (ModelState.IsValid)
            {
                await _servicoProduto.Edit(id, produtoDTO);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.EmpresaId = new SelectList(await _servicoEmpresa.BuscarTodos(), "Id", "RazaoSocial");
            return View(produtoDTO);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _servicoProduto.BuscarPeloId(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var produto = await _servicoProduto.BuscarPeloId(id);
            if (produto != null)
            {
                await _servicoProduto.Excluir(id);
            }


            return RedirectToAction(nameof(Index));
        }


    }
}
