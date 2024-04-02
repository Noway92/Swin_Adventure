using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public abstract class Game_Object : IdentifiableObject
    {
        private string _name;
        private string _description;

        public Game_Object(string[] ids,string name, string desc) : base (ids)
        {
            _name = name;
            _description = desc;
        }
        
        public string Name
        {
            get { return _name; }
        }

        public string ShortDescription
        {
            get { return "a "+ Name + " (" + FirstId + ")"; }

        }

        public virtual string FullDescription
        {
            get { return _description; }
        }

    }
}
