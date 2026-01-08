using zCustodiaUi.pages.register;

namespace zCustodiaUi.builders.register
{
    public class AssignorsBuilder : TestBuilder
    {
        private readonly AssignorsPage _assignorsPage;

        public AssignorsBuilder(AssignorsPage assignorsPage)
        {
            _assignorsPage = assignorsPage;
        }

        public AssignorsBuilder ConsultAssignorAndDelete()
        {
            AddStep(async () => await _assignorsPage.ConsultAssignorAndDelete());
            return this;
        }

        public AssignorsBuilder UpdateAssignor()
        {
            AddStep(async () => await _assignorsPage.UpdateAssignor());
            return this;
        }

        public AssignorsBuilder DeleteAssignorByApi(string idAssignor)
        {
            AddStep(async () => await _assignorsPage.DeleteAssignorByApi(idAssignor));
            return this;
        }

        public AssignorsBuilder ClickOnNewButtonAndRegisterByForm()
        {
            AddStep(async () => await _assignorsPage.ClickOnNewButtonAndRegisterByForm());
            return this;
        }

        public AssignorsBuilder FillGeneralData(bool personTypeCpf = false)
        {
            AddStep(async () => await _assignorsPage.FillGeneralData(personTypeCpf));
            return this;
        }

        public AssignorsBuilder FillAccountData()
        {
            AddStep(async () => await _assignorsPage.FillAccountData());
            return this;
        }

        public AssignorsBuilder FillAccountFormNotypeAccount()
        {
            AddStep(async () => await _assignorsPage.FillAccountFormNotypeAccount());
            return this;
        }

        public AssignorsBuilder AddAccount()
        {
            AddStep(async () => await _assignorsPage.AddAccount());
            return this;
        }

        public AssignorsBuilder FillRepresentatives()
        {
            AddStep(async () => await _assignorsPage.FillRepresentatives());
            return this;
        }

        public AssignorsBuilder AddRepresentative()
        {
            AddStep(async () => await _assignorsPage.AddRepresentative());
            return this;
        }

        public AssignorsBuilder ClickOnSaveButton()
        {
            AddStep(async () => await _assignorsPage.ClickOnSaveButton());
            return this;
        }

        public AssignorsBuilder ValidateSuccessMessage()
        {
            AddStep(async () => await _assignorsPage.ValidateSuccessMessage());
            return this;
        }

        public AssignorsBuilder ValidateSaveButtonDisabled()
        {
            AddStep(async () => await _assignorsPage.ValidateSaveButtonDisabled());
            return this;
        }

        public AssignorsBuilder ValidateAddAccountButtonDisabled()
        {
            AddStep(async () => await _assignorsPage.ValidateAddAccountButtonDisabled());
            return this;
        }

        public AssignorsBuilder ValidateErrorMessage(string expectedMessage)
        {
            AddStep(async () => await _assignorsPage.ValidateErrorMessage(expectedMessage));
            return this;
        }

        public AssignorsBuilder GoToForm(string formName)
        {
            AddStep(async () => await _assignorsPage.GoToForm(formName));
            return this;
        }
    }
}
