using Assinaturas.Domain.Assinaturas;
using NSubstitute;
using System.Linq.Expressions;

namespace Assinaturas.UnitTests.Shared.ObjectMothers;

internal static class ContaMother
{
    public async static Task<Conta> ContaTeste()
    {
        var fakeContaRepository = Substitute.For<IContaRepository>();
        fakeContaRepository.CheckExistsAsync(Arg.Any<Expression<Func<Conta, bool>>>(), Arg.Any<CancellationToken>())
                           .Returns(false);

        var contaFake = await Conta.Criar("Conta Teste", "Descrição Conta Teste", fakeContaRepository, CancellationToken.None);

        return contaFake.Value;
    }
}