using Fundamental_Algorithms.Basic_Concepts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Fundamental_Algorithms.Basic_Concepts
{
    [TestClass]
    public class PermutationsUnitTest
    {
        [TestMethod]
        public void MultiplyTestMethod() {
            // (acf)(bd)(abd)(ef)=(acefb)
            Assert.AreEqual(Permutation.Multiply("(acfg)(bcd)(aed)(fade)(bgfae)"), "(adg)(ceb)(f)");

            Permutation first = new Permutation("(acfg)");
            Permutation second = new Permutation("(bcd)");
            Permutation third = new Permutation("(aed)");
            Permutation fourth = new Permutation("(fade)");
            Permutation fifth = new Permutation("(bgfae)");
            Permutation result = first * second * third * fourth * fifth;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.CycleForm, "(adg)(bce)(f)"); // ceb offset by 1 is ok

            // (acf)(bd)(abd)(ef)=(acefb)
            Assert.AreEqual(Permutation.Multiply("(acf)(bd)(abd)(ef)"), "(acefb)(d)");

            first = new Permutation("(acf)");
            second = new Permutation("(bd)");
            third = new Permutation("(abd)");
            fourth = new Permutation("(ef)");
            result = first * second * third * fourth;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.CycleForm, "(acefb)(d)");
        }

        [TestMethod]
        public void InvertTestMethod() {
            int[] permutation = {6, 2, 1, 5, 4, 3};
            int[] realInverse = {3, 2, 6, 5, 4, 1};

            // -(621543) = (326541)
            int[] inverse = Permutation.InverseIntArrayI(permutation);
            CollectionAssert.AreEqual(inverse, realInverse);

            // Taking the inverse of the inverse will give us the original permutation again
            inverse = Permutation.InverseIntArrayI(inverse);
            CollectionAssert.AreEqual(inverse, permutation);

            // -(621543) = (326541)
            inverse = Permutation.InverseIntArrayJ(permutation);
            CollectionAssert.AreEqual(inverse, realInverse);

            // Taking the inverse of the inverse will give us the original permutation again
            inverse = Permutation.InverseIntArrayJ(inverse);
            CollectionAssert.AreEqual(inverse, permutation);
        }
    }
}