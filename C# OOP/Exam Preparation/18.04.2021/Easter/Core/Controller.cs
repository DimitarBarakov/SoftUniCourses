﻿using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType == "HappyBunny")
            {
                HappyBunny hb = new HappyBunny(bunnyName);
                bunnies.Add(hb);
                return String.Format(OutputMessages.BunnyAdded,bunnyType,bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                SleepyBunny sb = new SleepyBunny(bunnyName);
                bunnies.Add(sb);
                return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            IDye dye = new Dye(power);
            bunny.AddDye(dye);
            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.FindByName(eggName);
            List<IBunny> suitableBunnies = bunnies.Models.Where(b => b.Energy >= 50).OrderByDescending(b=>b.Energy).ToList();
            if (suitableBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            Workshop workshop = new Workshop();
            foreach (var bunny in suitableBunnies)
            {
                workshop.Color(egg, bunny);
                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }
                if (egg.IsDone())
                {
                    break;
                }
            }
            if (egg.IsDone())
            {
                return String.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return String.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            List<IEgg> colored = eggs.Models.Where(e => e.IsDone()).ToList();
            sb.AppendLine($"{colored.Count} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                List<IDye> dyes = bunny.Dyes.Where(d => !d.IsFinished()).ToList();
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {dyes.Count} not finished");
            }
            return sb.ToString().Trim();
        }
    }
}
