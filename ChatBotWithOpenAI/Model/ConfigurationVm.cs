namespace ChatBotWithOpenAI.Model
{
    public class ConfigurationVm
    {
        /// <summary>
        /// The maximum number of tokens to generate. Request can use up to 2048 or 4000 tokens shared between prompt and completion. The exact limit varies by model
        /// </summary>
        public int Tokens { get; set; } = 1000;
        /// <summary>
        /// Most capable Codex model. Particularly good at translating natural language to code. In addition to completing code, also supports inserting completions within code.
        /// </summary>
        public string Engine { get; set; } = "text-davinci-002";
        /// <summary>
        /// Controls randomness: Lovering results in less random completions. As the temperature approaches zero, the model will become deterministic and repetitive
        /// </summary>
        public double Temperature { get; set; } = 0.7;
        /// <summary>
        /// Controls diversity via nucleus sampling 0.5 means half of all likelihood-weighted options are considered
        /// </summary>
        public int TopP { get; set; } = 1;
        /// <summary>
        /// How much to penalize  new tokens based on their existing frequency in the text so far. Decreases the model's likelihood to repeat the same line verbatim
        /// </summary>
        public int FrequencyPenalty { get; set; } = 0;
        /// <summary>
        /// How much to penalize new tokens based on whatever they appear in the text so far. Increases the model's likelihood to talk about new topics
        /// </summary>
        public int PresencePenalty { get; set; } = 0;
    }
}
