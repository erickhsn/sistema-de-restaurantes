using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Restaurantes.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sistema_de_Restaurantes.Controllers
{
    [Route("api/[controller]")]
    public class EstabelecimentoController : Controller
    {
        private readonly Estabelecimento _estabelecimento;
        public EstabelecimentoController(Estabelecimento estabelecimento)
        {
            _estabelecimento = estabelecimento;
        }
    }

}
