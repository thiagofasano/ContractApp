using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.User.Request
{
    public class UserUpdatePasswordRequestDTO
    {
        public string PasswordOld { get; set; } = string.Empty;
        public string PasswordNew { get; set; } = string.Empty;
    }
}
