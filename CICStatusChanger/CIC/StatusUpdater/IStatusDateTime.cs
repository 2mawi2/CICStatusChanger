using System;

namespace CICStatusChanger.CIC.StatusUpdater
{
    public interface IStatusDateTime
    {
        DateTime AtTime(int hours, int minutes, int seconds);
        bool IsInGoneHomeTime(DateTime dateTime);
        bool IsInLunchTime(DateTime dateTime);
        bool IsInWorkingHoursTime(DateTime dateTime);
    }
}