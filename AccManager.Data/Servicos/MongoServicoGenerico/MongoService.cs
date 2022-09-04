using System;
using System.Linq.Expressions;
using AccManager.Data.Configurations;
using AccManagerData.Model;
using AccManagerData.Models.ModelSettings;
using MongoDB.Driver;
using X.PagedList;

namespace AccManagerData.MongoServicoGenerico
{
    public class MongoService<TEntity> : IMongoService<TEntity> where TEntity : Models.Entity
    {
        protected IEnvioDeContasMongoSettings settings;
        protected IMongoDatabase Database;
        protected IMongoCollection<TEntity> MongoCollection;

        private int _sizePag = 10;

        public MongoService(MongoClient mongoClient, string database)
        {
            this.Database = mongoClient.GetDatabase(database);
            this.MongoCollection = this.Database.GetCollection<TEntity>(typeof(TEntity).Name == "Contas" ? typeof(TEntity).Name.ToLower() : typeof(TEntity).Name);
        }

        public MongoService(IEnvioDeContasMongoSettings settings, MongoClient mongoClient)
        {
            this.settings = settings;
            int.TryParse(settings.SizPag, out this._sizePag);
            this.Database = mongoClient.GetDatabase(settings.DataBaseName);
            this.MongoCollection = this.Database.GetCollection<TEntity>(typeof(TEntity).Name == "Contas" ? typeof(TEntity).Name.ToLower() : typeof(TEntity).Name);
        }

        public void Adicionar(TEntity document) => this.MongoCollection.InsertOne(document);

        public void Atualizar(TEntity document) => this.MongoCollection.ReplaceOne(x => x.id.Equals(document.id), document);

        public void Excluir(Expression<Func<TEntity, bool>> expression) => this.MongoCollection.DeleteOne(expression);

        public Pagination<TEntity> ListarPaginado(int pagina)
        {
            long count = MongoCollection.CountDocuments(x => true);
            return new Pagination<TEntity>(MongoCollection.Find(x => true).Skip((pagina - 1) * _sizePag).Limit(_sizePag).ToEnumerable(), count, pagina, _sizePag);
        }

        public ICollection<TEntity> ListarTudo() => MongoCollection.Find(x => true).ToList();

        public Pagination<TEntity> Buscar(Expression<Func<TEntity, bool>> expression, int pagina)
        {
            long count = MongoCollection.CountDocuments(x => true);
            return new Pagination<TEntity>(MongoCollection.Find(expression).Skip((pagina - 1) * _sizePag).Limit(_sizePag).ToEnumerable(), count, pagina, _sizePag);
        }

        public ICollection<TEntity> Buscar(Expression<Func<TEntity, bool>> expression) => this.MongoCollection.Find(expression).ToList();


    }
}
