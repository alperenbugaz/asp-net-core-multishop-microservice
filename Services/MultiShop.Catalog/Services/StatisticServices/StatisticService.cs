using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMongoCollection<Product> _productCollection;


        public StatisticService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }

        public async Task<long> GetBrandCount()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);

        }

        public Task<long> GetCategoryCount()
        {
            return _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }


        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                      y.ProductName).Exclude("ProductId");
            var product = await _productCollection.Find(filter)
                                                .Sort(sort)
                                                .Project(projection)
                                                .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                      y.ProductName).Exclude("ProductId");
            var product = await _productCollection.Find(filter)
                                                .Sort(sort)
                                                .Project(projection)
                                                .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var pipeline = new BsonDocument[]
            {
              new BsonDocument("$group",new BsonDocument
              {
                  {"_id",null },
                  {"averagePrice",new BsonDocument("$avg","$ProductPrice") }
              })
            };
            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var price = result.FirstOrDefault().GetValue("averagePrice", decimal.Zero).AsDecimal;
            return price;
        }

        public Task<long> GetProductCount()
        {
            return _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
