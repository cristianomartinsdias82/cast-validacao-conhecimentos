using Assinaturas.Application.Assinaturas.CriarConta;
using Assinaturas.Domain.Assinaturas;
using NSubstitute;
using System.Linq.Expressions;
using Xunit;
using FluentAssertions;

namespace Assinaturas.UnitTests.Application;

public class ContaTests
{
    private IContaRepository _repository;
    private CancellationTokenSource _cts;

    public ContaTests()
    {
        _repository = Substitute.For<IContaRepository>();
        _cts = new CancellationTokenSource();
    }

    [Fact]
    public async Task Criar_ExistingAccount_ShouldReturnBusinessRuleValidationFailure()
    {
        //Arrange
        _repository.CheckExistsAsync(Arg.Any<Expression<Func<Conta, bool>>>(), Arg.Any<CancellationToken>())
                   .Returns(true);

        //Act
        var criarContaResult = await Conta.Criar("Conta A", "Descrição Conta A", _repository, _cts.Token);

        //Assert
        criarContaResult.IsSuccessful.Should().BeFalse();
        criarContaResult.Value.Should().BeNull();
        criarContaResult.Error.IsBusinessRuleValidationError.Should().BeTrue();
        criarContaResult.Error.MessageCode.Should().Be((int)ContaDomainErrorCodes.ContaExistente);
    }

    [Fact]
    public async Task Handle_ExistingAccount_ShouldSuccess()
    {
        //Arrange
        _repository.CheckExistsAsync(Arg.Any<Expression<Func<Conta, bool>>>(), Arg.Any<CancellationToken>())
                   .Returns(false);

        //Act
        const string nomeConta = "Conta A";
        const string descricaoConta = "Conta A";
        var criarContaResult = await Conta.Criar(nomeConta, descricaoConta, _repository, _cts.Token);

        //Assert
        criarContaResult.IsSuccessful.Should().BeTrue();
        criarContaResult.Value.Should().NotBeNull();
        criarContaResult.Value.Id.Should().NotBe(Guid.Empty);
        criarContaResult.Value.Nome.Should().BeEquivalentTo(nomeConta);
        criarContaResult.Value.Descricao.Should().BeEquivalentTo(descricaoConta);
    }
}
