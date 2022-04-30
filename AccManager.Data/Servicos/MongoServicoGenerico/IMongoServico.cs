using System.Linq.Expressions;
using X.PagedList;

namespace AccManager.Data.MongoServicoGenerico
{
    public interface IMongoServico<TEntity> where TEntity : Models.Entity
    {
        void Adicionar(TEntity document);
        void Excluir(Expression<Func<TEntity, bool>> expression);
        void Atualizar(TEntity document);

        ICollection<TEntity> ListarTudo();
        IPagedList<TEntity> Buscar(Expression<Func<TEntity, bool>> expression, int? pagina);
        ICollection<TEntity> Buscar(Expression<Func<TEntity, bool>> expression);
        IPagedList ListarPaginado(int? pagina);
    }
}
