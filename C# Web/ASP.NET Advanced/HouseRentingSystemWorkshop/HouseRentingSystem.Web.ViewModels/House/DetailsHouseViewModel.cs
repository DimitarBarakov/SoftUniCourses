using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Web.ViewModels.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agent = HouseRentingSystem.Data.Models;

namespace HouseRentingSystem.Web.ViewModels.House
{
    public class DetailsHouseViewModel : AllHouseViewModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public AgentInfoInDetailsHouseViewModel Agent { get; set; } = null!;
    }
}
