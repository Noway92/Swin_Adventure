using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Inventory
    {
        private List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();
        }

        public string ItemList
        {
            get
            {
                string a = "";
                foreach(Item item in _items)
                {
                    a += item.ShortDescription + "\n";
                }
                return a;
            }
        }

        public bool HasItem(string id)
        {
            foreach (Item i in _items) 
            {
                if(i.AreYou(id.ToLower()))
                {
                    return true;
                }            
            }
            return false;            
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
            }
            return null;
        }

        public Item Take(string id)
        {
            Item item = Fetch(id.ToLower());
            _items.Remove(item);
            return item;
        }
    }
}
