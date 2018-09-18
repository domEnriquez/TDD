using System;

namespace LeapYearTests
{
    internal class LeapYear
    {
        public static bool IsLeapYear(int year)
        {
            if (year == 0)
                return false;

            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
                return true;
            else
                return false;
        }
    }
}