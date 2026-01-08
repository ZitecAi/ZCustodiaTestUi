using zCustodiaUi.pages.register;

namespace zCustodiaUi.builders.register
{
    public class EntitiesBuilder : TestBuilder
    {
        private readonly EntitiesPage _entitiesPage;

        public EntitiesBuilder(EntitiesPage entitiesPage)
        {
            _entitiesPage = entitiesPage;
        }

        public EntitiesBuilder ClickOnButtonNew()
        {
            AddStep(async () => await _entitiesPage.ClickOnButtonNew());
            return this;
        }

        public EntitiesBuilder ClickOnButtonNewAccount()
        {
            AddStep(async () => await _entitiesPage.ClickOnButtonNewAccount());
            return this;
        }

        public EntitiesBuilder FillMainData()
        {
            AddStep(async () => await _entitiesPage.FillMainData());
            return this;
        }

        public EntitiesBuilder SetFunctionOfEntity()
        {
            AddStep(async () => await _entitiesPage.SetFunctionOfEntity());
            return this;
        }

        public EntitiesBuilder GoToForm(string formName)
        {
            AddStep(async () => await _entitiesPage.GoToForm(formName));
            return this;
        }

        public EntitiesBuilder FillAccountData()
        {
            AddStep(async () => await _entitiesPage.FillAccountData());
            return this;
        }

        public EntitiesBuilder FillAccountDataWithoutSelectingBank()
        {
            AddStep(async () => await _entitiesPage.FillAccountDataWithoutSelectingBank());
            return this;
        }

        public EntitiesBuilder FillAccountDataFields()
        {
            AddStep(async () => await _entitiesPage.FillAccountDataFields());
            return this;
        }

        public EntitiesBuilder FillRepresentativeData()
        {
            AddStep(async () => await _entitiesPage.FillRepresentativeData());
            return this;
        }

        public EntitiesBuilder SetAssign()
        {
            AddStep(async () => await _entitiesPage.SetAssign());
            return this;
        }

        public EntitiesBuilder SetAssignByEndorsement()
        {
            AddStep(async () => await _entitiesPage.SetAssignByEndorsement());
            return this;
        }

        public EntitiesBuilder SetAssignSessionTerm()
        {
            AddStep(async () => await _entitiesPage.SetAssignSessionTerm());
            return this;
        }

        public EntitiesBuilder SetIssueDuplicate()
        {
            AddStep(async () => await _entitiesPage.SetIssueDuplicate());
            return this;
        }

        public EntitiesBuilder CLickOnSaveButton()
        {
            AddStep(async () => await _entitiesPage.CLickOnSaveButton());
            return this;
        }

        public EntitiesBuilder CLickOnAddButton()
        {
            AddStep(async () => await _entitiesPage.CLickOnAddButton());
            return this;
        }

        public EntitiesBuilder ValidateSuccessMessage()
        {
            AddStep(async () => await _entitiesPage.ValidateSuccessMessage());
            return this;
        }

        public EntitiesBuilder ValidateSaveButtonIsDisable()
        {
            AddStep(async () => await _entitiesPage.ValidateSaveButtonIsDisable());
            return this;
        }

        public EntitiesBuilder ValidateAddButtonIsDisable()
        {
            AddStep(async () => await _entitiesPage.ValidateAddButtonIsDisable());
            return this;
        }

        public EntitiesBuilder ValidateErrorMessage(string expectedText)
        {
            AddStep(async () => await _entitiesPage.ValidateErrorMessage(expectedText));
            return this;
        }
    }
}
