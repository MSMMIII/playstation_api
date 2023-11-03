using PlaystationAPI.Data.Repository;
using PlaystationAPI.Models;

namespace PlaystationAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly PlaystationContext _context;

        public UnitOfWork(PlaystationContext context)
        {
            _context = context;
            PlaystationRepository = new GenericRepository<Playstation>(context);
        }

        public IGenericRepository<Playstation> PlaystationRepository { get; }
        
        //Methodes
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
