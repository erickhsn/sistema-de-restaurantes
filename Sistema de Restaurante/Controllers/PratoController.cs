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
        public IActionResult getAll()
        {
            return Ok(_context.pratos);
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

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Prato prato)
        {
            if (prato == null || prato.id != id)
                return BadRequest();

            var p = _context.pratos.Find(id);
            if (p == null)
                return NotFound();

            p.nome = prato.nome;
            p.preco = prato.preco;
            
            _context.pratos.Update(p);
            _context.SaveChanges();
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var prato = _context.pratos.Find(id);
            if (prato == null)
                return NotFound();

            _context.pratos.Remove(prato);
            _context.SaveChanges();
            return Ok(prato);
        }

    }
}