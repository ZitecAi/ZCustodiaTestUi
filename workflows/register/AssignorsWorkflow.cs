using zCustodiaUi.pages.register;
using zCustodiaUi.data.register;

namespace zCustodiaUi.workflows.register
{
    public class AssignorsWorkflow
    {
        private readonly AssignorsPage _assignorsPage;

        public AssignorsWorkflow(AssignorsPage assignorsPage)
        {
            _assignorsPage = assignorsPage;
        }

        public async Task RegisterAssignor()
        {
            await _assignorsPage.ClickOnNewButtonAndRegisterByForm();
            await _assignorsPage.FillGeneralData();
            await _assignorsPage.GoToForm("Dados da Conta");
            await _assignorsPage.FillAccountData();
            await _assignorsPage.AddAccount();
            await _assignorsPage.GoToForm("Representante");
            await _assignorsPage.FillRepresentatives();
            await _assignorsPage.AddRepresentative();
            await _assignorsPage.ClickOnSaveButton();
            await _assignorsPage.ValidateSuccessMessage();
        }

        public async Task ExecuteStandardFlowAndClickSave(bool personTypeCpf = false)
        {
            await _assignorsPage.ClickOnNewButtonAndRegisterByForm();
            await _assignorsPage.FillGeneralData(personTypeCpf);
            await _assignorsPage.GoToForm("Dados da Conta");
            await _assignorsPage.FillAccountData();
            await _assignorsPage.AddAccount();
            await _assignorsPage.GoToForm("Representante");
            await _assignorsPage.FillRepresentatives();
            await _assignorsPage.AddRepresentative();
            await _assignorsPage.ClickOnSaveButton();
        }

        public async Task ExecuteStandardFlowAndValidateSaveButtonDisabled(bool personTypeCpf = false)
        {
            await _assignorsPage.ClickOnNewButtonAndRegisterByForm();
            await _assignorsPage.FillGeneralData(personTypeCpf);
            await _assignorsPage.GoToForm("Dados da Conta");
            await _assignorsPage.FillAccountData();
            await _assignorsPage.AddAccount();
            await _assignorsPage.GoToForm("Representante");
            await _assignorsPage.FillRepresentatives();
            await _assignorsPage.AddRepresentative();
            await _assignorsPage.ValidateSaveButtonDisabled();
        }

        public async Task ExecuteStandardFlowAndValidateAddAccountButtonDisabled(bool personTypeCpf = false)
        {
            await _assignorsPage.ClickOnNewButtonAndRegisterByForm();
            await _assignorsPage.FillGeneralData(personTypeCpf);
            await _assignorsPage.GoToForm("Dados da Conta");
            await _assignorsPage.FillAccountData();
            await _assignorsPage.ValidateAddAccountButtonDisabled();
        }
    }
}
