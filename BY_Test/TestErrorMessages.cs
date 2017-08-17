using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackYab;
namespace BY_Test
{
    [TestClass()]
    public class TestErrorMessages
    {
        [TestMethod()]
        public void ShouldReturnFalseAndMessage()
        {
            //arrange
            bool expectedbool = false;
            string expectedstring = "Undescribed error detected ";
            //act
            var error = new ErrorResponse();

            //assert
            Assert.AreEqual(expectedbool, error.canAccess);
            Assert.AreEqual(expectedstring, error.ErrorMessage);
        }
    }
}
