using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


// Represents the data structure for objects.
// This model is used for both request payloads and server responses.
namespace RestfulApi.Tests.Models
{
    internal class ObjectData
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string,object>? Data { get; set; }

        [JsonPropertyName("createdAt")]
        public long? CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public long? UpdatedAt { get; set; }
    }
}
