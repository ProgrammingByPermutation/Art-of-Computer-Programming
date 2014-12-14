using Fundamental_Algorithms.Basic_Concepts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Fundamental_Algorithms.Basic_Concepts
{
    [TestClass]
    public class PermutationsUnitTest
    {
        [TestMethod]
        public void MultiplyTestMethod()
        {
            // (acf)(bd)(abd)(ef)=(acefb)
            Assert.AreEqual(Permutations.Multiply("(acfg)(bcd)(aed)(fade)(bgfae)"), "(adg)(ceb)(f)");

            // (acf)(bd)(abd)(ef)=(acefb)
            Assert.AreEqual(Permutations.Multiply("(acf)(bd)(abd)(ef)"), "(acefb)(d)");
        }
    }
}
