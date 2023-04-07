using Newtonsoft.Json;

namespace DemoApiCalls.Models
{
    [JsonObject]
    public class ColorsUpdateModel
    {
        [JsonProperty(PropertyName = "id")]
        public int InputId { get; set; }

        [JsonProperty(PropertyName = "red")]
        public int InputRedGain { get; set; }

        [JsonProperty(PropertyName = "green")]
        public int InputGreenGain { get; set; }

        [JsonProperty(PropertyName = "blue")]
        public int InputBlueGain { get; set; }
    }
}
