using System.ComponentModel.DataAnnotations;

namespace MvcAssignment.Entities
{
    public class Patientdetail
    {
        [Key]
        public int patientid { get; set; }
        public string? PatientCode { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? FName { get; set;}
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Age { get; set; }
        public DateTime? BOD { get; set; }
        public string? BloodGroup { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }

        public bool? IsActive { get; internal set; }


    }

    
}
