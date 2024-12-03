using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
		try
		{
            HttpClient client = new HttpClient();

            String url = "https://jsonplaceholder.typicode.com/todos/2";
            HttpResponseMessage response = await client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
            }
            else {
                Console.WriteLine($"Failed: {response.StatusCode}");
                }

        }
		catch (HttpRequestException e)
		{

            Console.WriteLine($"Error: {e.Message}");
        }
    }
}