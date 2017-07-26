using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediaApp2.Models
{
    public class Albums
    {
        [Key]
        public int ID { get; set;}
        public string AlbumName { get; set;}
        public int NumTracks { get; set;}

        public ICollection<Label> Label { get; set; }

        [ForeignKey("Media")]
        public int MediaID { get; set; }
        public virtual Media Media { get; set; }

    }
}