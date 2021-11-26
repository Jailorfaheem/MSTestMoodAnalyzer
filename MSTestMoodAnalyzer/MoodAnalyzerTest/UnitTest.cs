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
        //Test Case 3.1 : Given null mood should throw mood exception indicating null mood
        [TestMethod]
        public void getCustomNullException()
        {
            ///AAA method
            //Arrange
            string expected = "message should not be null";
            //creating object of moodanalyzer class and passing null
            MoodAnalyzer modeAnalyzer = new MoodAnalyzer(" ");

            try
            {
                //Act
                string actual = modeAnalyzer.AnalyseMood();

            }
            catch (CustomException ex)
            {

                //Assert
                //comparing actual and expected value
                Assert.AreEqual(expected, ex.Message);
            }

        }
        //Test case 3.2 : Given empty message should throw mood exception indicating empty mood
        [TestMethod]
        public void getCustomEmptyException()
        {
            ///AAA method
            //Arrange
            string expected = "message should not be empty";
            //creating object of moodanalyzer class and passing null
            MoodAnalyzer modeAnalyzer = new MoodAnalyzer(string.Empty);

            try
            {
                //Act
                string actual = modeAnalyzer.AnalyseMood1();

            }
            catch (CustomException ex)
            {

                //Assert
                //comparing actual and expected value
                Assert.AreEqual(expected, ex.Message);
            }

        }

    }

}