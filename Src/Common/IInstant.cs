namespace Isitar.DoenerOrder.CleanArchitecture.Common
{
    using NodaTime;

    /// <summary>
    /// Interface representing an instant on the earth (e.g. UtcNow)
    /// </summary>
    public interface IInstant
    {
        Instant Now { get; }
    }
}