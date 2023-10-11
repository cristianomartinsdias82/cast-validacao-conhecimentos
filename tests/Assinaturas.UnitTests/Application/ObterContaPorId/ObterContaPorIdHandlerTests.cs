using Assinaturas.Domain.Assinaturas;
using NSubstitute;
using System.Linq.Expressions;
using Xunit;
using FluentAssertions;
using Assinaturas.Application.Assinaturas.ObterContaPorId;
using Assinaturas.UnitTests.Shared.ObjectMothers;

namespace Assinaturas.UnitTests.Application.ObterContaPorId;

public class ObterContaPorIdHandlerTests
{
    private ObterContaPorIdHandler _sut;
    private IContaRepository _repository;
    private CancellationTokenSource _cts;

    public ObterContaPorIdHandlerTests()
    {
        _repository = Substitute.For<IContaRepository>();
        _sut = new ObterContaPorIdHandler(_repository);
        _cts = new CancellationTokenSource();
    }

    [Fact]
    public async Task Handle_ExistingAccount_ShouldReturnTheAccount()
    {
        //Arrange
        var contaTeste = await ContaMother.ContaTeste();

        _repository.GetByIdAsync(Arg.Is(contaTeste.Id), Arg.Is(_cts.Token))
                        .Returns(contaTeste);

        //Act
        var handleResult = await _sut.Handle(new(contaTeste.Id), _cts.Token);

        //Assert
        await _repository.Received(1).GetByIdAsync(Arg.Is(contaTeste.Id), Arg.Is(_cts.Token));
        handleResult.Conta.Should().NotBeNull();
        handleResult.Conta!.Value.Id.Should().Be(contaTeste.Id);
    }

    [Fact]
    public async Task Handle_ExistingAccount_ShouldReturnNull()
    {
        //Arrange
        var contaTeste = await ContaMother.ContaTeste();

        _repository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(default(Conta));

        //Act
        var handleResult = await _sut.Handle(new(Guid.Empty), _cts.Token);

        //Assert
        await _repository.Received(1).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        handleResult.Conta.Should().BeNull();
    }
}
