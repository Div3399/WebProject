using System.ComponentModel.DataAnnotations;

namespace MvcAssignment.Model
{
    public class DoctordetailDTO
    {
        [Key]
        public int DoctorID { get; set; }
        public DateTime? RegDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? BloodGroup { get; set; }
        public string? Mobile1 { get; set; }
        public string? Line1 { get; set; }

        public bool? IsActive { get; internal set; }

    }

    public class InsertDoctorDTO
    {
        public int DoctorID { get; set; }
        public DateTime? RegDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? BloodGroup { get; set; }
        public string? Mobile1 { get; set; }
        public string? Line1 { get; set; }

        public bool? IsActive { get; internal set; }
    }
}
