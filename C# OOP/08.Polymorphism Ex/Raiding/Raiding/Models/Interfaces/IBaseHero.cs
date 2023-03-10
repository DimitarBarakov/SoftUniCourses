using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models.Interfaces
{
    internal interface IBaseHero
    {
        string Name { get; }
        int Power { get; }

        string CastAbility();
    }
}
