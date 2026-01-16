using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Repositories
{
    public class PlanRepository : BaseRepository<Plan>, IPlanRepository 
    {
    }
}
