using Microsoft.Playwright;
using zCustodiaUi.locators.login;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.login
{
    public class LoginPage
    {
        Utils utils;
        LoginElements el = new LoginElements();
        private readonly IPage page;
        public LoginPage(IPage page)
        {
            this.page = page;
            utils = new Utils(page);
        }

        public async Task DoLogin()
        {
            await utils.Write(el.EmailField, "al@zitec.ai", "write email user on email Field to do Login");
            await utils.Write(el.PasswordField, "12345678", "write password user on password Field to do Login");
            await utils.Click(el.SubmitButton, "Click on submit button to do Login");
            if (page.Url.Contains("dev"))
            {
                await utils.ValidateUrl("https://custodia-dev.idsf.com.br/home/dashboard", "Validate URL at home Page in dev environment");
                await utils.Click(el.DeveloperEnvironment, "Set developer Environment");
            }
            else if (page.Url.Contains("staging"))
            {
                await utils.ValidateUrl("https://custodia-staging.idsf.com.br/home/dashboard", "Validate URL at home Page in stg environment");
                await utils.Click(el.CustodiaEnvironment, "Set Custodia Environment");
            }
            else
            {
                await utils.ValidateUrl("https://custodia.idsf.com.br/home/dashboard", "Validate URL at home Page in prod environment");
                await utils.Click(el.CustodiaEnvironment, "Set custodia Environment");
            }
            await utils.Click(el.NextButton, "Click on the button post set the environment");
        }

        public async Task NegativeLogin(string testCase)
        {
            if (testCase == "invalid email")
            {
                await utils.Write(el.EmailField, "al@zitecai", "write invalid email user on email Field to do Login");
                await utils.Write(el.PasswordField, "12345678", "write password user on password Field to do Login");
                await utils.Click(el.SubmitButton, "Click on submit button to do Login");
                await utils.ValidateReturnedMessageIsVisible(el.ErrorMessage, "Validate Error message is present, given that i try should login with invalid email");
            }
            else if (testCase == "invalid password")
            {
                await utils.Write(el.EmailField, "al@zitec.ai", "write email user on email Field to do Login");
                await utils.Write(el.PasswordField, "invalid", "write invalid password user on password Field to do Login");
                await utils.Click(el.SubmitButton, "Click on submit button to do Login");
                await utils.ValidateReturnedMessageIsVisible(el.ErrorMessage, "Validate Error message is present, given that i try should login with invalid password");
            }
        }



    }
}
