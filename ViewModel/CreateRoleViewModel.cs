using System.ComponentModel.DataAnnotations;

namespace ClientManagementSys.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
