using System.ComponentModel.DataAnnotations;

namespace Assinaturas.WebUI.Models.Assinaturas;

public sealed record ManterContaViewModel
{
    public Guid? Id { get; set; }

    [Required, StringLength(20)]
    public string Nome { get; set; } = default!;
    
    [Required, StringLength(100)]
    public string Descricao { get; set; } = default!;

    public static ContaDto MapToDto(ManterContaViewModel model)
        => new ContaDto() { Id = model.Id, Nome = model.Nome, Descricao = model.Descricao };
}