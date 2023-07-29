namespace integration;

public interface ISmartyApi
{
    Task RunAsync(CancellationToken cancellationToken = default);
}
