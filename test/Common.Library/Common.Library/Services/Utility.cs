using System.Globalization;

namespace Common.Library
{
    public class Utility : IUtility
    {
        TextInfo _textInfo;
        public Utility()
        {
            _textInfo = new CultureInfo(Constant.CULTURE, false).TextInfo;
        }

        public string GetFullName(string FirstName, string LastName, string MiddleName, string? Suffix = null)
        {
            if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
            {
                throw new NullReferenceException(Constant.FNAME_LNAME_NULL_MSG);
            }

            FirstName = _textInfo.ToTitleCase(FirstName.Trim());
            LastName = _textInfo.ToTitleCase(LastName.Trim());

            var FullName = LastName + Constant.SPACE + FirstName;

            if (!string.IsNullOrEmpty(MiddleName))
            {
                var MiddleInitial = _textInfo.ToTitleCase(MiddleName.Trim()).Substring(0, 1);
                FullName += Constant.SPACE + MiddleInitial + Constant.PERIOD;
            }

            if (!string.IsNullOrEmpty(Suffix))
            {
                FullName += Constant.SPACE + Suffix;

                if (FullName.Substring(FullName.Length - 1, 1) != Constant.PERIOD)
                {
                    FullName += Constant.PERIOD;
                }
            }

            return string.IsNullOrEmpty(FullName) ? string.Empty : FullName.Trim();
        }

        public int GetTotal(int[] numbers)
        {
            if (numbers == null)
            {
                throw new NullReferenceException(Constant.INT_ARRAY_NULL_MSG);
            }

            int total = 0;
            foreach (var number in numbers)
            {
                total += number;
            }

            return total;
        }

        public double GetTotal(double[] numbers)
        {
            if (numbers == null)
            {
                throw new NullReferenceException(Constant.DOUBLE_ARRAY_NULL_MSG);
            }

            double total = 0;
            foreach (var number in numbers)
            {
                total += number;
            }

            return total;
        }

        public double GetTotal(float[] numbers)
        {
            if (numbers == null)
            {
                throw new NullReferenceException(Constant.FLOAT_ARRAY_NULL_MSG);
            }

            float total = 0;
            foreach (var number in numbers)
            {
                total += number;
            }

            return total;
        }
    }
}