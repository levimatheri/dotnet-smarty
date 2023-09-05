using System.ComponentModel;

namespace Smarty.Net.Core.Shared;
/// <summary>
/// Base type for all client option types, exposes various common client options like <see cref="Diagnostics"/>, <see cref="Retry"/>, <see cref="Transport"/>.
/// </summary>
public abstract class ClientOptions
{
    /// <summary>
    /// Creates a new instance of <see cref="ClientOptions"/>.
    /// </summary>
    protected ClientOptions()
    {
    }

    /// <summary>
    /// Gets the client retry options.
    /// </summary>
    public RetryOptions Retry { get; }

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => base.Equals(obj);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string? ToString() => base.ToString();
}
