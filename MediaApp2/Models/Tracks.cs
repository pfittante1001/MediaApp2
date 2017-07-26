using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediaApp2.Models
{
    public class Tracks
    {
        public int ID { get; set;}
        public int TrackNum { get; set;}
        public string TrackName { get; set;}

        [ForeignKey("Albums")]
        public int AlbumsID { get; set;}
        public virtual Albums Albums { get; set;}
    }
}