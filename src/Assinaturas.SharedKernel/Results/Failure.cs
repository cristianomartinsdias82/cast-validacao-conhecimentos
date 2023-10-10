namespace Assinaturas.SharedKernel.Results;

public struct Failure
{
    public Failure(string message, int? messageCode, FailureTypes failureType, IEnumerable<FailureItem> failures)
    {
        Message = message;
        MessageCode = messageCode;
        FailureType = failureType;
        Failures = failures;
    }

    public Failure(int messageCode, FailureTypes failureType, IEnumerable<FailureItem> failures) : this(default!, messageCode, failureType, failures) { }

    public Failure(string message, FailureTypes failureType, IEnumerable<FailureItem> failures) : this(message, default!, failureType, failures) { }

    public FailureTypes FailureType { get; }
    public int? MessageCode { get; }
    public string Message { get; }
    public IEnumerable<FailureItem> Failures { get; } = Enumerable.Empty<FailureItem>();

    public bool IsBusinessRuleValidationError => FailureType == FailureTypes.BusinessRuleValidationError;
    public bool IsInputValidationError => FailureType == FailureTypes.InputValidationError;

    public static Failure InputValidationError(int messageCode, IEnumerable<FailureItem> failures)
        => new Failure(messageCode, FailureTypes.InputValidationError, failures);

    public static Failure InputValidationError(string message, IEnumerable<FailureItem> failures)
        => new Failure(message, FailureTypes.InputValidationError, failures);

    public static Failure BusinessRuleValidationError(int messageCode, IEnumerable<FailureItem> failures)
        => new Failure(messageCode, FailureTypes.BusinessRuleValidationError, failures);
}
