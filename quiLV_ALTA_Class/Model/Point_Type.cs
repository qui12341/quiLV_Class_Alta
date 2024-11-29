using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Point_Type
    {
        [Key]
        public int Point_Type_ID { get; set; }
        public string Point_Type_Name {  get; set; }
        public string coefficient { get; set; }

    }
}
