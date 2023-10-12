namespace Assinaturas.WebUI.Core.Integrations.AssinaturasApi;

public sealed class AssinaturasApiSettings
{
    public string BaseUrl { get; init; } = default!;
    public string Endpoint { get; init; } = default!;
    public string RetryAttemptsMaxCount { get; init; } = default!;
    public int RequestTimeoutInSeconds { get; init; } = default!;
}