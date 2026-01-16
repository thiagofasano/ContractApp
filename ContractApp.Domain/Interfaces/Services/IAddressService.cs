using ContractApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Interfaces.Services
{
    public interface IUserAddressService
    {
        public UserAddress GetAddressByUserId(int id);
    }
}
