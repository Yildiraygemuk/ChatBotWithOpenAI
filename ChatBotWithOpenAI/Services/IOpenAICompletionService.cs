using ChatBotWithOpenAI.Model;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace ChatBotWithOpenAI.Services
{
    public interface IOpenAICompletionService
    {
        string CallAPI(QuestionVm questionVm);
    }
}
