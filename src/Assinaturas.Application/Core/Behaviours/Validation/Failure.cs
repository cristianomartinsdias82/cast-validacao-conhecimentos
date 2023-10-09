namespace Assinaturas.Application.Core.Behaviours.Validation;

public struct Failure
{
    public Failure(string message, IEnumerable<FailureItem> failures)
    {
        Message = message;
        Failures = failures;
    }

    public string Message { get; }
    public IEnumerable<FailureItem> Failures { get; } = Enumerable.Empty<FailureItem>();
}
