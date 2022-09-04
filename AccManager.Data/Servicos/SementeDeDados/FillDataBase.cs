using AccManagerData.Models;
using AccManagerData.Models.ModelSettings;
using MongoDB.Driver;

namespace AccManagerData.SementeDeDados
{
    public class FillDataBase
    {
        private IMongoDatabase _mongoDatabase;
        public FillDataBase(IEnvioDeContasMongoSettings settings)
        {
            this._mongoDatabase = new MongoClient(settings.ConnectionString).GetDatabase(settings.DataBaseName);
        }

        public FillDataBase PreencheContas()
        {
            this._mongoDatabase.GetCollection<Contas>(nameof(Contas)).InsertMany(new List<Contas>()
            {
               new Contas(){ nome = "" }
            });
            return this;
        }
    }
}
