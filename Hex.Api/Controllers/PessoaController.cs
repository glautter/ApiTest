using Hex.Application.Interfaces;
using Hex.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hex.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            this.pessoaService = pessoaService;
        }

        // GET: api/Pessoa
        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(Pessoa))]
        public async Task<ActionResult<IEnumerable<Pessoa>>> Get()
        {
            return Ok(await pessoaService.GetAllPessoas());
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> Get(int id)
        {
            var pessoa = await pessoaService.GetPessoaById(id);

            return pessoa == null ? NotFound() : Ok(pessoa);
        }

        // PUT: api/Pessoa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
                return BadRequest();

            try
            {
                await this.pessoaService.UpdatePessoa(pessoa);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pessoa
        [HttpPost]
        public async Task<ActionResult> Post(Pessoa pessoa)
        {
            await pessoaService.SavePessoa(pessoa);

            return CreatedAtAction(nameof(Post), new { id = pessoa.Id }, pessoa);
        }

        // DELETE: api/Pessoa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pessoa = await pessoaService.GetPessoaById(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            await pessoaService.DeletePessoa(pessoa);

            return NoContent();
        }

        private bool PessoaExists(int id) => pessoaService.GetPessoaById(id) != null;
    }
}
