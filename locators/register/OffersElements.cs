namespace zCustodiaUi.locators.register
{
    public class OffersElements
    {
        public string OffersPage { get; } = "//span[text()='Ofertas']";
        public string SelectFund { get; } = "Fundo";
        public string FilterButton { get; } = "Filtro";
        public string SelectPortfolio { get; } = "Carteira";
        public string QuantityOfQuotasInput { get; } = "Quantidade de Cotas";
        public string InitialQuotaInput { get; } = "Cota Inicial";
        public string OfferValueInput { get; } = "Valor Oferta";
        public string InvestorProfileDropdown { get; } = "Perfil do Investidor";
        public string RestritionObservationInput { get; } = "Observação Restrição";
        public string IsPrivateCheckbox { get; } = "$mat-mdc-checkbox-2-input";
        public string CalendarOfDeadline { get; } = "(//button[@aria-label='Open calendar'])[2]";
        public string FundAndPortfolioInTable { get; } = "(//tr//td[2]//span)[1]";
        public string QuantityOfQuotasInTable { get; } = "(//tr//td[3]//span)[1]";
        public string StatusOfferInTable { get; } = "(//tr//td//div//app-status-column//div)[1]";
        public string InitialValueInTable { get; } = "(//tr//td[7]//span)[1]";
        public string OfferValueInTable { get; } = "(//tr//td[8]//span)[1]";

    }
}
