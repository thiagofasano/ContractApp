using ContractApp.Domain.Dtos.User;
using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using UsuariosApp.Domain.Helpers;

namespace ContractApp.Domain.Services
{
    public class UserService(IUserRepository userRepository, IUserAddressRepository userAddressRepository) : IUserService
    {
        public void CriarConta(UserCreateRequest request)
        {

            // Verificar se o e-mail já está em uso
            var existingUser = userRepository.BuscarPorEmail(request.Email);

            if (existingUser != null) { 
                throw new Exception("E-mail já está em uso.");
            }

            // Criar o PassWordHash
            var passWordHash = CryptoHelper.ToSha256(request.Password);

            // Criar e gravar o usuário
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                DocumentType = request.DocumentType,
                DocumentPerson = request.DocumentPerson,
                PasswordHash = passWordHash
            };

            userRepository.Add(user);

            // Buscar o usuário recém-criado para obter o ID
            var createdUser = userRepository.BuscarPorEmail(request.Email);

            // Criar e gravar o endereço
            var address = new UserAddress 
            {                 
                UserId = createdUser.Id,
                Street = request.Address?.Street,
                Number = request.Address?.Number,
                City = request.Address?.City,
                State = request.Address?.State,
                Country = request.Address?.Country,
                ZipCode = request.Address?.ZipCode
            };

            userAddressRepository.Add(address);
        }
    }
}
