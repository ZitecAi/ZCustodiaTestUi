using Microsoft.Playwright;
using zCustodiaUi.pages.login;

namespace zCustodiaUi.workflows.login
{
    public class LoginWorkflow
    {
        private readonly LoginPage _loginPage;

        public LoginWorkflow(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        public async Task DoLogin()
        {
            await _loginPage.DoLogin();
        }

        public async Task NegativeLogin(string testCase)
        {
            await _loginPage.NegativeLogin(testCase);
        }
    }
}
