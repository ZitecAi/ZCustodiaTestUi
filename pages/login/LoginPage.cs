using Microsoft.Playwright;
using zCustodiaUi.data.login;
using zCustodiaUi.locators.login;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.login
{
    public class LoginPage
    {
        Utils _utils;
        LoginElements _el = new LoginElements();
        private readonly LoginData _data = new LoginData();
        private readonly IPage _page;
        public LoginPage(IPage _page)
        {
            this._page = _page;
            _utils = new Utils(_page);
        }

        public async Task DoLogin()
        {
            await _utils.Write(_el.EmailField, _data.Email, "write email user on email Field to do Login");
            await _utils.Write(_el.PasswordField, _data.Password, "write password user on password Field to do Login");
            await _utils.Click(_el.SubmitButton, "Click on submit button to do Login");
            if (_page.Url.Contains("dev"))
            {
                await _utils.ValidateUrl("https://custodia-dev.idsf.com.br/home/dashboard", "Validate URL at home Page in dev environment");
                await _utils.Click(_el.DeveloperEnvironment, "Set developer Environment");
            }
            else if (_page.Url.Contains("staging"))
            {
                await _utils.ValidateUrl("https://custodia-staging.idsf.com.br/home/dashboard", "Validate URL at home Page in stg environment");
                await _utils.Click(_el.CustodiaEnvironment, "Set Custodia Environment");
            }
            else
            {
                await _utils.ValidateUrl("https://custodia.idsf.com.br/home/dashboard", "Validate URL at home Page in prod environment");
                await _utils.Click(_el.CustodiaEnvironment, "Set custodia Environment");
            }
            await _utils.Click(_el.NextButton, "Click on the button post set the environment");
        }

        public async Task NegativeLogin(string testCase)
        {
            if (testCase == "invalid email")
            {
                await _utils.Write(_el.EmailField, _data.InvalidEmail, "write invalid email user on email Field to do Login");
                await _utils.Write(_el.PasswordField, _data.Password, "write password user on password Field to do Login");
                await _utils.Click(_el.SubmitButton, "Click on submit button to do Login");
                await _utils.ValidateTextIsVisibleOnScreen(_el.ErrorMessage, "Validate Error message is present, given that i try should login with invalid email");
            }
            else if (testCase == "invalid password")
            {
                await _utils.Write(_el.EmailField, _data.Email, "write email user on email Field to do Login");
                await _utils.Write(_el.PasswordField, _data.InvalidPassword, "write invalid password user on password Field to do Login");
                await _utils.Click(_el.SubmitButton, "Click on submit button to do Login");
                await _utils.ValidateTextIsVisibleOnScreen(_el.ErrorMessage, "Validate Error message is present, given that i try should login with invalid password");
            }
        }



    }
}
