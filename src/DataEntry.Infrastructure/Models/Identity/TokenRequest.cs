using System.ComponentModel.DataAnnotations;

namespace DataEntry.Infrastructure.Models.Identity
{
    public class TokenRequest
    {
        [Required]
        public string? Token { get; set; }

        [Required]
        public string? RefreshToken { get; set; }
    }
}