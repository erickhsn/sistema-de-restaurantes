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
                _context.restaurantes.Add(new Restaurante { nome = "Restaurante 2", pratos = new List<Prato>() });
                _context.SaveChanges();
                List<Prato> pratos1 = new List<Prato>();
                List<Prato> pratos2 = new List<Prato>();
                pratos1.Add(new Prato { nome = "Prato 1", preco = 10, restauranteId = 1, restaurante = _context.restaurantes.Single(res => res.id == 1) });
                pratos1.Add(new Prato { nome = "Prato 2", preco = 15, restauranteId = 1, restaurante = _context.restaurantes.Single(res => res.id == 1) });

                pratos2.Add(new Prato { nome = "Prato 1", preco = 12, restauranteId = 2, restaurante = _context.restaurantes.Single(res => res.id == 2) });
                pratos2.Add(new Prato { nome = "Prato 2", preco = 13, restauranteId = 2, restaurante = _context.restaurantes.Single(res => res.id == 2) });

                _context.restaurantes.Single(r => r.id == 1).pratos.AddRange(pratos1);
                _context.restaurantes.Single(r => r.id == 2).pratos.AddRange(pratos2);
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