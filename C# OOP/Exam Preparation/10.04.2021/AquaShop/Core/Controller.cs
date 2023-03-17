using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            if (aquariumType == "FreshwaterAquarium")
            {
                FreshwaterAquarium fq = new FreshwaterAquarium(aquariumName);
                aquariums.Add(fq);
                return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            SaltwaterAquarium sq = new SaltwaterAquarium(aquariumName);
            aquariums.Add(sq);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);

        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                Ornament ornament = new Ornament();
                decorations.Add(ornament);
                return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else if (decorationType == "Plant")
            {
                Plant plant = new Plant();
                decorations.Add(plant);
                return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            if (fishType == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium")
            {
                FreshwaterFish fish = new FreshwaterFish(fishName, fishSpecies, price);
                aquarium.AddFish(fish);
                return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            if (fishType == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium")
            {
                SaltwaterFish fish = new SaltwaterFish(fishName, fishSpecies, price);
                aquarium.AddFish(fish);
                return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            return OutputMessages.UnsuitableWater;
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            decimal fishesPrice = aquarium.Fish.Sum(f => f.Price);
            decimal decorationsPrice = aquarium.Decorations.Sum(d => d.Price);
            decimal totalPrice = fishesPrice + decorationsPrice;

            return String.Format(OutputMessages.AquariumValue, aquariumName, totalPrice);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(a=>a.Name == aquariumName);
            aquarium.Feed();
            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            IDecoration decoration = decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aq in aquariums)
            {
                sb.AppendLine(aq.GetInfo());
            }
            return sb.ToString().Trim();
        }
    }
}
