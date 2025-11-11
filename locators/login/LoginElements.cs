using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators.login
{
    public class LoginElements
    {
        public string EmailField { get; } = "#mat-input-0";
        public string PasswordField { get; } = "#mat-input-1";
        public string SubmitButton { get; } = "//span[text()='Acessar']";
        public string CustodiaEnvironment { get; } = "//h6[text()='custodia']";
        public string DeveloperEnvironment { get; } = "//h6[text()='developer']";
        public string HomologEnvironment { get; } = "//h6[text()='homolog']";
        public string NextButton { get; } = "//span[text()='Avançar']";
        public string ErrorMessage { get; } = "//div[text()=' Algum erro ocorreu! ']";

    }
}
