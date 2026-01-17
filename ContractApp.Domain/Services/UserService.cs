using ContractApp.Domain.Dtos.Subscription.Request;
using ContractApp.Domain.Dtos.User.Request;
using ContractApp.Domain.Dtos.User.Response;
using ContractApp.Domain.Dtos.UserAddress.Response;
using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using UsuariosApp.Domain.Helpers;

namespace ContractApp.Domain.Services
{
    public class UserService(IUserRepository userRepository, IUserAddressRepository userAddressRepository, ISubscriptionService subscriptionService, ISubscriptionAnalysisUsageService subscriptionAnalysisUsageService) : IUserService
    {
        public UserResponseDTO GetById(int id)
        {
            var user = userRepository.GetById(id);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            var address = userAddressRepository.GetAddressByUserId(user.Id);

            return new UserResponseDTO
            {
                Id = user.Id,
                Guid = user.Guid,
                Name = user.Name,
                Email = user.Email,
                DocumentType = user.DocumentType,
                DocumentPerson = user.DocumentPerson,
                Address = new UserAddressResponseDTO
                {
                    Id = address.Id,
                    Street = address.Street,
                    Number = address.Number,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode 
                }
            };

        }

        public void CreateAccount(UserCreateRequestDTO request)
        {

            // Verificar se o e-mail já está em uso
            var existingUser = GetByEmail(request.Email);

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

            // Criar e gravar o endereço
            var createdUser = userRepository.GetUserByEmail(request.Email);
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

            // Criar Subscription Free como default
            subscriptionService.AddFree(1, createdUser.Id);

            var subscription = subscriptionService.GetByUserId(createdUser.Id);

            // Criar AnalysisUsage inicialmente com contador 0
            subscriptionAnalysisUsageService.Add(subscription.Id);
        }

        public void UpdatePassword(int userId, string passwordOld, string passwordNew)
        {
            var user = userRepository.GetById(userId);

            if (user != null) {

                var passWordOldHash = CryptoHelper.ToSha256(passwordOld);

                if (user.PasswordHash != passWordOldHash)
                {
                    throw new Exception("Senha antiga inválida");
                }

                var passWordNewHash = CryptoHelper.ToSha256(passwordNew);

                user.PasswordHash = passWordNewHash;
                user.UpdatedAt = DateTime.UtcNow;

                userRepository.Update(user);
            }
            else
            {
                throw new Exception("Usuário não encontrado");
            }
        }

        public User GetByEmail(string email)
        {
            if (email == null)
            {
                throw new Exception("Informe o e-mail");
            }

            var user = userRepository.GetUserByEmail(email);

            return user;
        }

        public UserResponseDTO Auth(UserAuthenticateRequestDTO request)
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

            return new UserResponseDTO 
            {
                Id = user.Id,
                Guid = user.Guid,
                Name = user.Name,
                Email = user.Email,
                DocumentType = user.DocumentType,
                DocumentPerson = user.DocumentPerson,
                Address = address != null ? new UserAddressResponseDTO
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

        public void Update(int id, UserUpdateRequestDTO request)
        {
            var user = userRepository.GetById(id);
            
            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            user.Name = request.Name;
            user.DocumentType = request.DocumentType;
            user.DocumentPerson = request.DocumentPerson;
            user.UpdatedAt = DateTime.UtcNow;
            
            userRepository.Update(user);
        }


    }
}
