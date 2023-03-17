using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> models;
        public HeroRepository()
        {
            models = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models { get { return this.models; } }

        public void Add(IHero model)
        {
            this.models.Add(model);
        }

        public IHero FindByName(string name)
        {
            if (models.Any(m=>m.Name == name))
            {
                return this.models.First(m => m.Name == name);
            }
            return null;
        }

        public bool Remove(IHero model)
        {
            if (this.models.Contains(model))
            {
                models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
