using System;

namespace CICStatusChanger.CIC.StatusUpdater
{
    public interface IRandomMinuteGenerator
    {
        DateTime GetRandomTimeInInterval(int intervalMinutes);
    }
}