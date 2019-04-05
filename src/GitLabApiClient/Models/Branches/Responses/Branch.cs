using GitLabApiClient.Models.Milestones.Responses;
using Newtonsoft.Json;

namespace GitLabApiClient.Models.Repositories.Responses
{
    public sealed class Branch : ModifiableObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("merged")]
        public bool Merged { get; set; }

        [JsonProperty("protected")]
        public bool Protected { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }

        [JsonProperty("developers_can_push")]
        public bool DeveloperCanPush { get; set; }

        [JsonProperty("developers_can_merge")]
        public bool DeveloperCanMerge { get; set; }

        [JsonProperty("can_push")]
        public bool CanPush { get; set; }
    }
}
