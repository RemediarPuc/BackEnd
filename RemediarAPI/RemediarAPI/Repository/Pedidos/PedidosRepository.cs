using RemediarAPI.Context;

namespace RemediarAPI.Repository.Pedidos
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly ContextDb _contextDb;

        public PedidosRepository(ContextDb context)
        {
            this._contextDb = context;
        }
        public Task<bool> Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
