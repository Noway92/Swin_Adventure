using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" }) {}

        public string LookAtIn(string thingiD,IHaveIventory container)
        {
            Game_Object game_object = container.Locate(thingiD);
            if (game_object==null)
            {
                return null;
            }
            return game_object.FullDescription;           
        }

        public IHaveIventory FetchContainer(Player p,string ContainerId)
        {
            return (IHaveIventory)p.Locate(ContainerId);
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0] == "look")
                {
                    if (text[1]=="at")
                    {
                        IHaveIventory container = p;
                        if(text.Length==5)
                        {
                            if (text[3]!="in")
                            {
                                return "What do you want to look in?";
                                
                            }
                            container = FetchContainer(p, text[4]);
                            if(container==null)
                            {
                                return "I can't find the " + text[4];
                            }
                        }
                        string result = LookAtIn(text[2], container);
                        if(result==null)
                        {
                            return "I can't find the " + text[2] + " in " + container.Name;

                        }
                        else
                        {
                            return result;
                        }


                    }
                    return "What do you want to look at?";
                }
                return "Error in look input";
            }
            return "I don’t know how to look like that";
        }
    }
}
