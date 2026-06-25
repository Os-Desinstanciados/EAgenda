using AutoMapper;
using EAgenda.WebApp.Modulos.ModuloCompromisso.Aplicacao;

namespace EAgenda.WebApp.Modulos.ModuloCompromisso.Apresentacao;

public class CompromissoProfile : Profile
{
    public CompromissoProfile()
    {
        CreateMap<ListarCompromissosDto, ListarCompromissosViewModel>();
        CreateMap<CadastrarCompromissoViewModel, CadastrarCompromissoDto>();
        CreateMap<EditarCompromissoViewModel, EditarCompromissoDto>();
        CreateMap<DetalhesCompromissoDto, EditarCompromissoViewModel>();
        CreateMap<DetalhesCompromissoDto, ExcluirCompromissoViewModel>();
    }
}