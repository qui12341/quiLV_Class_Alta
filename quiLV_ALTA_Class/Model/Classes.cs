using System.ComponentModel.DataAnnotations;

namespace quiLV_ALTA_Class.Model
{
    public class Classes
    {
        [Key]
        public int Class_Id {  get; set; }
        public string Class_Name { get; set; }
        public string School_Year {  get; set; }
        public string Block {  get; set; }
        public int Number_Of_Students { get;set; }
        public float School_Fee {  get; set; }
        public int Teacher_Id { get; set; }

    }
}
