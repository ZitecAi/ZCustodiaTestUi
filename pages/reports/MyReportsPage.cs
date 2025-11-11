using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.locators.modules;
using zCustodiaUi.locators.reports;
using zCustodiaUi.utils;

namespace zCustodiaUi.pages.reports
{
    public class MyReportsPage
    {
        private IPage page;
        Utils util;
        ModulesElements mod = new ModulesElements();
        MyReportsElements reports = new MyReportsElements();

        public MyReportsPage(IPage page)
        {
            this.page = page;
            util = new Utils(page);
        }

        public async Task ValidateGenerateReportsAndDownloadReport(string fund)
        {
            var tomorrow = DateTime.Now.AddDays(1).Day.ToString();
            var today = DateTime.Now.Day.ToString();


            //Validate generate report
            await util.Click(mod.MainMenu, "Click on main menu");
            await util.Click(mod.ReportsPage, "Click on section reports on main menu");
            await util.Click(reports.MyReportsPage, "Click on My Reports Page to go to page");
            await util.Click(reports.Calendar, "Click on calendar to expand days available");
            await util.Click(reports.DayValue(tomorrow), "set day that want filter");
            await util.Click(reports.SearchBar, $"Click on search bar to search {fund} fund");
            await util.Write(reports.SearchBar, fund, $"filter to {fund}");
            await Task.Delay(500);
            await util.ValidateFundReportGenerated(page, reports.TableReports("1"), $"{fund}", "CAPA_ESTOQUE", "Validate if report generate \"CAPA_ESTOQUE\" is present on the table");
            await util.ValidateDownloadAndLength(page, reports.ButtonDownloadReport("1"), "1", $"Validate Download and lenght of report generated of that report 'CAPA_ESTOQUE' ");

            await util.ValidateFundReportGenerated(page, reports.TableReports("2"), $"{fund}", "LIQUIDADOS_BAIXADOS", "Validate if report generate \"LIQUIDADOS_BAIXADOS\" is present on the table");
            await util.ValidateDownloadAndLength(page, reports.ButtonDownloadReport("2"), "1", $"Validate Download and lenght of report generated of that report 'LIQUIDADOS_BAIXADOS' ");

            await util.ValidateFundReportGenerated(page, reports.TableReports("3"), $"{fund}", "AQUISICAO", "Validate if report generate \"AQUISICAO\" is present on the table");
            await util.ValidateDownloadAndLength(page, reports.ButtonDownloadReport("3"), "1", $"Validate Download and lenght of report generated of that report 'AQUISICAO' ");

            //await util.ValidateFundReportGenerated(page, reports.TableReports("4"), $"{fund}", "ESTOQUE_COMPLETOV2", "Validate if report generate \"ESTOQUE_COMPLETOV2\" is present on the table");
            //await util.ValidateDownloadAndLength(page, reports.ButtonDownloadReport("4"), "1", $"Validate Download and lenght of report generated of that report 'ESTOQUE_COMPLETOV2' ");

            await util.ValidateFundReportGenerated(page, reports.TableReports("5"), $"{fund}", "ESTOQUE_COMPLETO", "Validate if report generate \"ESTOQUE_COMPLETO\" is present on the table");
            await util.ValidateDownloadAndLength(page, reports.ButtonDownloadReport("5"), "1", $"Validate Download and lenght of report generated of that report 'ESTOQUE_COMPLETO' ");

        }

        

    }
}
