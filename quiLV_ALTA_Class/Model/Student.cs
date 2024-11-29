using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }
        public string Student_FirstName { get; set; }
        public string Student_LastName { get; set; }
        public DateTime Birthday { get; set; }
        public byte Gender { get; set; }
        public string Email {  get; set; }
        public string Phone { get; set; }
        public string Parent {  get; set; }
        public string Password {  get; set; }
        public int Class_Id { get; set; }
        public string Student_Image {  get; set; }
        public int User_ID {  get; set; }
    }
}
