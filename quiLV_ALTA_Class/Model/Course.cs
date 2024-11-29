using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Course //Khóa
    {
        [Key]
        public int Course_ID { get; set; }
        public string Course_Name { get; set; }
    }
}
