using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Subject //Môn học
    {
        [Key]
        public int Subject_ID { get; set; }
        public string Subject_Name { get; set; }
        public int Nest_Department_Id {get; set;}
    }
}
