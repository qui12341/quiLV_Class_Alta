using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Teacher_CLass
    {
        [Key]
        public int Id { get; set; }
        public int Teacher_Id { get; set; }
        public int Class_Id { get; set; }
    }
}
