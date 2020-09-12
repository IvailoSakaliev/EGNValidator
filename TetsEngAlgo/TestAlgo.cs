using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckEGN;

namespace TetsEngAlgo
{
    [TestClass]
    public class TestAlgo
    {
        #region important
        // information about the value of egn is from Wikipedia : https://bg.wikipedia.org/wiki/%D0%95%D0%B4%D0%B8%D0%BD%D0%B5%D0%BD_%D0%B3%D1%80%D0%B0%D0%B6%D0%B4%D0%B0%D0%BD%D1%81%D0%BA%D0%B8_%D0%BD%D0%BE%D0%BC%D0%B5%D1%80
        /*
         I make two tests because the first 9 digits of the EGN because their sum is a constant as well as the remainder that is obtained in the calculation. Other methods are to further strengthen the software against invalid data entered by the user
         */
        #endregion
        [TestMethod]
        public void Test_valid_egn()
        {
            CheckAlgo model = new CheckAlgo("6101057509"); // correct
            Assert.AreEqual(model.EGN(), true);
        }
        [TestMethod]
        public void Test_INvalid_egn()
        {
            CheckAlgo model = new CheckAlgo("6101057508"); // incorrect
            Assert.AreEqual(model.EGN(), false);
        }
    }
}
