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

        [Test]
        public async Task ForAuthentication()
        {
            await Page.GotoAsync("https://the-internet.herokuapp.com/login");
            var userNameTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" });
            await userNameTextBox.FillAsync("wrong");
            var passwordTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });
            await passwordTextBox.FillAsync("wrong");
            var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            await loginButton.ClickAsync();
            var errorMessageLabel = Page.Locator("//div[@id='flash']");
            var errorMessage = await errorMessageLabel.InnerTextAsync();
            errorMessage.Should().Contain("Your username is invalid!");
        }
    }   
}