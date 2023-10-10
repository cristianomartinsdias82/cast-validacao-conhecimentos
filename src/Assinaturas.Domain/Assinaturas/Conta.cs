using Assinaturas.Domain.Core;
using Assinaturas.SharedKernel.Results;

namespace Assinaturas.Domain.Assinaturas;

public class Conta : Entity, IConta
{
    public string Nome { get; private set; } = default!;

    public string Descricao { get; private set; } = default!;

    protected Conta() { }

    public static async ValueTask<Result<Conta, Failure>> Criar(
        string nome,
        string descricao,
        IContaRepository repository,
        CancellationToken cancellationToken = default)
    {
        var contaExists = await repository.CheckExistsAsync(ct => ct.Nome.Contains(nome), cancellationToken);
        if (contaExists)
            return Failure.BusinessRuleValidationError((int)ContaDomainErrorCodes.ContaExistente, default!);

        var novaConta = new Conta()
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            Descricao = descricao
        };

        await repository.AddAsync(novaConta, cancellationToken);

        return novaConta;
    }

    public void Atualizar(string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
    }
}
