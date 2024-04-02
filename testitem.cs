namespace Swin_Adventure
{
    public class TestItem
    {
        Item item;
        [SetUp]
        public void Setup()
        {
            item = new Item(new string[] { "sword", "shield" }, "bronze sword", "a sword sharp and big");
        }

        [Test]
        public void TestisIdentifiable()
        {
            Assert.IsTrue(item.AreYou("sword"));
            Assert.IsFalse(item.AreYou("test"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.IsTrue(item.ShortDescription == "a bronze sword (sword)");
        }

        [Test]

        public void TestFullDescription()
        {
            Assert.IsTrue(item.FullDescription == "a sword sharp and big");
        }
    }
}