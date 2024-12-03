using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();

		try
		{
            // String url of which I want to update
            string url = "https://jsonplaceholder.typicode.com/todos/1";

            /* We need to update first data object of the api. Which is,
              {
                "userId": 1,
                "id": 1,
                "title": "delectus aut autem",
                "completed": false
              },*/
            // Let's update
            // Here "/" is an escape character to tell the constructor that "" is not string literal
            var jsonUpdate = new StringContent(
                "{ " +
                "\"userId\": 1, " +
                "\"id\": 1, " +
                "\"title\": \"this is the updated title\", " +
                "\"completed\": true " +
                "}",
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PutAsync(url, jsonUpdate);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response:{responseBody}");
           
        }
		catch (HttpRequestException e)
		{

            Console.WriteLine($"Error reqyest: {e.Message}");
        }
    }
}