using sqlWebApp.Models;
using System.Data.SqlClient;
namespace sqlWebApp.Services
{
    public class ProductService
    {
        private static string db_source = "azurewebappserver.database.windows.net";
        private static string db_user = "alviasiraj";
        private static string db_password = "C@ndyC@ndy110";
        private static string db_database = "axurewebappDB";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();

            _builder.DataSource = db_source;
            _builder.UserID= db_user;
            _builder.Password= db_password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection connection = GetConnection();
            List<Product> productList = new List<Product>();
            string statement = "SELECT productID,ProductName,Quantity FROM Products";
            connection.Open();
            SqlCommand cmd = new SqlCommand(statement, connection);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    {
                        product.productId = reader.GetInt32(0);
                        product.productName = reader.GetString(1);
                        product.quantity = reader.GetInt32(2);
                    };
                    productList.Add(product);
                }
            }
            connection.Close();
            return productList;
        }
    }

}
