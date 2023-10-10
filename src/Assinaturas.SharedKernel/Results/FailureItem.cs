namespace Assinaturas.SharedKernel.Results;

public struct FailureItem
{
    public FailureItem(string fieldOrProperty, string errorCode, string message)
    {
        FieldOrProperty = fieldOrProperty;
        ErrorCode = errorCode;
        Message = message;
    }

    public string FieldOrProperty { get; }
    public string ErrorCode { get; }
    public string Message { get; }
}
