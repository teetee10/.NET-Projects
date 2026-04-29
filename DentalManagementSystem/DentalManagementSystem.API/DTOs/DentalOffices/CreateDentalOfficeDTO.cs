using System.ComponentModel.DataAnnotations;

namespace DentalManagementSystem.API.DTOs.DentalOffices
{
    //DTO for creating a new dental office
    public class CreateDentalOfficeDTO
    {
        [Required]
        [StringLength(150)]
        public required string Name { get; set; }
    }
}
