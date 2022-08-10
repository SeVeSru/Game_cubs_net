namespace Game_cubs_net.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_pole_true()
        {
            int player = 1;
            int rx = 2;
            int ry = 2;

            bool test = Game_cubs.CheckPole(player, rx, ry);
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void Test_pole_false()
        {
            int player = 0;
            int rx = 2;
            int ry = 2;

            bool test = Game_cubs.CheckPole(player, rx, ry);
            Assert.IsFalse(test);
        }
    }
}