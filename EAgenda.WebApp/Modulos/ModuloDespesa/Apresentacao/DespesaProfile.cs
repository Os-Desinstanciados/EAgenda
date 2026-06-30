using AutoMapper;
using EAgenda.WebApp.Modulos.ModuloDespesa.Aplicacao;

namespace EAgenda.WebApp.Modulos.ModuloDespesa.Apresentacao;

public class DespesaProfile : Profile
{
    public DespesaProfile()
    {
        CreateMap<OpcaoCategoriaDto, OpcaoCategoriaViewModel>(); 
        CreateMap<ListarDespesasDto, ListarDespesasViewModel>();
        CreateMap<CadastrarDespesaViewModel, CadastrarDespesaDto>();
        CreateMap<EditarDespesaViewModel, EditarDespesaDto>();
        CreateMap<DetalhesDespesaDto, EditarDespesaViewModel>()
            .ForCtorParam("Categorias", opt => opt.MapFrom(_ => new List<OpcaoCategoriaViewModel>()));        
        CreateMap<DetalhesDespesaDto, ExcluirDespesaViewModel>();
    }
}
