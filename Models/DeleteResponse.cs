using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

// Represents the data structure for Delete Confirmation message response.
namespace RestfulApi.Tests.Models
{
    internal class DeleteResponse
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
