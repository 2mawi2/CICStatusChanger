using System;

namespace CICStatusChanger.CIC.StatusUpdater
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}