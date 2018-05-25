using System;

namespace CICStatusChanger.CIC.StatusUpdater
{
    public class RandomMinuteGenerator : IRandomMinuteGenerator
    {
        private readonly Random _random = new Random();
        private int _currentRandomMintues = 0;
        private int CurrentDay { get; set; } = -1;
        private readonly ITimeProvider _timeProvider;

        public RandomMinuteGenerator(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }


        public DateTime GetRandomTimeInInterval(int intervalMinutes)
        {
            if (intervalMinutes < 0) throw new IndexOutOfRangeException();
            if (CurrentDay != _timeProvider.Today.Day)
            {
                CurrentDay = _timeProvider.Today.Day;
                _currentRandomMintues = _random.Next(0, intervalMinutes);
            }
            return _timeProvider.Now.AddMinutes(_currentRandomMintues);
        }
    }
}