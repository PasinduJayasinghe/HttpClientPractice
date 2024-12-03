using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class Todo
{
    public int userId { get; set; }
    public string title { get; set; }
    public Boolean completed { get; set; }


}
class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();

		try
		{
            // Url of the fake api
            String url= "https://jsonplaceholder.typicode.com/todos";

            Todo todoItem = new Todo();

            todoItem.userId = 10;
            todoItem.title = "Post Item";
            todoItem.completed = true;

            // Now, seriealize to json object

            var jsonContent = new StringContent(
                    JsonSerializer.Serialize(todoItem));
            // Sending the post request
            HttpResponseMessage response = await client.PostAsync(url, jsonContent);

            //Console.WriteLine(response.EnsureSuccessStatusCode()); 

            // Console.WriteLine(response.Content);

            String responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);



            
        }
		catch (HttpRequestException e)
		{
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}

