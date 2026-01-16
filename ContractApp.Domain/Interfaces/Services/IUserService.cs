using ContractApp.Domain.Dtos.User.Request;
using ContractApp.Domain.Dtos.User.Response;
using ContractApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Interfaces.Services
{
    public interface IUserService
    {
        UserResponseDTO GetById(int id);
        User GetByEmail(string email);
        UserResponseDTO Auth(UserAuthenticateRequestDTO request);
        void CreateAccount(UserCreateRequestDTO user);
        void Update(int id, UserUpdateRequestDTO request);
        void UpdatePassword (int userId, string passwordOld, string passwordNew);

    }
}
