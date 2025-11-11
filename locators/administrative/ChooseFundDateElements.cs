using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators.administrative
{
    public class ChooseFundDateElements
    {
        public string ChooseFundDatePage { get; } = "//span[text()='Alteração Data do Fundo']";
        public string SearchBar { get; } = "#mat-input-4";
        public string ButtonSearch { get; } = "//span[text()='Pesquisar']";
        public string FirstCheckbox { get; } = "(//tr[@class='ng-star-inserted']//mat-checkbox)[1]";
        public string Calendar { get; } = "(//button[@aria-label='Open calendar'])[2]";
        public string DayValue(string day) => $"//td[@role='gridcell']//button//span[text()=' {day} ']";
        public string SuccessMessageReturned { get; } = "//div[text()='Registro inserido com sucesso, aguarde o processamento']";
        public string ChooseButton { get; } = "//span[text()='Alterar']";
        
    }
}
