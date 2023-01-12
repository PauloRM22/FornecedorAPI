using System.Text.Json.Serialization;

namespace FornecedorAPI
{
    public class Fornecedor
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }        
        public List<FornecedorEndereco>? FornecedorEnderecos { get; set;}
    }
}
