﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Domain.Repositorios.Interfaces
{
    public interface IRepositorioProfissao
    {
        Task<int> Criar(Profissao profissao);
        Task<int> Edit(Profissao profissao);
        Task<int> Excluir(Guid id);
        Task<List<Profissao>> BuscarTodos();
        Task<Profissao> BuscarPeloId(Guid id);    
    }
}
