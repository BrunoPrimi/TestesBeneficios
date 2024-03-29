﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Repositorios.Interfaces;
using TestesBeneficios.Domain.Servicos.Interfaces;
using TestesBeneficios.Infra.Data.Context;

namespace TestesBeneficios.Infra.Data.Repositorios.Implementacoes
{
    public class RepositorioProfissao : IRepositorioProfissao
    {
        private readonly TesteContext _contexto;

        public RepositorioProfissao(TesteContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Edit(Profissao profissao )
        {

            _contexto.Profissoes.Update(profissao);

            return await _contexto.SaveChangesAsync() ;
        }

        public async Task<Profissao> BuscarPeloId(Guid id)
        {
          

            return await _contexto.Profissoes.FindAsync(id);
        }

        public async Task<List<Profissao>> BuscarTodos()
        {
            return await _contexto.Profissoes.ToListAsync();
        }

        public async Task<int> Criar(Profissao profissao)
        {
            await _contexto.Profissoes.AddAsync(profissao);
          
            return await _contexto.SaveChangesAsync();

        }

        public async Task<int> Excluir(Guid id)
        {
            var profissao = await _contexto.Profissoes.FindAsync(id);

            _contexto.Profissoes.Remove(profissao);

            return await _contexto.SaveChangesAsync();
        }
    }
}
