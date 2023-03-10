using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public interface IHero
    {
        BaseHero CreateHero(string type, string name);
    }
}
