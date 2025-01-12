using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MultiShop.Catalog.Entites
{
    public class ProductDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductDetailsId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }

        public string ProductId { get; set; }
        [BsonIgnore] // This attribute is used to ignore the Category property when serializing to BSON

        public Product Product { get; set; }


    }
}