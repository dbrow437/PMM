using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using MongoDB.Driver;

namespace API.Repositories
{
    public class MongoDbExpenseEntriesRepository : IExpenseEntriesRepository
    {
        #region Private
        private const string databaseName = "expense";
        private const string collectionName = "entries";
        private readonly IMongoCollection<ExpenseEntry> expenseEntriesCollection;
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
            throw new NotImplementedException();
        }

        public IEnumerable<ExpenseEntry> GetEntries()
        {
            throw new NotImplementedException();
        }

        public ExpenseEntry GetEntry(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntry(ExpenseEntry entry)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}