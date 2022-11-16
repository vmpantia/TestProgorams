using App.Api.Models.Request;
using App.Common.DataAccess;
using App.Common.Models;

namespace App.Api.Services
{
    public class UtilityService : IUtilityService
    {
        public bool IsRequestValid(object request)
        {
            if (request == null)
                return false;

            var requestBase = request as RequestBase;

            if (requestBase == null)
                return false;

            //Check if the Token is still valid
            if (requestBase.client.Token == Guid.Empty)
                return false;

            return true;
        }

        public string GenerateId(string latestId, IdType type)
        {
            var firstLayerId = string.Empty;
            var secondLayerId = Constants.DEFAULT_START_ID;

            switch(type)
            {
                case IdType.DepartmentId:
                    firstLayerId = string.Concat(Constants.START_DEPARTMENT_ID, Globals.ExecDate_YYYYMM);
                    break;
                case IdType.PositionId:
                    firstLayerId = string.Concat(Constants.START_POSITION_ID, Globals.ExecDate_YYYYMM);
                    break;
                default:
                    firstLayerId = Globals.ExecDate_YYYYMMDD;
                    break;
            }

            if (!string.IsNullOrEmpty(latestId))
            {
                var no = int.Parse(latestId.Substring(Constants.NO_FIRST_LAYER_ID, 
                                                      Constants.NO_SECOND_LAYER_ID));
                no++;

                secondLayerId = no.ToString().PadLeft(Constants.NO_SECOND_LAYER_ID, Constants.ZERO);
            }

            return string.Concat(firstLayerId, secondLayerId);
        }

        public int ConvertStringStatusToInt(string status)
        {
            switch(status)
            {
                case "Enabled":
                    return 0;
                case "Disabled":
                    return 1;
                default: /* For Deletion */
                    return 2;
            }
        }
    }
}
