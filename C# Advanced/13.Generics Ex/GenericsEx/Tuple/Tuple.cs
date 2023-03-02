using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<TfirstItem, TsecondItem>
    {
        private TfirstItem firstItem;
        private TsecondItem secondItem;
        private Tuple<TfirstItem, TsecondItem> pair;

        public Tuple<TfirstItem, TsecondItem> Pair
        {
            get { return pair; }
            set { pair = value; }
        }


        public TsecondItem SecondItem
        {
            get { return secondItem; }
            set { secondItem = value; }
        }


        public TfirstItem FirstItem
        {
            get { return firstItem; }
            set { firstItem = value; }
        }


        public void Add()
        {
        }

    }
}
