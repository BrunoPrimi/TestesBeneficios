using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Infra.Data.Configuracoes;

namespace TestesBeneficios.Infra.Data.Context
{
    public class TesteDbContextFactory : IDesignTimeDbContextFactory<TesteContext>
    {
        public TesteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TesteContext>();
            optionsBuilder.UseSqlServer("Server=TesteDB.mssql.somee.com;database=TesteDB;user id=Primi_SQLLogin_1;password=6ul8yeadfr;trust server certificate=true;");

            return new TesteContext(optionsBuilder.Options);
        }
    }
}
