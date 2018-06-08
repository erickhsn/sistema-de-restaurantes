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

        
        /*[HttpGet("{id}", Name = "GetRestaurante")]
        public IActionResult GetById(long id)
        {
            var item = _context.restaurantes.Find(id);
            if (item == null)
                return NotFound();
            return Ok(item.nome);
        }*/

        
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Restaurante restaurante)
        {
            if (restaurante == null || restaurante.id != id)
                return BadRequest();

            var r = _context.restaurantes.Find(id);
            if (r == null)
                return NotFound();

            r.nome = restaurante.nome;

            _context.restaurantes.Update(r);
            _context.SaveChanges();
            return Ok(r);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var restaurante = _context.restaurantes.Find(id);
            if (restaurante == null)
                return NotFound();

            _context.restaurantes.Remove(restaurante);
            _context.SaveChanges();
            return Ok(restaurante);
        }

    }
}