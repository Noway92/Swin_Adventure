using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public interface IHaveIventory
    {
        public string Name { get; }
        public Game_Object Locate(string id);
    }
}
