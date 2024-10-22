namespace Talabat.DashBoardAdminstrator.Models
{
    public class UserEditViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<EditRoleViewModel> Roles { get; set; }
    }
}
