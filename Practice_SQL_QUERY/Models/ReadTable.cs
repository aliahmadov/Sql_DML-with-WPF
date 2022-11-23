using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SQL_QUERY
{
    internal class ReadTable
    {

        public static List<Author> GetData()
        {

            var librarians = new List<Author>();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=LAPTOP-H1FQS8GT;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                connection.Open();

                SqlDataReader reader = null;
                string query = "SELECT* FROM Authors";
                using (var command = new SqlCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader[0].ToString());

                        var librarian = new Author
                        {
                            Id = id,
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString()
                        };

                        librarians.Add(librarian);
                        
                    }
                }

                return librarians;

            }

        }

    }
}
