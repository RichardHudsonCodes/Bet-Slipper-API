using System;
using Bet_Slipper_API.Mongo;

namespace Bet_Slipper_API.RepositoryService
{
    public interface IRepository<TDocument> where TDocument : IDocument
    {
        public int Create();
        void InsertOne(TDocument document);
        public void Update(int ID);
        public void GetByID(object ID);
        public void Delete(int ID);
    }
}
