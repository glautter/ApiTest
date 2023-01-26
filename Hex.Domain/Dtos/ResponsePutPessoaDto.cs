namespace Hex.Domain.Dtos
{
    public class ResponsePutPessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public int EstadoCivil { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
