using Assinaturas.Domain.Core;

namespace Assinaturas.Domain.Assinaturas;

public class Conta : Entity, IConta
{
    public string Nome { get; private set; } = default!;

    public string Descricao { get; private set; } = default!;

    protected Conta() { }

    public static Conta Criar(string nome, string descricao)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            Nome = nome,
            Descricao = descricao
        };
    }

    public void Atualizar(string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
    }
}
