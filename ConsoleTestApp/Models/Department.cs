using ValidationComponent.CustomAttributes;

namespace ConsoleTestApp.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [StringLength(15, 2)]
        public string ShortName { get; set; }
        public string LongName { get; set; }
    }
}
