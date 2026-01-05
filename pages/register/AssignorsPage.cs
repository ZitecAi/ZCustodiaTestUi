using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using zCustodiaUi.data.register;
using zCustodiaUi.locators;
using zCustodiaUi.locators.register;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.register
{
    public class AssignorsPage
    {
        private readonly IPage _page;
        private readonly Utils _util;
        private readonly GenericElements _gen = new GenericElements();
        private readonly AssignorsElements _el = new AssignorsElements();
        private readonly AssignorsData _data;

        public AssignorsPage(IPage _page, AssignorsData data = null)
        {
            this._page = _page;
            _data = data ?? new AssignorsData();
            _util = new Utils(_page);
        }

        [AllureStep("Consult Assignor")]
        public async Task ConsultAssignorAndDelete()
        {
            await _util.Click(_gen.FilterButton, "Click on Filter Button to filter Assignor to be consulted");
            await Task.Delay(500);
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on Filter Select to filter Assignor to be consulted");
            await _util.Write(_gen.Filter, _data.FundAssignor, "Insert Find Assignor to be consulted");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundAssignor), $"Click on {_data.FundAssignor} option");
            await _util.Write(_gen.LocatorMatLabel("Nome Cedente"), _data.NameAssignor + " EDITADO", "Insert Name Assignor to be consulted");
            await _util.Click(_el.ApplyFilterButton, "Click on Apply Filter Button to show results");
            await Task.Delay(1000);
            var idAssignor = await _util.ValidateIfElementHaveValue(_el.IdPosition, "Validate If ID of assignor is present on screen");
            if (idAssignor == null)
            {
                return;
            }
            await DeleteAssignorByApi(idAssignor);
        }

        [AllureStep("Update Assignor")]
        public async Task UpdateAssignor()
        {
            await _util.Click(_gen.FilterButton, "Click on Filter Button to filter Assignor to be consulted");
            await Task.Delay(500);
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on Filter Select to filter Assignor to be consulted");
            await _util.Write(_gen.Filter, _data.FundAssignor, "Insert Find Assignor to be consulted");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundAssignor), $"Click on {_data.FundAssignor} option");
            await _util.Write(_gen.LocatorMatLabel("Nome Cedente"), _data.NameAssignor, "Insert Name Assignor to be consulted");
            await _util.Click(_el.ApplyFilterButton, "Click on Apply Filter Button to show results");
            await Task.Delay(1000);
            await _util.Click(_gen.EditButton, "Click on Edit button to update Assignor");
            await Task.Delay(150);
            await _util.Write(_gen.LocatorMatLabel("Nome"), _data.NameAssignor + " EDITADO", "Insert Name EDITED of Assignor to be Registered");
            await _util.Click(_gen.SaveButton, "Click on Add button to add EDITED Assignor");
            await _util.ValidateTextIsVisibleOnScreen("Dados Salvos com Sucesso!", "Validate if success Message is visible on screen after updated existing assignor");
        }

        [AllureStep("Delete Assignor By Api")]
        public async Task DeleteAssignorByApi(string idAssignor)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Token", AssignorsData.Token);
            var request = await httpClient.DeleteAsync(AssignorsData.Api + idAssignor);
            string response = await request.Content.ReadAsStringAsync();
            Console.WriteLine(response);
        }

        [AllureStep("Click on New Button and Register By Form")]
        public async Task ClickOnNewButtonAndRegisterByForm()
        {
            await _util.Click(_gen.LocatorSpanText(" Novo "), "Click on new assignor button to start register");
            await _util.Click(_el.FormAssignors, "Click on Form Assignors button to start register");
            await Task.Delay(500);
        }

        [AllureStep("Fill General Data")]
        public async Task FillGeneralData(bool personTypeCpf = false)
        {
            await _util.Click(_gen.LocatorMatLabel("Fundo"), "Click on fund select");
            await _util.Write(_gen.Filter, _data.FundAssignor, "Click on filter input to search for fund");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundAssignor), "Click on fund option");
            await Task.Delay(100);
            await _util.Write(_gen.LocatorMatLabel("Nome"), _data.NameAssignor, "Insert Name of Assignor to be Registered");

            if (personTypeCpf is true)
            {
                await _util.Click(_gen.RadioButtonOption("CPF"), "Click on CPF radio button");
                await _util.Write(_gen.LocatorMatLabel("CPF"), _data.CpfAssignor, "Insert CPF of Assignor to be Registered");
            }
            else
            {
                await _util.Write(_gen.LocatorMatLabel("CNPJ"), _data.CnpjAssignor, "Insert CNPJ of Assignor to be Registered");
            }

            await _util.Write(_gen.LocatorMatLabel("Inscrição Estadual"), _data.StateRegistration, "Insert State Registration of Assignor to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Inscrição Municipal"), _data.MunicipalRegistration, "Insert Municipal Registration of Assignor to be Registered");

            await _util.Click(_gen.LocatorMatLabel("Ramo de Atividade"), "Click on Activity Select");
            await _util.Write(_gen.Filter, _data.Activity, "Insert Activity of Assignor to be Registered");
            await _util.Click(_gen.ReceiveTypeOption(_data.Activity), "Click on Activity option");
            await Task.Delay(150);

            await _util.Click(_gen.LocatorMatLabel("Porte"), "COMÉRCIO on Port Select");
            await _util.Write(_gen.Filter, _data.Port, "Insert Port of Assignor to be Registered");
            await _util.Click(_gen.ReceiveTypeOption(_data.Port), "Click on Port option");
            await Task.Delay(150);
            await _util.Write(_gen.LocatorMatLabel("Email"), _data.Email, "Insert Email to be registered");

            await _util.Click(_gen.LocatorMatLabel("Tipo de Sociedade"), "Click on Type of Society Select");
            await _util.Write(_gen.Filter, _data.SocietyType, "Insert Type of Society to be Registered");
            await _util.Click(_gen.ReceiveTypeOption(_data.SocietyType), "Click on Type of Society option");
            await Task.Delay(150);
            await _util.Click(_gen.LocatorMatLabel("Classificação de Risco"), "Click on Risk Classification Select");
            await _util.Write(_gen.Filter, _data.RiskClassification, "Insert Risk Classification to be Registered");
            await _util.Click(_gen.ReceiveTypeOption(_data.RiskClassification), "Click on Risk Classification option");

            await _util.Write(_gen.LocatorMatLabel("Faturamento Anual"), _data.AnnualBilling, "Insert Annual Billing to be Registered");
            await _page.Keyboard.PressAsync("Space");
            await _util.Click(_el.Authorization(true), "Click on Authorization Radio Button to be Registered");

            await _util.ScrollToElementAndMaintainPosition(_gen.LocatorMatLabel("CEP"), "Scroll to CEP");

            await _util.Write(_gen.LocatorMatLabel("CEP"), _data.PostalCode, "Insert Postal Code to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Endereço"), _data.Address, "Insert Address to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Número"), _data.Number, "Insert Number to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Complemento"), _data.Complement, "Insert Complement to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Bairro"), _data.Neighborhood, "Insert Neighborhood to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Cidade"), _data.City, "Insert City to be Registered");

            await _util.Click(_gen.LocatorMatLabel("UF"), "Click on UF Select");
            await _util.Write(_gen.Filter, _data.UF, "Insert UF to be Registered");
            await _util.Click(_gen.ReceiveTypeOption(_data.UF), "Click on UF option");
            await Task.Delay(150);

            await _util.Write(_el.TelInput, _data.Telephone, "Insert Telephone to be Registered");

            await _util.Write(_gen.LocatorMatLabel("Conglomerado Econômico"), _data.EconomicConglomerate, "Insert Economic Conglomerate to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Número mínimo de assinaturas para aprovação"), _data.MinSignaturesApproval, "Insert Assignor Percentage to be Approved to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Limite de Crédito"), _data.CreditLimit, "Insert Credit Limit to be Registered");
            await _page.Keyboard.PressAsync("Space");
            await Task.Delay(150);

            await _util.ScrollToElementAndMaintainPosition(_gen.LocatorMatLabel("Chave Pix"), "Scrool on Is Chave Pix Select");
            await _util.Click(_gen.LocatorMatLabel("Coobrigação"), "Click on Is Coobrigation Select");
            await _util.Write(_gen.Filter, _data.Coobrigation, "Insert Is Coobrigation to be Registered");
            await Task.Delay(500);
            await _util.Click(_gen.ReceiveTypeOption(_data.Coobrigation), "Click on Is Coobrigation option");
        }

        [AllureStep("Fill Account Data")]
        public async Task FillAccountData()
        {
            await _util.Click(_gen.ButtonNew, "Click in New to insert a New Account");
            await Task.Delay(150);
            await _util.Click(_gen.LocatorMatLabel("Banco"), "Insert Bank Number to be Registered");
            await _util.Write(_gen.Filter, _data.Bank, "Insert Is Coobrigation to be Registered");
            await _util.Click(_gen.ReceiveTypeOption(_data.Bank), "Click on Is Coobrigation option");

            await _util.Write(_gen.LocatorMatLabel("Número Agência"), _data.AgencyNumber, "Insert Agency Number to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Conta Corrente"), _data.AccountNumber, "Insert Account Number to be Registered");
            await _util.Write("(" + _gen.LocatorMatLabel("Dígito") + ")[2]", _data.AccountDigit, "Insert Account Digit to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Descrição"), _data.AccountDescription, "Click on Account Type Select");
            await _util.Click(_el.Pattern(true), "Click on Active Account");
        }

        [AllureStep("Fill Account Form without type account")]
        public async Task FillAccountFormNotypeAccount()
        {
            await _util.Click(_gen.ButtonNew, "Click in New to insert a New Account");
            await Task.Delay(150);
            await _util.Click(_gen.LocatorMatLabel("Banco"), "Insert Bank Number to be Registered");
            await _util.Write(_gen.Filter, _data.Bank, "Insert Is Coobrigation to be Registered");
            await _util.Click(_gen.ReceiveTypeOption(_data.Bank), "Click on Is Coobrigation option");

            await _util.Write(_gen.LocatorMatLabel("Número Agência"), _data.AgencyNumber, "Insert Agency Number to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Conta Corrente"), _data.AccountNumber, "Insert Account Number to be Registered");
            await _util.Write("(" + _gen.LocatorMatLabel("Dígito") + ")[2]", _data.AccountDigit, "Insert Account Digit to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Descrição"), _data.AccountDescription, "Click on Account Type Select");
            await _util.Click(_el.Pattern(true), "Click on Active Account");
        }

        [AllureStep("Add Account")]
        public async Task AddAccount()
        {
            await _util.Click(_gen.AddButton, "Click on Add Button to add new account");
        }

        [AllureStep("Fill Representatives Data")]
        public async Task FillRepresentatives()
        {
            await _util.Click(_gen.ButtonNew, "Click in New to insert a New Account");
            await _util.Write(_gen.LocatorMatLabel("Nome"), _data.RepresentativeName, "Insert Name of Representative to be Registered");
            await _util.Write(_gen.LocatorMatLabel("E-mail"), _data.RepresentativeEmail, "Insert E-mail of Representative to be Registered");
            await _util.Write(_gen.LocatorMatLabel("CPF"), _data.RepresentativeCPF, "Insert CPF of Representative to be Registered");
            await _util.Write(_gen.LocatorMatLabel("Telefone"), _data.RepresentativeTelephone, "Insert Telephone of Representative to be Registered");
            await _util.Click(_el.Assign(true), "Click on 'yes' to Assign");
            await _util.Click(_el.AssignTerm(true), "Click on 'yes' to Assign Term");
            await _util.Click(_el.AssignByEndorsement(true), "Click on 'yes' to Assign By Endorsement");
            await _util.Click(_el.IssueDouble(true), "Click on 'yes' to Issue Double");
        }

        [AllureStep("Add Representative")]
        public async Task AddRepresentative()
        {
            await _util.Click(_gen.AddButton, "Click on Add button to add new Assignor");
        }



        [AllureStep("Click on Save Button")]
        public async Task ClickOnSaveButton()
        {
            await _util.Click(_gen.SaveButton, "Click on Save button");
        }

        [AllureStep("Validate Success Message")]
        public async Task ValidateSuccessMessage()
        {
            await _util.ValidateTextIsVisibleOnScreen("Dados Salvos com Sucesso!", "Validate if success Message is visible on screen");
        }

        [AllureStep("Validate Save Button Disabled")]
        public async Task ValidateSaveButtonDisabled()
        {
            await _util.ValidateElementIsDisabled(_gen.SaveButton, "Validate if Save Button is disabled");
        }

        [AllureStep("Validate Add Account Button Disabled")]
        public async Task ValidateAddAccountButtonDisabled()
        {
            await _util.ValidateElementIsDisabled(_gen.AddButton, "Validate if Add Button is disabled");
        }

        [AllureStep("Validate Error Message")]
        public async Task ValidateErrorMessage(string expectedMessage)
        {
            await _util.ValidateTextIsVisibleOnScreen(expectedMessage, $"Validate if error message '{expectedMessage}' is visible on screen");
        }

        public async Task ExecuteStandardFlow(bool personTypeCpf = false)
        {
            await ClickOnNewButtonAndRegisterByForm();
            await FillGeneralData(personTypeCpf);
            await _util.GoToForm("Dados da Conta");
            await FillAccountData();
            await AddAccount();
            await _util.GoToForm("Representante");
            await FillRepresentatives();
            await AddRepresentative();
        }

        public async Task RegisterAssignor()
        {
            await ExecuteStandardFlow();
            await ClickOnSaveButton();
            await ValidateSuccessMessage();
        }
    }
}
