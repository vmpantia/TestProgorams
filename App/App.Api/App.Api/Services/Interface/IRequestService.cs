using App.Api.Models.Request;
using App.Common.DataAccess;
using App.Common.Models;

namespace App.Api.Services
{
    public interface IRequestService
    {
        Request InsertRequest(AppDBContext db, RequestBase request);
    }
}