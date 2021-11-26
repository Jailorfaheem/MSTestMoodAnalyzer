using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        public string message;
        //initialising the parameterised constructor
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        //initialising the default constructor
        public MoodAnalyser()
        {
            this.message = null;
        }

        //declaring the analyse mood method
        public string AnalyseMood()
        {
            //the try and catch block is for exception handling
            try
            {
                //this is the custom exception that we declared for checking empty messages. exception type is an enum followed by the message.
                if (this.message.Equals(string.Empty))
                {
                    throw new CustomMoodException(CustomMoodException.ExceptionType.EMPTY_MESSAGE, "Mood should not be Empty");
                }

                if (this.message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            //this shows that it should not be null. NullREferenceException is a predefined exception class
            catch (NullReferenceException ex)
            {
                throw new CustomMoodException(CustomMoodException.ExceptionType.NULL_VALUE, "Mood can not be null");
            }
        }
    }
}