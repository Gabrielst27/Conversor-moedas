using ConversorMoedas.API.Models;

namespace ConversorMoedas.API.Repositories
{
    public interface IMoedaRepository
    {
        public Moeda Get(string id);
        public IEnumerable<Moeda> GetAll();
        public Moeda Create(Moeda moeda);
        public Moeda Update(Moeda moeda);
        public Moeda Delete(int id);
    }
}
