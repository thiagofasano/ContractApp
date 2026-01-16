using ContractApp.Domain.Dtos.User.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.User.Request
{
    public class UserUpdateRequest
    {
        public string Name { get; init; } = string.Empty;
        public string DocumentType { get; init; } = string.Empty;
        public string DocumentPerson { get; init; } = string.Empty;
        public UserAddressResponse? Address { get; init; }
    }
}
