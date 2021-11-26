using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestMoodAnalyzerProblem
{
    public class MoodAnalyzer
    {
        //instance variable
        public string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyzer"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        //creating constructor for mood analyzer
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        //This method analyzes mood
        public string AnalyseMood()
        {
            try
            {
                //if condition for to check null is present or not
                if (message.ToLower().Contains(""))
                {
                    return "happy";
                }
                else
                    return "sad";
            }
            catch (NullReferenceException ex)
            {
                //return "happy";
                throw new CustomException(CustomException.ExceptionType.Null_Type_Exception, "Message should not be null");
            }
        }
        public string AnalyseMood1()
        {
            try
            {
                //if condition for to check null is present or not
                if (message.ToLower().Contains(string.Empty))
                {
                    return "happy";
                }
                else
                    return "sad";
            }
            catch (NullReferenceException ex)
            {
                //return "happy";
                throw new CustomException(CustomException.ExceptionType.Empty_Type_Exception, "Message should not be empty");
            }
        }
    }
}