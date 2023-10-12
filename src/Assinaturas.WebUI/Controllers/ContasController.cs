using Assinaturas.WebUI.Core.Integrations.AssinaturasApi;
using Assinaturas.WebUI.Models.Assinaturas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Assinaturas.WebUI.Controllers;

public sealed class ContasController : Controller
{
    private readonly IAssinaturasApiServiceClient _assinaturasApiServiceClient;

    private readonly IStringLocalizer<ContasController> _stringLocalizer;

    public ContasController(
        IStringLocalizer<ContasController> stringLocalizer,
        IAssinaturasApiServiceClient assinaturasApiServiceClient)
    {
        _stringLocalizer = stringLocalizer;
        _assinaturasApiServiceClient = assinaturasApiServiceClient;
    }

    [ResponseCache(Duration = 10/*300*/, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var contas = await _assinaturasApiServiceClient.ObterContasAsync(cancellationToken);

        return View(nameof(Index), new ListarContasViewModel(contas));
    }

    [HttpPost]
    public async Task<IActionResult> Remover(Guid id, CancellationToken cancellationToken)
    {
        if (!await _assinaturasApiServiceClient.RemoverContaAsync(id, cancellationToken))
            return HandleUnsuccessfulOperation();

        TempData["SuccessMessage"] = _stringLocalizer["ContaRemovidaComSucesso"].Value;
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Manter(Guid? id, CancellationToken cancellationToken)
    {
        if (!id.HasValue)
            return View(new ManterContaViewModel());

        var conta = await _assinaturasApiServiceClient.ObterContaPorIdAsync(id.Value, cancellationToken);
        if (conta is null)
        {
            TempData["ErrorMessage"] = _stringLocalizer["FalhaAoSalvarOsDados"].Value;
            return RedirectToAction(nameof(Index));
        }

        return View(ContaDto.MapToViewModel(conta));
    }

    [HttpPost]
    public async Task<IActionResult> Manter(ManterContaViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return View(model);

        var operationSuccessful = false;
        if (model.Id.HasValue)
            operationSuccessful = await _assinaturasApiServiceClient.AtualizarContaAsync(ManterContaViewModel.MapToDto(model), cancellationToken);
        else
            operationSuccessful = await _assinaturasApiServiceClient.RegistrarContaAsync(ManterContaViewModel.MapToDto(model), cancellationToken);

        if (!operationSuccessful)
            return HandleUnsuccessfulOperation();

        TempData["SuccessMessage"] = _stringLocalizer["DadosSalvosComSucesso"].Value;
        return RedirectToAction(nameof(Index));
    }

    private IActionResult HandleUnsuccessfulOperation()
        => Redirect("~/home/error");
}
