using App.Common.DataAccess;

namespace App.DataAccess.Repository
{
    public interface IRepositoryConnection
    {
        AppDBContext Context { get; }
    }
}