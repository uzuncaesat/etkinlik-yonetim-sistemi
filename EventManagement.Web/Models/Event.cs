using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Web.Models
{
    [Table("Events")]
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Etkinlik başlığı gereklidir.")]
        [MaxLength(255, ErrorMessage = "Etkinlik başlığı en fazla 255 karakter olabilir.")]
        [Display(Name = "Etkinlik Başlığı")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kısa açıklama gereklidir.")]
        [MaxLength(512, ErrorMessage = "Kısa açıklama en fazla 512 karakter olabilir.")]
        [Display(Name = "Kısa Açıklama")]
        public string ShortDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Uzun açıklama gereklidir.")]
        [Display(Name = "Uzun Açıklama")]
        public string LongDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlangıç tarihi gereklidir.")]
        [Display(Name = "Başlangıç Tarihi ve Saati")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi gereklidir.")]
        [Display(Name = "Bitiş Tarihi ve Saati")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [MaxLength(500)]
        [Display(Name = "Resim")]
        public string? ImagePath { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Durum")]
        public string Status { get; set; } = "active";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public int CreatedBy { get; set; }

        // Navigation Properties
        [ForeignKey("CreatedBy")]
        public virtual User Creator { get; set; } = null!;
    }
} 