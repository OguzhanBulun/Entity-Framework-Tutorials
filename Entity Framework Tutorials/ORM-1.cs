﻿using System.Configuration;
using System.Data.SqlClient;

#region SQL without Entity Framework

string connectionString = ConfigurationManager.ConnectionStrings["exampleConnString"].ConnectionString;

await using SqlConnection connection = new SqlConnection(connectionString);

await connection.OpenAsync();

SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[ExampleTable]", connection);

SqlDataReader reader = await command.ExecuteReaderAsync();

while (await reader.ReadAsync())
{
    //read data
}
await connection.CloseAsync();

#endregion

#region ORM with Entity Framework

MyDbContext northwinddbcontext = new MyDbContext();

var data  = northwinddbcontext.ExampleProperty.ToList();

//for example

var query = from c in northwinddbcontext.ExampleProperty
            where c.ExampleProperty == "Example"
            select c;

var query2 = northwinddbcontext.ExampleProperty.Where(c => c.ExampleProperty == "Example");

var dataResult = query.ToList();

#endregion
