using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestMoodAnalyzerProblem;

namespace MoodAnalyserTest
{
    [TestClass]
    public class TestClass
    {
        //Test case 2.1 : Handle exception if user provide null mood 
        [TestMethod]
        public void GivenNullMoodReturnHappy()
        {
            //AAA method
            //Arrange
            string message = " ";
            string expected = "happy";
            //creating object of moodanalyzer class and passing message
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

            //Act
            string actual = moodAnalyzer.AnalyseMood();

            //Assert
            //comparing actual and expected value
            Assert.AreEqual(expected, actual);
        }

    }

}