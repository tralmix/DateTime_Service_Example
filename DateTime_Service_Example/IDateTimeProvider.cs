#if NETSTANDARD
using System;
#endif

namespace DateTime_Service_Example
{
    public interface IDateTimeProvider
    {
        DateTime Now();
        DateTime UtcNow();
        DateTime Today();
    }
}
