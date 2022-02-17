using System;
using System.Collections.Generic;
using System.Text;

namespace POSERPAPI.Utilities
{
    public static class Enums
    {
        public  enum  statusCode
        {
            Success = 1,
            Failure = 2,
            Incomplete = 3,
            Error = 4,
            DuplicateRecord=5

        }
        public enum Role
        {
            Admin,
            User
        }


    }
}
