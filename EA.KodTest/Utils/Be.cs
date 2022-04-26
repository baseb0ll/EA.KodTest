namespace EA.KodTest.Utils
{
    //validation helper to validate that only digits are present
    public static class Be
    {
        public static bool OnlyDigits(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
