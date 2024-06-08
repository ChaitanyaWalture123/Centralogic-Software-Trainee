

namespace Chaitanya_Walture_Assignment4.Common
{
    public class Credentials
    {
        public static readonly string URI = Environment.GetEnvironmentVariable("URL");
        public static readonly string PrimaryKey = Environment.GetEnvironmentVariable("primaryKey");
        public static readonly string DatabaseName = Environment.GetEnvironmentVariable("databaseName");
        public static readonly string ContainerName = Environment.GetEnvironmentVariable("containerName");

    }
}
