using App.Api.Models.Request;
using App.Common.DataAccess;
using App.Common.Models;
using App.DataAccess.Repository;

namespace App.Api.Services
{
    public class PositionService : IPositionService
    {
        private readonly IRequestService _request;
        private readonly IUtilityService _utility;
        private readonly AppDBContext _db;
        public PositionService(IRepositoryConnection connection,
                               IRequestService requestService,
                               IUtilityService utilityService)
        {
            _db = connection.Context;
            _request = requestService;
            _utility = utilityService;
        }

        #region Public and Async Methods
        public async Task<string> SavePositionAsync(PositionRequest request)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var requestDetails = _request.InsertRequest(_db, request); /*Insert Request Details*/
                    switch (request.FunctionID)
                    {
                        case Constants.FUNC_ID_NEW_POSITION_ADMIN:
                            InsertPosition(request.position); /*Insert New Position Details*/
                            InsertPosition_TRN(requestDetails.RequestId, request.position); /*Insert New Position TRN Details*/
                            break;
                        case Constants.FUNC_ID_UPDATE_POSITION_ADMIN:
                            UpdatePosition(request.position); /*Update Position Details*/
                            InsertPosition_TRN(requestDetails.RequestId, request.position); /*Insert Update Position TRN Details*/
                            break;
                    }
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return requestDetails.RequestId;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region Private Methods
        private void InsertPosition(Position newPosition)
        {
            newPosition.InternalId = Guid.NewGuid();
            newPosition.PositionId = GeneratePositionId();
            _db.Positions.Add(newPosition);
        }
        private void UpdatePosition(Position updatedPosition)
        {
            var currentPosition = _db.Positions.Find(updatedPosition.InternalId);

            //Check if the Position is exist
            if (currentPosition == null)
                throw new Exception(Constants.ERROR_CANT_FIND_POSITION);

            currentPosition.Name = updatedPosition.Name;
            currentPosition.DepartmentInternalId = updatedPosition.DepartmentInternalId;
            currentPosition.Status = updatedPosition.Status;
            currentPosition.ModifiedDate = updatedPosition.ModifiedDate;
        }
        private void InsertPosition_TRN(string requestId, Position position)
        {
            var newTrn = new Position_TRN
            {
                RequestId = requestId,
                InternalId = position.InternalId,
                PositionId = position.PositionId,
                Name = position.Name,
                DepartmentInternalId = position.DepartmentInternalId,
                Status = position.Status,
                CreatedDate = position.CreatedDate,
                ModifiedDate = position.ModifiedDate
            };
            _db.Add(newTrn);
        }
        private string GeneratePositionId()
        {
            var latestPositionId = string.Empty;
            var latestPosition = _db.Positions.OrderByDescending(data => data.PositionId)
                                              .ToList();

            latestPositionId = latestPosition == null || latestPosition.Count == 0 ? string.Empty : latestPosition.First().PositionId;
            return _utility.GenerateId(latestPositionId, IdType.PositionId);
        }
        #endregion
    }
}
