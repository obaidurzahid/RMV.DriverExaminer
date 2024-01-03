using RMV.DriverExaminer.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RMV.DriverExaminer.Domain.Entities
{
    public class Sample : AuditableEntity
    {
        [Key]
        public long Id { get; set; }
        public required string EmployeeCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
    }
}
