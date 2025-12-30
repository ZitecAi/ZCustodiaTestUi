using Microsoft.Playwright;
using zCustodiaUi.data.register;
using zCustodiaUi.pages.register;

namespace zCustodiaUi.builders.register
{
    public class FundsBuilder
    {
        private readonly FundsPage _page;
        private readonly List<Func<Task>> _steps = new();

        public FundsBuilder(IPage page, FundsData data = null)
        {
            _page = new FundsPage(page, data);
        }

        public FundsBuilder WithRegisterData()
        {
            _steps.Add(() => _page.RegisterData());
            return this;
        }

        public FundsBuilder WithRules()
        {
            _steps.Add(() => _page.Rules());
            return this;
        }

        public FundsBuilder WithRepresentatives()
        {
            _steps.Add(() => _page.Representatives());
            return this;
        }

        public FundsBuilder WithLiquidation()
        {
            _steps.Add(() => _page.Liquidation());
            return this;
        }

        public FundsBuilder WithAccount()
        {
            _steps.Add(() => _page.FillAccountForm());
            return this;
        }

        public FundsBuilder AddAccount()
        {
            _steps.Add(() => _page.AddAccount());
            return this;
        }

        public FundsBuilder WithSlack()
        {
            _steps.Add(() => _page.Slack());
            return this;
        }

        public FundsBuilder WithFileValidation()
        {
            _steps.Add(() => _page.FileValidation());
            return this;
        }

        public FundsBuilder WithServiceProvider(string providerType,
            string personType,
            int? personOptionPosition = null,
            int? ChargeTypeOptionPosition = null)
        {
            _steps.Add(() => _page.RegisterServiceProvider(providerType, personType, personOptionPosition, ChargeTypeOptionPosition));
            return this;
        }

        public FundsBuilder GoToForm(string formName)
        {
            _steps.Add(() => _page.GoToForm(formName));
            return this;
        }

        public FundsBuilder WithAction(Func<Task> action)
        {
            _steps.Add(action);
            return this;
        }

        public async Task Execute()
        {
            foreach (var step in _steps)
                await step();
        }

        public async Task ValidateSaveDisabled()
        {
            await Execute();
            await _page.ValidateSaveButtonDisabled();
        }

        public async Task ValidateAddAccountButtonDisabled()
        {
            await Execute();
            await _page.ValidateAddAccountButtonDisabled();
        }

        public async Task ValidateErrorMessage(string expectedMessage)
        {
            await Execute();
            await _page.SaveFundNegative(expectedMessage);
        }

        public async Task SaveFund()
        {
            await Execute();
            await _page.SaveFund();
        }
    }
}
