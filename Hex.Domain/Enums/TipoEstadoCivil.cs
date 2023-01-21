using System.ComponentModel;

namespace Hex.Domain.Enums
{
    public enum TipoEstadoCivil
    {
        [Description("Solteiro")]
        Solteiro,
        [Description("Casado")]
        Casado,
        [Description("Divorciado")]
        Divorciado,
        [Description("Viúvo")]
        Viúvo
    }
}
