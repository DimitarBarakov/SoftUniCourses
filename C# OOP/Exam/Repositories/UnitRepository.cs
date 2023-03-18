using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;
        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => models.AsReadOnly();

        public void AddItem(IMilitaryUnit model) => this.models.Add(model);

        public IMilitaryUnit FindByName(string name) => this.models.FirstOrDefault(m => m.GetType().Name == name);

        public bool RemoveItem(string name) => this.models.Remove(this.models.FirstOrDefault(m => m.GetType().Name == name));
        //{
        //    if (this.models.Any(m => m.GetType().Name == name))
        //    {
        //        IMilitaryUnit militaryUnitToRemove = this.models.First(m => m.GetType().Name == name);
        //        this.models.Remove(militaryUnitToRemove);
        //        return true;
        //    }
        //    return false;
        //}
    }
}
