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
    public class FilmeController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public FilmeController (Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]
        public List<Filme> Get()
        {
            return Contexto.Filmes.ToList();
        }

        [HttpGet("id")]

        public Filme Get(int id)
        {
            return Contexto.Filmes.First(e => e.IdFilme == id);
        }

        [HttpGet("id/{id}")]
        public List<Filme> Filtrar(int id)
        {
            return Contexto.Filmes.Where(e => e.IdFilme == id).ToList();
        }

        [HttpPost]
        [Route("add")]

        public async Task<ActionResult<Filme>> Create(Filme Filme)
        {
            Filme.IdFilme = 0;
            Contexto.Filmes.Add(Filme);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Filme.IdFilme, Filme });
        }

        [HttpPost]
        [Route("update")]

        public async Task<ActionResult<Filme>> Update(Filme Filme)
        {
            Contexto.Filmes.Update(Filme);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Filme.IdFilme, Filme });
        }
    }
}
