using System.Xml.Linq;

namespace Swin_Adventure
{
    public class TestBags
    {
        Bag bag1;
        Item item1;
        Item item2;
        [SetUp]
        public void Setup()
        {
            item1 = new Item(new string[] { "sword" }, "bronze sword", "a sword sharp and big");
            item2 = new Item(new string[] { "shield" }, "Shield", "a good shield that protect you from getting killed");
            bag1 = new Bag(new string[] { "bag1" }, "Bag1", "It's the first bag you have, you can put just 50 items here");
            bag1.Inventory.Put(item1);
            bag1.Inventory.Put(item2);
        }

        [Test]
        public void TestLocateItSelf()
        {
            Assert.AreEqual(bag1, bag1.Locate("bag1"));
        }
        [Test]
        public void TestLocateItems()
        {
            Assert.AreEqual(item1, bag1.Locate("sword"));
            Assert.AreEqual(item2, bag1.Locate("shield"));
        }

        [Test]
        public void TestLocateNothing()
        {
            Assert.AreEqual(null, bag1.Locate("Test"));
        }

        [Test]

        public void TestBagFullDescription()
        {
            Assert.AreEqual("In the Bag1 you can see:a bronze sword (sword)\na Shield (shield)\n", bag1.FullDescription);

        }

        [Test]
        public void TestBaginBag()
        {
            Bag bag2 = new Bag(new string[] { "bag2" }, "Bag2", "It's the second bag you have, you can put just 200 items here");
            Item item3 = new Item(new string[] { "paper" }, "Paper", "Somehere you can write at");
            bag2.Inventory.Put(item3);
            bag1.Inventory.Put(bag2);

            Assert.AreEqual(item1, bag1.Locate("sword"));
            Assert.AreEqual(bag2, bag1.Locate("bag2"));
            Assert.AreEqual(item3, bag2.Locate("paper"));
            Assert.AreEqual(null, bag1.Locate("paper"));
        }
    }
}