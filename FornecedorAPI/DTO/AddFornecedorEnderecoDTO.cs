using System.Reflection.Metadata.Ecma335;

namespace FornecedorAPI.DTO
{
    public class AddFornecedorEnderecoDTO
    {      
        public string CEP { get; set; } = string.Empty;
        public string Rua { get; set; } = "Desconhecido";
        public int Numero { get; set; } = 0;
        public string Complemento { get; set; } = "Sem complemento";
        public string Cidade { get; set; } = "Curitiba";
        public string Estado { get; set; } = "Paraná";
        public string Pais { get; set; } = "Brasil";
        public int FornecedorId { get; set; } = 1;
    }
}
