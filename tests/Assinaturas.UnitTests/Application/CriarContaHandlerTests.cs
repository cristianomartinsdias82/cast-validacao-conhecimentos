using Assinaturas.Application.Assinaturas.CriarConta;
using Assinaturas.Domain.Assinaturas;
using NSubstitute;
using System.Linq.Expressions;
using Xunit;
using FluentAssertions;

namespace Assinaturas.UnitTests.Application;

public class CriarContaHandlerTests
{
    private CriarContaHandler _sut;
    private IContaRepository _repository;
    private CancellationTokenSource _cts;

    public CriarContaHandlerTests()
    {
        _repository = Substitute.For<IContaRepository>();
        _sut = new CriarContaHandler(_repository);
        _cts = new CancellationTokenSource();
    }

    [Fact]
    public async Task Handle_ExistingAccount_ShouldFail()
    {
        //Arrange
        _repository.CheckExistsAsync(Arg.Any<Expression<Func<Conta, bool>>>(), Arg.Any<CancellationToken>())
                   .Returns(true);

        //Act
        var handleResult = await _sut.Handle(new(), _cts.Token);

        //Assert
        handleResult.IsSuccessful.Should().BeFalse();
        await _repository.Received(0).AddAsync(Arg.Any<Conta>(), _cts.Token);
    }

    [Fact]
    public async Task Handle_ExistingAccount_ShouldSuccess()
    {
        //Arrange
        var criarContaContaRequest = new CriarContaRequest("Conta A", "Descrição da Conta A");
        _repository.CheckExistsAsync(Arg.Any<Expression<Func<Conta, bool>>>(), Arg.Any<CancellationToken>())
                   .Returns(false);

        //Act
        var handleResult = await _sut.Handle(criarContaContaRequest, _cts.Token);

        //Assert
        handleResult.IsSuccessful.Should().BeTrue();
        handleResult.Value.Conta.Nome.Should().BeEquivalentTo(criarContaContaRequest.Nome);
        handleResult.Value.Conta.Descricao.Should().BeEquivalentTo(criarContaContaRequest.Descricao);
        await _repository.Received(1).AddAsync(Arg.Any<Conta>(), _cts.Token);
    }
}
