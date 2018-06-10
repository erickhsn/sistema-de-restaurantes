using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Restaurante.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

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

        /// <summary>
        /// Tras uma lista com todos os pratos cadastrados
        /// </summary>
        /// <returns>Restorna uma lista com os pratos</returns>
        [SwaggerResponse(200, Type = typeof(IEnumerable<Prato>))]
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_context.pratos.ToList());
        }

        /// <summary>
        /// Adiciona um novo prato ao restaurante
        /// </summary>
        /// <param name="prato">Modelo de Prato</param>
        /// <remarks>Adiciona novo prato</remarks>
        [SwaggerResponse(200, Type = typeof(IEnumerable<Prato>), Description = "Objeto criado com sucesso")]
        [SwaggerResponse(400, Description = "Prato não pode ser nulo ou restauranteId não existe")]
        [HttpPost]
        public IActionResult Create([FromBody] Prato prato)
        {
            
            var item = _context.restaurantes.Find(prato.RestauranteId);
            if (prato == null || item == null)
                return BadRequest();

            Restaurante r = _context.restaurantes.Single(res => res.Id == prato.RestauranteId);

            Prato p = new Prato
            {
                Nome = prato.Nome,
                Preco = prato.Preco,
                Restaurante = r     
            };

            _context.pratos.Add(p);
            _context.SaveChanges();

            return Ok(p);

        }

        /// <summary>
        /// Atualiza informações do prato
        /// </summary>
        /// <param name="id">Id do prato</param>
        /// <param name="prato">Modelo de Prato</param>
        /// <remarks>Atualiza prato</remarks>
        [SwaggerResponse(200, Type = typeof(IEnumerable<Prato>), Description = "Prato atualizado com sucesso")]
        [SwaggerResponse(400, Description = "Prato não pode ser nulo, pratoId diferente do id ou pratoId não existe")]
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Prato prato)
        {
            if (prato == null || prato.Id != id)
                return BadRequest();

            var p = _context.pratos.Find(id);
            if (p == null)
                return BadRequest();

            p.Nome = prato.Nome;
            p.Preco = prato.Preco;
            
            _context.pratos.Update(p);
            _context.SaveChanges();
            return Ok(p);
        }

        /// <summary>
        /// Deleta um prato
        /// </summary>
        /// <param name="id">Id do prato</param>
        /// <remarks>Deleta prato</remarks>
        [SwaggerResponse(200, Type = typeof(IEnumerable<Prato>), Description = "Prato removido com sucesso")]
        [SwaggerResponse(400, Description = "Prato não encontrado")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var prato = _context.pratos.Find(id);
            if (prato == null)
                return BadRequest();

            _context.pratos.Remove(prato);
            _context.SaveChanges();
            return Ok(prato);
        }

    }
}