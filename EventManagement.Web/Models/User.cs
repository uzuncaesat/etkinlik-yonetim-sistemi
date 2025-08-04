using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Web.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [MaxLength(500)]
        [Display(Name = "Şifre")]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string PasswordSalt { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ad Soyad gereklidir.")]
        [MaxLength(255)]
        [Display(Name = "Ad Soyad")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Doğum tarihi gereklidir.")]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
} 