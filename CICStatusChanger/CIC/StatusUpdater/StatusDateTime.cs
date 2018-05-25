using System;

namespace CICStatusChanger.CIC.StatusUpdater
{
    public class StatusDateTime : IStatusDateTime
    {
        private readonly ITimeProvider _timeProvider;

        public StatusDateTime(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public bool IsInGoneHomeTime(DateTime dateTime)
            => !IsInWorkingHoursTime(dateTime) && !IsInLunchTime(dateTime) || IsInWeekend(dateTime);

        public bool IsInWorkingHoursTime(DateTime dateTime)
            => dateTime <= AtTime(17, 30, 0) && dateTime >= AtTime(8, 30, 0)
               && !IsInLunchTime(dateTime) && !IsInWeekend(dateTime);

        public bool IsInLunchTime(DateTime dateTime)
            => dateTime >= AtTime(12, 0, 0) && dateTime <= AtTime(13, 0, 0) && !IsInWeekend(dateTime);


        private static bool IsInWeekend(DateTime dateTime)
        {
            return dateTime.DayOfWeek.Equals(DayOfWeek.Saturday)
                   || dateTime.DayOfWeek.Equals(DayOfWeek.Sunday);
        }

        public DateTime AtTime(int hours, int minutes, int seconds)
        {
            var time = _timeProvider.Today;
            return new DateTime(time.Year, time.Month, time.Day, hours, minutes, seconds);
        }
    }
}