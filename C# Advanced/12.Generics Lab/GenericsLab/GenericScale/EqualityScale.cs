using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<t>
    {
        private t left;
        private t right;

        public EqualityScale(t left,t right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            return this.left.Equals(right);
        }
    }
}
