using System.Text.Json.Serialization;

namespace StylishkidsConfections
{
    public class GitHubReleaseInfo
    {
        [JsonPropertyName("tag_name")]
        public string TagName { get; set; } // e.g., "v1.3.0"

        [JsonPropertyName("body")]
        public string Body { get; set; } // Release notes / description

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } // Web link to the release page
    }
}