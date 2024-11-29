using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Nest_Department //Tổ - bộ môn
    {
        [Key]
        public int Nest_Department_Id { get; set; }
        public string Nest_Department_Name { get; set;}
    }
}
