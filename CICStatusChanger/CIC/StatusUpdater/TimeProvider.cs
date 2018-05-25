using System;

namespace CICStatusChanger.CIC.StatusUpdater
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime Now => DateTime.Now;
        public DateTime Today => DateTime.Today;
    }
}