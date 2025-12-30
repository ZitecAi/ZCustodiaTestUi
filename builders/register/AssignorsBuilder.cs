using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using zCustodiaUi.data.register;
using zCustodiaUi.pages.register;

namespace zCustodiaUi.builders.register
{
    public class AssignorsBuilder
    {
        private readonly AssignorsPage _page;
        private readonly List<Func<Task>> _steps = new();

        public AssignorsBuilder(IPage page, AssignorsData data = null)
        {
            _page = new AssignorsPage(page, data);
        }

        public AssignorsBuilder ClickOnNewButtonAndRegisterByForm()
        {
            _steps.Add(() => _page.ClickOnNewButtonAndRegisterByForm());
            return this;
        }

        public AssignorsBuilder FillGeneralData(bool personTypeCpf = false)
        {
            _steps.Add(() => _page.FillGeneralData(personTypeCpf));
            return this;
        }

        public AssignorsBuilder GoToAccountForm()
        {
            _steps.Add(() => _page.GoToForm("Dados da Conta"));
            return this;
        }

        public AssignorsBuilder FillAccountData()
        {
            _steps.Add(() => _page.FillAccountData());
            return this;
        }

        public AssignorsBuilder AddAccount()
        {
            _steps.Add(() => _page.AddAccount());
            return this;
        }

        public AssignorsBuilder GoToRepresentativeForm()
        {
            _steps.Add(() => _page.GoToForm("Representante"));
            return this;
        }

        public AssignorsBuilder FillRepresentatives()
        {
            _steps.Add(() => _page.FillRepresentatives());
            return this;
        }

        public AssignorsBuilder AddRepresentative()
        {
            _steps.Add(() => _page.AddRepresentative());
            return this;
        }

        public AssignorsBuilder ClickOnSaveButton()
        {
            _steps.Add(() => _page.ClickOnSaveButton());
            return this;
        }

        public AssignorsBuilder WithAction(Func<Task> action)
        {
            _steps.Add(action);
            return this;
        }

        public async Task Execute()
        {
            foreach (var step in _steps)
                await step();
        }

        public async Task ValidateSuccessMessage()
        {
            await Execute();
            await _page.ValidateSuccessMessage();
        }

        public async Task ValidateSaveButtonDisabled()
        {
            await Execute();
            await _page.ValidateSaveButtonDisabled();
        }

        public async Task ValidateErrorMessage(string expectedMessage)
        {
            await Execute();
            await _page.ValidateErrorMessage(expectedMessage);
        }
    }
}
