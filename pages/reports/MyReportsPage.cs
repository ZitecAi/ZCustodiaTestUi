using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using zCustodiaUi.data.reports;
using zCustodiaUi.locators.modules;
using zCustodiaUi.locators.reports;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.reports
{
    public class MyReportsPage
    {
        private IPage _page;
        Utils _util;
        ModulesElements _mod = new ModulesElements();
        MyReportsElements _reports = new MyReportsElements();
        private readonly MyReportsData _data = new MyReportsData();

        public MyReportsPage(IPage _page)
        {
            this._page = _page;
            _util = new Utils(_page);
        }
        [AllureStep("Generate Report and download")]
        public async Task ValidateGenerateReportsAndDownloadReport(string fund)
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();
            var today = DateTime.Now.Day.ToString();


            //Validate generate report
            await _util.Click(_mod.MainMenu, "Click on main menu");
            await _util.Click(_mod.ReportsPage, "Click on section reports on main menu");
            await _util.Click(_reports.MyReportsPage, "Click on My Reports Page to go to page");
            await _util.Click(_reports.Calendar, "Click on calendar to expand days available");
            await _util.Click(_reports.DayValue(tomorrow), "set day that want filter");
            await _util.Click(_reports.SearchBar, $"Click on search bar to search {_data.Fund} fund");
            await _util.Write(_reports.SearchBar, _data.Fund, $"filter to {_data.Fund}");
            await Task.Delay(500);
            await _util.ValidateFundReportGenerated(_page, _reports.TableReports("1"), $"{_data.Fund}", "CAPA_ESTOQUE", "Validate if report generate \"CAPA_ESTOQUE\" is present on the table");
            await _util.ValidateDownloadAndLength(_page, _reports.ButtonDownloadReport("1"), "1", $"Validate Download and lenght of report generated of that report 'CAPA_ESTOQUE' ");

            await _util.ValidateFundReportGenerated(_page, _reports.TableReports("2"), $"{_data.Fund}", "LIQUIDADOS_BAIXADOS", "Validate if report generate \"LIQUIDADOS_BAIXADOS\" is present on the table");
            await _util.ValidateDownloadAndLength(_page, _reports.ButtonDownloadReport("2"), "1", $"Validate Download and lenght of report generated of that report 'LIQUIDADOS_BAIXADOS' ");

            await _util.ValidateFundReportGenerated(_page, _reports.TableReports("3"), $"{_data.Fund}", "AQUISICAO", "Validate if report generate \"AQUISICAO\" is present on the table");
            await _util.ValidateDownloadAndLength(_page, _reports.ButtonDownloadReport("3"), "1", $"Validate Download and lenght of report generated of that report 'AQUISICAO' ");

            //await _util.ValidateFundReportGenerated(_page, _reports.TableReports("4"), $"{_data.Fund}", "ESTOQUE_COMPLETOV2", "Validate if report generate \"ESTOQUE_COMPLETOV2\" is present on the table");
            //await _util.ValidateDownloadAndLength(_page, _reports.ButtonDownloadReport("4"), "1", $"Validate Download and lenght of report generated of that report 'ESTOQUE_COMPLETOV2' ");

            await _util.ValidateFundReportGenerated(_page, _reports.TableReports("5"), $"{_data.Fund}", "ESTOQUE_COMPLETO", "Validate if report generate \"ESTOQUE_COMPLETO\" is present on the table");
            await _util.ValidateDownloadAndLength(_page, _reports.ButtonDownloadReport("5"), "1", $"Validate Download and lenght of report generated of that report 'ESTOQUE_COMPLETO' ");

        }



    }
}
