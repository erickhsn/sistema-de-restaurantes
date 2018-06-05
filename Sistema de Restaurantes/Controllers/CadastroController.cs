using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_de_Restaurantes.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult cadastroRestaurante()
        {
            return View();
        }

        public IActionResult cadastroPrato()
        {
            return View();
        }
    }
}