using System.Configuration;
using System.Data.SqlClient;

#region SQL without Entity Framework

string connectionString = ConfigurationManager.ConnectionStrings["exampleConnString"].ConnectionString;

await using SqlConnection connection = new SqlConnection(connectionString);

await connection.OpenAsync();

SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[ExampleTable]", connection);


SqlCommand command2 = new SqlCommand("SELECT * FROM ExampleProperty " +
    "JOIN ExampleProperty2 ON ExampleProperty.ExampleProperty = ExampleProperty2.ExampleProperty2 " +
    "JOIN ExampleProperty3 ON ExampleProperty.ExampleProperty = ExampleProperty3.ExampleProperty3 " +
    "JOIN ExampleProperty4 ON ExampleProperty.ExampleProperty = ExampleProperty4.ExampleProperty4 " +
    "JOIN ExampleProperty5 ON ExampleProperty.ExampleProperty = ExampleProperty5.ExampleProperty5 " +
    "JOIN ExampleProperty6 ON ExampleProperty.ExampleProperty = ExampleProperty6.ExampleProperty6 " +
    "JOIN ExampleProperty7 ON ExampleProperty.ExampleProperty = ExampleProperty7.ExampleProperty7 " +
    "JOIN ExampleProperty8 ON ExampleProperty.ExampleProperty = ExampleProperty8.ExampleProperty8 " +
    "JOIN ExampleProperty9 ON ExampleProperty.ExampleProperty = ExampleProperty9.ExampleProperty9 " +
    "JOIN ExampleProperty10 ON ExampleProperty.ExampleProperty = ExampleProperty10.ExampleProperty10 " +
    "WHERE ExampleProperty.ExampleProperty = 'Example'\r\nAND ExampleProperty2.ExampleProperty2 = 'Example2';", connection);

SqlDataReader reader = await command.ExecuteReaderAsync(); //or execute command2

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

var query3 = from c in northwinddbcontext.ExampleProperty
             join c2 in northwinddbcontext.ExampleProperty2 on c.ExampleProperty equals c2.ExampleProperty2
             join c3 in northwinddbcontext.ExampleProperty3 on c.ExampleProperty equals c3.ExampleProperty3
             join c4 in northwinddbcontext.ExampleProperty4 on c.ExampleProperty equals c4.ExampleProperty4
             join c5 in northwinddbcontext.ExampleProperty5 on c.ExampleProperty equals c5.ExampleProperty5
             join c6 in northwinddbcontext.ExampleProperty6 on c.ExampleProperty equals c6.ExampleProperty6
             join c7 in northwinddbcontext.ExampleProperty7 on c.ExampleProperty equals c7.ExampleProperty7
             join c8 in northwinddbcontext.ExampleProperty8 on c.ExampleProperty equals c8.ExampleProperty8
             join c9 in northwinddbcontext.ExampleProperty9 on c.ExampleProperty equals c9.ExampleProperty9
             join c10 in northwinddbcontext.ExampleProperty10 on c.ExampleProperty equals c10.ExampleProperty10
             where c.ExampleProperty == "Example"
             where c2.ExampleProperty2 == "Example2"
             where c3.ExampleProperty3 == "Example3"
             where c4.ExampleProperty4 == "Example4"
             where c5.ExampleProperty5 == "Example5"
             where c6.ExampleProperty6 == "Example6"
             where c7.ExampleProperty7 == "Example7"
             where c8.ExampleProperty8 == "Example8"
             where c9.ExampleProperty9 == "Example9"
             where c10.ExampleProperty10 == "Example10"
             select new
             {
                 c.ExampleProperty,
                 c2.ExampleProperty2,
                 c3.ExampleProperty3,
                 c4.ExampleProperty4,
                 c5.ExampleProperty5,
                 c6.ExampleProperty6,
                 c7.ExampleProperty7,
                 c8.ExampleProperty8,
                 c9.ExampleProperty9,
                 c10.ExampleProperty10
             };

var query4 = northwinddbcontext.ExampleProperty
    .Join(northwinddbcontext.ExampleProperty2, c => c.ExampleProperty, c2 => c2.ExampleProperty2, (c, c2) => new { c, c2 })
    .Join(northwinddbcontext.ExampleProperty3, c => c.c.ExampleProperty, c3 => c3.ExampleProperty3, (c, c3) => new { c, c3 })
    .Join(northwinddbcontext.ExampleProperty4, c => c.c.c.ExampleProperty, c4 => c4.ExampleProperty4, (c, c4) => new { c, c4 })
    .Join(northwinddbcontext.ExampleProperty5, c => c.c.c.c.ExampleProperty, c5 => c5.ExampleProperty5, (c, c5) => new { c, c5 })
    .Join(northwinddbcontext.ExampleProperty6, c => c.c.c.c.c.ExampleProperty, c6 => c6.ExampleProperty6, (c, c6) => new { c, c6 })
    .Join(northwinddbcontext.ExampleProperty7, c => c.c.c.c.c.c.ExampleProperty, c7 => c7.ExampleProperty7, (c, c7) => new { c, c7 })
    .Join(northwinddbcontext.ExampleProperty8, c => c.c.c.c.c.c.c.ExampleProperty, c8 => c8.ExampleProperty8, (c, c8) => new { c, c8 })
    .Join(northwinddbcontext.ExampleProperty9, c => c.c.c.c.c.c.c.c.ExampleProperty, c9 => c9.ExampleProperty9, (c, c9) => new { c, c9 })
    .Join(northwinddbcontext.ExampleProperty10, c => c.c.c.c.c.c.c.c.c.ExampleProperty, c10 => c10.ExampleProperty10, (c, c10) => new { c, c10 })
    .Where(c => c.c.c.c.c.c.c.c.c.c.ExampleProperty == "Example")
    .Where(c => c.c.c.c.c.c.c.c.c.c2.ExampleProperty2 == "Example2")
    .Where(c => c.c.c);

//change managamenet is more easier with using ORM tools


#endregion
