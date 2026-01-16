using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Services
{
    public class UserAddressService(IUserAddressRepository userAddressRepository) : IUserAddressService
    {
        public UserAddress GetAddressByUserId(int id)
        {

            if(id <= 0)
            {
                throw new Exception("ID do usuário inválido.");
            }

            var address = userAddressRepository.GetAddressByUserId(id);
            
            if (address != null) {
                new Exception("Endereço não encontrado para o usuário informado.");
            }

            return address;
        }
    }
}
