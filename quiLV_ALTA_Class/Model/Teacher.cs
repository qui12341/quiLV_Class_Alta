using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Teacher
    {
        [Key]
        public int Teacher_Id { get; set; }
        public string Teacher_FirstName { get; set; }
        public string Teacher_LastName { get; set; }
        public DateTime Teacher_Birthday { get; set;}
        public byte Gender {  get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Teacher_Image {  get; set; }
        public string Tax_Code { get; set; }
        public int Nest_Department_Id { get; set; }
        public string Concurrently { get; set; }
        public int User_ID { get; set; }


    }
}
