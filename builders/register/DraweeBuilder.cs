using zCustodiaUi.Pages.register;

namespace zCustodiaUi.builders.register
{
    public class DraweeBuilder : TestBuilder
    {
        private readonly DraweePage _draweePage;

        public DraweeBuilder(DraweePage draweePage)
        {
            _draweePage = draweePage;
        }

        public DraweeBuilder ClickOnNewDraweeButton()
        {
            AddStep(async () => await _draweePage.ClickOnNewDraweeButton());
            return this;
        }

        public DraweeBuilder FillFund()
        {
            AddStep(async () => await _draweePage.FillFund());
            return this;
        }

        public DraweeBuilder FillDraweeName(string name)
        {
            AddStep(async () => await _draweePage.FillDraweeName(name));
            return this;
        }

        public DraweeBuilder FillEmail()
        {
            AddStep(async () => await _draweePage.FillEmail());
            return this;
        }

        public DraweeBuilder FillCPF()
        {
            AddStep(async () => await _draweePage.FillCPF());
            return this;
        }

        public DraweeBuilder FillRelationshipDates(string startDate = null, string endDate = null)
        {
            AddStep(async () => await _draweePage.FillRelationshipDates(startDate, endDate));
            return this;
        }

        public DraweeBuilder FillAnnualRevenue()
        {
            AddStep(async () => await _draweePage.FillAnnualRevenue());
            return this;
        }

        public DraweeBuilder FillEconomicConglomerate()
        {
            AddStep(async () => await _draweePage.FillEconomicConglomerate());
            return this;
        }

        public DraweeBuilder FillSize()
        {
            AddStep(async () => await _draweePage.FillSize());
            return this;
        }

        public DraweeBuilder FillRiskClassification()
        {
            AddStep(async () => await _draweePage.FillRiskClassification());
            return this;
        }

        public DraweeBuilder FillSocietyType()
        {
            AddStep(async () => await _draweePage.FillSocietyType());
            return this;
        }

        public DraweeBuilder FillStateRegistration()
        {
            AddStep(async () => await _draweePage.FillStateRegistration());
            return this;
        }

        public DraweeBuilder FillAddress()
        {
            AddStep(async () => await _draweePage.FillAddress());
            return this;
        }

        public DraweeBuilder ClickOnSaveButton()
        {
            AddStep(async () => await _draweePage.ClickOnSaveButton());
            return this;
        }

        public DraweeBuilder ValidateSuccessMessage()
        {
            AddStep(async () => await _draweePage.ValidateSuccessMessage());
            return this;
        }

        public DraweeBuilder FilterAndValidateDrawee(string nameDrawee)
        {
            AddStep(async () => await _draweePage.FilterAndValidateDrawee(nameDrawee));
            return this;
        }

        public DraweeBuilder Register_Drawee()
        {
            AddStep(async () => await _draweePage.Register_Drawee());
            return this;
        }
    }
}
