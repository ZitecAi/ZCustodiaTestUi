using Microsoft.Playwright;
using zCustodiaUi.data.register;
using zCustodiaUi.pages.register;
using zCustodiaUi.utils;

namespace zCustodiaUi.builders.register
{
    public class EntitiesBuilder
    {
        private readonly EntitiesPage _page;
        private readonly Utils _util;
        private readonly List<Func<Task>> _steps = new();

        public EntitiesBuilder(IPage page, EntitiesData data = null)
        {
            _page = new EntitiesPage(page, data);
            _util = new Utils(page);
        }



        public EntitiesBuilder FillMainData()
        {
            _steps.Add(() => _page.FillMainData());
            return this;
        }

        public EntitiesBuilder SetFunctionOfEntity()
        {
            _steps.Add(() => _page.SetFunctionOfEntity());
            return this;
        }

        public EntitiesBuilder FillAccountData()
        {
            _steps.Add(() => _page.FillAccountData());
            return this;
        }

        public EntitiesBuilder FillRepresentativeData()
        {
            _steps.Add(() => _page.FillRepresentativeData());
            return this;
        }

        public EntitiesBuilder ClickOnButtonNew()
        {
            _steps.Add(() => _page.ClickOnButtonNew());
            return this;
        }

        public EntitiesBuilder GoToForm(string formName)
        {
            _steps.Add(() => _page.GoToForm(formName));
            return this;
        }

        public EntitiesBuilder SetAssign()
        {
            _steps.Add(() => _page.SetAssign());
            return this;
        }

        public EntitiesBuilder SetAssignByEndorsement()
        {
            _steps.Add(() => _page.SetAssignByEndorsement());
            return this;
        }

        public EntitiesBuilder SetAssignSessionTerm()
        {
            _steps.Add(() => _page.SetAssignSessionTerm());
            return this;
        }

        public EntitiesBuilder SetIssueDuplicate()
        {
            _steps.Add(() => _page.SetIssueDuplicate());
            return this;
        }

        public EntitiesBuilder CLickOnSaveButton()
        {
            _steps.Add(() => _page.CLickOnSaveButton());
            return this;
        }
        public EntitiesBuilder CLickOnAddButton()
        {
            _steps.Add(() => _page.CLickOnAddButton());
            return this;
        }

        public EntitiesBuilder Action(Func<Task> action)
        {
            _steps.Add(action);
            return this;
        }

        public async Task Execute()
        {
            foreach (var step in _steps)
            {
                await step();
            }
        }

        public async Task ValidateSuccessMessage()
        {
            await Execute();
            await _page.ValidateSuccessMessage();
        }
        public async Task ValidateErrorMessage(string expectedText)
        {
            await Execute();
            await _page.ValidateErrorMessage(expectedText);
        }
        public async Task ValidateButtonSaveDisable()
        {
            await Execute();
            await _page.ValidateSaveButtonIsDisable();
        }



    }
}
