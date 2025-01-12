using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MultiShop.Catalog.Entites
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }

        [BsonIgnore] // This attribute is used to ignore the Category property when serializing to BSON
        public Category Category { get; set; }

    }
}