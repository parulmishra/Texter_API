using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Texter.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string number { get; set; }
        public virtual User User { get; set; }
    }
}
