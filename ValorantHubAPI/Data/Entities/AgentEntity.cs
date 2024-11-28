using System.ComponentModel.DataAnnotations;

namespace ValorantHubAPI.Data.Entities
{
    public class AgentEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string displayName { get; set; } = string.Empty;
        [MaxLength(250)]
        public string description { get; set; } = string.Empty;
        public string imageUrl { get; set; } = string.Empty;
    }
}
