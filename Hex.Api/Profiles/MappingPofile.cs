using AutoMapper;
using Hex.Domain.Dtos;
using Hex.Domain.Entities;
using Hex.Infra.Shared;

namespace Hex.Api.Profiles
{
    public class MappingPofile : Profile
    {
        public MappingPofile()
        {
            CreateMap<Pessoa, PessoaDto>()
                .ForMember(p => p.Cpf, opts => opts.MapFrom(m => m.Documento.Cpf))
                .ForMember(p => p.EstadoCivil, opts => opts.MapFrom(m => m.TipoEstadoCivil.ToDescription()))
                .ForMember(p => p.Cidade, opts => opts.MapFrom(m => m.Localidade.Cidade))
                .ForMember(p => p.Estado, opts => opts.MapFrom(m => m.Localidade.Estado));
        }
    }
}
