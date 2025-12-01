using Microsoft.Extensions.Configuration;


namespace zCustodiaUi.data.login
{
    public class LoginData
    {
        public static string Config(bool isEmail)
        {
            var config = new ConfigurationManager();
            config.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
            var email = config["Credentials:Email"] ?? Environment.GetEnvironmentVariable("CUSTODIA_EMAIL");
            var senha = config["Credentials:Password"] ?? Environment.GetEnvironmentVariable("CUSTODIA_PASS");

            return isEmail ? $"{email}" : $"{senha}";
        }

        public string Email { get; set; } = Config(true);
        public string Password { get; set; } = Config(false);
        public string InvalidEmail { get; set; } = "al@zitecai";
        public string InvalidPassword { get; set; } = "invalid";
    }
}