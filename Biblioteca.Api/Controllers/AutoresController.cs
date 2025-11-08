using Biblioteca.Application.Commands.Autor;
using Biblioteca.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class AutoresController : ControllerBase
    {

        private readonly IAutorService _service;

        public AutoresController(IAutorService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] AutorAdicionarCommand command)
        {
            var result = _service.Adicionar(command);

            return result.Sucesso ? Ok(result) : BadRequest(result);
        }

        
        [HttpPut]
        public IActionResult Alterar([FromBody] AutorAlterarCommand command)
        {
            var result = _service.Alterar(command);
            return result.Sucesso ? Ok(result) : BadRequest(result);
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.Get();
            return result.Sucesso ? Ok(result) : BadRequest(result);
        }

      
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result.Sucesso ? Ok(result) : BadRequest(result);
        }

     
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var result = _service.Excluir(id);
            return result.Sucesso ? Ok(result) : BadRequest(result);
        }
    }
}
