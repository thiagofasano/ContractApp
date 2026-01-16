using ContractApp.Domain.Dtos;
using ContractApp.Domain.Dtos.User.Response;
using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public User GetUserByEmail(string email)
        {
            using (var dataContext = new DataContext()) {                 
                var user = dataContext.Set<User>()
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Email == email);

                if (user == null)
                {
                    return null;
                }

                return user;
            }
        }
    }
}
