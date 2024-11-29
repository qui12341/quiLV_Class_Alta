using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Point //Loại điểm môn
    {
        [Key]
        public int Point_ID { get; set; }
        public int Course_ID {  get; set; }
        public int Subject_ID {  get; set; }
        public int Point_Type_ID { get; set; }
        public int Score_Column_Number { get; set; }
        public int Required_Points { get; set;}


    }
}
