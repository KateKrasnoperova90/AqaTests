using Microsoft.Extensions.DependencyInjection;
using AqaTest.Interfaces;
using AqaTest.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AqaTest.Tests
{
    public class UserNotifierTest
    {
        [Test]
        public void TestNotifyViaDI()
        {
            var services = new ServiceCollection();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<UserNotifier>();

            var provider = services.BuildServiceProvider();
            var notifier = provider.GetService<UserNotifier>();

            notifier.Should().NotBeNull();
            notifier.Notify(42);
        }
    }
}