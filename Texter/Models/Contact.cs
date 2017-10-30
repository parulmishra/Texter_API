using System;
namespace Texter.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public virtual User User { get; set; }
    }
}
