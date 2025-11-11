using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators.processing
{
    public class ReceivablesElements
    {
        public string ReceivablesPage { get; } = "//span[text()='Recebiveis']";
        public string SecondCheckBox { get; } = "(//div[@class='mdc-checkbox__background'])[2]";
        public string StatusPositionOnTheTable { get; } = "//app-status-column//div";
    }
}
