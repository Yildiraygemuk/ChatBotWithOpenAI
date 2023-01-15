using ChatBotWithOpenAI.Model;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using System.Globalization;
using static OpenAI.GPT3.ObjectModels.SharedModels.IOpenAiModels;
using System.Net.Http.Headers;

namespace ChatBotWithOpenAI.Services
{
    public class OpenAICompletionService : IOpenAICompletionService
    {
        private readonly string _apiKey;
        public OpenAICompletionService(IConfiguration configuration)
        {
            _apiKey = configuration.GetValue<string>("openAIKey");
        }
        public string CallAPI(QuestionVm questionVm)
        {
            var openAIKey = _apiKey;
            ConfigurationVm config = new ConfigurationVm();
            var apiCall = "https://api.openai.com/v1/engines/" + config.Engine + "/completions";
                var answer = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), apiCall))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + openAIKey);
                        request.Content = new StringContent("{\n  \"prompt\": \"" + questionVm.Input + "\",\n  \"temperature\": " +
                        config.Temperature.ToString(CultureInfo.InvariantCulture) + ",\n  \"max_tokens\": " + config.Tokens + ",\n  \"top_p\": " + config.TopP +
                                                            ",\n  \"frequency_penalty\": " + config.FrequencyPenalty + ",\n  \"presence_penalty\": " + config.PresencePenalty + "\n}");

                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = httpClient.SendAsync(request).Result;
                        var json = response.Content.ReadAsStringAsync().Result;

                        dynamic dynObj = JsonConvert.DeserializeObject(json);

                        if (dynObj != null)
                        {
                            answer = dynObj.choices[0].text.ToString();
                        }
                    }
                }
                return answer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
