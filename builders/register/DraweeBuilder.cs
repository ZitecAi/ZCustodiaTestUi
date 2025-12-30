using Microsoft.Playwright;
using zCustodiaUi.data.register;
using zCustodiaUi.Pages.register;

namespace zCustodiaUi.builders.register
{
    public class DraweeBuilder
    {
        private readonly DraweePage _page;
        private readonly List<Func<Task>> _steps = new();

        public DraweeBuilder(IPage page, DraweeData data = null)
        {
            _page = new DraweePage(page, data);
        }

        public DraweeBuilder ClickOnNewDraweeButton()
        {
            _steps.Add(() => _page.ClickOnNewDraweeButton());
            return this;
        }

        public DraweeBuilder FillFund()
        {
            _steps.Add(() => _page.FillFund());
            return this;
        }

        public DraweeBuilder FillDraweeName(string name)
        {
            _steps.Add(() => _page.FillDraweeName(name));
            return this;
        }

        public DraweeBuilder FillEmail()
        {
            _steps.Add(() => _page.FillEmail());
            return this;
        }

        public DraweeBuilder FillCPF()
        {
            _steps.Add(() => _page.FillCPF());
            return this;
        }

        public DraweeBuilder FillRelationshipDates(string startDate = null, string endDate = null)
        {
            _steps.Add(() => _page.FillRelationshipDates(startDate, endDate));
            return this;
        }

        public DraweeBuilder FillAnnualRevenue()
        {
            _steps.Add(() => _page.FillAnnualRevenue());
            return this;
        }

        public DraweeBuilder FillEconomicConglomerate()
        {
            _steps.Add(() => _page.FillEconomicConglomerate());
            return this;
        }

        public DraweeBuilder FillSize()
        {
            _steps.Add(() => _page.FillSize());
            return this;
        }

        public DraweeBuilder FillRiskClassification()
        {
            _steps.Add(() => _page.FillRiskClassification());
            return this;
        }

        public DraweeBuilder FillSocietyType()
        {
            _steps.Add(() => _page.FillSocietyType());
            return this;
        }

        public DraweeBuilder FillStateRegistration()
        {
            _steps.Add(() => _page.FillStateRegistration());
            return this;
        }

        public DraweeBuilder FillAddress()
        {
            _steps.Add(() => _page.FillAddress());
            return this;
        }

        public DraweeBuilder ClickOnSaveButton()
        {
            _steps.Add(() => _page.ClickOnSaveButton());
            return this;
        }

        public DraweeBuilder WithAction(Func<Task> action)
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

        public async Task FilterAndValidateDrawee(string draweeName)
        {
            await Execute();
            await _page.FilterAndValidateDrawee(draweeName);
        }
    }
}
