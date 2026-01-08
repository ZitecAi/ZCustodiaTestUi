// AssignorsTests

using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using zCustodiaUi.builders.register;
using zCustodiaUi.data.register;
using zCustodiaUi.locators.modules;
using zCustodiaUi.locators.register;
using zCustodiaUi.pages.login;
using zCustodiaUi.pages.register;
using zCustodiaUi.runner;
using zCustodiaUi.utils;

namespace zCustodiaUi.tests.register
{
    [AllureNUnit]
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureOwner("Levi")]
    [AllureSeverity(SeverityLevel.critical)]
    [Category("Critícity: High")]
    [Category("Regression Tests")]
    [AllureSuite("Assignors UI")]
    public class AssignorsTests : TestBase
    {

        private Utils _util;
        private readonly ModulesElements _mod = new ModulesElements();
        private readonly AssignorsElements _el = new AssignorsElements();

        [SetUp]
        [AllureBefore]
        public async Task SetUp()
        {
            _page = await OpenBrowserAsync();
            _util = new Utils(_page);
            var login = new LoginPage(_page);
            await login.DoLogin();
            await _util.Click(_mod.MainMenu, "Open main menu to extend options");
            await _util.Click(_mod.RegisterPage, "Open Register module");

            await _util.Click(_el.AssignorPage, "Click on assignor page to visit page");
        }

        [TearDown]
        [AllureAfter]
        public async Task TearDown()
        {
            await CloseBrowserAsync();
        }

        [Test, Order(1)]
        [AllureName("Should Register Assignors")]
        public async Task Should_Register_Assignor()
        {
            var assignorsPage = new AssignorsPage(_page);
            await new AssignorsBuilder(assignorsPage)
                .ClickOnNewButtonAndRegisterByForm()
                .FillGeneralData()
                .GoToForm("Dados da Conta")
                .FillAccountData()
                .AddAccount()
                .GoToForm("Representante")
                .FillRepresentatives()
                .AddRepresentative()
                .ClickOnSaveButton()
                .ValidateSuccessMessage()
                .Execute();
        }

        [Test, Order(2)]
        [AllureName("Should Update Assignor")]
        public async Task Should_Update_Assignor()
        {
            var assignorsPage = new AssignorsPage(_page);
            await new AssignorsBuilder(assignorsPage)
                .UpdateAssignor()
                .Execute();
        }

        [Test, Order(3)]
        [AllureName("Should Consult and Delete Assignor")]
        public async Task Should_Consult_And_Delete_Assignor()
        {
            var assignorsPage = new AssignorsPage(_page);
            await new AssignorsBuilder(assignorsPage)
                .ConsultAssignorAndDelete()
                .Execute();
        }

        [Test, Order(4)]
        [AllureName("Shouldn´t Register Assignor with empty Name")]
        public async Task Shouldnt_Register_Assignor_With_empty_Name()
        {
            var dataTest = new AssignorsData { NameAssignor = string.Empty };
            var assignorsPage = new AssignorsPage(_page, dataTest);
            await new AssignorsBuilder(assignorsPage)
                .ClickOnNewButtonAndRegisterByForm()
                .FillGeneralData()
                .GoToForm("Dados da Conta")
                .FillAccountData()
                .AddAccount()
                .GoToForm("Representante")
                .FillRepresentatives()
                .AddRepresentative()
                .ValidateSaveButtonDisabled()
                .Execute();
        }

        [Test, Order(5)]
        [AllureName("Shouldn´t Register Assignor with CNPJ 10 Chars")]
        public async Task Shouldnt_Register_Assignor_With_CPF_10_Chars()
        {
            var dataTest = new AssignorsData { CpfAssignor = "4095611480" };
            var assignorsPage = new AssignorsPage(_page, dataTest);
            await new AssignorsBuilder(assignorsPage)
                .ClickOnNewButtonAndRegisterByForm()
                .FillGeneralData(true)
                .GoToForm("Dados da Conta")
                .FillAccountData()
                .AddAccount()
                .GoToForm("Representante")
                .FillRepresentatives()
                .AddRepresentative()
                .ValidateSaveButtonDisabled()
                .Execute();
        }

        [Test, Order(6)]
        [AllureName("Shouldn´t Register Assignor with CNPJ 13 Chars")]
        public async Task Shouldnt_Register_Assignor_With_CNPJ_13_Chars()
        {
            var dataTest = new AssignorsData { CnpjAssignor = "5272117500019" };
            var assignorsPage = new AssignorsPage(_page, dataTest);
            await new AssignorsBuilder(assignorsPage)
                .ClickOnNewButtonAndRegisterByForm()
                .FillGeneralData()
                .GoToForm("Dados da Conta")
                .FillAccountData()
                .AddAccount()
                .GoToForm("Representante")
                .FillRepresentatives()
                .AddRepresentative()
                .ValidateSaveButtonDisabled()
                .Execute();
        }

        [Test, Order(7)]
        public async Task Shouldnt_Register_Assignor_With_CNPJ_already_registered()
        {
            var dataTest = new AssignorsData { CnpjAssignor = "24537861000171" };
            var assignorsPage = new AssignorsPage(_page, dataTest);
            await new AssignorsBuilder(assignorsPage)
                .ClickOnNewButtonAndRegisterByForm()
                .FillGeneralData()
                .GoToForm("Dados da Conta")
                .FillAccountData()
                .AddAccount()
                .GoToForm("Representante")
                .FillRepresentatives()
                .AddRepresentative()
                .ClickOnSaveButton()
                .Execute();
        }

        [Test, Order(8)]
        [AllureName("Shouldn´t Register Assignor with Invalid Email Whitout 'at'")]
        public async Task Shouldnt_Register_Assignor_With_Invalid_Email()
        {
            var dataTest = new AssignorsData { Email = "alvesleviicloud.com" };
            var assignorsPage = new AssignorsPage(_page, dataTest);
            await new AssignorsBuilder(assignorsPage)
                .ClickOnNewButtonAndRegisterByForm()
                .FillGeneralData()
                .GoToForm("Dados da Conta")
                .FillAccountData()
                .AddAccount()
                .GoToForm("Representante")
                .FillRepresentatives()
                .AddRepresentative()
                .ValidateSaveButtonDisabled()
                .Execute();
        }

        [Test, Order(9)]
        [AllureName("Shouldn´t Register Assignor with Invalid Email Whitout domain")]
        public async Task Shouldnt_Register_Assignor_With_Invalid_Email_No_domain()
        {
            var dataTest = new AssignorsData { Email = "alveslevi@icloud" };
            var assignorsPage = new AssignorsPage(_page, dataTest);
            await new AssignorsBuilder(assignorsPage)
                .ClickOnNewButtonAndRegisterByForm()
                .FillGeneralData()
                .GoToForm("Dados da Conta")
                .FillAccountData()
                .AddAccount()
                .GoToForm("Representante")
                .FillRepresentatives()
                .AddRepresentative()
                .ValidateSaveButtonDisabled()
                .Execute();
        }

        [Test, Order(10)]
        [AllureName("Shouldn´t Register Assignor with Invalid Email Whitout domain")]
        //[Ignore("Waiting for validation")]
        public async Task Shouldnt_Register_Assignor_With_Num_Min_Sign_Approval_is_0()
        {
            var dataTest = new AssignorsData { MinSignaturesApproval = "0" };
            var assignorsPage = new AssignorsPage(_page, dataTest);
            await new AssignorsBuilder(assignorsPage)
                .ClickOnNewButtonAndRegisterByForm()
                .FillGeneralData()
                .GoToForm("Dados da Conta")
                .FillAccountData()
                .AddAccount()
                .GoToForm("Representante")
                .FillRepresentatives()
                .AddRepresentative()
                .ValidateSaveButtonDisabled()
                .Execute();
        }


    }
}
