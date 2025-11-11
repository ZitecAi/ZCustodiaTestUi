using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators.administrative
{
    public class ClosingOfFundsElements
    {
        public string ClosingFundsPage { get; } = "//span[text()='Fechamento de Fundo']";
        public string SearchBar { get; } = "#mat-input-0";
        public string SearchButton { get; } = "//mat-icon[text()='search']";
        public string FirstCheckbox { get; } = "(//tr[@class='ng-star-inserted']//mat-checkbox)[1]";
        public string Calendar { get; } = "(//button[@aria-label='Open calendar'])[2]";
        public string DayValue (string day) => $"//td[@role='gridcell']//button//span[text()=' {day} ']";
        public string ButtonCloseFund { get; } = "//span[text()='Fechar']";
        public string ButtonSearch { get; } = "//span[text()='Pesquisar']";
        public string SuccessMessageReturned { get; } = "//div[text()='Registro inserido com sucesso, aguarde o processamento']";
    }
}
