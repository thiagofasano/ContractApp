using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.UserAddress.Request
{
    public class UserAddressRequestDTO
    {
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
