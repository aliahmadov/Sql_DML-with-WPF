using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SQL_QUERY.Models
{
    public class DMLOpeations
    {

        public static void Delete(int id)
        {
            using (var connection=new SqlConnection())
            {
                connection.ConnectionString =
                   ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                connection.Open();

                string query = @"DELETE FROM Authors WHERE Id=@id";

                var param_id = new SqlParameter();
                param_id.ParameterName = "@id";
                param_id.SqlDbType = SqlDbType.Int;
                param_id.Value = id;

                using (var command=new SqlCommand(query,connection))
                {
                    command.Parameters.Add(param_id);

                    var result=command.ExecuteNonQuery();
                }
            }
        }

        public static void Insert(int id,string firstName,string lastName)
        {
            using (var connection=new SqlConnection())
            {
                connection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                connection.Open();

                string query = @"INSERT INTO Authors(Id,FirstName,LastName)
                VALUES(@id,@firstName,@lastName)";

                var id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@id";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                var fN_parameter = new SqlParameter();
                fN_parameter.ParameterName = @"firstName";
                fN_parameter.SqlDbType = SqlDbType.NVarChar;
                fN_parameter.Value = firstName;

                var lN_parameter = new SqlParameter();
                lN_parameter.ParameterName = @"lastName";
                lN_parameter.SqlDbType=SqlDbType.NVarChar;
                lN_parameter.Value = lastName;

                using (var command=new SqlCommand(query,connection))
                {
                    command.Parameters.Add(id_parameter);
                    command.Parameters.Add(fN_parameter);
                    command.Parameters.Add(lN_parameter);

                    var result=command.ExecuteNonQuery();
                }
            }
        }

    }
}
