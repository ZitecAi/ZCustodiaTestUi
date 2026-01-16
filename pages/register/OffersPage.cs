using System;
using System.Collections.Generic;
using Microsoft.Playwright;
using System.Linq;
using zCustodiaUi.data.register;
using zCustodiaUi.locators;
using zCustodiaUi.locators.register;
using zCustodiaUi.utils;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.pages.register
{
    public class OffersPage
    {
        private readonly IPage _page;
        private readonly Utils _util;
        private readonly GenericElements _gen = new GenericElements();
        private readonly OffersElements _el = new OffersElements();
        private readonly OffersData _data;

        public OffersPage(IPage page, OffersData data = null)
            {
            this._page = page;
            _data = data ?? new OffersData();
            _util = new Utils(_page);            
        }

        public async Task ClickOnNewButton()
        {
            await _util.Click(_gen.LocatorSpanText("Novo"), "Click on new offer button to register a new offer");        
        }

        public async Task FillFormNewOffer()
        {
            var today = DateTime.Now.Day.ToString();

            await _util.Click("("+_gen.LocatorMatLabel(_el.SelectFund)+")[2]", "Click on select fund to expand list of funds");
            await _util.Write(_gen.Filter, _data.FundName, "Select fund to choose fund name");
            await _util.Click(_gen.ReceiveTypeOption(_data.FundName), $"Select fund {_data.FundName} from the options");
            await _util.Click(_gen.LocatorMatLabel(_el.SelectPortfolio), "Click on select portfolio to expand list of portfolios");
            await _util.Write(_gen.Filter, _data.PortfolioName, $"Filter portfolio to choose portfolio {_data.PortfolioName}");
            await _util.Click(_gen.ReceiveTypeOption(_data.PortfolioName), "Select portfolio from the options");
            await _util.Write(_gen.LocatorMatLabel(_el.QuantityOfQuotasInput), _data.QuantityOfQuotas, "Fill the Quantity of Quotas field with quantity of quotas");
            await _util.Write(_gen.LocatorMatLabel(_el.InitialQuotaInput), _data.InitialQuota, "Fill the Initial Quota field with initial quota");
            await _page.Keyboard.PressAsync("Space");
            await _util.Write(_gen.LocatorMatLabel(_el.OfferValueInput), _data.OfferValue, "Fill the Offer Value field with offer value");
            await _page.Keyboard.PressAsync("Space");
            await _util.Click(_el.CalendarOfDeadline, "Click on calendar to choose deadline date");
            await _util.Click(_gen.DayValue(today), $"Select today's date {today} as deadline date");
        }

        public async Task ClickOnSaveButton()
        {
            await _util.Click(_gen.SaveButton, "Click on save button to save the new offer");
        }



    }
}
