using System.ComponentModel.DataAnnotations;

namespace Talabat.DashBoardAdminstrator.Models
{
    public class RoleViewModel
    {

        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(255)]
        public  string Name { get; set; }
    }
}
