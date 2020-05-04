using System;

namespace MyChessProject.Common
{
    public static class ObjectValidator
    {
        public static void CheckIfObjectIsNull(object obj, string errorMessage = GlobalConstants.EmptyString)
        {
            if (obj == null)
            {
                throw new NullReferenceException(errorMessage);
            }
        }
    }
}
