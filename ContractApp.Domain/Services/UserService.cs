using ContractApp.Domain.Dtos.User.Request;
using ContractApp.Domain.Dtos.User.Response;
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
        public void CreateAccount(UserCreateRequest request)
        {

            // Verificar se o e-mail já está em uso
            var existingUser = GetUserByEmail(request.Email);

            if (existingUser != null)
            {
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
            var createdUser = userRepository.GetUserByEmail(request.Email);

            // Criar e gravar o endereço
            var address = new UserAddress
            {
                UserId = createdUser.Id,
                Street = request.Address?.Street ?? string.Empty,
                Number = request.Address?.Number ?? string.Empty,
                City = request.Address?.City ?? string.Empty,
                State = request.Address?.State ?? string.Empty,
                Country = request.Address?.Country ?? string.Empty,
                ZipCode = request.Address?.ZipCode ?? string.Empty
            };

            userAddressRepository.Add(address);
        }

        public User GetUserByEmail(string email)
        {
            if (email == null)
            {
                throw new Exception("Informe o e-mail");
            }

            var user = userRepository.GetUserByEmail(email);

            return user;
        }

        public UserResponse Auth(UserAuthenticateRequest request)
        {
            var user = userRepository.GetUserByEmail(request.Email);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            var passWordHash = CryptoHelper.ToSha256(request.Password);

            if (user.PasswordHash != passWordHash)
            {
                throw new Exception("Senha inválida");
            }

            var address = userAddressRepository.GetAddressByUserId(user.Id);

            return new UserResponse 
            {
                Id = user.Id,
                Guid = user.Guid,
                Name = user.Name,
                Email = user.Email,
                DocumentType = user.DocumentType,
                DocumentPerson = user.DocumentPerson,
                Address = address != null ? new UserAddressResponse
                {
                    Street = address.Street,
                    Number = address.Number,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode
                } : null
            };
        }

    }
}
