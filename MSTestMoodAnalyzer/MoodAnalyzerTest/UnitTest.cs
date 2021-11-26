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
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(" ");

            try
            {
                //Act
                string actual = moodAnalyzer.AnalyseMood();

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
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(string.Empty);

            try
            {
                //Act
                string actual = moodAnalyzer.AnalyseMood1();

            }
            catch (CustomException ex)
            {

                //Assert
                //comparing actual and expected value
                Assert.AreEqual(expected, ex.Message);
            }

        }
        [TestMethod]
        //Test Case 4.1 given mood Analyse class name should return mood analyser object.

        public void GivenMoodAnalyseClassName_Should_return_MoodAnalyseObject()
        {
            string message = null;

            object expected = new MoodAnalyzer(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MSTestMoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyser");
            expected.Equals(obj);
        }
        [TestMethod]
        //Test Case 4.2 Given mood Analyse wrong class name should return exception stating no such class name exist 

        public void GivenMoodAnalyseWrongClassName_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyzer(message);
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("MSTestMoodAnalyzerProblem.MoodAnalyserWrong", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch (CustomException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }
        [TestMethod]
        //Test Case 4.3 Given wrong constructor name should return simproper message in exception  

        public void GivenMoodAnalyseWrongConstructor_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyzer(message);
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("MSTestMoodAnalyzerProblem.MoodAnalyser", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch (CustomException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }
        [TestMethod]
        //Test Case 5.1 given mood Analyse class name should return mood analyser object with parameterised constructor

        public void Given_ParameterisedConstructor_MoodAnalyseClassName_Should_return_MoodAnalyseObject()
        {
            object expected = new MoodAnalyzer("HAPPY");
            object obj = MoodAnalyserFactory.CreateMoodAnalyserParameterisedConstructor("MSTestMoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
        [TestMethod]
        //Test Case 5.2 Given mood Analyse wrong class name should return exception stating no such class name exist 

        public void Given_ParameterisedConstructor_WrongClassName_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                object expected = new MoodAnalyzer("HAPPY");
                object obj = MoodAnalyserFactory.CreateMoodAnalyserParameterisedConstructor("MSTestMoodAnalyzerProblem.MoodAnalyserWrong", "MoodAnalyser");
                expected.Equals(obj);
            }

            catch (CustomException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }


        //Test Case 5.3 Given mood Analyse wrong constructor name should return exception stating no such consrtructor exist 
        [TestMethod]
        public void Given_ParameterisedConstructor_WrongConstrcutorName_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                object expected = new MoodAnalyzer("HAPPY");
                object obj = MoodAnalyserFactory.CreateMoodAnalyserParameterisedConstructor("MSTestMoodAnalyzerProblem.MoodAnalyser", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch (CustomException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }

    }


}