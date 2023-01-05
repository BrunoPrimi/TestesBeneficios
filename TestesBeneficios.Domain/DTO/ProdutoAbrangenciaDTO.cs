﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Enumeradores;

namespace TestesBeneficios.Domain.DTO
{
    public class ProdutoAbrangenciaDTO
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string UF { get; set; }
        public Guid IdProduto { get; set; }
        public ProdutoDTO Produto { get; set; }
    }
}
    
