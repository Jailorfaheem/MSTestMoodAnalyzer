using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    /// <summary>
    /// Mood analyser reflector factory
    /// this conatains data about all the reflection methods,exceptions and other things that we are handling
    /// </summary>
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// Creates the mood analyse.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyser01_Core.CustomMoodAnException">
        /// Class not found
        /// or
        /// Constructor not found
        /// </exception>
        /// 
        //following is for default constructor
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = "." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);

                }

                catch (Exception e)
                {
                    throw new CustomMoodException(CustomMoodException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }

            }
            else
            {
                throw new CustomMoodException(CustomMoodException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
        }
        /// <summary>
        /// Creates the mood analyser parameterised constructor.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constrcutorName">Name of the constrcutor.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserProblem.CustomMoodException">
        /// Constructor not found
        /// or
        /// Class not found
        /// </exception>
        public static object CreateMoodAnalyserParameterisedConstructor(string className, string constrcutorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constrcutorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new CustomMoodException(CustomMoodException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
                }
            }

            else
            {
                throw new CustomMoodException(CustomMoodException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }
        /// <summary>
        /// Invokes the analyse mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserProblem.CustomMoodException">method not found</exception>
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyser);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object moodAnalyserObject = MoodAnalyserFactory.CreateMoodAnalyserParameterisedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }

            catch (NullReferenceException)
            {
                throw new CustomMoodException(CustomMoodException.ExceptionType.NULL_VALUE, "method not found");
            }
        }
        /// <summary>
        /// Setfields the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserProblem.CustomMoodException">
        /// Message should not be null
        /// or
        /// Field should not be null
        /// </exception>
        public static string Setfield(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyse = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new CustomMoodException(CustomMoodException.ExceptionType.EMPTY_MESSAGE, "Message should not be null");
                }
                field.SetValue(moodAnalyse, message);
                return moodAnalyse.message;
            }

            catch (NullReferenceException)
            {
                throw new CustomMoodException(CustomMoodException.ExceptionType.NO_SUCH_FIELD, "Field not found");
            }
        }

    }
}