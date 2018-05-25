using System;
using ININ.IceLib.Connection;
using ININ.IceLib.People;


namespace CICStatusChanger.CIC.StatusUpdater
{
    public class StatusServiceBase : IDisposable
    {
        private readonly Session _session;

        protected const string AwayFromDesk = "Away from desk";
        protected const string AvailableNoAcd = "Available, No ACD";
        protected const string GoneHome = "Gone Home";
        protected const string AtLunch = "At Lunch";

        protected StatusServiceBase()
        {
            _session = SessionFactory.Get();
        }

        protected void SetUserStatus(string statusId)
        {
            var peopleManager = PeopleManager.GetInstance(_session);
            var statusList = new StatusMessageList(peopleManager);
            statusList.StartWatching();
            var userStatusUpdate = new UserStatusUpdate(peopleManager, _session.UserId)
            {
                StatusMessageDetails = statusList[statusId]
            };
            userStatusUpdate.UpdateRequest();
            statusList.StopWatching();
        }

        protected string GetUserStatus()
        {
            var peopleManager = PeopleManager.GetInstance(_session);
            var cache = new UserStatusList(peopleManager);
            return cache.GetUserStatus(_session.UserId).StatusMessageDetails.Id;
        }

        #region IDisposable

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _session?.Disconnect();
                _session?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}