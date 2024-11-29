using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Point_Class //Loại điểm môn - lớp học
    {
        [Key]
        public int Id {  get; set; }
        public int Class_Id { get; set; }
        public int Point_ID { get; set; }
    }
}
