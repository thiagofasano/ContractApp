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
        UserResponse GetById(int id);
        void CreateAccount(UserCreateRequest user);
        User GetUserByEmail(string email);
        UserResponse Auth(UserAuthenticateRequest request);
        void UpdateUser(int id, UserUpdateRequest request);

    }
}
