using System;
using System.Collections.Generic;


namespace RecordLabelDB
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }

        public Band Band { get; set; }
        public List<Songs> Song { get; set; }


    }
}