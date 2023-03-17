using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;
        public RaceRepository()
        {
            models = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => models;

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IRace FindByName(string name)
        {
            if (models.Any(c => c.RaceName == name))
            {
                return models.FirstOrDefault(c => c.RaceName == name);
            }
            return null;
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }
    }
}
