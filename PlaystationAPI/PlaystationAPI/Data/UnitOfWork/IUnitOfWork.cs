using PlaystationAPI.Data.Repository;
using PlaystationAPI.Models;

namespace PlaystationAPI.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Playstation> PlaystationRepository { get; }
        public void SaveChanges();
    }
}
