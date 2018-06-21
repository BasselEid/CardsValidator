using System;

namespace Validator 
{
    public static class NumberHelper 
    {
        public static bool IsPrime (int number) {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int) Math.Floor (Math.Sqrt (number));

            for (int i = 3; i <= boundary; i += 2) {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static bool checkLuhn (String cardNo) 
        {
            int nDigits = cardNo.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--) {

                int d = cardNo[i] - 'a';

                if (isSecond == true)
                    d = d * 2;

                // We add two digits to handle
                // cases that make two digits 
                // after doubling
                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }
    }
}