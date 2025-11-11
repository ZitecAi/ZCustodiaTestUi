using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using zCustodiaUi.pages.login;
using zCustodiaUi.runner;

namespace zCustodiaUi.tests.login
{
    [AllureNUnit]
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureOwner("Levi")]
    [AllureSeverity(SeverityLevel.critical)]
    [Category("Critícity: Critical")]
    [Category("Regression Tests")]
    [AllureSuite("Login UI")]
    public class LoginTests : TestBase
    {
        private IPage page;

        [SetUp]
        [AllureBefore]
        public async Task Setup()
        {
            page = await OpenBrowserAsync();
        }
        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Deve Realizar login com credenciais válidas")]
        public async Task Should_Do_Login_With_Valid_Credentials()
        {
            var login = new LoginPage(page);
            await login.DoLogin();
        }
        [Test, Order(2)]
        [AllureName("Não Deve Realizar login com Email inválidos")]
        public async Task Do_Not_Should_Do_Login_With_Invalid_Email()
        {
            var login = new LoginPage(page);
            await login.NegativeLogin("invalid email");
        }
        [Test, Order(3)]
        [AllureName("Não Deve Realizar login com Senha inválida")]
        public async Task Do_Not_Should_Do_Login_With_Invalid_Password()
        {
            var login = new LoginPage(page);
            await login.NegativeLogin("invalid password");
        }

    }
}
