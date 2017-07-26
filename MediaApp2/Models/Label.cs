using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediaApp2.Models
{
    public class Label
    {
        [Key]

        public int ID { get; set;}
        public string Name { get; set;}
        public string Address { get; set;}
        public string EmailAddress { get; set;}

        [ForeignKey("Albums")]
        public int AlbumsID { get; set; }
        public virtual Albums Albums { get; set; }
    }
}