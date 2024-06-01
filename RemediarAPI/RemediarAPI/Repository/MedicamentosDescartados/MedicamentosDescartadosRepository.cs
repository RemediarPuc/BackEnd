
using RemediarAPI.Context;

namespace RemediarAPI.Repository.MedicamentosDescartados
{
    public class MedicamentosDescartadosRepository : IMedicamentosDescartadosRepository
    {
        private readonly ContextDb _contextDb;

        public MedicamentosDescartadosRepository(ContextDb context)
        {
            this._contextDb = context;
        }
        public Task<bool> Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
