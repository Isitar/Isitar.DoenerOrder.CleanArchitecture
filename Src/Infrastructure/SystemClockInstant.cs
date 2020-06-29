namespace Isitar.DoenerOrder.CleanArchitecture.Infrastructure
{
    using System.Drawing;
    using Common;
    using NodaTime;

    public class SystemClockInstant: IInstant
    {
        public Instant Now => SystemClock.Instance.GetCurrentInstant();
    }
}