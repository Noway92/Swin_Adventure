using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public  class Bag : Item, IHaveIventory
    {
        private Inventory _inventory;

        public Bag(string[] ids,string name,string desc) : base(ids,name,desc)
        {
            _inventory = new Inventory();
        }

        public Game_Object Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id.ToLower());
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public string FullDescription
        {
            get
            {
                return "In the " + Name + " you can see:" + _inventory.ItemList;
            }
        }
    }
}
