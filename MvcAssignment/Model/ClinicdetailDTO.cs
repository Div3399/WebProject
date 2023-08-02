using System.ComponentModel.DataAnnotations;

namespace MvcAssignment.Model
{
    public class ClinicdetailDTO
    {
        [Key]
        public int ClinicID { get; set; }

        public string? ClinicName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? PhoneNo1 { get; set; }
        public string? OpenTime { get; set; }
        public string? CloseTime { get; set; }
        public string? EmailID { get; set; }
        public string? DayOfWeek { get; set; }
        public bool? IsActive { get; internal set; }
    }

    public class InsertClinicDTO
    {
        public int ClinicID { get; set; }

        public string? ClinicName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? PhoneNo1 { get; set; }
        public string? OpenTime { get; set; }
        public string? CloseTime { get; set; }
        public string? EmailID { get; set; }
        public string? DayOfWeek { get; set; }
        public bool? IsActive { get; internal set; }

    }
}
