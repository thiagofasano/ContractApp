using ContractApp.Domain.Dtos;
using ContractApp.Domain.Dtos.User;
using ContractApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        UserResponse BuscarPorEmail(string email);
    }
}
