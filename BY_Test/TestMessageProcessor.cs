using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackYab;

namespace BY_Test
{
    [TestClass()]
    public class TestMessageProcessor
    {
        [TestMethod()]
        public void ShouldReturnStringWithoutBlanks()
        {
            //arrange
            string expected = "User does not exist ";
            //act
            var message = new MessageProcessor();
            string actual = message.ProcessorMessage(WordList.User_does_not_exist);
            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void ShouldReturnAnotherStringWithoutBlanks()
        {
            //arrange
            string expected = "reportSpeakers ";
            //act
            var message = new MessageProcessor();
            string actual = message.ProcessorMessage(WordList.reportSpeakers);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass()]
    public class TestErrorMessages
    {
        [TestMethod()]
        public void ShouldReturnFalseAndMessage()
        {
            //arrange
            bool expectedbool = false;
            string expectedstring= "Undescribed error detected ";
            //act
            var error = new ErrorResponse();
            
            //assert
            Assert.AreEqual(expectedbool, error.canAccess);
            Assert.AreEqual(expectedstring, error.ErrorMessage);
        }
    }
}
