using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Repositories
{
    public class UserAddressRepository : BaseRepository<UserAddress>, IUserAddressRepository
    {
        public UserAddress GetAddressByUserId(int id)
        {
            using (var dataContext = new DataContext())
            {
                var userAddress = dataContext.Set<UserAddress>()
                    .FirstOrDefault(ua => ua.UserId == id);
                if (userAddress == null)
                {
                    return null;
                }
                return userAddress;
            }
        }
    }
}
