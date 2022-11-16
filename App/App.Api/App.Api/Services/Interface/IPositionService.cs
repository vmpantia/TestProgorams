using App.Api.Models.Request;

namespace App.Api.Services
{
    public interface IPositionService
    {
        Task<string> SavePositionAsync(PositionRequest request);
    }
}