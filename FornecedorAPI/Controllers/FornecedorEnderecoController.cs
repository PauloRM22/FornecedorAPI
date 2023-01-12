using FornecedorAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;

namespace FornecedorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorEnderecoController : ControllerBase
    {
        private readonly DataContext _context;

        public FornecedorEnderecoController(DataContext context)
        {
            _context = context;
        }        

        [HttpGet("{fornecedorId}")]
        public async Task<ActionResult<List<FornecedorEndereco>>> Get(int fornecedorId)
        {
            var fornecedorEnderecos = await _context.FornecedorEnderecos
                .Where(c => c.FornecedorId == fornecedorId)
                .ToListAsync();            

            return fornecedorEnderecos;
        }        

        [HttpPost]
        public async Task<ActionResult<List<FornecedorEndereco>>> AddFornecedorEndereco(AddFornecedorEnderecoDTO request)
        {
            var fornecedor = await _context.Fornecedores
                .FindAsync(request.FornecedorId);

            if (fornecedor == null)
                return NotFound();

            var newFornecedorEndereco = new FornecedorEndereco
            {
                CEP = request.CEP,
                Rua = request.Rua,
                Numero= request.Numero,
                Complemento = request.Complemento,
                Cidade = request.Cidade,
                Estado= request.Estado,
                Pais= request.Pais,
                Fornecedor = fornecedor
            };

            _context.FornecedorEnderecos.Add(newFornecedorEndereco);
            await _context.SaveChangesAsync();

            return await Get(newFornecedorEndereco.FornecedorId);
        }        

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<FornecedorEndereco>>> DeleteFornecedorEndereco(int id)
        { 
            var dbFornecedorEndereco = await _context.FornecedorEnderecos.FindAsync(id);
            if (dbFornecedorEndereco == null)
                return BadRequest("Endereço do fornecedor não encontrado, por favor verifique e tente novamente!");

            _context.FornecedorEnderecos.Remove(dbFornecedorEndereco);
            await _context.SaveChangesAsync();

            return Ok(await _context.FornecedorEnderecos.ToListAsync());
        }        
    }
}
