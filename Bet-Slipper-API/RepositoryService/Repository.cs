﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bet_Slipper_API.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Bet_Slipper_API.RepositoryService
{
    public class Repository<TDocument> : IRepository<TDocument> where TDocument : IDocument
    {
        private MongoClient _context { get; set; }
        private IMongoCollection<TDocument> _collection { get; set; }

        public Repository(IMongoDbSettings settings)
        {
            var _context = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = _context.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }
        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }


        public int Create()
        {
            throw new NotImplementedException();
        }

        public virtual void InsertOne(TDocument document)
        {
            _collection.InsertOne(document);
        }

        public virtual void InsertMany(List<TDocument> documents)
        {
            _collection.InsertMany(documents);
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<TDocument> GetByID(ObjectId Id)
        {
            var result = await _collection.FindAsync(x => x.Id == Id); 
            return result.Single();
        }

        public void Update(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
