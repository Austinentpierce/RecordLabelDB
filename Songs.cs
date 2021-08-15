using System;
using System.Collections.Generic;

namespace RecordLabelDB
{
    public class Songs
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public DateTime Duration { get; set; }
        public int AlbumId { get; set; }

        public Album Album { get; set; }
        
    }
}