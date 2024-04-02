namespace Swin_Adventure
{
    public class TestInventory
    {
        Inventory inventory;
        Item Test;
        [SetUp]
        public void Setup()
        {
            inventory = new Inventory();
            Test = new Item(new string[] { "sword", "shield" }, "bronze sword", "a sword sharp and big");
            inventory.Put(Test);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.IsTrue(inventory.HasItem("sword"));
            Assert.AreEqual(inventory.HasItem("shield"), true);
        }

        [Test]
        public void TestNoFindItem()
        {
            Assert.IsFalse(inventory.HasItem("Test"));
        }

        [Test]
        public void TestFetch()
        {
            Assert.AreEqual(inventory.Fetch("sword"), Test);
        }
        [Test]
        public void TestTake()
        {
            inventory.Take("sword");
            Assert.IsFalse(inventory.HasItem("sword"));
        }

        [Test]
        public void TestItemList()
        {
            inventory.Put(new Item(new string[] { "Test1", "Test2" }, "Test item", "it's a test for print"));
            inventory.Put(new Item(new string[] { "test2", "Test2" }, "another Test item", "it's a test for print"));
            Assert.AreEqual("a bronze sword (sword)\na Test item (test1)\na another Test item (test2)\n", inventory.ItemList);

        }
    }
}