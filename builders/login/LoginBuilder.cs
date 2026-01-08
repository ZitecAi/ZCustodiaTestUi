using zCustodiaUi.pages.login;

namespace zCustodiaUi.builders.login
{
    public class LoginBuilder : TestBuilder
    {
        private readonly LoginPage _loginPage;

        public LoginBuilder(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        public LoginBuilder DoLogin()
        {
            AddStep(async () => await _loginPage.DoLogin());
            return this;
        }

        public LoginBuilder NegativeLogin(string testCase)
        {
            AddStep(async () => await _loginPage.NegativeLogin(testCase));
            return this;
        }
    }
}
