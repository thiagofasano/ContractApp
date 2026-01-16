using ContractApp.Domain.Dtos.UserAddress.Request;
using ContractApp.Domain.Dtos.UserAddress.Response;
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
        public UserAddressResponseDTO GetById(int id)
        {
            var address = userAddressRepository.GetById(id);

            if (address == null)
            {
                throw new Exception("Endereço não encontrado.");
            }

            return new UserAddressResponseDTO
            {
                Id = address.Id,
                Guid = address.Guid,
                UserId = address.UserId,
                Street = address.Street,
                Number = address.Number,
                City = address.City,
                State = address.State,
                Country = address.Country,
                ZipCode = address.ZipCode
            };
        }

        public UserAddressResponseDTO GetByUserId(int id)
        {

            if(id <= 0)
            {
                throw new Exception("ID do usuário inválido.");
            }

            var address = userAddressRepository.GetAddressByUserId(id);
            
            if (address != null) {
                new Exception("Endereço não encontrado para o usuário informado.");
            }

            return new UserAddressResponseDTO
            {
                Id = address.Id,
                Guid = address.Guid,
                UserId = address.UserId,
                Street = address.Street,
                Number = address.Number,
                City = address.City,
                State = address.State,
                Country = address.Country,
                ZipCode = address.ZipCode
            };
        }

        public void Update(int id, UserAddressRequestDTO address)
        {
            var addressToUpdate = userAddressRepository.GetById(id);
            if (addressToUpdate != null)
            {
                addressToUpdate.Street = address.Street;
                addressToUpdate.Number = address.Number;
                addressToUpdate.City = address.City;
                addressToUpdate.State = address.State;
                addressToUpdate.Country = address.Country;
                addressToUpdate.ZipCode = address.ZipCode;
                addressToUpdate.UpdatedAt = DateTime.UtcNow;

                userAddressRepository.Update(addressToUpdate);
            }
            else
            {
                throw new Exception("Endereço não encontrado para atualização.");
            }
        }
    }
}
