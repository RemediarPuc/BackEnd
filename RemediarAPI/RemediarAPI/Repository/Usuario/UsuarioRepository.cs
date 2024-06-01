
using Microsoft.EntityFrameworkCore;
using RemediarAPI.Context;

namespace RemediarAPI.Repository.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContextDb _contextDb;
        public UsuarioRepository(ContextDb context)
        {
            _contextDb = context;
        }
        public Task<bool> Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
