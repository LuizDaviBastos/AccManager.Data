using AccManagerData.Model;
using System.Linq.Expressions;
using X.PagedList;

namespace AccManagerData.MongoServicoGenerico
{
    public interface IMongoService<TEntity> where TEntity : Models.Entity
    {
        void Adicionar(TEntity document);
        void Excluir(Expression<Func<TEntity, bool>> expression);
        void Atualizar(TEntity document);

        ICollection<TEntity> ListarTudo();
        Pagination<TEntity> Buscar(Expression<Func<TEntity, bool>> expression, int pagina);
        ICollection<TEntity> Buscar(Expression<Func<TEntity, bool>> expression);
        Pagination<TEntity> ListarPaginado(int pagina);
    }
}
