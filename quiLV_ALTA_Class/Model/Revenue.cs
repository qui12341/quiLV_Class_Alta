using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Revenue //Doanh thu
    {
        [Key]
        public int Revenue_Id { get; set; }
        public string Revenue_Image { get; set;}
        public string Fullname { get; set;}
        public string Parent { get; set;}
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set;}
        public int Class_Id { get; set; }
    }
}
