using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FornecedorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {        
        private readonly DataContext _context;

        public FornecedorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fornecedor>>> Get()
        {
            var fornecedor = await _context.Fornecedores                
                .Include(x => x.FornecedorEnderecos)
                .ToListAsync();

            if (fornecedor == null)
                return BadRequest("Nenhum fornecedor cadastrado, por favor verifique e tente novamente!");

            return Ok(fornecedor);
        }   

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> Get(int id)
        {
            var fornecedor = await _context.Fornecedores
                .Where(x=> x.Id == id)
                .Include(x=> x.FornecedorEnderecos)
                .ToListAsync();

            if (fornecedor == null)
                return BadRequest("Fornecedor não encontrado, por favor verifique e tente novamente!");

            return Ok(fornecedor);
        }        

        [HttpPost]
        public async Task<ActionResult<List<Fornecedor>>> AddFornecedor(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();

            var fornecedores = await _context.Fornecedores               
                .Include(x => x.FornecedorEnderecos)
                .ToListAsync();

            return Ok(fornecedores);
        }        

        [HttpPut]
        public async Task<ActionResult<List<Fornecedor>>> UpdateFornecedor(Fornecedor request)
        {
            var dbFornecedor = await _context.Fornecedores.FindAsync(request.Id);
            if (dbFornecedor == null)
                return BadRequest("Fornecedor não encontrado, por favor verifique e tente novamente!");

            dbFornecedor.Nome= request.Nome;
            dbFornecedor.CNPJ= request.CNPJ;
            dbFornecedor.Telefone = request.Telefone;
            dbFornecedor.Email = request.Email;

            await _context.SaveChangesAsync();

            return Ok(await _context.Fornecedores.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Fornecedor>>> DeleteFornecedor(int id)
        {
            var dbFornecedor = await _context.Fornecedores.FindAsync(id);
            if (dbFornecedor == null)
                return BadRequest("Fornecedor não encontrado, por favor verifique e tente novamente!");

            _context.Fornecedores.Remove(dbFornecedor);
            await _context.SaveChangesAsync();

            return Ok(await _context.Fornecedores.ToListAsync());
        }        
    }
}
