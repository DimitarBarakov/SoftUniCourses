using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Bag : IBag
    {
        private ICollection<string> items;
        public Bag()
        {
            this.items = new List<string>();
        }
        public ICollection<string> Items
        {
            get => this.items;
            set => this.items = value;
        }

    }
}
