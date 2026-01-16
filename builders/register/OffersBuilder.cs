using zCustodiaUi.pages.register;

namespace zCustodiaUi.builders.register
{
    public class OffersBuilder : TestBuilder
    {
        private readonly OffersPage _page;

        public OffersBuilder(OffersPage page)
        {
            _page = page;
        }

        public OffersBuilder ClickOnNewButton()
        {
            AddStep(async () => await _page.ClickOnNewButton());
            return this;
        }

        public OffersBuilder FillFormNewOffer()
        {
            AddStep(async () => await _page.FillFormNewOffer());
            return this;
        }

        public OffersBuilder ClickOnSaveButton()
        {
            AddStep(async () => await _page.ClickOnSaveButton());
            return this;
        }
        public OffersBuilder ClickOnFilterButton()
        {
            AddStep(async () => await _page.ClickOnFilterButton());
            return this;
        }

        public OffersBuilder ValidateOfferPresentInTable()
        {
            AddStep(async () => await _page.ValidateOfferPresentInTable());
            return this;
        }

        public OffersBuilder ConsultFundOnFilter()
        {
            AddStep(async () => await _page.ConsultFundOnFilter());
            return this;
        }



    }
}
