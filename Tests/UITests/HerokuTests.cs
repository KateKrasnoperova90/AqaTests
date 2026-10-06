using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;

namespace AqaTest.Tests.UITests
{
    public class HerokuTests : PlaywrightBaseTest
    {
        [Test]
        public async Task CheckBoxTest()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/checkboxes", new PageGotoOptions
            {
                Timeout = 60000
            });
            var first = Page.Locator("input[type='checkbox']").Nth(0);
            await first.CheckAsync();
            (await first.IsCheckedAsync()).Should().BeTrue();
        }
    }
}