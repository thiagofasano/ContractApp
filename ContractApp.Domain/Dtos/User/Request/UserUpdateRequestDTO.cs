using ContractApp.Domain.Dtos.UserAddress.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.User.Request
{
    public class UserUpdateRequestDTO
    {
        public string Name { get; init; } = string.Empty;
        public string DocumentType { get; init; } = string.Empty;
        public string DocumentPerson { get; init; } = string.Empty;
    }
}
