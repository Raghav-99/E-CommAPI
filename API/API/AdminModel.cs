using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API
{
    [Table("tblAdmin")]
    public class AdminModel
    {
        [Key]
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }

        //public List<string> Question { get; set; }

        //public  List<string> Answer { get; set; }



      
    }
}
