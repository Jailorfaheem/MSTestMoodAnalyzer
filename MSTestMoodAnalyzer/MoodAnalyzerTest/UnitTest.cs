using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;

namespace TestClass
{
    [TestClass]
    public class UnitTest1
    {
        // Test Case 1.1 : Given I am in sad mood should return SAD.
        [TestMethod]
        public void GivenSadshouldreturnSad()
        {
            //Arrange
            string expected = "SAD";
            string message = "I am in sad mood";
            MoodAnalyser moodAnalysis = new MoodAnalyser(message);

            //Act
            string mood = moodAnalysis.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);
        }
        // Test Case 1.2 : Given I am in happy mood should return HAPPY.
        [TestMethod]
        public void GivenHappyshouldreturnHappy()
        {
            //Arrange
            string expected = "HAPPY";
            string message = "I am in happy mood";
            MoodAnalyser moodAnalysis = new MoodAnalyser(message);

            //Act
            string mood = moodAnalysis.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);
        }

        // Test Case 3.1 : Given null mood, should throw custom exception
        [TestMethod]
        public void Given_Null_Should_Throw_CustomException_Indicating_NullMood()
        {
            try
            {
                string message = null;
                MoodAnalyser moodAnalysis = new MoodAnalyser(message);
                string mood = moodAnalysis.AnalyseMood();
            }
            catch (CustomMoodException e)
            {
                Assert.AreEqual("Mood can not be null", e.Message);
            }

        }

        // Test Case 3.2 : Given Empty mood should throw custom exception showing empty.
        [TestMethod]
        public void Given_Empty_Should_Throw_CustomException_Indicating_EmptyMood()
        {
            try
            {
                string message = "";
                MoodAnalyser moodAnalysis = new MoodAnalyser(message);
                string mood = moodAnalysis.AnalyseMood();
            }
            catch (CustomMoodException e)
            {
                Assert.AreEqual("Mood should not be Empty", e.Message);
            }
        }

        // Test Case 4.1 :Given mood Analyse class name should return mood analyser object.
        [TestMethod]
        public void GivenMoodAnalyseClassName_Should_return_MoodAnalyseObject()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        // Test Case 4.2 : Given mood Analyse wrong class name should return exception stating no such class name exist 
        [TestMethod]
        public void GivenMoodAnalyseWrongClassName_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyser(message);
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalyserWrong", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch (CustomMoodException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }

        // Test Case 4.3 : Given wrong constructor name should return improper message in exception 
        [TestMethod]
        public void GivenMoodAnalyseWrongConstructor_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyser(message);
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch (CustomMoodException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }

        //Test Case 5.1 : Given mood Analyse class name should return mood analyser object with parameterised constructor
        [TestMethod]
        public void Given_ParameterisedConstructor_MoodAnalyseClassName_Should_return_MoodAnalyseObject()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserFactory.CreateMoodAnalyserParameterisedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", "Happy");
            expected.Equals(obj);
        }

        //Test Case 5.2 : Given mood Analyse wrong class name should return exception stating no such class name exist
        [TestMethod]
        public void Given_ParameterisedConstructor_WrongClassName_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                object expected = new MoodAnalyser("HAPPY");
                object obj = MoodAnalyserFactory.CreateMoodAnalyserParameterisedConstructor("MoodAnalyserProblem.MoodAnalyserWrong", "MoodAnalyser", "Happy");
                expected.Equals(obj);
            }

            catch (CustomMoodException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }

        //Test Case 5.3 : Given mood Analyse wrong constructor name should return exception stating no such consrtructor exist 
        [TestMethod]
        public void Given_ParameterisedConstructor_WrongConstrcutorName_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                object expected = new MoodAnalyser("HAPPY");
                object obj = MoodAnalyserFactory.CreateMoodAnalyserParameterisedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyserWrong", "Happy");
                expected.Equals(obj);
            }

            catch (CustomMoodException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }

        //Test Case 6.1
        [TestMethod]

        public void GivenHappy_ShouldReturn_Happy_ReflectorInvoke_method()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }

        //Test Case 6.2
        [TestMethod]
        public void GivenHappy_ShouldReturnException_WithWrongMethodName()
        {
            try
            {
                string expected = "method not found";
                string mood = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMoodWrong");
                Assert.AreEqual(expected, mood);
            }

            catch (CustomMoodException ex)
            {
                Assert.AreEqual("method not found", ex.Message);
            }
        }

    }
}