using System;
using CICStatusChanger.CIC.StatusUpdater;
using Moq;

internal static class TestUtils
{
    public static ITimeProvider MockTimeProvider(DateTime dateTimeOverride = default(DateTime))
    {
        var time = dateTimeOverride.Equals(default(DateTime)) ? new DateTime(2017, 3, 22, 15, 30, 20) : dateTimeOverride;
        var mock = new Mock<ITimeProvider>();
        mock.Setup(i => i.Now).Returns(time);
        mock.Setup(i => i.Today).Returns(time.Date);
        return mock.Object;
    }
}