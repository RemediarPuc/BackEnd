
using RemediarAPI.Context;

namespace RemediarAPI.Repository.Medicamentos
{
    public class MedicamentosRepository : IMedicamentosRepository
    {
        private readonly ContextDb _contextDb;

        public MedicamentosRepository(ContextDb context)
        {
            this._contextDb = context;
        }
        public Task<bool> Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
