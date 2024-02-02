using Application._Common;

namespace Infrastructure._Common;

internal class ClockService : IClockService
{
    public DateTime Now => DateTime.Now;
}