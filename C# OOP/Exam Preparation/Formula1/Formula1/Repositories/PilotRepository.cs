using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;
        public PilotRepository()
        {
            models = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => models;

        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            if (models.Any(c => c.FullName == name))
            {
                return models.FirstOrDefault(c => c.FullName == name);
            }
            return null;
        }

        public bool Remove(IPilot model)
        {
            return models.Remove(model);
        }
    }
}
