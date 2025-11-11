using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;


namespace zCustodiaUi.utils
{
    public class Utils
    {
        private readonly IPage page;
        public Utils(IPage page)
        {
            this.page = page;
        }

        [AllureStep("Escrever '{text}' em {locator} — {step}")]
        public async Task Write(string locator, string text, string step)
        {
            try
            {
                var elemento = page.Locator(locator);
                await elemento.WaitForAsync();
                await elemento.FillAsync(text);
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t Possible Found the element: {locator}, to write on step: {step}. Details {ex.Message}");
            }
        }
        [AllureStep("Clicae em {locator} — {step}")]
        public async Task Click(string locator, string step)
        {
            try
            {
                var elemento = page.Locator(locator);
                await elemento.WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });
                await elemento.ClickAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t Possible Found the element: {locator}, to Click on step: {step}. Details {ex.Message}");
            }
        }

        public async Task ValidateUrl(string expectedUrl, string step)
        {
            try
            {
                await page.WaitForURLAsync(expectedUrl);
                if (expectedUrl == "https://custodia.idsf.com.br/home/dashboard")
                {
                    await Expect(page).ToHaveURLAsync(expectedUrl);
                }
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate expected Url: '{expectedUrl}' on step: '{step}'. Details: {ex.Message}");
            }
        }

        public async Task ValidateReturnedMessageIsVisible(string locator, string step)
        {
            try
            {
                await page.WaitForSelectorAsync(locator, new PageWaitForSelectorOptions
                {
                    State = WaitForSelectorState.Visible
                });
                await Expect(page.Locator(locator)).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate/found the element:'{locator}' on step: '{step}'. Details: {ex.Message}");
            }
        }

        public async Task ValidateElementPresentOnTheTable(IPage page, string locatorTable, string expectedText, string step)
        {
            try
            {
                await page.WaitForSelectorAsync(locatorTable, new PageWaitForSelectorOptions
                {
                    State = WaitForSelectorState.Visible
                });

                var locator = page.Locator(locatorTable);
                int count = await locator.CountAsync();

                bool textFound = false;

                for (int i = 0; i < count; i++)
                {
                    var text = await locator.Nth(i).InnerTextAsync();

                    if (!string.IsNullOrWhiteSpace(text) && text.Contains(expectedText, StringComparison.OrdinalIgnoreCase))
                    {
                        textFound = true;
                        Console.WriteLine($" Text found: {text}");
                        break;
                    }
                }

                Assert.That(textFound, Is.True, $" The text '{expectedText}' don´t found on the table: {locatorTable}");
            }
            catch (TimeoutException)
            {
                throw new Exception($" time out to wait the table is visible on step: {step}");
            }
            catch (Exception ex)
            {
                throw new Exception($" Error to verify the text'{expectedText}' on the table on step: {step}. Details {ex.Message}");
            }
        }

        public async Task ValidateFundReportGenerated(IPage page, string lineSelector, string expectedFundo, string expectedRelatorio, string step)
        {
            try
            {
                string fundPosition = lineSelector + "//td[2]//app-table-cell//div//span";
                string reportPosition = lineSelector + "//td[4]//app-table-cell//div//span";

                string fundText = (await page.Locator(fundPosition).InnerTextAsync()).Trim();
                string reportText = (await page.Locator(reportPosition).InnerTextAsync()).Trim();

                Assert.That(fundText, Does.Contain(expectedFundo).IgnoreCase);
                Assert.That(reportText, Does.Contain(expectedRelatorio).IgnoreCase);
            }
            catch (Exception ex)
            {
                throw new Exception($"Don´t possible validate generation report on step: {step}. Details {ex.Message}");
            }
        }



        public async Task ValidateDownloadAndLength(IPage page, string locatorClickDownload, string step, string downloadsDir = null)
        {
            try
            {
                downloadsDir ??= Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Downloads"
                );

                // Dispara o download e captura o objeto
                var download = await page.RunAndWaitForDownloadAsync(async () =>
                {
                    var element = page.Locator(locatorClickDownload);
                    await element.WaitForAsync();
                    await element.ClickAsync();
                });

                // Nome real sugerido pelo navegador
                var fileName = download.SuggestedFilename;
                var finalPath = Path.Combine(downloadsDir, fileName);

                // Remove arquivo pré-existente com o mesmo nome
                if (File.Exists(finalPath))
                    File.Delete(finalPath);

                // Salva no destino final
                await download.SaveAsAsync(finalPath);

                // Validações
                Assert.That(File.Exists(finalPath), $"❌ Arquivo '{fileName}' não foi salvo.");
                var info = new FileInfo(finalPath);
                Assert.That(info.Length, Is.GreaterThan(0), $"❌ Arquivo '{fileName}' está vazio (0 bytes).");

                Console.WriteLine($"✅ Download ok: '{fileName}' | {info.Length} bytes.");

                // (Opcional) limpar depois
                // File.Delete(finalPath);
                // Console.WriteLine("ℹ️ Arquivo excluído após validação.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"❌ Erro ao validar download no passo '{step}': {ex.Message}");
            }
        }

        public async Task ScrollToElementAndMaintainPosition(string locator, string step)
        {
            try
            {
                var element = page.Locator(locator);
                await element.WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });
                await element.ScrollIntoViewIfNeededAsync();

                // Wait for any JavaScript to settle
                await Task.Delay(1000);

                // Check if element is still visible, if not scroll again
                var isVisible = await element.IsVisibleAsync();
                if (!isVisible)
                {
                    await element.ScrollIntoViewIfNeededAsync();
                    await Task.Delay(500);
                }
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t Possible Found the element:  {locator} to scroll and maintain position on step: {step}. Details {ex.Message}");
            }
        }

        public async Task ClickMatTabAsync(string tabLocator, string step)
        {
            try
            {
                var tab = page.Locator(tabLocator);
                await tab.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Attached,
                    Timeout = 60000
                });

                await tab.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 60000
                });
                await page.WaitForTimeoutAsync(500);
                await tab.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 60000
                });

                await tab.ClickAsync(new LocatorClickOptions
                {
                    Timeout = 60000,
                    Force = true,  // Bypass actionability checks
                    Position = new Position { X = 10, Y = 10 }  // Click near top-left corner
                });
                await tab.ClickAsync();
                // 5. Wait for Angular to process the click
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                await page.WaitForTimeoutAsync(300); // Additional stability wait
            }
            catch (Exception ex)
            {
                throw new PlaywrightException(
                    $"Failed to click Angular Material tab: {tabLocator} in step: {step} .Error: {ex.Message}."
                );
            }
        }

        public async Task ValidateTextIsVisibleInElement(string locator, string expectedText, string step)
        {
            try
            {
                ILocator element = page.Locator(locator);
                await Expect(element).ToHaveTextAsync(expectedText);
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate/found the element on {step}. Details {ex.Message}");
            }

        }
        [AllureStep("Validar Texto '{text}' Visível na tela para usuário — {step}")]
        public async Task ValidateTextIsVisibleOnScreen(string expectedText, string step)
        {
            try
            {
                ILocator text = page.GetByText(expectedText);
                await Expect(text).ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate/found the element on {step}. Details {ex.Message}");
            }

        }
        public async Task ValidateTextIsNotVisibleOnScreen(string expectedText, string step)
        {
            try
            {
                ILocator text = page.GetByText(expectedText);
                await Expect(text).Not.ToBeVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate/found the element on {step}. Details {ex.Message}");
            }

        }

        public async Task<string> ValidateIfElementHaveValue(string locator, string step)
        {
            try
            {
                var getText = page.Locator(locator).InnerTextAsync();
                string id = getText.Result;
                if (string.IsNullOrWhiteSpace(id))
                {
                    Assert.Fail($"The element: {locator} don´t have value on the step: {step}");
                }
                Console.WriteLine($"The element: {locator} have value! value is: {id}");

                return id;
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate/found the element on {step}. Details  {ex.Message}");
            }

        }


        public async Task<string> UpdateDateAndSentFile(string filePath, string locator, string step)
        {
            try
            {

                var linhas = File.ReadAllLines(filePath);
                // Change date
                string actualDate = DateTime.Now.ToString("ddMMyy");
                string DateFileTemplate = linhas[0].Substring(94, 6);
                string BeforeData = linhas[0].Substring(0, 94);
                string PostData = linhas[0].Substring(101);
                linhas[0] = linhas[0].Replace("#DATA#", actualDate);
                // Change num consultancy
                Random random = new Random();
                for (int i = 1; i <= 2; i++)
                {
                    string randomNumber = "";
                    for (int j = 0; j < 25; j++)
                    {
                        randomNumber += random.Next(0, 10).ToString();
                    }
                    linhas[i] = linhas[i].Replace("#DOC_NUMERO_CONSULTORIA_#", randomNumber);
                    string randomNumberNumDoc = "";
                    for (int j = 0; j < 10; j++)
                    {
                        randomNumberNumDoc += random.Next(0, 10).ToString();
                    }
                    linhas[i] = linhas[i].Replace("#NUM_DOCU#", randomNumberNumDoc);
                }

                string dataFormatada = DateTime.Now.ToString("yyyyMMdd");
                // Use GUID to ensure file name is unique
                string uniqueIdentifier = Guid.NewGuid().ToString().Split('-')[0];
                string nameNewFile = $"FundoQA_{dataFormatada}_{uniqueIdentifier}.txt";
                string newPathFile = Path.Combine(Path.GetDirectoryName(filePath), nameNewFile);

                File.WriteAllLines(newPathFile, linhas);
                var fileInput = page.Locator(locator);
                await fileInput.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Attached,
                    Timeout = 15000
                });

                await fileInput.SetInputFilesAsync(newPathFile);
                Console.WriteLine($"File {nameNewFile} Sent successfull.");

                return nameNewFile;
            }
            catch (Exception ex)
            {
                throw new Exception($"Don´t possible Found File: {filePath} on step: {step}. Details {ex.Message}");
            }
        }


        public async Task ValidateElementHaveValue(string locator, string step)
        {
            try
            {
                bool hasValue = false;
                while (hasValue == false)
                {
                    string text = await page.Locator(locator).InputValueAsync();
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        hasValue = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PlaywrightException($"Don´t possible validate/found the element on step: {step}. Details {ex.Message}");
            }
        }



    }
}
