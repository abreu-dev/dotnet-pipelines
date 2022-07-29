namespace Pipelines.Infra.Data.Models
{
    public class ProductDataEntity : DataEntity
    {
        public string? Name { get; set; }

        public static string TableName => "Product";
        public static int NameMaxLength => 15;
    }
}
