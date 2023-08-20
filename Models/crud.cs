using System.ComponentModel.DataAnnotations;

namespace testauthcookiegoogle.Models
{
    public class crud
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string phoneNo { get;set; }
        public string email { get; set; }
    }
}
