using Hex.Domain.Enums;

namespace Hex.Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public Documento Documento { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public TipoEstadoCivil TipoEstadoCivil { get; set; }
        public Localidade Localidade { get; set; }
    }
}
