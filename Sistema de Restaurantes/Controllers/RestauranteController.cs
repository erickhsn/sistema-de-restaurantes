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
    public class RestauranteController : Controller
    {

        private readonly Restaurante _restaurante;

        public RestauranteController(Restaurante restaurante)
        {
            _restaurante = restaurante;

            if(_restaurante.pratos.Count() == 0)
            {
                _restaurante.pratos.Add(new Prato { nome = "Item 1" });
                _restaurante.SaveChanges();
            }
        }

        [HttpGet]
        public List<Prato> getAll()
        {
            return _restaurante.pratos.ToList();
        }

        [HttpGet("{id}", Name = "GetPrato")]
        public IActionResult GetById(long id)
        {
            var item = _restaurante.pratos.Find(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Prato prato)
        {
            if (prato == null)
                return BadRequest();

            _restaurante.pratos.Add(prato);
            _restaurante.SaveChanges();

            return CreatedAtRoute("GetPrato", new { id = prato.id }, prato);

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

    }

}
