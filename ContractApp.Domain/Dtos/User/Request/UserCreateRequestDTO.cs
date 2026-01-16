using ContractApp.Domain.Dtos.UserAddress.Request;
using ContractApp.Domain.Dtos.UserAddress.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.User.Request
{
    public class UserCreateRequestDTO
    {
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string DocumentType { get; init; } = string.Empty;
        public string DocumentPerson { get; init; } = string.Empty;     
        public string Password { get; init; } = string.Empty;
        public UserAddressRequestDTO? Address { get; init; }
    }
}
