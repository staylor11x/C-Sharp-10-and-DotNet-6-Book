using static System.Console;

HttpClient client = new();

HttpResponseMessage response = await client.GetAsync("Http://apple.com/");

WriteLine("Apple's homepage has {0:N0} bytes",response.Content.Headers.ContentLength);


