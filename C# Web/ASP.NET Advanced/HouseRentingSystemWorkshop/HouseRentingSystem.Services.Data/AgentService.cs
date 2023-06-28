using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Data;
using HouseRentingSystem.Web.ViewModels.Agent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Data
{
    public class AgentService : IAgentService
    {
        private readonly HouseRentingSystemDbContext dbContext;

        public AgentService(HouseRentingSystemDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<bool> AgentExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await dbContext.Agents.AnyAsync(a=>a.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> AgentExistsByUserId(string userId)
        {
            bool result = await dbContext.Agents.AnyAsync(a => a.UserId.ToString() == userId);

            return result;
        }

        public async Task Create(string userId, BecomeAgentFormModel model)
        {
            Agent agentToAdd = new Agent()
            {
                UserId = Guid.Parse(userId),
                PhoneNumber = model.PhoneNumber
            };

            await dbContext.Agents.AddAsync(agentToAdd);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> HasRentsAsync(string userId)
        {
            bool result = await dbContext.Houses.AnyAsync(h => h.RenterId.ToString() == userId);

            return result;
        }
    }
}
