using System.Text.Json;

namespace Assinaturas.WebUI.Models.Assinaturas;

public sealed record ContaDto
{
    public Guid? Id { get; init; }
    public string Nome { get; init; } = default!;
    public string Descricao { get; init; } = default!;

    public static ManterContaViewModel MapToViewModel(ContaDto conta)
        => new ManterContaViewModel { Id = conta.Id, Nome = conta.Nome, Descricao = conta.Descricao };
}