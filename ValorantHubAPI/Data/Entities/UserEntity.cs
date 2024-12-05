using System.ComponentModel.DataAnnotations;

namespace ValorantHubAPI.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string userName{ get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
