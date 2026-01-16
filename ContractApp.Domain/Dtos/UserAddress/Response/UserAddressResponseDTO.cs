using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.UserAddress.Response
{
    public class UserAddressResponseDTO
    {
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public int UserId { get; set; } = 0;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
