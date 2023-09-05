using Microsoft.Extensions.DependencyInjection;

namespace Smarty.Net.Core.Shared;
public static class SmartyClientServiceCollectionExtensions
{
    public static void AddSmartyClients(this IServiceCollection services, Action<SmartyClientFactoryBuilder> configureClients)
    {
        services.AddOptions();
        configureClients(new SmartyClientFactoryBuilder(services));
    }
}
