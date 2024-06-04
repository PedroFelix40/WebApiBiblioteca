﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapibibliotech.Domains;
using webapibibliotech.Interfaces;

namespace webapibibliotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EmprestimoLivroController : ControllerBase
    {
        private IEmprestimo _emprestimo;

        public EmprestimoLivroController(IEmprestimo emprestimo)
        {
            _emprestimo = emprestimo ?? throw new ArgumentNullException(nameof(emprestimo)); // validação para conferir se a instância de IGenero é != de null
        }

        [HttpPost]
        public IActionResult Post(EmprestimosLivro emprestimos)
        {
            try
            {
                _emprestimo.Inscrever(emprestimos);

                return Ok(emprestimos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _emprestimo.Deletar(id);

                return Ok("Emprestimo deletado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_emprestimo.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
