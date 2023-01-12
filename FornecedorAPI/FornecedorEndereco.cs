using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FornecedorAPI
{
    public class FornecedorEndereco
    {       
        public int Id { get; set; }        
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        [JsonIgnore]
        public Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }
    }
}
