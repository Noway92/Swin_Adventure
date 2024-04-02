using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Player : Game_Object, IHaveIventory
    {
        private Inventory _inventory;
        public Player(string name,string desc) : base(new string[] {"me","inventory"},name,desc)
        {
            _inventory = new Inventory();
        }
        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription
        {
            get 
            {
                if(_inventory.ItemList=="")
                {
                    return "You are " + Name + ", " + base.FullDescription;
                }
                return "You are " + Name + ", " + base.FullDescription + ". You are carrying: " + _inventory.ItemList;
            }
        }

        public Game_Object Locate(string id)
        {
            if(AreYou(id))
            {
                return this;              
            }
            return _inventory.Fetch(id.ToLower());
        }
    }
}
