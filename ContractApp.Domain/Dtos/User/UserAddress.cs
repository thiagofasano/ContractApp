using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ContractApp.Domain.Dtos.User
{
    public record UserAddressRequest
    {
        public int UsuarioId { get; init; } 
        public string Street { get; init; } = string.Empty;
        public string Number { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public string State { get; init; } = string.Empty;
        public string Country { get; init; } = string.Empty;
        public string ZipCode { get; init; } = string.Empty;
    }
}
