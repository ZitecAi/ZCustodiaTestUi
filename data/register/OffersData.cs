namespace zCustodiaUi.data.register
{
    public class OffersData
    {
        public string FundName { get; set; } = "Zitec FIDC";
        public string PortfolioName { get; set; } = "CarteiraTeste";
        public string QuantityOfQuotas { get; set; } = "1000";
        public string InitialQuota { get; set; } = "10";
        public string OfferValue { get; set; } = "1000";
        public string InvestorProfile { get; set; } = "Restrito por relação prévia";
        public string RestritionObservation { get; set; } = "Cotista já cadastrado";

        public string ExpectedFundPortfolioInTable { get; } = "Zitec FIDC / 185";
        public string ExpectedQuantityOfQuotasInTable { get; } = "10";
        public string ExpectedStatusOfferInTable { get; } = "Aberta";
        public string ExpectedInitialValueInTable { get; } = "10,00";
        public string ExpectedOfferValueInTable { get; } = "10,00";

    }
}
