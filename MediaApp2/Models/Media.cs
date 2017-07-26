using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediaApp2.Models
{
    public class Media
    {
        [Key]

        public int ID { get; set;}
        public string AlbumName { get; set;}
        public string ArtistName { get; set;}
        
        public ICollection<Albums> Albums { get; set;}
        


    }
}