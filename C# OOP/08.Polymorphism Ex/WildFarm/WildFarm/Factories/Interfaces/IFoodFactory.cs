using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        Food CreateFood(string[] tokens);
    }
}
