using App.Common.Models;

namespace App.Api.Services
{
    public interface IUtilityService
    {
        bool IsRequestValid(object request);
        string GenerateId(string latestId, IdType type);
        int ConvertStringStatusToInt(string status);
    }
}