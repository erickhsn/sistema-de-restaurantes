using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Restaurante.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;

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
                _context.restaurantes.Add(new Restaurante { Nome = "Restaurante 1", Pratos = new List<Prato>() });
                _context.restaurantes.Add(new Restaurante { Nome = "Restaurante 2", Pratos = new List<Prato>() });
                _context.SaveChanges();
                List<Prato> pratos1 = new List<Prato>();
                List<Prato> pratos2 = new List<Prato>();
                pratos1.Add(new Prato { Nome = "Prato 1", Preco = 10, RestauranteId = 1, Restaurante = _context.restaurantes.Single(res => res.Id == 1) });
                pratos1.Add(new Prato { Nome = "Prato 2", Preco = 15, RestauranteId = 1, Restaurante = _context.restaurantes.Single(res => res.Id == 1) });

                pratos2.Add(new Prato { Nome = "Prato 1", Preco = 12, RestauranteId = 2, Restaurante = _context.restaurantes.Single(res => res.Id == 2) });
                pratos2.Add(new Prato { Nome = "Prato 2", Preco = 13, RestauranteId = 2, Restaurante = _context.restaurantes.Single(res => res.Id == 2) });

                _context.restaurantes.Single(r => r.Id == 1).Pratos.AddRange(pratos1);
                _context.restaurantes.Single(r => r.Id == 2).Pratos.AddRange(pratos2);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// Tras uma lista com todos os Restaurantes
        /// </summary>
        /// <returns>Restorna uma lista com os Restaurantes</returns>
        [SwaggerResponse(200, Type = typeof(IEnumerable<Prato>), Description = "Restaurante criado com sucesso")]
        [HttpGet]
        public List<Restaurante> getAll()
        {
            return _context.restaurantes.Include(r => r.Pratos).ToList();
        }

        /// <summary>
        /// Adiciona um novo prato ao restaurante
        /// </summary>
        /// <param name="restaurante">Modelo de restaurante</param>
        /// <remarks>Adiciona novo restaurante</remarks>
        [SwaggerResponse(200, Type = typeof(IEnumerable<Prato>), Description = "Restaurante criado com sucesso")]
        [SwaggerResponse(400, Description = "Restaurante não pode ser nulo")]
        [HttpPost]
        public IActionResult Create([FromBody] Restaurante restaurante)
        {
            if (restaurante == null)
                return BadRequest();

            _context.restaurantes.Add(restaurante);
            _context.SaveChanges();


            return Ok(restaurante);

        }


        /// <summary>
        /// Atualiza informações do Restaurante
        /// </summary>
        /// <param name="id">Id do Restaurante</param>
        /// <param name="restaurante">Modelo de Restaurante</param>
        /// <remarks>Atualiza restaurante</remarks>
        [SwaggerResponse(200, Type = typeof(IEnumerable<Prato>), Description = "Restaurante atualizado com sucesso")]
        [SwaggerResponse(400, Description = "Restaurante não pode ser nulo, restauranteId diferente do id ou restauranteId não existe")]
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Restaurante restaurante)
        {
            if (restaurante == null || restaurante.Id != id)
                return BadRequest();

            var r = _context.restaurantes.Find(id);
            if (r == null)
                return BadRequest();

            r.Nome = restaurante.Nome;

            _context.restaurantes.Update(r);
            _context.SaveChanges();
            return Ok(r);
        }

        /// <summary>
        /// Deleta um restaurante
        /// </summary>
        /// <param name="id">Id do restaurante</param>
        /// <remarks>Deleta prato</remarks>
        [SwaggerResponse(200, Type = typeof(IEnumerable<Prato>), Description = "Restaurante removido com sucesso")]
        [SwaggerResponse(400, Description = "Restaurante não encontrado")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var restaurante = _context.restaurantes.Find(id);
            if (restaurante == null)
                return BadRequest();

            _context.restaurantes.Remove(restaurante);
            _context.SaveChanges();
            return Ok(restaurante);
        }

    }
}