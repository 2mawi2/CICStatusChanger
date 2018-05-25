using System.Security;
using CICStatusChanger.Common;
using ININ.IceLib.Connection;

namespace CICStatusChanger.CIC.StatusUpdater
{
    public static class SessionFactory
    {
        private const string Host = "indyhqic"; //isupport.i3domain.inin.com

        public static Session Get()
        {
            var session = Connect();
            return session;
        }

        private static Session Connect()
        {
            var session = new Session();
            session.Connect(
                new SessionSettings
                {
                    ApplicationName = "StatusChangerApp",
                    ApplicationTraceId = "StatusChangerAppId",
                },
                new HostSettings(new HostEndpoint
                {
                    Host = Host
                }),
                new WindowsAuthSettings(),
                new StationlessSettings());
            session.AutoReconnectEnabled = true;
            return session;
        }
    }
}