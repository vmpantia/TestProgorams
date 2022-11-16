using App.Api.Models.Request;
using App.Common.DataAccess;
using App.Common.Models;
using App.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUtilityService _utility;
        public RequestService(IUtilityService utilityService)
        {
            _utility = utilityService;
        }

        #region Public Methods
        public Request InsertRequest(AppDBContext db, RequestBase request)
        {
            var newRequest = new Request
            {
                RequestId = GenerateRequestId(db),
                FunctionId = request.FunctionID,
                Status = request.RequestStatus,
                CreatedBy = request.client.UserID,
                CreatedDate = DateTime.Now,
                /* ApprovedBy =   ApprovedBy is not required in Inserting Request */
                /* ApprovedDate = ApprovedDate is not required in Inserting Request */
                /* ModifiedBy =   ModifiedBy is not required in Inserting Request */
                /* ModifiedDate = ModifiedDate is not required in Inserting Request */
            };
            db.Requests.Add(newRequest);
            return newRequest;
        }
        #endregion

        #region Private Methods
        private string GenerateRequestId(AppDBContext db)
        {
            var latestRequestId = string.Empty;
            var latestRequest = db.Requests.Where(data => data.RequestId.Contains(Globals.ExecDate_YYYYMMDD))
                                           .OrderByDescending(data => data.RequestId)
                                           .ToList();

            latestRequestId = latestRequest == null || latestRequest.Count == 0 ? string.Empty : latestRequest.First().RequestId;
            return _utility.GenerateId(latestRequestId, IdType.RequestId);
        }
        #endregion
    }
}
