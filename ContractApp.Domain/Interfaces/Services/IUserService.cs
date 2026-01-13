using ContractApp.Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Interfaces.Services
{
    public interface IUserService
    {
        void CriarConta(UserCreateRequest user);
     }
}
