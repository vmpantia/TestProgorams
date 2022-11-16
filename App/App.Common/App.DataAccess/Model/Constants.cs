namespace App.Common.Models
{
    public class Constants
    {
        public const string CON_STRING = "Data Source=localhost;Initial Catalog=AppDB;Integrated Security=True";
        public const string YEARMONTHDAY_FORMAT = "yyyyMMdd";
        public const string YEARMONTH_FORMAT = "yyyyMM";

        #region ID(s)
        public const string DEFAULT_START_ID = "0000001";
        public const int NO_FIRST_LAYER_ID = 8;
        public const int NO_SECOND_LAYER_ID = 7;
        public const char ZERO = '0';

        public const string START_DEPARTMENT_ID = "DP";
        public const string START_POSITION_ID = "PS";
        #endregion

        #region Filter Type of Department
        public const string FILTER_DEPARTMENT_ID = "DepartmentId";
        public const string FILTER_DEPARTMENT_NAME = "Name";
        public const string FILTER_DEPARTMENT_MANAGER = "Manager";
        public const string FILTER_DEPARTMENT_STATUS = "Status";

        public const string FILTER_POSITION_NAME = "Name";
        public const string FILTER_POSITION_DEPARTMENT = "Department";
        public const string FILTER_POSITION_STATUS = "Status";
        #endregion

        #region Error Messages
        public const string ERROR_REQUEST_NOT_VALID = "User request is NOT valid";

        public const string ERROR_CANT_FIND_REQUEST = "Existing request can't find in the database";

        public const string ERROR_CANT_FIND_DEPARTMENT = "Cannot find existing Department";
        public const string ERROR_EXIST_DEPARTMENT_NAME = "Department Name is already exist in the database";

        public const string ERROR_CANT_FIND_POSITION = "Cannot find existing Position";
        public const string ERROR_EXIST_POSITION_NAME = "Position Name is already exist in the database";
        #endregion

        #region Function ID(s)
        public const string FUNC_ID_NEW_DEPARTMENT_ADMIN = "00A00"; 
        public const string FUNC_ID_UPDATE_DEPARTMENT_ADMIN = "00C00";

        public const string FUNC_ID_NEW_POSITION_ADMIN = "01A00";
        public const string FUNC_ID_UPDATE_POSITION_ADMIN = "01C00";
        #endregion

        #region Request Statuses
        public const string REQ_STATUS_COMPLETED = "A2";
        #endregion
    }
}
