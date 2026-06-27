using AutoMapper;
using FluentResults;
using EAgenda.WebApp.Compartilhado.Apresentacao.Extensions;
using EAgenda.WebApp.Modulos.ModuloDespesa.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace EAgenda.WebApp.Modulos.ModuloDespesa.Apresentacao;

public class DespesaController(ServicoDespesa servicoDespesa, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarDespesasDto> dtos = servicoDespesa.SelecionarTodos();
        List<ListarDespesasViewModel> listarVms = mapeador.Map<List<ListarDespesasViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarDespesaViewModel cadastrarVm = new CadastrarDespesaViewModel(
            string.Empty,
            DateTime.Now,
            0,
            string.Empty            
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarDespesaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarDespesaDto dto = mapeador.Map<CadastrarDespesaDto>(cadastrarVm);
        Result resultado = servicoDespesa.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesDespesaDto> resultado = servicoDespesa.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        EditarDespesaViewModel editarVm =
            mapeador.Map<EditarDespesaViewModel>(resultado.Value);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarDespesaViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarDespesaDto dto = mapeador.Map<EditarDespesaDto>(editarVm);
        Result resultado = servicoDespesa.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesDespesaDto> resultado = servicoDespesa.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ExcluirDespesaViewModel excluirVm = mapeador.Map<ExcluirDespesaViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirDespesaViewModel excluirVm)
    {
        Result resultado = servicoDespesa.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }    
}
