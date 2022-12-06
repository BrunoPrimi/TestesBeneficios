using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Infra.Data.Context;

namespace TestesBeneficios.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR", true); 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR", true);
        }
    }
}



