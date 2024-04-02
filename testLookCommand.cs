using Swin_Adventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjet
{
    public class testLookCommand
    {
        Player player;
        Bag bag;
        Item item;
        LookCommand lc;

        [SetUp]
        public void Setup()
        {
            lc = new LookCommand();
            player = new Player("noe", "he is a blondie man");
            bag = new Bag(new string[] { "bag" }, "Bag", "It's the first bag you have, you can put just 50 items here");
            item = new Item(new string[] { "gem"}, "Gem", "A bright red");
            bag.Inventory.Put(item);
            player.Inventory.Put(item);

        }

        [Test]
        public void TestLookAtme()
        {

            Assert.AreEqual("You are noe, he is a blondie man. You are carrying: a Gem (gem)\n", lc.Execute(player, new string[] { "look", "at", "inventory" }));
        }

        [Test]
        public void TestlookAtGel()
        {
            Assert.AreEqual("A bright red", lc.Execute(player, new string[] { "look", "at", "gem"}));
        }

        [Test]
        public void TestlookAtUnk()
        {
            player.Inventory.Take("gem");
            Assert.AreEqual("I can't find the gem in noe", lc.Execute(player, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void TestlookAtGemInMe()
        {
            Assert.AreEqual("A bright red", lc.Execute(player, new string[] { "look", "at", "gem","in","inventory" }));
        }

        [Test]
        public void TestlookAtGemInBag()
        {
            player.Inventory.Take("gem");
            player.Inventory.Put(bag);
            Assert.AreEqual("A bright red", lc.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void TestlookAtGemInNoBag()
        {
            Assert.AreEqual("I can't find the bag", lc.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void TestlookAtNoGemInBag()
        {
            bag.Inventory.Take("gem");
            player.Inventory.Put(bag);
            Assert.AreEqual("I can't find the gem in Bag", lc.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.AreEqual("I don’t know how to look like that", lc.Execute(player, new string[] { "look", "at", "gem", "in", "bag","Test" }));
            Assert.AreEqual("Error in look input", lc.Execute(player, new string[] { "hello","look","around" }));
            Assert.AreEqual("What do you want to look at?", lc.Execute(player, new string[] { "look", "in", "gem", "in", "bag" }));
            Assert.AreEqual("What do you want to look in?", lc.Execute(player, new string[] { "look", "at", "gem", "at", "bag" }));
        }
    }
}
