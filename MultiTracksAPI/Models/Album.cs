﻿#nullable disable
using System;
using System.Collections.Generic;

namespace MultiTracksAPI.Models
{
    public partial class Album
    {
        public int AlbumId { get; set; }
        public DateTime DateCreation { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
    }
}