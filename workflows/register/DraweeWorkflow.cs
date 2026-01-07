using zCustodiaUi.Pages.register;

namespace zCustodiaUi.workflows.register
{
    public class DraweeWorkflow
    {
        private readonly DraweePage _draweePage;

        public DraweeWorkflow(DraweePage draweePage)
        {
            _draweePage = draweePage;
        }

        public async Task RegisterDrawee()
        {
            var random = new Random();
            int uniqueNumber = random.Next(0, 9999);
            string draweeName = $"Sacado Test {uniqueNumber}";

            await _draweePage.ClickOnNewDraweeButton();
            await _draweePage.FillFund();
            await _draweePage.FillDraweeName(draweeName);
            await _draweePage.FillEmail();
            await _draweePage.FillCPF();
            await _draweePage.FillRelationshipDates();
            await _draweePage.FillAnnualRevenue();
            await _draweePage.FillEconomicConglomerate();
            await _draweePage.FillSize();
            await _draweePage.FillRiskClassification();
            await _draweePage.FillSocietyType();
            await _draweePage.FillStateRegistration();
            await _draweePage.FillAddress();
            await _draweePage.ClickOnSaveButton();
            await _draweePage.ValidateSuccessMessage();
            await _draweePage.FilterAndValidateDrawee(draweeName);
        }
    }
}
