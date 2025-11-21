using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zCustodiaUi.utils;

namespace zCustodiaUi.data.login
{
    public class LoginData
    {
        public string Email { get; set; } = "al@zitec.ai";
        public string Password { get; set; } = "12345678";
        public string InvalidEmail { get; set; } = "al@zitecai";
        public string InvalidPassword { get; set; } = "invalid";
    }
}