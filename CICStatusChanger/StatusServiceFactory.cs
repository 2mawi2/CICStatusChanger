using CICStatusChanger.CIC.StatusUpdater;

namespace CICStatusChanger
{
    public static class StatusServiceFactory
    {
        public static StatusService Get()
        {
            var timeProvider = new TimeProvider();
            var statusDateTime = new StatusDateTime(timeProvider);
            var randomMinuteGenerator = new RandomMinuteGenerator(timeProvider);
            var statusChangerService = new StatusService(statusDateTime, randomMinuteGenerator);
            return statusChangerService;
        }
    }
}