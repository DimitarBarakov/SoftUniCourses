﻿using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    internal class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => models;

        public void Add(IPlanet model) => this.models.Add(model);


        public IPlanet FindByName(string name) => this.models.FirstOrDefault(p => p.Name == name);

        public bool Remove(IPlanet model) => this.models.Remove(model);
    }
}
