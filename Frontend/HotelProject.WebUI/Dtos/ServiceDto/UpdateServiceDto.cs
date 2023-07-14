using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Hizmet ikon linki giriniz.")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet açıklaması giriniz.")]
        [StringLength(500, ErrorMessage = "Hizmet açıklaması en fazla 500 karakter olmalıdır.")]

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
