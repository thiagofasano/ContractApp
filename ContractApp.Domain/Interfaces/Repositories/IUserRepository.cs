using ContractApp.Domain.Dtos;
using ContractApp.Domain.Dtos.User;
using ContractApp.Domain.Dtos.User.Request;
using ContractApp.Domain.Dtos.User.Response;
using ContractApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
