
using RemediarAPI.Context;

namespace RemediarAPI.Repository.Doacoes
{
    public class DoacoesRepository : IDoacoesRepository
    {
        private readonly ContextDb _contextDb;

        public DoacoesRepository(ContextDb context)
        {
            this._contextDb = context;
        }
        public Task<bool> Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
