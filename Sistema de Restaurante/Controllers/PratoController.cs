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
        private Context _context = new Context();

        public PratoController(Context context)
        {
            _context = context;

            if (_context.pratos.Count() == 0)
            {

                _context.AddRange(_context);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Prato> getAll()
        {
            return _context.pratos.ToList();
        }
        /*
        [HttpPost]
        public IActionResult Create([FromBody] Prato restaurante)
        {
            if (restaurante == null)
                return BadRequest();

            _context.restaurantes.Add(restaurante);
            _context.SaveChanges();


            return Ok(restaurante);

        }*/
    }
}