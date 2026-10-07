using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;

namespace AqaTest.Tests.UITests
{
    public class SauceDemoTests : PlaywrightBaseTest
    {
        [Test]
        public async Task SuccessfulAuthentication()
        {
            await Page.GotoAsync("https://www.saucedemo.com");
            var userNameTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" });
            await userNameTextBox.FillAsync("standard_user");
            var passwordTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });
            await passwordTextBox.FillAsync("secret_sauce");
            var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            await loginButton.ClickAsync();
            await Page.WaitForURLAsync("https://www.saucedemo.com/inventory.html");
            Page.Url.Should().Be("https://www.saucedemo.com/inventory.html");
        }
    }
}