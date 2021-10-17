using CinemaMat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngressoController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public IngressoController (Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]
        public List<Ingresso> Get()
        {
            return Contexto.Ingressos.ToList();
        }

        [HttpGet("id")]

        public Ingresso Get(int id)
        {
            return Contexto.Ingressos.First(e => e.IdIngresso == id);
        }

        [HttpGet("id/{id}")]
        public List<Ingresso> Filtrar(int id)
        {
            return Contexto.Ingressos.Where(e => e.IdIngresso == id).ToList();
        }

        [HttpPost]
        [Route("add")]

        public async Task<ActionResult<Ingresso>> Create(Ingresso Ingresso)
        {
            Ingresso.IdIngresso = 0;
            Contexto.Ingressos.Add(Ingresso);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Ingresso.IdIngresso, Ingresso });
        }

        [HttpPost]
        [Route("update")]

        public async Task<ActionResult<Ingresso>> Update(Ingresso Ingresso)
        {
            Contexto.Ingressos.Update(Ingresso);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Ingresso.IdIngresso, Ingresso });
        }
    }
}
