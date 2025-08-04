using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EventManagement.Web.ViewModels
{
    public class EventViewModel
    {
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

        [Display(Name = "Resim")]
        [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "Sadece jpg, jpeg, png formatında dosya yükleyebilirsiniz.")]
        public IFormFile? ImageFile { get; set; }

        public string? ImagePath { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;

        public string Status => IsActive ? "active" : "inactive";
    }
} 