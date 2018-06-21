using System;

namespace Validator 
{
    public static class DateHelper 
    {
        public static bool CheckIfLessThanToday(int year, int month)
        {
            return DateTime.Now < (new DateTime(year, month, 1));
        }
    }
}