using System;
using System.Threading.Tasks;
using System.Timers;
using ININ.IceLib.People;

namespace CICStatusChanger.CIC.StatusUpdater
{
    public class StatusService : StatusServiceBase, IStatusService
    {
        private bool _isRunning;
        private Timer _timer;
        private int _minuteInterval;
        private readonly IRandomMinuteGenerator _randomMinuteGenerator;
        private readonly IStatusDateTime _statusDateTime;

        public StatusService(IStatusDateTime statusDateTime, IRandomMinuteGenerator randomMinuteGenerator)
        {
            _statusDateTime = statusDateTime;
            _randomMinuteGenerator = randomMinuteGenerator;
        }

        public void Enable()
        {
            _isRunning = true;
            SetupTimer();
        }

        private void SetupTimer()
        {
            _minuteInterval = 60 * 1000;
            _timer = new Timer(_minuteInterval); // milliseconds to one minute
            _timer.Elapsed += CheckForTime_Elapsed;
            _timer.Enabled = true;
        }

        private void CheckForTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_isRunning)
            {
                var dateTime = _randomMinuteGenerator.GetRandomTimeInInterval(5);
                if (_statusDateTime.IsInWorkingHoursTime(dateTime) && !GetUserStatus().Equals(AvailableNoAcd))
                {
                    SetUserStatus(AvailableNoAcd);
                }
                else if (_statusDateTime.IsInLunchTime(dateTime) && !GetUserStatus().Equals(AtLunch))
                {
                    SetUserStatus(AtLunch);
                }
                else if (_statusDateTime.IsInGoneHomeTime(dateTime) && !GetUserStatus().Equals(GoneHome))
                {
                    SetUserStatus(GoneHome);
                }
            }
        }

        public void Disable()
        {
            _isRunning = false;
            _timer.Stop();
        }
    }
}