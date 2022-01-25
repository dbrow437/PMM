using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Repositories
{
    public class MongoDbExpenseEntriesRepository : IExpenseEntriesRepository
    {
        #region Private
        private const string databaseName = "expense";
        private const string collectionName = "entries";
        private readonly IMongoCollection<ExpenseEntry> expenseEntriesCollection;
        private readonly FilterDefinitionBuilder<ExpenseEntry> filterBuilder = Builders<ExpenseEntry>.Filter;
        #endregion

        #region Constructor
        public MongoDbExpenseEntriesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            expenseEntriesCollection = database.GetCollection<ExpenseEntry>(collectionName);
        }
        #endregion

        #region Public Methods
        public void CreateEntry(ExpenseEntry entry)
        {
            expenseEntriesCollection.InsertOne(entry);
        }

        public void DeleteEntry(Guid id)
        {
            var filter = filterBuilder.Eq(entry => entry.Id, id);
            expenseEntriesCollection.DeleteOne(filter);
        }

        public IEnumerable<ExpenseEntry> GetEntries()
        {
            return expenseEntriesCollection.Find(new BsonDocument()).ToList();
        }

        public ExpenseEntry GetEntry(Guid id)
        {
            var filter = filterBuilder.Eq(entry => entry.Id, id);
            return expenseEntriesCollection.Find(filter).SingleOrDefault();
        }

        public void UpdateEntry(ExpenseEntry entry)
        {
            var filter = filterBuilder.Eq(existingEntry => existingEntry.Id, entry.Id);
            expenseEntriesCollection.ReplaceOne(filter, entry);
        }
        #endregion
    }
}