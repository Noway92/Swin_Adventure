using static System.Net.Mime.MediaTypeNames;

namespace Swin_Adventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey, What's your name ? ");
            string name = Console.ReadLine();
            Console.WriteLine("Give me your description : ");
            string description = Console.ReadLine();
            Player p1 = new Player(name, description);
            Item item1 = new Item(new string[] { "gem" }, "Gem", "A bright red");
            Item item2 = new Item(new string[] { "shield" }, "Shield", "a good shield that protect you from getting killed");
            p1.Inventory.Put(item1);
            p1.Inventory.Put(item2);
            Bag bag1 = new Bag(new string[] { "bag" }, "Bag", "It's the first bag you have, you can put just 50 items here");
            p1.Inventory.Put(bag1);
            Item item3 = new Item(new string[] { "sword" }, "bronze sword", "a sword sharp and big");
            bag1.Inventory.Put(item3);
            LookCommand C1 = new LookCommand();
            string test = "";
            Console.WriteLine("If you want to stop the loop, write 'stop'");
            while(test!="stop")
            {
                Console.WriteLine("What do you want to look at ?");
                test = Console.ReadLine();
                if(test!="stop")
                {
                    Console.WriteLine(C1.Execute(p1, test.Split(" ")));
                }               

            }



        }
    }
}