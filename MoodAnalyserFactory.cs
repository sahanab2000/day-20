﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserDemo1
{
        public class MoodAnalyserFactory
        {
            private string message;
            public MoodAnalyserFactory(string message)
            {
                this.message = message;
            }

            // UC 4
            public static object CreateMoodAnalyser(string className, string constructorName)
            {
                string pattern = @"." + constructorName + "$";//.MoodAnalyser$
                Match result = Regex.Match(className, pattern);
                if (result.Success)
                {
                    try
                    {
                        //double result1=100 / num\n;

                        Assembly executing = Assembly.GetExecutingAssembly();
                        Type moodAnalyseType = executing.GetType(className);
                        return Activator.CreateInstance(moodAnalyseType);
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Your input is not valid");
                        throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Something wrong happened.");
                        Console.WriteLine(e.Message);
                    }


                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                }
                return null;
            }

            //below code is UC-5
            public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName, string message)
            {
                Type type = typeof(MoodAnalyser);
                if (type.Name.Equals(className) || type.FullName.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                        object instance = ctor.Invoke(new object[] { message });
                        return instance;
                    }
                    else
                    {
                        throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                    }
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");

                }
            }
        }



    }
