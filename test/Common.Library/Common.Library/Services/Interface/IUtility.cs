namespace Common.Library
{
    public interface IUtility
    {
        string GetFullName(string FirstName, string LastName, string MiddleName, string? Suffix = null);
        double GetTotal(double[] numbers);
        double GetTotal(float[] numbers);
        int GetTotal(int[] numbers);
    }
}