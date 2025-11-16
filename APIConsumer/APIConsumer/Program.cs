/*******************************************************************************************
 * 
 * Test programme for API consumption.
 * 
 * This script makes use of https://jsonplaceholder.typicode.com/.
 * A free fake API for testing and prototyping.
 * 
 * {JSON}Placeholder is a REST API (REpresentational State Transfer). Therefore, it utilises
 * HTTP methods (verbs) to act on resources (nouns). The most common verbs being:
 * 
 * GET - retrieve data.
 * POST - create data.
 * PUT / PATCH - update data.
 * DELETE - remove data.
 * 
 ******************************************************************************************/

HttpClient httpClient = new HttpClient();

string uri = @"https://jsonplaceholder.typicode.com/posts";

try
{
    //using var response = await httpClient.GetAsync(@"https://jsonplaceholder.typicode.com/posts");
    //response.EnsureSuccessStatusCode();
    //string responseBody = await response.Content.ReadAsStringAsync();

    // This is equivalent to the previous three lines.
    string responseBody = await httpClient.GetStringAsync(uri);

    Console.WriteLine(responseBody);
}
catch(Exception e)
{
    Console.WriteLine("\nException Caught!");
    Console.WriteLine("Message :{0} ", e.Message);
}
