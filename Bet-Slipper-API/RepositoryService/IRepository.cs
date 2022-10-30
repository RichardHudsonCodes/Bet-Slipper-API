using System.Collections.Generic;
using System.Threading.Tasks;
using Bet_Slipper_API.Mongo;
using MongoDB.Bson;

namespace Bet_Slipper_API.RepositoryService
{
    public interface IRepository<TDocument> where TDocument : IDocument
    {
        public int Create();
        void InsertOne(TDocument document);
        void InsertMany(List<TDocument> documents);
        public void Update(int ID);
        public Task<TDocument> GetByID(ObjectId ID);
        public void Delete(int ID);
    }
}
