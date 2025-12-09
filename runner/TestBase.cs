using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using zCustodiaUi.utils;

namespace zCustodiaUi.runner
{
    public abstract class TestBase
    {
        protected IPage page;
        private IPlaywright? playwright;
        private IBrowser? browser;
        private IBrowserContext? context;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            VideoHelper.ClearOldVideos();
        }
        protected async Task<IPage> OpenBrowserAsync()
        {
            playwright = await Playwright.CreateAsync();

            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = true,
                Args = new[]
                {
                    "--no-sandbox",
                    "--disable-dev-shm-usage",
                    "--disable-gpu",
                    "--disable-setuid-sandbox"
                }
            };

            browser = await playwright.Chromium.LaunchAsync(launchOptions);

            var videosDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "videos");
            Directory.CreateDirectory(videosDir);

            var contextOptions = new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
                IgnoreHTTPSErrors = true,
                RecordVideoDir = videosDir,
                RecordVideoSize = new RecordVideoSize { Width = 1366, Height = 768 }
            };

            context = await browser.NewContextAsync(contextOptions);
            page = await context.NewPageAsync();
            page.SetDefaultTimeout(60000);
            page.SetDefaultNavigationTimeout(60000);
            page.Console += (_, msg) =>
            {
                if (msg.Type == "error")
                    TestContext.Out.WriteLine($"⚠ Console Error Ignored: {msg.Text}");
            };
            var config = new ConfigurationManager();
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var linkCustodia = config["Links:Custodia"];

            await page.GotoAsync(linkCustodia!, new PageGotoOptions
            {
                Timeout = 60000,
                WaitUntil = WaitUntilState.NetworkIdle
            });
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await WaitForAngularStable(page);
            await WaitForOverlayToDisappear(page);

            return page;
        }
        protected async Task CloseBrowserAsync()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status.ToString();

            try
            {
                if (page != null)
                {
                    await VideoUtils.ForceVideoFinalization(page);
                }

                if (context != null)
                {
                    await context.CloseAsync();
                }

                if (page != null)
                {
                    await VideoHelper.AttachVideoAsync(page, status);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar vídeo no teardown: {ex.Message}");
            }
            finally
            {
                try
                {
                    if (browser != null)
                    {
                        await browser.CloseAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao fechar browser: {ex.Message}");
                }

                try
                {
                    playwright?.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao dispose playwright: {ex.Message}");
                }
            }
        }

        // =============================
        // ANGULAR WAIT HELPERS
        // =============================

        /// <summary>
        /// Aguarda o Angular terminar microtasks, HTTP e detecção de mudanças.
        /// </summary>
        protected async Task WaitForAngularStable(IPage page)
        {
            try
            {
                await page.EvaluateAsync(@"() => {
                    return new Promise(resolve => {
                        if (window.getAllAngularTestabilities) {
                            const testability = window.getAllAngularTestabilities()[0];
                            testability.whenStable(resolve);
                        } else {
                            resolve();
                        }
                    });
                });");
            }
            catch
            {
                // Caso não seja Angular, não quebra
            }
        }

        /// <summary>
        /// Evita Angular Material bloquear cliques com overlays invisíveis.
        /// </summary>
        protected async Task WaitForOverlayToDisappear(IPage page)
        {
            await page.WaitForFunctionAsync(
                "() => !document.querySelector('.cdk-overlay-backdrop')"
            );
        }
    }
}
