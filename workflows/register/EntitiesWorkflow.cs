using zCustodiaUi.pages.register;
using zCustodiaUi.data.register;

namespace zCustodiaUi.workflows.register
{
    public class EntitiesWorkflow
    {
        private readonly EntitiesPage _entitiesPage;

        public EntitiesWorkflow(EntitiesPage entitiesPage)
        {
            _entitiesPage = entitiesPage;
        }

        public async Task ExecuteStandardFlow()
        {
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillMainData();
            await _entitiesPage.SetFunctionOfEntity();
            await _entitiesPage.GoToForm("Conta Corrente Consultoria");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillAccountData();
            await _entitiesPage.CLickOnAddButton();
            await _entitiesPage.GoToForm("Representantes");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillRepresentativeData();
            await _entitiesPage.SetAssign();
            await _entitiesPage.CLickOnAddButton();
            await _entitiesPage.CLickOnSaveButton();
            await _entitiesPage.ValidateSuccessMessage();
        }

        public async Task ExecuteStandardFlowAndClickSave()
        {
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillMainData();
            await _entitiesPage.SetFunctionOfEntity();
            await _entitiesPage.GoToForm("Conta Corrente Consultoria");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillAccountData();
            await _entitiesPage.CLickOnAddButton();
            await _entitiesPage.GoToForm("Representantes");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillRepresentativeData();
            await _entitiesPage.SetAssign();
            await _entitiesPage.CLickOnAddButton();
            await _entitiesPage.CLickOnSaveButton();
        }

        public async Task ExecuteStandardFlowAndValidateSaveButtonDisabled()
        {
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillMainData();
            await _entitiesPage.SetFunctionOfEntity();
            await _entitiesPage.GoToForm("Conta Corrente Consultoria");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillAccountData();
            await _entitiesPage.CLickOnAddButton();
            await _entitiesPage.GoToForm("Representantes");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillRepresentativeData();
            await _entitiesPage.SetAssign();
            await _entitiesPage.CLickOnAddButton();
            await _entitiesPage.ValidateSaveButtonIsDisable();
        }

        public async Task ExecuteWithBankFieldEmpty()
        {
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillMainData();
            await _entitiesPage.SetFunctionOfEntity();
            await _entitiesPage.GoToForm("Conta Corrente Consultoria");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillAccountDataWithoutSelectingBank();
            await _entitiesPage.ValidateAddButtonIsDisable();
        }

        public async Task ExecuteNegativeAccount()
        {
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillMainData();
            await _entitiesPage.SetFunctionOfEntity();
            await _entitiesPage.GoToForm("Conta Corrente Consultoria");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillAccountDataFields();
            await _entitiesPage.ValidateAddButtonIsDisable();
        }

        public async Task ExecuteWithoutAccount()
        {
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillMainData();
            await _entitiesPage.SetFunctionOfEntity();
            await _entitiesPage.GoToForm("Conta Corrente Consultoria");
            await _entitiesPage.GoToForm("Representantes");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillRepresentativeData();
            await _entitiesPage.SetAssign();
            await _entitiesPage.CLickOnAddButton();
        }

        public async Task ExecuteWithoutPermissionAndClickSave()
        {
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillMainData();
            await _entitiesPage.GoToForm("Conta Corrente Consultoria");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillAccountData();
            await _entitiesPage.CLickOnAddButton();
            await _entitiesPage.GoToForm("Representantes");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillRepresentativeData();
            await _entitiesPage.SetAssign();
            await _entitiesPage.CLickOnAddButton();
            await _entitiesPage.CLickOnSaveButton();
        }

        public async Task ExecuteNoRepresentative()
        {
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillMainData();
            await _entitiesPage.SetFunctionOfEntity();
            await _entitiesPage.GoToForm("Conta Corrente Consultoria");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillAccountData();
            await _entitiesPage.CLickOnAddButton();
            await _entitiesPage.CLickOnSaveButton();
        }

        public async Task ExecuteNoRepresentativeAndValidateErrorMessage(string errorMessage)
        {
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillMainData();
            await _entitiesPage.SetFunctionOfEntity();
            await _entitiesPage.GoToForm("Conta Corrente Consultoria");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillAccountData();
            await _entitiesPage.CLickOnAddButton();
            await _entitiesPage.CLickOnSaveButton();
            await _entitiesPage.ValidateErrorMessage(errorMessage);
        }

        public async Task ExecuteNegativeRepresentative()
        {
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillMainData();
            await _entitiesPage.SetFunctionOfEntity();
            await _entitiesPage.GoToForm("Conta Corrente Consultoria");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillAccountData();
            await _entitiesPage.CLickOnAddButton();
            await _entitiesPage.GoToForm("Representantes");
            await _entitiesPage.ClickOnButtonNew();
            await _entitiesPage.FillRepresentativeData();
            await _entitiesPage.SetAssign();
            await _entitiesPage.ValidateAddButtonIsDisable();
        }
    }
}
