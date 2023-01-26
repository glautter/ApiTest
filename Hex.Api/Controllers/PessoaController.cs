using AutoMapper;
using Hex.Application.Interfaces;
using Hex.Domain.Dtos;
using Hex.Domain.Entities;
using Hex.Domain.Enums;
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

        public IMapper Mapper { get; }

        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            this.pessoaService = pessoaService;
            Mapper = mapper;
        }

        // GET: api/Pessoa
        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(Pessoa))]
        public async Task<ActionResult<IEnumerable<Pessoa>>> Get()
        {
            var pessoas = Mapper.Map<IEnumerable<PessoaDto>>(await pessoaService.GetAllPessoas());
            return Ok(pessoas);
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
        public async Task<ActionResult> Post(ResponsePutPessoaDto pessoaModel)
        {
            try
            {
                var pessoaDomain = new Pessoa
                {
                    Nome = pessoaModel.Nome,
                    Documento = new Documento
                    {
                        Cpf = pessoaModel.Cpf
                    },
                    Idade = pessoaModel.Idade,
                    Localidade = new Localidade
                    {
                        Cidade = pessoaModel.Cidade,
                        Estado = pessoaModel.Estado
                    },
                    TipoEstadoCivil = (TipoEstadoCivil)pessoaModel.EstadoCivil
                };

                await pessoaService.SavePessoa(pessoaDomain);

                return CreatedAtAction(nameof(Post), new { id = pessoaModel.Id }, pessoaModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadHttpRequestException(ex.Message));
            }


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
