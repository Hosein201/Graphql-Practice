using GraphQL;
using GraphQL.SystemTextJson; // First add PackageReference to GraphQL.SystemTextJson
using GraphQL.Types;

public class Program
{
    public static async Task Main(string[] args)
    {
        var schema = Schema.For(@" 
                                  type Query {
                                                name: String,
                                                id: Int,
                                                isvalid : Boolean,
                                                data : DateTime
                                             }
        ");

        var json = await schema.ExecuteAsync( ex =>
        {
            ex.Query = "{ name , id ,isvalid , data }";
            ex.Root = new
            {
                name = "hossein",
                id = 1,
                isvalid = true,
                data = DateTime.UtcNow
            };
        });
        
        Console.WriteLine(json);

        Console.ReadKey();
    }
}