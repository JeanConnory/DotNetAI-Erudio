using OpenAI;
using System.ClientModel;

namespace DotNetAIErudio.Extensions;

public static class OpenAIExtensions
{
    public static WebApplicationBuilder AddOpenAI(this WebApplicationBuilder builder)
    {
        //var apiKey = builder.Configuration["OpenAI:Key"]; //Pegar pelo appsettings

        //var apiKey = Environment.GetEnvironmentVariable("OPEN_AI_API_KEY"); //Pegar pela variavel de ambiente do PC
        var apiKey = Environment.GetEnvironmentVariable("DEEP_SEEK_API_KEY"); //Pegar pela variavel de ambiente do PC

        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("OpenAI API key is not set");
        }

        var options = new OpenAIClientOptions
        {
            Endpoint = new Uri("https://api.deepseek.com")
        };

        //var openAIClient = new OpenAIClient(apiKey); ChatGPT     
        var openAIClient = new OpenAIClient(new ApiKeyCredential(apiKey), options); //DeepSeek

        builder.Services.AddSingleton(openAIClient);

        return builder;
    }
}
