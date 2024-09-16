using System.ComponentModel.DataAnnotations;

namespace ValorantHubAPI.Data.Entities
{
    public class WeaponEntity
    {
        [Required]
        [MaxLength(15)]
        public string displayName { get; set; } = string.Empty;
        [MaxLength(250)]
        public string description { get; set; } = string.Empty;
    }
}
