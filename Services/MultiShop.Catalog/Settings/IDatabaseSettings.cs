namespace MultiShop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        string CategoryCollectionName { get; set; }
        string ProductCollectionName { get; set; }
        string ProductImageCollectionName { get; set; }
        string ProductDetailCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}