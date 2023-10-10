namespace Assinaturas.Infrastructure.Integrations.ViaCep.Core;

public sealed record ViaCepIntegrationSettings
(
    int RequestTimeoutInSecs,
    string BaseUrl,
    string RouteTemplate,
    int RetryAttemptsMaxCount
);