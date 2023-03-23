﻿#if NETSTANDARD
using System;
#endif
namespace DateTime_Service_Example
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now() => DateTime.Now;

        public DateTime UtcNow() => DateTime.UtcNow;

        public DateTime Today() => DateTime.Today;
    }
}
