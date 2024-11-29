using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Calendar //Lịch giảng dạy
    {
        [Key]
        public int Id { get; set; }
        public int Class_Id { get; set; }
        public int Subject_ID { get; set; }

        public string? Study_Time {  get; set; }
        public int ClassRoom {  get; set; }
        public DateTime Time { get; set; }
        public int Rank { get; set; }
        public int Teacher_Id { get; set; }

    }
}
