using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Holiday_schedule //Lịch nghĩ
    {
        [Key]
        public int Holiday_Schedule_Id {  get; set; }
        public string Holiday_Schedule_Name { get; set; }
        public string Reason { get; set; }
        public DateTime Time_Start { get; set; }
        public DateTime Time_End { get; set;}

    }
}
