using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using zCustodiaUi.data.register;
using zCustodiaUi.locators;
using zCustodiaUi.locators.register;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.register
{
    public class EntitiesPage
    {
        private readonly IPage _page;
        private readonly Utils _util;
        private readonly GenericElements _gen = new GenericElements();
        private readonly EntitiesElements _el = new EntitiesElements();
        private readonly EntitiesData _data;
        public EntitiesPage(IPage _page, EntitiesData data = null)
        {
            this._page = _page;
            _data = data ?? new EntitiesData();
            _util = new Utils(_page);
        }

        public async Task ClickOnButtonNewEntity()
        {
            await _util.Click(_gen.LocatorSpanText("Novo"), "Click on new entity to open form");
        }

        [AllureStep("Fill main data of entity")]
        public async Task FillMainData()
        {
            await _util.Write(_gen.LocatorMatLabel("Nome"), _data.EntityName, "Fill the Name field with entity name");
            await _util.Write(_gen.LocatorMatLabel("CNPJ"), _data.EntityCnpj, "Fill the CNPJ field with entity CNPJ");
            await _util.Write(_gen.LocatorMatLabel("Email"), _data.EntityEmail, "Fill the Email field with entity email");
            await _util.Write(_gen.LocatorMatLabel("CEP"), _data.EntityPostalCode, "Fill the Postal code field with postal code test");
            await _util.Write(_gen.LocatorMatLabel("Número"), _data.NumberAdress, "Fill the Number field with number address test");
        }
        [AllureStep("Set Functon of entity")]
        public async Task SetFunctionOfEntity()
        {
            await _util.Click(_el.CheckBoxAdminRole, "Click on Admin Role checkbox to set entity as admin role");
        }

        public async Task GoToForm(string formName)
        {
            await _util.GoToForm(formName);
        }

        public async Task FillAccountData()
        {
            await _util.Click(_gen.LocatorMatLabel("Banco"), "Open filter Bank field with bank name");
            await _util.Write(_gen.LocatorMatLabel("Banco"), _data.BankName, "Fill the Bank field with bank name");
            await _util.Click(_gen.ReceiveTypeOption(_data.BankName), "Select the bank from the options");
            await _util.Write(_gen.LocatorMatLabel("Agência"), _data.NumberAgency, "Fill the Agency field with agency number");
            await _util.Write(_gen.LocatorMatLabel("Conta"), _data.NumberAccount, "Fill the Account field with account number");
            await _util.Write(_gen.LocatorMatLabel("Descrição"), _data.Description, "Fill description");
        }

        public async Task FillRepresentativeData()
        {
            await _util.Write(_gen.LocatorMatLabel("Nome"), _data.RepresentativeName, "Fill Representative name");
            await _util.Write(_gen.LocatorMatLabel("Email"), _data.RepresentativeEmail, "Fill Representative Email");
            await _util.Write(_gen.LocatorMatLabel("CPF"), _data.RepresentativeCpf, "Fill Representative CPF");
            await _util.Write(_gen.LocatorMatLabel("Telefone"), _data.RepresentativeTelNumber, "Fill Representative number");
        }

        public async Task SetAssign()
        {
            await _util.Click(_el.RadioButtonAssign, "Set assign on representative");
        }
        public async Task SetAssignByEndorsement()
        {
            await _util.Click(_el.RadioButtonAssignByEndorsement, "Set assign by endorsement on representative");
        }
        public async Task SetAssignSessionTerm()
        {
            await _util.Click(_el.RadioButtonAssignSessionTerm, "Set assign session term on representative");
        }
        public async Task SetIssueDuplicate()
        {
            await _util.Click(_el.RadioButtonIssueDuplicate, "Set Issue Duplicate on representative");
        }

        public async Task CLickOnSaveButton()
        {
            await _util.Click(_gen.LocatorSpanText("Salvar"), "Click on save button");
        }

    }
}
