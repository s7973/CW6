using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTO
{
    public class DoctorRequest
    {
        [Required(ErrorMessage = "400")]
        public int IdDoctor { get; set; }

        [Required(ErrorMessage = "400")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "400")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "400")]
        public string Email { get; set; }
    }

    public class DoctorId
    {
        [Required(ErrorMessage = "400")]
        public int IdDoctor { get; set; }
    }
}
