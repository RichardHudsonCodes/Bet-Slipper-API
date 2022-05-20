using System;
using MongoDB.Bson;

namespace Bet_Slipper_API.Mongo
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
