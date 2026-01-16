using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.User.Request
{
    public class UserAuthenticateRequestDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
