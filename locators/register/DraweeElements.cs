using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators.register
{
    public class DraweeElements
    {
        //General Data
        public string DraweePage { get; } = "//span[text()='Sacados']";
        public string CalendarStartRelationship { get; } = "(//button[@aria-label='Open calendar'])[1]";
        public string CalendarEndRelationship { get; } = "(//button[@aria-label='Open calendar'])[2]";
        public string DraweeTable { get; } = "//tbody//tr//td[1]//span[1]";
        public string NeighborhoodInput { get; } = "//input[@id='input-bairro']";
        public string DayValue(string day) => $"//td[@role='gridcell']//button//span[text()=' {day} ']";

        //Location


        //tax data


    }
}
