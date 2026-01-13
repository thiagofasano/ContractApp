using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.User
{
    public record UserUpdateRequest
    {
        public string Name { get; init; } = string.Empty;
        public string DocumentType { get; init; } = string.Empty;
        public string DocumentPerson { get; init; } = string.Empty;
        public UserAddressRequest? Address { get; init; }
    }
}
