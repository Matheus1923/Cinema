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
    public class ClienteController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public ClienteController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]
        public List<Cliente> Get()
        {
            return Contexto.Clientes.ToList();
        }

        [HttpGet("id")]

        public Cliente Get(int id)
        {
            return Contexto.Clientes.First(e => e.IdCliente == id);
        }

        [HttpGet("id/{id}")]
        public List<Cliente> Filtrar(int id)
        {
            return Contexto.Clientes.Where(e => e.IdCliente == id).ToList();
        }

        [HttpPost]
        [Route("add")]

        public async Task<ActionResult<Cliente>> Create (Cliente Cliente)
        {
            Cliente.IdCliente = 0;
            Contexto.Clientes.Add(Cliente);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Cliente.IdCliente, Cliente });
        }

        [HttpPost]
        [Route("update")]

        public async Task<ActionResult<Cliente>> Update(Cliente Cliente)
        {
            Contexto.Clientes.Update(Cliente);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Cliente.IdCliente, Cliente });
        }
    }
}
