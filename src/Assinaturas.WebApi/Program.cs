using Assinaturas.WebApi.Presentation.Core;

namespace Assinaturas.WebApi;

public class Program
{
    public static void Main(string[] args)
        => WebApplication
            .CreateBuilder(args)
            .ConfigureAndBuild()
            .Run();
}