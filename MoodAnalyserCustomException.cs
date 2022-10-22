using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserDemo1
{

        public class MoodAnalyserCustomException : Exception
        {
            public enum ExceptionType
            {
                NULL_MESSAGE,
                EMPTY_MESSAGE,
                NO_SUCH_FIELD,
                NO_SUCH_METHOD,
                NO_SUCH_CLASS,
                OBJECT_CREATION_ISSUE
            }
            private readonly ExceptionType type;
            public MoodAnalyserCustomException(ExceptionType Type, String message) : base(message)
            {
                this.type = Type;
            }
        }


    }

