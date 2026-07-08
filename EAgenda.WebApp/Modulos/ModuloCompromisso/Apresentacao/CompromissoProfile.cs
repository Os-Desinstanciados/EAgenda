using AutoMapper;
using EAgenda.WebApp.Modulos.ModuloCompromisso.Aplicacao;

namespace EAgenda.WebApp.Modulos.ModuloCompromisso.Apresentacao;

public class CompromissoProfile : Profile
{
    public CompromissoProfile()
    {
        CreateMap<OpcaoContatoDto, OpcaoContatoViewModel>();
        CreateMap<ListarCompromissosDto, ListarCompromissosViewModel>();
        CreateMap<CadastrarCompromissoViewModel, CadastrarCompromissoDto>();
        CreateMap<EditarCompromissoViewModel, EditarCompromissoDto>();

        CreateMap<DetalhesCompromissoDto, EditarCompromissoViewModel>()
            .ForCtorParam("Contatos", opt => opt.MapFrom(_ => new List<OpcaoContatoViewModel>()));

        CreateMap<DetalhesCompromissoDto, ExcluirCompromissoViewModel>();
    }
}