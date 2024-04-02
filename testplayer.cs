using System.Xml.Linq;

namespace Swin_Adventure
{
    public class TestPlayer
    {
        Player player;
        Item item;
        [SetUp]
        public void Setup()
        {
            player = new Player("noe", "he is a blondie man");
            item = new Item(new string[] { "Test1", "Test2" }, "Test item", "it's a test for print");
            player.Inventory.Put(item);
        }

        [Test]
        public void TestIsIdentifiable()
        {
            Assert.IsTrue(player.AreYou("me"));
            Assert.IsTrue(player.AreYou("inventory"));
        }

        [Test]
        public void TestLocatesPlayers()
        {
            Assert.AreEqual(player.Locate("me"), player);
            Assert.AreEqual(player.Locate("inventory"), player);
        }

        [Test]
        public void TestLocatesNothing()
        {
            Assert.AreEqual(player.Locate("Test"), null);
        }

        [Test]
        public void TestLocatesItems()
        {
            Assert.AreEqual(player.Locate("test1"), item);
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual(player.FullDescription, "You are noe, he is a blondie man. You are carrying: a Test item (test1)\n");
        }
    }
}