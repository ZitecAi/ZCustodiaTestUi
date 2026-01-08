using zCustodiaUi.pages.register;

namespace zCustodiaUi.builders.register
{
    public class FundsBuilder : TestBuilder
    {
        private readonly FundsPage _fundsPage;

        public FundsBuilder(FundsPage fundsPage)
        {
            _fundsPage = fundsPage;
        }

        public FundsBuilder RegisterData()
        {
            AddStep(async () => await _fundsPage.RegisterData());
            return this;
        }

        public FundsBuilder Rules()
        {
            AddStep(async () => await _fundsPage.Rules());
            return this;
        }

        public FundsBuilder Representatives()
        {
            AddStep(async () => await _fundsPage.Representatives());
            return this;
        }

        public FundsBuilder Liquidation()
        {
            AddStep(async () => await _fundsPage.Liquidation());
            return this;
        }

        public FundsBuilder FillAccountForm()
        {
            AddStep(async () => await _fundsPage.FillAccountForm());
            return this;
        }

        public FundsBuilder FillAccountFormNotypeAccount()
        {
            AddStep(async () => await _fundsPage.FillAccountFormNotypeAccount());
            return this;
        }

        public FundsBuilder AddAccount()
        {
            AddStep(async () => await _fundsPage.AddAccount());
            return this;
        }

        public FundsBuilder Slack()
        {
            AddStep(async () => await _fundsPage.Slack());
            return this;
        }

        public FundsBuilder FileValidation()
        {
            AddStep(async () => await _fundsPage.FileValidation());
            return this;
        }

        public FundsBuilder GoToForm(string formName)
        {
            AddStep(async () => await _fundsPage.GoToForm(formName));
            return this;
        }

        public FundsBuilder RegisterServiceProvider(string providerType, string personType, int? feePercentage = null, int? minimumValue = null)
        {
            AddStep(async () => await _fundsPage.RegisterServiceProvider(providerType, personType, feePercentage, minimumValue));
            return this;
        }

        public FundsBuilder SaveFund()
        {
            AddStep(async () => await _fundsPage.SaveFund());
            return this;
        }

        public FundsBuilder SaveFundNegative(string expectedText)
        {
            AddStep(async () => await _fundsPage.SaveFundNegative(expectedText));
            return this;
        }

        public FundsBuilder ValidateSaveButtonDisabled()
        {
            AddStep(async () => await _fundsPage.ValidateSaveButtonDisabled());
            return this;
        }

        public FundsBuilder ValidateAddAccountButtonDisabled()
        {
            AddStep(async () => await _fundsPage.ValidateAddAccountButtonDisabled());
            return this;
        }

        public FundsBuilder ConsultFund()
        {
            AddStep(async () => await _fundsPage.ConsultFund());
            return this;
        }

        public FundsBuilder UpdateFund()
        {
            AddStep(async () => await _fundsPage.UpdateFund());
            return this;
        }
    }
}
