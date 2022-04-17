using Catalog.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private const string _databaseName = "catalog";
        private const string _collectionName = "items";
        private readonly IMongoCollection<Item> _itemsCollections;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(_databaseName);
            _itemsCollections = database.GetCollection<Item>(_collectionName);
        }

        public void CreateItem(Item item)
        {
            _itemsCollections.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            _itemsCollections.DeleteOne(filter);
        }

        public Item GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return _itemsCollections.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemsCollections.Find(_ => true).ToList();
        }

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            _itemsCollections.ReplaceOne(filter, item);
        }
    }
}
