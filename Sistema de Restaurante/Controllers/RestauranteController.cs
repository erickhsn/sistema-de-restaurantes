using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Restaurante.Models;
using Microsoft.EntityFrameworkCore;

namespace Sistema_de_Restaurante.Controllers
{
    [Route("api/[controller]")]
    public class RestauranteController : Controller
    {

        private readonly Context _context;

        public RestauranteController(Context context)
        {
            _context = context;
            
            if (_context.restaurantes.Count() == 0)
            {
                _context.restaurantes.Add(new Restaurante { nome = "Restaurante 1", pratos = new List<Prato>() });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Restaurante> getAll()
        {
            return _context.restaurantes.Include(r => r.pratos).ToList();
        }


        [HttpPost]
        public IActionResult Create([FromBody] Restaurante restaurante)
        {
            if (restaurante == null)
                return BadRequest();

            _context.restaurantes.Add(restaurante);
            _context.SaveChanges();


            return Ok(restaurante);

        }



        /*
        [HttpGet("{id}", Name = "GetPrato")]
        public IActionResult GetById(long id)
        {
            var item = _restaurante.pratos.Find(id);
            if (item == null)
                return NotFound();
            return Ok(_restaurante);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Prato prato)
        {
            if (prato == null || prato.id != id)
                return BadRequest();

            var p = _restaurante.pratos.Find(id);
            if (p == null)
                return NotFound();

            p.nome = prato.nome;
            p.preco = prato.preco;

            _restaurante.pratos.Update(p);
            _restaurante.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var prato = _restaurante.pratos.Find(id);
            if (prato == null)
                return NotFound();

            _restaurante.pratos.Remove(prato);
            _restaurante.SaveChanges();
            return NoContent();
        }*/

    }
}