using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.utils;

namespace zCustodiaUi.locators.Importation
{
    public class ShippingFileElements
    {
        public string ShippingFilePage { get; } = "//span[text()='Arquivo Remessa']";
        public string ProcessButton { get; } = "//span[text()='Processar']";
        public string Dropzone { get; } = "//div[@dropzone]";
        public string Calendar { get; } = "(//button[@aria-label='Open calendar'])[2]";
        public string IdPositionOnTheTable(string nameFile) => $"(//span[contains(text(),'{nameFile}')]/ancestor::tr//td)[2]//span";
        public string NameFilePositionOnTheTable(string idFile) => $"(//span[text()=' {idFile} ']/ancestor::tr//td)[3]//span";
        public string ReegistersNumber { get; } = "//app-table-header//div//div//span";
        public string Table { get; } = "//table//tbody";
        public string DeleteButton (string fileName) => $"//span[normalize-space(text())='{fileName}']/ancestor::tr//button[.//mat-icon[normalize-space(text())='delete']]";



    }
}
