namespace App.Common.Models
{
    public static class Globals
    {
        public static string ExecDate_YYYYMMDD = DateTime.Now.ToString(Constants.YEARMONTHDAY_FORMAT);
        public static string ExecDate_YYYYMM = DateTime.Now.ToString(Constants.YEARMONTH_FORMAT);
    }
}
