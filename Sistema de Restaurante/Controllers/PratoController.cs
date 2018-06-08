using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Restaurante.Models;

namespace Sistema_de_Restaurante.Controllers
{
    [Route("api/[controller]")]
    public class PratoController : Controller
    {
        private readonly Context _context;

        public PratoController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Prato> getAll()
        {
            return _context.pratos.ToList();
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Prato prato)
        {
            var item = _context.restaurantes.Find(prato.restauranteId);
            if (prato == null || item == null)
                return BadRequest();

            Restaurante r = _context.restaurantes.Single(res => res.id == prato.restauranteId);

            Prato p = new Prato
            {
                nome = prato.nome,
                preco = prato.preco,
                restaurante = r
            };

            _context.pratos.Add(p);
            _context.SaveChanges();

            return Ok(p);

        }
    }
}