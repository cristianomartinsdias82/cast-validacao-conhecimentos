namespace Assinaturas.Application.Core.Behaviours.Validation;

public struct Failure
{
    public Failure(string message, int? messageCode, IEnumerable<FailureItem> failures)
    {
        Message = message;
        MessageCode = messageCode;
        Failures = failures;
    }

    public Failure(int messageCode, IEnumerable<FailureItem> failures) : this(default!, messageCode, failures) { }

    public Failure(string message, IEnumerable<FailureItem> failures) : this(message, default!, failures) { }

    public int? MessageCode { get; }
    public string Message { get; }
    public IEnumerable<FailureItem> Failures { get; } = Enumerable.Empty<FailureItem>();
}
