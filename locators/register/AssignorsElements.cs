using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCustodiaUi.locators.register
{
    public class AssignorsElements
    {
        //General Data
        public string AssignorPage { get; } = "//span[text()='Cedentes Ativos']";
        public string NewAssignorButton { get; } = "//span[text()=' Novo ']";
        public string FormAssignors { get; } = "//span[text()='Formulário de Cedentes']";
        
        public string Authorization (bool isTrue) => $"#mat-radio-{(isTrue ? "5":"6")}-input";
        public string Pattern(bool isTrue) => $"#mat-radio-{(isTrue ? "26":"27")}-input";
        public string Assign(bool isTrue) => $"#mat-radio-{(isTrue ? "32":"33")}-input";
        public string AssignTerm(bool isTrue) => $"#mat-radio-{(isTrue ? "35":"36")}-input";
        public string AssignByEndorsement(bool isTrue) => $"#mat-radio-{(isTrue ? "38":"39")}-input";
        public string IssueDouble (bool isTrue) => $"#mat-radio-{(isTrue ? "41":"42")}-input";
        public string ApplyFilterButton { get; } = "//span[text()='Filtro']";
        public string IdPosition { get; } = "(//td//app-table-cell//div//span)[1]";

        
        //Location
       
        public string TelInput { get; } = "#input-telefoneDDD";
        //tax data
       

    }
}
