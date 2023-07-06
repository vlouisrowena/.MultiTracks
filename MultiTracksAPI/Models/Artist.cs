#nullable disable
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MultiTracksAPI.Models
{
    public partial class Artist
    {
        [BindNever]
        [JsonIgnore]
        public int ArtistId { get; set; }
        [BindNever]
        [JsonIgnore]
        public DateTime DateCreation { get; set; }
        public string Title { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }
        public string HeroUrl { get; set; }
    }
}