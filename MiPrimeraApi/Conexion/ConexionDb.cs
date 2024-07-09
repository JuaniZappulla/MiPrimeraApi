namespace MiPrimeraApi.Conexion
{
    public class ConexionDb
    {
        private string connectionString = string.Empty;
        public ConexionDb() 
        {
            var constructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = constructor.GetSection("ConnectionString:Conexion").Value;
        }
        public string ConnectionString()
        {
            return connectionString;
        }
    }
}
