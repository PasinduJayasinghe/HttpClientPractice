using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Creating a httpclient object with "using" keyword ensuring proper resource management
       using HttpClient client = new HttpClient();

		try
		{
            string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/1");
            Console.WriteLine(response);
        }
		catch (HttpRequestException e)
		{
            Console.WriteLine($"Request Error :{e.Message}");
            
		}
    }
}