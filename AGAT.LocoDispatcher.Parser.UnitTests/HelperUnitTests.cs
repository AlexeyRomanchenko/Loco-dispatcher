using System;
using AGAT.LocoDispatcher.Parser.Utils.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGAT.LocoDispatcher.Parser.UnitTests
{
    [TestClass]
    public class HelperUnitTests
    {
        [DataTestMethod]
        [DataRow("14", "0014")]
        [DataRow("4", "0004")]
        [DataRow("653", "0653")]
        [DataRow("2653", "2653")]
        public void ConvertLocomotiveOK(string trainId, string result)
        {
            string finalNumber = LocoShiftHelper.TransformTrainNumber(trainId);
            Assert.AreEqual(result, finalNumber);
        }
    }
}
