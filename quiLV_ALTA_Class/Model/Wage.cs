using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Wage //Lương
    {
        [Key]
        public int Wage_ID {  get; set; }
        public int Teacher_Id { get; set; }
        public string SDT {  get; set; }
        public string Email { get; set; }
        public float Total_Salary { get; set; }
        public byte Status {  get; set; }
    }
}
