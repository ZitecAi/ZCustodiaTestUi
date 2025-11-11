using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators.reports
{
    public class MyReportsElements
    {

        public string MyReportsPage { get; } = "//span[text()='Meus Relatórios']";
        public string SearchBar { get; } = "#mat-input-2";
        public string Calendar { get; } = "//button[@aria-label='Open calendar']";
        public string DayValue(string day) => $"//td[@role='gridcell']//button//span[text()=' {day} ']";
        public string TableReports (string position) => $"(//table//tbody//tr)[{position}]";
        public string ButtonDownloadReport (string linePosition) => $"(//mat-icon[text()=' download '])[{linePosition}]";
    }
}
