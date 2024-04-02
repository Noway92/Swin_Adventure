namespace Swin_Adventure
{
    public class Test_identifiable_object
    {
        IdentifiableObject id;
        IdentifiableObject id2;
        [SetUp]
        public void Setup()
        {
            id = new IdentifiableObject(new string[] { "id1", "id2" });
            id2 = new IdentifiableObject(new string[] { });
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(id.AreYou("id1"));
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(id.AreYou("Test"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(id.AreYou("ID1"));
        }

        [Test]
        public void TestFirstID()
        {
            Assert.IsTrue(id.FirstId == "id1");
        }

        [Test]
        public void TestFirstIDWithNoIDs()
        {
            Assert.IsTrue(id2.FirstId == "");
        }

        [Test]
        public void TestAddID()
        {
            id.AddIdentifier("id3");
            Assert.IsTrue(id.AreYou("id3"));
        }

    }
}