using Beneficios.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace Beneficios.Web.Controllers
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
