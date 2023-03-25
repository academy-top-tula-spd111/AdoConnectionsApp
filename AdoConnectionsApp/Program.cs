using System.Data;

/*
Data Source=DESKTOP-ISC66B9\MSSQLSERVER2022;Database=Shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False

Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
Pooling = true; 
Max Pool Size = 10;
Min Pool Size = 1;
*/

using Microsoft.Data.SqlClient;
using System.Collections.Generic;

string connectionString = @"Data Source=DESKTOP-ISC66B9\MSSQLSERVER2022;Database=Shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

/*
SqlConnection sqlConnection = new SqlConnection(connectionString);

try
{
    sqlConnection.Open();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    if (sqlConnection.State == System.Data.ConnectionState.Open)
        sqlConnection.Close();
}
*/

using (SqlConnection sqlConnection = new SqlConnection(connectionString))
{

    sqlConnection.Open();

    //SqlConnection.ClearPool(sqlConnection);
    //SqlConnection.ClearAllPools();

    //Console.WriteLine($"Connection string: {sqlConnection.ConnectionString}");
    //Console.WriteLine($"Database: {sqlConnection.Database}");
    //Console.WriteLine($"Server: {sqlConnection.DataSource}");
    //Console.WriteLine($"Server version: {sqlConnection.ServerVersion}");
    //Console.WriteLine($"State: {sqlConnection.State}");
    //Console.WriteLine(sqlConnection.ClientConnectionId);

    SqlCommand command = sqlConnection.CreateCommand(); //new SqlCommand();
    //command.Connection = sqlConnection;

    //command.CommandText = "CREATE TABLE TempTable (id INT, text VARCHAR(50))";
    //command.ExecuteNonQuery();

    //command.CommandText = "INSERT INTO TempTable VALUES (1, 'Computer')";
    //command.ExecuteNonQuery();

    //command.CommandText = "SELECT * FROM Product";
    //using (SqlDataReader reader = command.ExecuteReader())
    //{
    //    if(reader.HasRows)
    //    {
    //        for (int i = 0; i < reader.FieldCount; i++)
    //            Console.Write($"{reader.GetName(i)}\t");
    //        Console.WriteLine();
    //        while (reader.Read())
    //        {
    //            for (int i = 0; i < reader.FieldCount; i++)
    //            {
    //                Console.Write($"{reader.GetValue(i).ToString()}\t");
    //            }
    //            Console.WriteLine();
    //        }
    //    }
    //}

    //command.CommandText = "SELECT COUNT(*) FROM Product";
    //var count = command.ExecuteScalar();

    //Console.WriteLine(count);

    /*
    int id = 4;
    string text = "Iron";// = "Notebook";

    command.CommandText = $"INSERT INTO TempTable VALUES (@id, @text); SET @scope = SCOPE_IDENTITY();";

    SqlParameter idParam = new SqlParameter()
    {
        ParameterName = "@id", 
        SqlDbType = SqlDbType.Int,
        Direction = ParameterDirection.Input
    };
    SqlParameter textParam = new SqlParameter("@text", SqlDbType.VarChar, 50);
    idParam.Value = id;
    textParam.Value = text;

    SqlParameter scopeParam = new SqlParameter()
    {
        ParameterName = "@scope",
        SqlDbType = SqlDbType.Int,
        Direction = ParameterDirection.Output,
    };

    command.Parameters.AddRange(new[] { idParam, textParam, scopeParam });

    int countRow = command.ExecuteNonQuery();

    Console.WriteLine(scopeParam.Value);
    */
    /*
    string proc1 = @"CREATE PROCEDURE InsertTemp
	@id INT,
	@text VARCHAR(50)
AS
INSERT INTO TempTable VALUES(@id, @text);

";
    command.CommandText = proc1;
    command.ExecuteNonQuery();

    int id = 6;
    string text = "Car";

    command.CommandText = "InsertTemp";
    command.CommandType = CommandType.StoredProcedure;

    SqlParameter idParam = new SqlParameter()
    {
        ParameterName = "@id",
        SqlDbType = SqlDbType.Int,
        Direction = ParameterDirection.Input
    };
    SqlParameter textParam = new SqlParameter("@text", SqlDbType.VarChar, 50);
    idParam.Value = id;
    textParam.Value = text;
    command.Parameters.AddRange(new[] { idParam, textParam });

    command.ExecuteNonQuery();
    */

    //   string proc2 = @"CREATE PROCEDURE GetPrices
    //@id_category INT,
    //@minPrice MONEY OUT,
    //   @maxPrice MONEY OUT
    //   AS 
    //       SELECT @minPrice = MIN(Price), @maxPrice = MAX(Price) 
    //       FROM Product
    //       WHERE Product.id_category = @id_category";

    //   command.CommandText = proc2;
    //   command.ExecuteNonQuery();

    /*
    command.CommandText = "GetPrices";
    command.CommandType = CommandType.StoredProcedure;

    SqlParameter idCat = new()
    {
        ParameterName = "@id_category",
        Value = 1
    };
    SqlParameter minPrice = new()
    {
        ParameterName = "@minPrice",
        SqlDbType = SqlDbType.Money,
        Direction = ParameterDirection.Output,
    };
    SqlParameter maxPrice = new()
    {
        ParameterName = "@maxPrice",
        SqlDbType = SqlDbType.Money,
        Direction = ParameterDirection.Output,
    };
    command.Parameters.Add(idCat);
    command.Parameters.Add(minPrice);
    command.Parameters.Add(maxPrice);

    command.ExecuteNonQuery();

    var min = command.Parameters["@minPrice"].Value;
    var max = command.Parameters["@maxPrice"].Value;

    Console.WriteLine($"{min.ToString()} {max.ToString()}");

    */
    /*
    SqlTransaction transaction = sqlConnection.BeginTransaction();
    command.Transaction = transaction;

    try
    {
        command.CommandText = "INSERT INTO TempTable (id, text) VALUES (5, 'Hello')";
        await command.ExecuteNonQueryAsync();
        command.CommandText = "INSERT INTO TempTable (id, text) VALUES (6, 'Good by')";
        command.ExecuteNonQuery();

        transaction.Commit();
        Console.WriteLine("Data insert into table");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        transaction.Rollback();
    }
    */

    //command.CommandText = @"INSERT INTO FileTable VALUES (@fileName, @data)";
    //command.Parameters.Add("@fileName", SqlDbType.VarChar, 50);

    //string fileName = @"D:\img01.png";

    //byte[] fileData;
    //using(FileStream stream = new FileStream(fileName, FileMode.Open))
    //{
    //    fileData = new byte[stream.Length];
    //    stream.Read(fileData, 0, fileData.Length);
    //    command.Parameters.Add("@data", SqlDbType.Binary, fileData.Length);
    //}

    //command.Parameters["@fileName"].Value = fileName;
    //command.Parameters["@data"].Value = fileData;

    //command.ExecuteNonQuery();

    string sqlSelect = "SELECT * FROM FileTable";
    command.CommandText = sqlSelect;

    using(SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            string fileName = reader.GetString(1);
            fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            byte[] fileData = (byte[])reader.GetValue(2);

            using(FileStream stream = new(fileName, FileMode.Create))
            {
                stream.Write(fileData, 0, fileData.Length);
            }
        }
    }
}

