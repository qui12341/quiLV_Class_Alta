using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Subject_Class
    {
        [Key]
        public int Id {  get; set; }
        public int Subject_ID { get; set; }
        public int Class_Id { get; set; }

    }
}
