using System.Linq.Expressions;
using AccManager.Data.Models.ModelSettings;
using MongoDB.Driver;
using X.PagedList;

namespace AccManager.Data.MongoServicoGenerico
{
    public class MongoServico<TEntity> : IMongoServico<TEntity> where TEntity : Models.Entity
    {
        protected IEnvioDeContasMongoSettings settings;
        protected IMongoDatabase Database;
        protected IMongoCollection<TEntity> MongoCollection;

        private int _sizePag = 10;

        public MongoServico(MongoClient mongoClient, string database)
        {
            this.Database = mongoClient.GetDatabase(database);
            this.MongoCollection = this.Database.GetCollection<TEntity>(typeof(TEntity).Name == "Contas" ? typeof(TEntity).Name.ToLower() : typeof(TEntity).Name);
        }

        public MongoServico(IEnvioDeContasMongoSettings settings, MongoClient mongoClient)
        {
            this.settings = settings;
            int.TryParse(settings.SizPag, out this._sizePag);
            this.Database = mongoClient.GetDatabase(settings.DataBaseName);
            this.MongoCollection = this.Database.GetCollection<TEntity>(typeof(TEntity).Name == "Contas" ? typeof(TEntity).Name.ToLower() : typeof(TEntity).Name);
        }

        public void Adicionar(TEntity document) => this.MongoCollection.InsertOne(document);

        public void Atualizar(TEntity document) => this.MongoCollection.ReplaceOne(x => x.id.Equals(document.id), document);

        public void Excluir(Expression<Func<TEntity, bool>> expression) => this.MongoCollection.DeleteOne(expression);

        public IPagedList ListarPaginado(int? pagina) => MongoCollection.Find(x => true).ToList().ToPagedList(pagina ?? 1, this._sizePag);

        public ICollection<TEntity> ListarTudo() => MongoCollection.Find(x => true).ToList();

        public IPagedList<TEntity> Buscar(Expression<Func<TEntity, bool>> expression, int? pagina) => this.MongoCollection.Find(expression).ToList().ToPagedList(pagina ?? 1, this._sizePag);

        public ICollection<TEntity> Buscar(Expression<Func<TEntity, bool>> expression) => this.MongoCollection.Find(expression).ToList();


    }
}
