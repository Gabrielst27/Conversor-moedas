using ConversorMoedas.API.Context;
using ConversorMoedas.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConversorMoedas.API.Repositories
{
    public class MoedaRepository : IMoedaRepository
    {
        private readonly PgSQLContext _context;

        public MoedaRepository(PgSQLContext context)
        {
            _context = context;
        }

        public Moeda Get(int id)
        {
            return _context.Moedas.FirstOrDefault(m => m.Id == id);
        }
        public IEnumerable<Moeda> GetAll()
        {
            return _context.Moedas.AsNoTracking().ToList();
        }

        public Moeda Create(Moeda moeda)
        {
            throw new NotImplementedException();
        }

        public Moeda Delete(int id)
        {
            throw new NotImplementedException();
        }



        public Moeda Update(Moeda moeda)
        {
            throw new NotImplementedException();
        }
    }
}
