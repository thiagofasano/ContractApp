using ContractApp.Domain.Dtos.UserAddress.Request;
using ContractApp.Domain.Dtos.UserAddress.Response;
using ContractApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Interfaces.Services
{
    public interface IUserAddressService
    {
        public UserAddressResponseDTO GetById(int id);
        public UserAddressResponseDTO GetByUserId(int id);
        public void Update(int id, UserAddressRequestDTO address);
    }
}
