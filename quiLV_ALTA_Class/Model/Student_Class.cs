using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Student_Class
    {
        [Key]
        public int Id { get; set; }
        public int Student_Id {  get; set; }
        public int Class_Id {  get; set; }
    }
}
